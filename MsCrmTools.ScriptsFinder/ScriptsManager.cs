using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using Entity = Microsoft.Xrm.Sdk.Entity;

namespace MsCrmTools.ScriptsFinder
{
    public class ScriptsManager
    {
        private readonly IOrganizationService _service;
        private readonly BackgroundWorker _worker;
        private List<EntityMetadata> _emds;

        public ScriptsManager(IOrganizationService service, BackgroundWorker worker)
        {
            this._service = service;
            this._worker = worker;
            Scripts = new List<Script>();
        }

        public List<Entity> Forms { get; } = new List<Entity>();
        public List<Entity> HomePageGrids { get; } = new List<Entity>();
        public List<EntityMetadata> Metadata { get; private set; }
        public List<Script> Scripts { get; }
        public int UserLcid { get; private set; }
        public List<Entity> Views { get; } = new List<Entity>();

        public void Find(List<Entity> solutions, bool loadManagedEntities, Version crmVersion)
        {
            _worker.ReportProgress(0, "Loading User language...");
            GetCurrentUserLcid();

            _worker.ReportProgress(0, "Loading Entities metadata...");
            _emds = GetEntities(solutions, loadManagedEntities);
            Metadata = _emds.Where(x => x.DisplayName.UserLocalizedLabel != null).ToList();

            _worker.ReportProgress(0, "Loading Forms Scripts...");
            LoadScripts(Metadata);

            _worker.ReportProgress(0, "Loading Views Icon Scripts...");
            LoadViews(Metadata);

            if (crmVersion >= new Version(8, 2, 0, 0))
            {
                _worker.ReportProgress(0, "Loading Homepages Scripts...");
                LoadCustomControls(Metadata);
            }

            _worker.ReportProgress(0, "Loading Ribbon Commands Scripts...");
            LoadRibbonCommands(Metadata);

            _worker.ReportProgress(0, "Loading Ribbon Custom Rules Scripts...");
            LoadRibbonCustomRule(Metadata);
        }

        public void UpdateForms(List<Script> scripts)
        {
            var uiItems = scripts.Select(s => s.UiItem).Distinct();

            var bulk = new ExecuteMultipleRequest
            {
                Requests = new OrganizationRequestCollection(),
                Settings = new ExecuteMultipleSettings
                {
                    ReturnResponses = true,
                    ContinueOnError = true
                }
            };

            foreach (var uiItem in uiItems)
            {
                var attribute = uiItem.LogicalName == "systemform" ? "formxml" : uiItem.LogicalName == "savedquery" ? "layoutxml" : "eventsxml";
                var updateAttribute = uiItem.LogicalName == "systemform" ? "updatedformxml" : uiItem.LogicalName == "savedquery" ? "updatedlayoutxml" : "updatedeventsxml";

                if (!uiItem.Contains(updateAttribute))
                    continue;

                var formToUpdate = new Entity(uiItem.LogicalName)
                {
                    Id = uiItem.Id,
                    Attributes =
                    {
                        {attribute, uiItem[updateAttribute]}
                    }
                };

                bulk.Requests.Add(new UpdateRequest { Target = formToUpdate });
            }

            bulk.Requests.Add(new PublishAllXmlRequest());

            var bulkResponse = (ExecuteMultipleResponse)_service.Execute(bulk);

            foreach (var response in bulkResponse.Responses)
            {
                if (response.Fault == null)
                {
                    foreach (var script in scripts.Where(s => s.UiItem.Id == (bulk.Requests[response.RequestIndex] as UpdateRequest)?.Target.Id))
                    {
                        script.Parameters = script.NewParameters ?? script.Parameters;
                        script.Enabled = script.NewEnabled ?? script.Enabled;
                        script.MethodCalled = script.NewMethodCalled ?? script.MethodCalled;
                        script.PassExecutionContext = script.NewPassExecutionContext ?? script.PassExecutionContext;
                        script.Library = script.NewLibrary ?? script.Library;

                        script.NewParameters = null;
                        script.NewEnabled = null;
                        script.NewMethodCalled = null;
                        script.NewPassExecutionContext = null;
                        script.NewLibrary = null;
                        script.NewOrder = null;

                        script.UpdateErrorMessage = null;
                        if (script.UiItem.Contains(script.ItemUpdateAttribute))
                        {
                            script.UiItem[script.ItemAttribute] = script.UiItem[script.ItemUpdateAttribute];
                            script.UiItem.Attributes.Remove(script.ItemUpdateAttribute);
                        }
                    }
                }
                else
                {
                    foreach (var script in scripts.Where(s =>
                        s.UiItem.Id == (bulk.Requests[response.RequestIndex] as UpdateRequest)?.Target.Id))
                    {
                        script.UpdateErrorMessage = response.Fault.Message;
                    }
                }
            }

            if (bulkResponse.IsFaulted)
            {
                throw new Exception("At least one form could not be updated. Select a row in error and click on button \"Show Error Message\" to read a detailed error");
            }
        }

