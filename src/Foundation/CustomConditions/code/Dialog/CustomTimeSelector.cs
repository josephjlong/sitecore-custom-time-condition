using Sitecore;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;
using System;

namespace SitecoreDemo.Foundation.CustomCondtions.Dialog
{
    public class CustomTimeSelector : DialogForm
    {
        /// <summary>Gets or sets the time.</summary>
        /// <value>The time.</value>
        protected TimePicker Time { get; set; }

        /// <summary>Raises the load event.</summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Context.ClientPage.IsEvent)
                return;

            Time.Value = DateTime.Now.TimeOfDay.ToString();
        }

        /// <summary>Handles a click on the OK button.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The arguments.</param>
        protected override void OnOK(object sender, EventArgs args)
        {
            SheerResponse.SetDialogValue(Time.Value);
            base.OnOK(sender, args);
        }
    }
}
