using Microsoft.Xrm.Sdk;
using MsCrmTools.ScriptsFinder.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MsCrmTools.ScriptsFinder
{
    public enum ScriptAction
    {
        None,
        Create,
        Update,
        Delete
    }

    public class Script
    {
        #region Properties

        public ScriptAction Action { get; set; } = ScriptAction.None;
        public string Attribute { get; set; }
        public string AttributeLogicalName { get; set; }
        public bool? Enabled { get; set; }
        public string EntityLogicalName { get; set; }
        public string EntityName { get; set; }
        public string Event { get; set; }
        public string FormState { get; set; }
        public string FormType { get; internal set; }
        public bool HasProblem { get; set; }
        public string ItemAttribute => Type.Contains("Homepage") ? "eventsxml" : Type.Contains("Icon") ? "layoutxml" : "formxml";
        public string ItemName { get; set; }
        public string ItemUpdateAttribute => Type.Contains("Homepage") ? "updatedeventsxml" : Type.Contains("Icon") ? "updatedlayoutxml" : "updatedformxml";
        public string Library { get; set; }
        public string MethodCalled { get; set; }
        public bool? NewEnabled { get; set; }
        public string NewLibrary { get; set; }
        public string NewMethodCalled { get; set; }
        public int? NewOrder { get; internal set; }
        public string NewParameters { get; set; }
        public bool? NewPassExecutionContext { get; set; }
        public int Order { get; internal set; }
        public string Parameters { get; set; }
        public bool? PassExecutionContext { get; set; }

        public bool RequiresUpdate =>
            !string.IsNullOrEmpty(NewParameters) && NewParameters != Parameters
            || !string.IsNullOrEmpty(NewMethodCalled) && NewMethodCalled != MethodCalled
            || UiItem != null && UiItem.Contains(ItemUpdateAttribute) &&
            UiItem.GetAttributeValue<string>(ItemUpdateAttribute) != UiItem.GetAttributeValue<string>(ItemAttribute)
            || NewEnabled.HasValue && NewEnabled.Value != (Enabled ?? false)
            || NewPassExecutionContext.HasValue && NewPassExecutionContext.Value !=
            (PassExecutionContext ?? false)
            || NewOrder.HasValue && NewOrder.Value != Order
            || !string.IsNullOrEmpty(NewLibrary) &&
            NewLibrary.ToLower() != Library.ToLower();

        public string Type { get; set; }
        public Entity UiItem { get; set; }
        public string UpdateErrorMessage { get; set; }
        public string Problem { get; internal set; }

        #endregion Properties

        #region Method

        public void ProcessChanges(List<Script> allScripts)
        {
            var xml = UiItem.GetAttributeValue<string>(ItemUpdateAttribute) ?? UiItem.GetAttributeValue<string>(ItemAttribute);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            if (Type == "Form event" || Type == "Subgrid event")
            {
                if (Action == ScriptAction.Create)
                {
                    XmlNode eventNode = null;
                    XmlNode eventsNode;

                    if (Event == "ontabstatechange")
                    {
                        var tabNode = doc.SelectSingleNode("//tab[@id='" + AttributeLogicalName + "']");
                        if (tabNode == null)
                        {
                            throw new Exception($"Unable to find tab Node with id {AttributeLogicalName}");
                        }

                        eventsNode = tabNode.GetOrCreateNode("events");
                        eventNode = eventsNode.SelectSingleNode("event[@application='false' and @name='tabstatechange']");
                    }
                    else
                    {
                        eventsNode = doc.FirstChild.GetOrCreateNode("events");

                        if (Event == "onchange")
                        {
                            if (Type == "Form event")
                            {
                                eventNode = eventsNode.SelectSingleNode(
                                    "event[@application='false' and @name='onchange' and @attribute='" +
                                    AttributeLogicalName + "']");
                            }
                            else
                            {
                                var parts = AttributeLogicalName.Split(':');
                                eventNode = eventsNode.SelectSingleNode(
                                    "event[@application='false' and @name='onchange' and @attribute='" +
                                    parts[1] + "' and @control='" + parts[0] + "']");
                            }
                        }
                        else if (Event == "onload" || Event == "onsave" || Event == "onrecordselect")
                        {
                            if (Type == "Form event")
                            {
                                eventNode = eventsNode.SelectSingleNode(
                                    "event[@application='false' and @name='" + Event + "']");
                            }
                            else
                            {
                                eventNode = eventsNode.SelectSingleNode(
                                    "event[@application='false' and @name='" + Event + "' and @control='" +
                                    AttributeLogicalName + "']");
                            }
                        }
                    }

                    if (eventNode == null)
                    {
                        eventNode = eventsNode.AppendNewNode("event",
                            new Dictionary<string, string>
                            {
                                {"name", Event == "ontabstatechange" ? "tabstatechange" : Event},
                                {"application","false"},
                                {"active","false"}
                            }
                        );

                        if (Type == "Form event" && Event == "onchange")
                        {
                            eventNode.AddAttribute("attribute", AttributeLogicalName);
                        }

                        if (Type == "Subgrid event")
                        {
                            var parts = AttributeLogicalName.Split(':');

                            eventNode.AddAttribute("relationship", "");
                            eventNode.AddAttribute("control", parts[0]);

                            if (Event == "onchange")
                            {
                                eventNode.AddAttribute("attribute", parts[1]);
                            };
                        }

                        eventsNode.AppendChild(eventNode);
                    }

                    var handlersNode = eventNode.GetOrCreateNode("Handlers");

                    handlersNode.AppendNewNodeAtIndex("Handler",
                        new Dictionary<string, string>
                        {
                            {"functionName", MethodCalled},
                            {"libraryName", Library},
                            {"handlerUniqueId", Guid.NewGuid().ToString("B").ToLower()},
                            {"enabled", (Enabled ?? false).ToString().ToLower()},
                            {"parameters", Parameters},
                            {"passExecutionContext", (PassExecutionContext ?? false).ToString().ToLower()}
                        },
                        NewOrder ?? Order);
                }
                else
                {
                    var parts = AttributeLogicalName.Split(':');

                    var handlerNode = doc.SelectSingleNode("//event[@name='" + Event +
                                                           (Event == "onchange" ? "' and @attribute='" + (parts.Length > 1 ? parts[1] : AttributeLogicalName) : "") + "'" +
                                                           (Type == "Subgrid event" ? " and @control='" + parts[0] + "'" : "") +
                                                           "]/Handlers/Handler[@libraryName='" + Library + "' and @functionName='" + MethodCalled + "']");

                    if (handlerNode == null)
                    {
                        throw new Exception("Cannot find Handler node");
                    }

                    if (Action == ScriptAction.Delete)
                    {
                        var handlersNode = handlerNode.ParentNode;
                        var eventNode = handlersNode?.ParentNode;
                        if (eventNode == null) return;

                        var eventsNode = eventNode.ParentNode;

                        if (handlersNode.ChildNodes.Count > 1)
                        {
                            handlersNode.RemoveChild(handlerNode);
                        }
                        else
                        {
                            eventsNode?.RemoveChild(eventNode);
                        }

                        if (eventsNode?.ChildNodes.Count == 0)
                        {
                            eventsNode.ParentNode?.RemoveChild(eventsNode);
                        }
                    }
                    else if (Action == ScriptAction.Update)
                    {
                        if (NewEnabled.HasValue)
                        {
                            handlerNode.Attributes["enabled"].Value = NewEnabled.Value ? "true" : "false";
                        }

                        if (!string.IsNullOrEmpty(NewParameters))
                        {
                            handlerNode.Attributes["parameters"].Value = NewParameters;
                        }

                        if (!string.IsNullOrEmpty(NewLibrary))
                        {
                            handlerNode.Attributes["libraryName"].Value = NewLibrary;
                        }

                        if (!string.IsNullOrEmpty(NewMethodCalled))
                        {
                            handlerNode.Attributes["functionName"].Value = NewMethodCalled;
                        }

                        if (NewPassExecutionContext.HasValue)
                        {
                            handlerNode.Attributes["passExecutionContext"].Value =
                                NewPassExecutionContext.Value ? "true" : "false";
                        }

                        if (NewOrder.HasValue)
                        {
                            var eventScripts = allScripts.Where(s =>
                                s.Type == Type &&
                                s.Event == Event && s.UiItem.Id == UiItem.Id &&
                                s.AttributeLogicalName == AttributeLogicalName)
                                .OrderBy(s => s.NewOrder ?? s.Order);

                            var parentNode = handlerNode.ParentNode;
                            List<XmlNode> nodes = new List<XmlNode>();
                            foreach (var eventScript in eventScripts)
                            {
                                var esParts = eventScript.AttributeLogicalName.Split(':');

                                var node = doc.SelectSingleNode("//event[@name='" + eventScript.Event +
                                                                       (eventScript.Event == "onchange" ? "' and @attribute='" + (esParts.Length > 1 ? esParts[1] : eventScript.AttributeLogicalName) : "") + "'" +
                                                                       (eventScript.Type == "Subgrid event" ? " and @control='" + esParts[0] + "'" : "") +
                                                                       "]/Handlers/Handler[@libraryName='" + eventScript.Library + "' and @functionName='" + eventScript.MethodCalled + "']");

                                //var node = doc.SelectSingleNode("//event[@name='" + eventScript.Event + (eventScript.Event == "onchange" ? "' and @attribute='" + eventScript.AttributeLogicalName : "") + "']/Handlers/Handler[@libraryName='" +
                                //                                eventScript.Library +
                                //                                       "' and @functionName='" + eventScript.MethodCalled + "']");

                                if (node == null) continue;

                                nodes.Add(node);
                                parentNode?.RemoveChild(node);
                            }

                            foreach (var node in nodes)
                            {
                                parentNode?.AppendChild(node);
                            }
                        }
                    }
                }
            }
            else if (Type == "Form Library")
            {
                if (Action == ScriptAction.Create)
                {
                    var librariesNode = doc.FirstChild.GetOrCreateNode("formLibraries");
                    librariesNode.AppendNewNodeAtIndex("Library",
                        new Dictionary<string, string>
                        {
                            {"name", Library},
                            {"libraryUniqueId", Guid.NewGuid().ToString("B").ToLower()},
                        }, NewOrder ?? Order);
                }
                else
                {
                    var node = doc.FirstChild.SelectSingleNode("formLibraries/Library[@name = '" + Library + "']");
                    if (node == null)
                    {
                        throw new Exception("Unable to find Library node");
                    }

                    if (Action == ScriptAction.Update)
                    {
                        if (!string.IsNullOrEmpty(NewLibrary))
                        {
                            node.Attributes["name"].Value = NewLibrary;
                        }

                        if (NewOrder.HasValue)
                        {
                            var eventScripts = allScripts.Where(s =>
                                    s.Type == Type
                                    && s.UiItem.Id == UiItem.Id)
                                .OrderBy(s => s.NewOrder ?? s.Order);

                            var parentNode = node.ParentNode;
                            List<XmlNode> tempNodes = new List<XmlNode>();
                            foreach (var eventScript in eventScripts)
                            {
                                var tempNode = doc.FirstChild.SelectSingleNode("formLibraries/Library[@name = '" + eventScript.Library + "' or @name='" + eventScript.NewLibrary + "']");
                                if (tempNode == null) continue;

                                tempNodes.Add(tempNode);
                                parentNode?.RemoveChild(tempNode);
                            }

                            foreach (var tempNode in tempNodes)
                            {
                                parentNode?.AppendChild(tempNode);
                            }
                        }
                    }
                    else if (Action == ScriptAction.Delete)
                    {
                        var parentNode = node.ParentNode;
                        parentNode?.RemoveChild(node);
                        if (parentNode?.ChildNodes.Count == 0)
                        {
                            parentNode?.ParentNode?.RemoveChild(parentNode);
                        }
                    }
                }
            }
            else if (Type == "Homepage Grid event")
            {
                if (Action == ScriptAction.Create)
                {
                    XmlNode eventNode = null;
                    XmlNode eventsNode = doc.FirstChild.GetOrCreateNode("events");

                    if (Event == "onchange")
                    {
                        eventNode = eventsNode.SelectSingleNode(
                            "event[@application='false' and @name='onchange' and @attribute='" +
                            AttributeLogicalName + "']");
                    }
                    else if (Event == "onsave" || Event == "onrecordselect")
                    {
                        eventNode = eventsNode.SelectSingleNode(
                            "event[@application='false' and @name='" + Event + "']");
                    }

                    if (eventNode == null)
                    {
                        eventNode = eventsNode.AppendNewNode("event",
                            new Dictionary<string, string>
                            {
                                {"name",Event.ToLower() },
                                {"application","false" },
                                {"active","false" },
                                {"control","Grids" },
                                {"relationship","" }
                            }
                        );

                        if (Event == "onchange")
                        {
                            eventNode.AddAttribute("attribute", AttributeLogicalName);
                        }
                    }

                    var handlersNode = eventNode.GetOrCreateNode("Handlers");
                    handlersNode.AppendNewNodeAtIndex("Handler",
                        new Dictionary<string, string>
                        {
                            {"functionName", MethodCalled},
                            {"libraryName", Library},
                            {"handlerUniqueId", Guid.NewGuid().ToString("B").ToLower()},
                            {"enabled", (Enabled ?? false).ToString().ToLower()},
                            {"parameters", Parameters},
                            {"passExecutionContext", (PassExecutionContext ?? false).ToString().ToLower()}
                        },
                        NewOrder ?? Order
                    );
                }
                else
                {
                    var handlerNode = doc.SelectSingleNode("//event[@name='" + Event + (Event == "onchange" ? "' and @attribute='" + AttributeLogicalName : "") + "']/Handlers/Handler[@libraryName='" +
                                                    Library +
                                                    "' and @functionName='" + MethodCalled + "']");

                    if (handlerNode == null)
                    {
                        throw new Exception("Cannot find Handler node");
                    }

                    if (Action == ScriptAction.Delete)
                    {
                        var handlersNode = handlerNode.ParentNode;
                        var eventNode = handlersNode?.ParentNode;
                        var eventsNode = eventNode?.ParentNode;

                        if (handlersNode?.ChildNodes.Count > 1)
                        {
                            handlersNode.RemoveChild(handlerNode);
                        }
                        else
                        {
                            eventsNode?.RemoveChild(eventNode);
                        }

                        if (eventsNode?.ChildNodes.Count == 0)
                        {
                            eventsNode?.ParentNode?.RemoveChild(eventsNode);
                        }
                    }
                    else if (Action == ScriptAction.Update)
                    {
                        if (NewEnabled.HasValue)
                        {
                            handlerNode.Attributes["enabled"].Value = NewEnabled.Value ? "true" : "false";
                        }

                        if (!string.IsNullOrEmpty(NewParameters))
                        {
                            handlerNode.Attributes["parameters"].Value = NewParameters;
                        }

                        if (!string.IsNullOrEmpty(NewLibrary))
                        {
                            handlerNode.Attributes["libraryName"].Value = NewLibrary;
                        }

                        if (!string.IsNullOrEmpty(NewMethodCalled))
                        {
                            handlerNode.Attributes["functionName"].Value = NewMethodCalled;
                        }

                        if (NewPassExecutionContext.HasValue)
                        {
                            handlerNode.Attributes["passExecutionContext"].Value =
                                NewPassExecutionContext.Value ? "true" : "false";
                        }

                        if (NewOrder.HasValue)
                        {
                            var eventScripts = allScripts.Where(s =>
                                    s.Type == Type &&
                                    s.Event == Event && s.UiItem.Id == UiItem.Id &&
                                    s.AttributeLogicalName == AttributeLogicalName)
                                .OrderBy(s => s.NewOrder ?? s.Order);

                            var parentNode = handlerNode.ParentNode;
                            List<XmlNode> nodes = new List<XmlNode>();
                            foreach (var eventScript in eventScripts)
                            {
                                var node = doc.SelectSingleNode("//event[@name='" + eventScript.Event + (eventScript.Event == "onchange" ? "' and @attribute='" + eventScript.AttributeLogicalName : "") + "']/Handlers/Handler[@libraryName='" +
                                                                eventScript.Library +
                                                                "' and @functionName='" + eventScript.MethodCalled + "']");

                                if (node == null) continue;

                                nodes.Add(node);
                                parentNode?.RemoveChild(node);
                            }

                            foreach (var node in nodes)
                            {
                                parentNode?.AppendChild(node);
                            }
                        }
                    }
                }
            }
            else if (Type == "Homepage Grid Library")
            {
                if (Action == ScriptAction.Create)
                {
                    var formLibrariesNode = doc.FirstChild.GetOrCreateNode("formLibraries");
                    formLibrariesNode.AppendNewNodeAtIndex("Library",
                        new Dictionary<string, string>
                        {
                            {"name", Library },
                            {"libraryUniqueId", Guid.NewGuid().ToString("B").ToLower() }
                        },
                        NewOrder ?? Order
                    );
                }
                else
                {
                    var node = doc.SelectSingleNode("//Library[@name = '" + Library + "']");
                    if (node == null)
                    {
                        throw new Exception("Unable to find Library node");
                    }

                    if (Action == ScriptAction.Update)
                    {
                        if (!string.IsNullOrEmpty(NewLibrary))
                        {
                            node.Attributes["name"].Value = NewLibrary;
                        }

                        if (NewOrder.HasValue)
                        {
                            var eventScripts = allScripts.Where(s =>
                                    s.Type == Type
                                    && s.UiItem.Id == UiItem.Id)
                                .OrderBy(s => s.NewOrder ?? s.Order);

                            var parentNode = node.ParentNode;
                            List<XmlNode> tempNodes = new List<XmlNode>();
                            foreach (var eventScript in eventScripts)
                            {
                                var tempNode = doc.FirstChild.SelectSingleNode("//Library[@name = '" + eventScript.Library + "' or @name='" + eventScript.NewLibrary + "']");
                                if (tempNode == null) continue;

                                tempNodes.Add(tempNode);
                                parentNode?.RemoveChild(tempNode);
                            }

                            foreach (var tempNode in tempNodes)
                            {
                                parentNode?.AppendChild(tempNode);
                            }
                        }
                    }
                    else if (Action == ScriptAction.Delete)
                    {
                        var parentNode = node.ParentNode;
                        parentNode?.RemoveChild(node);
                        if (parentNode?.ChildNodes.Count == 0)
                        {
                            parentNode?.ParentNode?.RemoveChild(parentNode);
                        }
                    }
                }
            }
            else if (Type == "Grid Icon")
            {
                var node = doc.DocumentElement?.SelectSingleNode("row/cell[@name='" + AttributeLogicalName + "']");
                if (node == null)
                {
                    throw new Exception($"Unable to find cell node for attribute {AttributeLogicalName}");
                }

                if (Action == ScriptAction.Update || Action == ScriptAction.Create)
                {
                    if (!string.IsNullOrEmpty(NewLibrary))
                    {
                        if (node.Attributes["imageproviderwebresource"] == null)
                        {
                            node.AddAttribute("imageproviderwebresource", $"$webresource:{NewLibrary}");
                        }
                        else
                        {
                            node.Attributes["imageproviderwebresource"].Value = $"$webresource:{NewLibrary}";
                        }
                    }

                    if (!string.IsNullOrEmpty(NewMethodCalled))
                    {
                        if (node.Attributes["imageproviderfunctionname"] == null)
                        {
                            node.AddAttribute("imageproviderfunctionname", NewMethodCalled);
                        }
                        else
                        {
                            node.Attributes["imageproviderfunctionname"].Value = NewMethodCalled;
                        }
                    }
                }
                else if (Action == ScriptAction.Delete)
                {
                    node.Attributes.Remove(node.Attributes["imageproviderwebresource"]);
                    node.Attributes.Remove(node.Attributes["imageproviderfunctionname"]);
                }
            }
            else
            {
                return;
            }

            UiItem[ItemUpdateAttribute] = doc.OuterXml;
        }

        #endregion Method
    }
}