        private void GetCurrentUserLcid()
        {
            var user = (WhoAmIResponse)_service.Execute(new WhoAmIRequest());

            var userSettings = _service.RetrieveMultiple(new QueryByAttribute("usersettings")
            {
                ColumnSet = new ColumnSet("uilanguageid"),
                Attributes = { "systemuserid" },
                Values = { user.UserId },
            }).Entities.First();

            UserLcid = userSettings.GetAttributeValue<int>("uilanguageid");
        }

        private List<EntityMetadata> GetEntities(List<Entity> solutions, bool loadManagedEntities)
        {
            if (solutions.Count > 0)
            {
                var components = _service.RetrieveMultiple(new QueryExpression("solutioncomponent")
                {
                    ColumnSet = new ColumnSet("objectid"),
                    NoLock = true,
                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression("solutionid", ConditionOperator.In,
                                solutions.Select(s => s.Id).ToArray()),
                            new ConditionExpression("componenttype", ConditionOperator.Equal, 1)
                        }
                    }
                }).Entities;

                var list = components.Select(component => component.GetAttributeValue<Guid>("objectid"))
                    .ToList();

                if (list.Count > 0)
                {
                    EntityQueryExpression entityQueryExpression = new EntityQueryExpression
                    {
                        Criteria = new MetadataFilterExpression(LogicalOperator.Or),
                        Properties = new MetadataPropertiesExpression
                        {
                            AllProperties = false,
                            PropertyNames = { "DisplayName", "LogicalName", "Attributes", "ObjectTypeCode" }
                        },
                        AttributeQuery = new AttributeQueryExpression
                        {
                            // Récupération de l'attribut spécifié
                            Properties = new MetadataPropertiesExpression
                            {
                                AllProperties = false,
                                PropertyNames = { "DisplayName", "LogicalName" }
                            }
                        }
                    };

                    list.ForEach(id =>
                    {
                        entityQueryExpression.Criteria.Conditions.Add(new MetadataConditionExpression("MetadataId", MetadataConditionOperator.Equals, id));
                    });

                    RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
                    {
                        Query = entityQueryExpression,
                        ClientVersionStamp = null
                    };

                    var response = (RetrieveMetadataChangesResponse)_service.Execute(retrieveMetadataChangesRequest);

                    return response.EntityMetadata.ToList();
                }

