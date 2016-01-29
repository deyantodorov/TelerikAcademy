using System;
using System.Web.UI;

namespace T03.ExchangeUserData
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["UserName"];

            if (cookie == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Response.Write("<h1>Welcome at " + DateTime.Now + "</h1>");
            }
        }
    }
}