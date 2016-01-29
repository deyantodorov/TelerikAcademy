using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace T01.EmployeesAndOrders
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewEmployees_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            this.UpdatePanelOrders.Visible = true;
        }
    }
}