                return new List<EntityMetadata>();
            }
            else
            {
                EntityQueryExpression entityQueryExpression = new EntityQueryExpression
                {
                    Criteria = new MetadataFilterExpression(LogicalOperator.Or)
                    {
                        Conditions =
                        {
                            new MetadataConditionExpression("IsCustomizable", MetadataConditionOperator.Equals, true),
                        }
                    },
                    Properties = new MetadataPropertiesExpression
                    {
                        AllProperties = false,
                        PropertyNames = { "DisplayName", "LogicalName", "Attributes", "ObjectTypeCode" }
                    },
                    AttributeQuery = new AttributeQueryExpression
                    {
                        // Récupération de l'attribut spécifié
                        Properties = new MetadataPropertiesExpression
                        {
                            AllProperties = false,
                            PropertyNames = { "DisplayName", "LogicalName" }
                        }
                    }
                };

                if (!loadManagedEntities)
                {
                    entityQueryExpression.Criteria.Conditions.Add(
                        new MetadataConditionExpression("IsManaged", MetadataConditionOperator.Equals, false));
                }

                RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
                {
                    Query = entityQueryExpression,
                    ClientVersionStamp = null
                };

                var response = (RetrieveMetadataChangesResponse)_service.Execute(retrieveMetadataChangesRequest);

                return response.EntityMetadata.ToList();
            }
        }

        private void LoadCustomControls(List<EntityMetadata> emds)
        {
            var ccs = _service.RetrieveMultiple(new QueryExpression("customcontroldefaultconfig")
            {
                ColumnSet = new ColumnSet("eventsxml", "primaryentitytypecode"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("primaryentitytypecode", ConditionOperator.In, emds.Select(e => e.ObjectTypeCode??0).ToArray()),
                    }
                }
            });

            var homePageGrids = ccs.Entities.ToList();
            HomePageGrids.AddRange(homePageGrids);

            foreach (var cc in HomePageGrids)
            {
                if (!cc.Contains("eventsxml"))
                    continue;

                var emd = emds.First(e => e.LogicalName == cc.GetAttributeValue<string>("primaryentitytypecode"));

                var doc = new XmlDocument();
                doc.LoadXml(cc.GetAttributeValue<string>("eventsxml"));
                var eventNodes = doc.SelectNodes("//event");
                if (eventNodes == null) continue;

                foreach (XmlNode eventNode in eventNodes)
                {
                    if (eventNode.Attributes == null) continue;

                    string eventName = eventNode.Attributes["name"].Value;

                    var handlerNodes = eventNode.SelectNodes("Handlers/Handler");
                    if (handlerNodes == null) continue;

                    int index = 0;
                    foreach (XmlNode handlerNode in handlerNodes)
                    {
                        if (handlerNode.Attributes == null) continue;

                        var script = new Script
                        {
                            EntityLogicalName = emd.LogicalName,
                            EntityName = emd.DisplayName.UserLocalizedLabel.Label,
                            Library = handlerNode.Attributes["libraryName"].Value,
                            MethodCalled = handlerNode.Attributes["functionName"].Value,
                            Enabled = handlerNode.Attributes["enabled"].Value == "true",
                            PassExecutionContext = handlerNode.Attributes["passExecutionContext"]?.Value == "true",
                            Event = eventName,
                            Parameters = handlerNode.Attributes["parameters"] != null
                                ? handlerNode.Attributes["parameters"].Value
                                : "",
                            Type = "Homepage Grid event",
                            UiItem = cc,
                            Order = index++
                        };

                        if (eventName == "onchange")
                        {
                            var amd = emd.Attributes.FirstOrDefault(x => x.LogicalName == eventNode.Attributes?["attribute"].Value);

                            if (amd != null)
                            {
                                var displayName = amd.DisplayName?.UserLocalizedLabel != null
                                    ? amd.DisplayName.UserLocalizedLabel.Label
                                    : "(" + amd.LogicalName + ")";

                                script.Attribute = displayName;
                                script.AttributeLogicalName = amd.LogicalName;
                            }
                        }
                        else
                        {
                            script.Attribute = "";
                            script.AttributeLogicalName = "";
                        }

                        Scripts.Add(script);
                    }
                }

                var libraryNodes = doc.SelectNodes("//Library");
                if (libraryNodes == null) continue;

                int lIndex = 0;
                foreach (XmlNode libraryNode in libraryNodes)
                {
                    var script = new Script
                    {
                        EntityLogicalName = emd.LogicalName,
                        EntityName = emd.DisplayName.UserLocalizedLabel.Label,
                        Library = libraryNode.Attributes?["name"].Value,
                        MethodCalled = string.Empty,
                        Event = string.Empty,
                        Attribute = string.Empty,
                        AttributeLogicalName = string.Empty,
                        Type = "Homepage Grid Library",
                        UiItem = cc,
                        Order = lIndex++
                    };

                    Scripts.Add(script);
                }
            }
        }

        private void LoadRibbonCommands(List<EntityMetadata> emds)
        {
            var commands = _service.RetrieveMultiple(new QueryExpression("ribboncommand")
            {
                ColumnSet = new ColumnSet("commanddefinition", "entity", "command"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("commanddefinition", ConditionOperator.Like, "%Library=\"$webresource:%"),
                        new ConditionExpression("entity", ConditionOperator.In, emds.Select(e => e.LogicalName).ToArray())
                    }
                }
            });

            foreach (var command in commands.Entities)
            {
                var commandDoc = new XmlDocument();
                commandDoc.LoadXml(command.GetAttributeValue<string>("commanddefinition"));

                var actionsNode = commandDoc.SelectSingleNode("CommandDefinition/Actions");
                if (actionsNode == null)
                {
                    return;
                }

                int index = 0;
                foreach (XmlNode actionNode in actionsNode.ChildNodes)
                {
                    var libraryNode = actionNode.Attributes?["Library"];
                    if (libraryNode == null)
                    {
                        continue;
                    }

                    var emd = emds.First(e => e.LogicalName == command.GetAttributeValue<string>("entity"));

                    var libraryName = libraryNode.Value;

                    if (libraryName.Split(':').Length == 1)
                        continue;

                    var script = new Script
                    {
                        UiItem = command,
                        ItemName = command.GetAttributeValue<string>("command"),
                        EntityLogicalName = emd.LogicalName,
                        EntityName = emd.DisplayName.UserLocalizedLabel.Label,
                        Library = libraryName.Split(':')[1],
                        MethodCalled = actionNode.Attributes["FunctionName"].Value,
                        Event = "",
                        Attribute = "",
                        AttributeLogicalName = "",
                        FormState = string.Empty,
                        Type = "Ribbon Command",
                        Order = index++
                    };

                    var parameters = new List<string>();

                    foreach (XmlNode parameterNode in actionNode.ChildNodes)
                    {
                        parameters.Add($"{parameterNode.Name}:{parameterNode.Attributes?["Value"].Value}");
                    }

                    script.Parameters = string.Join(" / ", parameters);

                    if (script.Library.IndexOf("_main_system_library", StringComparison.Ordinal) >= 0)
                    {
                        continue;
                    }

                    Scripts.Add(script);
                }
            }
        }

        private void LoadRibbonCustomRule(List<EntityMetadata> emds)
        {
            var rules = _service.RetrieveMultiple(new QueryExpression("ribbonrule")
            {
                ColumnSet = new ColumnSet("ruledefinition", "ruleid", "entity"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("ruledefinition", ConditionOperator.Like, "%Library=\"$webresource:%"),
                        new ConditionExpression("entity", ConditionOperator.In, emds.Select(e => e.LogicalName).ToArray())
                    }
                }
            });

            foreach (var rule in rules.Entities)
            {
                var commandDoc = new XmlDocument();
                commandDoc.LoadXml(rule.GetAttributeValue<string>("ruledefinition"));

                var customRulesNode = commandDoc.SelectNodes("//CustomRule");
                if (customRulesNode == null)
                {
                    return;
                }

                int index = 0;
                foreach (XmlNode customRuleNode in customRulesNode)
                {
                    var libraryNode = customRuleNode.Attributes?["Library"];
                    if (libraryNode == null)
                    {
                        continue;
                    }

                    var libraryName = libraryNode.Value;

                    if (libraryName.Split(':').Length == 1)
                        continue;

                    var entity = rule.GetAttributeValue<string>("entity");

                    var script = new Script
                    {
                        UiItem = rule,
                        ItemName = rule.GetAttributeValue<string>("ruleid"),
                        EntityLogicalName = entity,
                        EntityName =
                            emds.FirstOrDefault(e => e.LogicalName == entity)?.DisplayName.UserLocalizedLabel.Label ??
                            "Application Ribbon",
                        Library = libraryName.Split(':')[1],
                        MethodCalled = customRuleNode.Attributes["FunctionName"].Value,
                        Event = "",
                        Attribute = "",
                        AttributeLogicalName = "",
                        FormState = string.Empty,
                        Type = "Ribbon Custom Rule",
                        Order = index++
                    };

                    var parameters = new List<string>();

                    foreach (XmlNode parameterNode in customRuleNode.ChildNodes)
                    {
                        parameters.Add($"{parameterNode.Name}:{parameterNode.Attributes?["Value"].Value}");
                    }

                    script.Parameters = string.Join(" / ", parameters);

                    if (script.Library.IndexOf("_main_system_library", StringComparison.Ordinal) >= 0)
                    {
                        continue;
                    }

                    Scripts.Add(script);
                }
            }
        }

        private void LoadScripts(List<EntityMetadata> emds)
        {
            var query = new QueryExpression("systemform")
            {
                ColumnSet = new ColumnSet("name", "formxml", "type", "formactivationstate", "objecttypecode"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("objecttypecode", ConditionOperator.In,
                            emds.Select(e => e.ObjectTypeCode ?? 0).ToArray())
                    }
                }
            };

            //var qba = new QueryByAttribute("systemform");
            //qba.Attributes.Add("objecttypecode");
            //qba.Values.Add(emd.ObjectTypeCode ?? 0);
            //qba.ColumnSet = new ColumnSet(true);

            var forms = _service.RetrieveMultiple(query).Entities.ToList();
            Forms.AddRange(forms);

            foreach (var form in forms)
            {
                if (form["formxml"] == null)
                {
                    continue;
                }

                var emd = emds.First(e => e.LogicalName == form.GetAttributeValue<string>("objecttypecode"));

                var doc = new XmlDocument();
                doc.LoadXml(form["formxml"].ToString());

                foreach (XmlNode eventNode in doc.SelectNodes("//event"))
                {
                    string eventName = eventNode.Attributes["name"]?.Value;
                    if (eventName == null) continue;

                    int index = 0;
                    foreach (XmlNode handlerNode in eventNode.SelectNodes("Handlers/Handler"))
                    {
                        var script = new Script
                        {
                            UiItem = form,
                            EntityLogicalName = emd.LogicalName,
                            EntityName = emd.DisplayName?.UserLocalizedLabel?.Label ?? "N/A",
                            Library = handlerNode.Attributes["libraryName"]?.Value ?? "N/A",
                            MethodCalled = handlerNode.Attributes["functionName"]?.Value ?? "N/A",
                            Enabled = handlerNode.Attributes["enabled"]?.Value == "true",
                            PassExecutionContext = handlerNode.Attributes["passExecutionContext"]?.Value == "true",
                            Event = eventName,
                            Parameters = handlerNode.Attributes["parameters"]?.Value ?? "",
                            Type = "Form event",
                            Order = index++
                        };

                        if (script.Library.IndexOf("_main_system_library", StringComparison.Ordinal) >= 0)
                        {
                            continue;
                        }

                        if (eventName == "onchange")
                        {
                            var amd = emd.Attributes.FirstOrDefault(x => eventNode.Attributes != null && x.LogicalName == eventNode.Attributes["attribute"]?.Value);

                            if (amd != null)
                            {
                                var displayName = amd.DisplayName?.UserLocalizedLabel?.Label ?? "(" + amd.LogicalName + ")";
                                script.Attribute = displayName;
                                script.AttributeLogicalName = amd.LogicalName;
                            }
                            else if (eventNode.Attributes["control"] == null)
                            {
                                script.Attribute = eventNode.Attributes["attribute"]?.Value ?? "N/A";
                                script.AttributeLogicalName = eventNode.Attributes["attribute"]?.Value ?? "N/A";
                                script.HasProblem = true;
                                script.Problem = $"Cannot find a control for attribute {eventNode.Attributes["attribute"]?.Value}";
                            }
                            else
                            {
                                XmlNode node = doc.SelectSingleNode("//control[@id='" + eventNode.Attributes["control"].Value + "']");
                                if (node == null)
                                {
                                    throw new Exception($"Unable to find control with id : {eventNode.Attributes["control"].Value}");
                                }
                                XmlNode targetEntityNode = node.SelectSingleNode("parameters/TargetEntityType");

                                if (targetEntityNode == null) continue;

                                amd = emds.First(e => e.LogicalName == targetEntityNode.InnerText).Attributes.First(x => x.LogicalName == eventNode.Attributes?["attribute"]?.Value);
                                var displayName = amd.DisplayName?.UserLocalizedLabel?.Label ?? "(" + amd.LogicalName + ")";
                                script.Attribute = displayName;
                                script.AttributeLogicalName = amd.LogicalName;
                            }

                            if (eventNode.Attributes["control"] != null)
                            {
                                var control = eventNode.Attributes["control"].Value;
                                script.Type = "Subgrid event";
                                script.AttributeLogicalName = $"{control}:{script.AttributeLogicalName}";

                                XmlNode node = doc.SelectSingleNode("//control[@id='" + control + "']");
                                if (node == null)
                                {
                                    script.HasProblem = true;
                                    script.Problem = $"Control '{control}' is not present anymore on the form";
                                }
                                else
                                {
                                    var labelNode = node.ParentNode.SelectSingleNode("labels/label[@languagecode='" + UserLcid + "']") ??
                                                      node.ParentNode.SelectSingleNode("labels/label");

                                    var label = labelNode.Attributes["description"]?.Value ?? "N/A";

                                    script.Attribute = $"{label} / {script.Attribute}";
                                }
                            }
                        }
                        else if (eventName == "onrecordselect")
                        {
                            var control = eventNode.Attributes["control"]?.Value;
                            if (control == null) continue;

                            script.Type = "Subgrid event";
                            script.AttributeLogicalName = control;

                            XmlNode node = doc.SelectSingleNode("//control[@id='" + control + "']");
                            if (node == null)
                            {
                                script.HasProblem = true;
                                script.Problem = $"Control '{control}' is not present anymore on the form";
                            }
                            else
                            {
                                var label = node.ParentNode?.SelectSingleNode("labels/label[@languagecode='" + UserLcid + "']")?.Attributes?[
                                        "description"]?.Value ?? "N/A";
                                script.Attribute = label;
                            }
                        }
                        else if (eventName == "onsave")
                        {
                            if (eventNode.Attributes["control"] != null)
                            {
                                var control = eventNode.Attributes["control"]?.Value;
                                if (control == null) continue;

                                script.Type = "Subgrid event";
                                script.AttributeLogicalName = control;

                                XmlNode node = doc.SelectSingleNode("//control[@id='" + control + "']");
                                if (node == null)
                                {
                                    script.HasProblem = true;
                                    script.Problem = $"Control '{control}' is not present anymore on the form";
                                }
                                else
                                {
                                    var label = node.ParentNode?.SelectSingleNode("labels/label[@languagecode='" + UserLcid + "']")?.Attributes?[
                                                    "description"]?.Value ?? "N/A";

                                    script.Attribute = label;
                                }
                            }
                        }
                        else
                        {
                            script.Attribute = "";
                            script.AttributeLogicalName = "";
                        }
                        script.ItemName = form["name"]?.ToString() ?? "N/A";
                        script.FormState = "Active";
                        if (form.Contains("formactivationstate"))
                        {
                            script.FormState = form.GetAttributeValue<OptionSetValue>("formactivationstate").Value == 0
                            ? "Inactive"
                            : "Active";
                        }

                        var type = form.GetAttributeValue<OptionSetValue>("type")?.Value ?? -1;
                        script.FormType = type == 2
                            ? "Main"
                            : (type == 7 ? "Quick Create" : "value: " + type);
                        Scripts.Add(script);
                    }
                }

                int lIndex = 0;
                foreach (XmlNode libraryNode in doc.SelectNodes("//Library"))
                {
                    var type = form.GetAttributeValue<OptionSetValue>("type")?.Value ?? -1;

                    var script = new Script
                    {
                        UiItem = form,
                        EntityLogicalName = emd.LogicalName,
                        EntityName = emd.DisplayName?.UserLocalizedLabel?.Label ?? "N/A",
                        Library = libraryNode.Attributes?["name"]?.Value ?? "N/A",
                        MethodCalled = string.Empty,
                        Event = string.Empty,
                        Attribute = string.Empty,
                        AttributeLogicalName = string.Empty,
                        Type = "Form Library",
                        Order = lIndex++,
                        ItemName = form["name"].ToString(),
                        FormState = form.GetAttributeValue<OptionSetValue>("formactivationstate")?.Value == 0
                            ? "Inactive"
                            : "Active",
                        FormType = type == 2
                            ? "Main"
                            : type == 7 ? "Quick Create" : "value: " + type
                    };

                    if (script.Library.IndexOf("_main_system_library", StringComparison.Ordinal) >= 0)
                    {
                        continue;
                    }

                    Scripts.Add(script);
                }
            }
        }

        private void LoadViews(List<EntityMetadata> emds)
        {
            var query = new QueryExpression("savedquery")
            {
                ColumnSet = new ColumnSet("layoutxml", "name", "returnedtypecode"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("returnedtypecode", ConditionOperator.In, emds.Select(e => e.LogicalName).ToArray())
                    }
                }
            };

            var views = _service.RetrieveMultiple(query).Entities.ToList();
            Views.AddRange(views);

            foreach (var view in views)
            {
                if (!view.Contains("layoutxml"))
                {
                    continue;
                }

                var emd = emds.First(e => e.LogicalName == view.GetAttributeValue<string>("returnedtypecode"));

                var doc = new XmlDocument();
                doc.LoadXml(view.GetAttributeValue<string>("layoutxml"));

                var nodes = doc.DocumentElement?.SelectNodes("row/cell[string(@imageproviderfunctionname)]");
                if (nodes == null) continue;
                foreach (XmlNode node in nodes)
                {
                    var script = new Script
                    {
                        Action = ScriptAction.None,
                        Attribute = emd.Attributes.FirstOrDefault(a => a.LogicalName == node.Attributes?["name"].Value)?
                                        .DisplayName?.UserLocalizedLabel?.Label ?? "N/A",
                        AttributeLogicalName = node.Attributes?["name"].Value,
                        Enabled = true,
                        EntityLogicalName = emd.LogicalName,
                        EntityName = emd.DisplayName?.UserLocalizedLabel?.Label ?? "N/A",
                        Event = "",
                        ItemName = view.GetAttributeValue<string>("name"),
                        FormState = "",
                        FormType = "",
                        HasProblem = false,
                        Library = node.Attributes?["imageproviderwebresource"].Value.Split(':').Last(),
                        MethodCalled = node.Attributes?["imageproviderfunctionname"].Value,
                        Order = 1,
                        Parameters = "",
                        PassExecutionContext = false,
                        Type = "Grid Icon",
                        UiItem = view
                    };

                    Scripts.Add(script);
                }
            }
        }
    }
}