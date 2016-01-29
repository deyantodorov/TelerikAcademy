using System;
using System.Web.UI;

namespace T02.Employee
{
    public partial class EmpDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ReturnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}