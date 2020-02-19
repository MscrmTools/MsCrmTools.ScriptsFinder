using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace MsCrmTools.ScriptsFinder.AppCode
{
    internal interface IUiUtem
    {
        Entity Item { get; }
        List<string> Libraries { get; }

        List<CdsFormControl> GetControls(int userLcid);
    }
}