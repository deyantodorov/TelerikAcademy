using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidationControls
{
    public partial class RegistrationWithServerValidation : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable GetSex()
        {
            return new List<string>()
            {
                "male",
                "female"
            };
        }

        protected void rblSex_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var list = sender as RadioButtonList;

            if (list != null)
            {
                var selected = list.SelectedItem.Text;
                this.DropDownListSex.Visible = true;

                if (selected == "female")
                {
                    var female = new List<string>()
                    {
                        "Lavazza",
                        "New Brazil"
                    };

                    this.DropDownListSex.DataSource = female;

                }
                else if (selected == "male")
                {
                    var male = new List<string>()
                    {
                        "Bmw",
                        "Toyota"
                    };

                    this.DropDownListSex.DataSource = male;
                }

                this.DropDownListSex.DataBind();
            }
        }
    }
}