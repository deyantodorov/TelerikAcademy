using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace T02.Employee
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        protected void FormViewEmployee_OnPageIndexChanged(object sender, FormViewPageEventArgs e)
        {
            this.FormViewEmployee.PageIndex = e.NewPageIndex;
        }
    }
}