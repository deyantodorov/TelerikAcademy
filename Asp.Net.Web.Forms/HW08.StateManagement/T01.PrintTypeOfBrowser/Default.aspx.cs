using System;
using System.Web;
using System.Web.UI;

namespace T01.PrintTypeOfBrowser
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;

            this.Ip.Text += context.Request.ServerVariables["REMOTE_ADDR"];
            this.Browser.Text += Request.Browser.Type;
            this.PageInfo.Text += Request.ServerVariables["PATH_INFO"];
        }
    }
}