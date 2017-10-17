using System.Collections.Generic;
using System.Windows.Forms;

namespace MsCrmTools.ScriptsFinder
{
    public class Script
    {
        public string Arguments { get; set; }
        public string Attribute { get; set; }
        public string AttributeLogicalName { get; set; }
        public List<string> Dependencies { get; set; }
        public string EntityLogicalName { get; set; }
        public string EntityName { get; set; }
        public string Event { get; set; }
        public bool HasProblem { get; set; }
        public bool? IsActive { get; set; }
        public string MethodCalled { get; set; }
        public string ScriptLocation { get; set; }
        public string Type { get; set; }
        public bool? PassExecutionContext { get; set; }
        public string FormType { get; internal set; }
        public string FormName { get; set; }
        public string FormState { get; set; }
    }
}