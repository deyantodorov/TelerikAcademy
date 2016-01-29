using System;
using System.Collections.Generic;
using System.Web.UI;

namespace HW12.UserControls.Controls.Menu
{
    public partial class UserMenu : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.dlUserMenu.Style.Add("font-family", this.FontFamily);
        }

        public UserMenu()
        {
            this.FontFamily = "Comic Sans MS";
            this.FontColor = "black";
        }

        public string FontFamily { get; set; }

        public string FontColor { get; set; }

        public IEnumerable<MenuItem> DataSource
        {
            get { return (IEnumerable<MenuItem>)this.dlUserMenu.DataSource; }
            set
            {
                foreach (var item in value)
                {
                    if (string.IsNullOrWhiteSpace(item.FontColor))
                    {
                        item.FontColor = this.FontColor;
                    }
                }

                this.dlUserMenu.DataSource = value;
            }
        }

        public override void DataBind()
        {
            this.dlUserMenu.DataBind();

            base.DataBind();
        }
    }
}