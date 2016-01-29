using System;
using System.Collections.Generic;
using System.Web.UI;
using HW12.UserControls.Controls.Menu;

namespace HW12.UserControls
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var menu = new List<MenuItem>()
            {
                new MenuItem("Pesho", "https://www.google.bg"),
                new MenuItem("Stamat", "https://www.google.bg"),
                new MenuItem("Gogo", "https://www.google.bg")
            };

            this.UserMenu.DataSource = menu;
            this.UserMenu.DataBind();
        }
    }
}