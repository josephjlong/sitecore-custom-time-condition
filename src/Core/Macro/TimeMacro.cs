using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Rules.RuleMacros;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;
using System.Xml.Linq;

namespace SitecoreDemo.Core.Macro
{
    public class TimeMacro : IRuleMacro
    {
        public void Execute(XElement element, string name, UrlString parameters, string value)
        {


            Assert.ArgumentNotNull((object)element, "element");
            Assert.ArgumentNotNull((object)name, "name");
            Assert.ArgumentNotNull((object)parameters, "parameters");
            Assert.ArgumentNotNull((object)value, "value");

            SheerResponse.ShowModalDialog(new UrlString(UIUtil.GetUri("control:Sitecore.Shell.Applications.Dialogs.TimeSelector")).ToString(), "580px", "475px", string.Empty, true);

        }

    }
}
