using System;
using System.Reflection;
using System.Web.UI;

namespace WebFormsApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtHi.InnerText = "From the C# code - \"Hello, ASP.NET\"";
            this.txtAssembly.InnerText = "Assembly location by " + Assembly.GetExecutingAssembly().Location;
        }
    }
}