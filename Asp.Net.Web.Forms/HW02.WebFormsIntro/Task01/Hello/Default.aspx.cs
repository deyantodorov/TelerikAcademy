using System;
using System.Web.UI;

namespace Hello
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            this.txtGreet.InnerText = "Hello, " + this.tbName.Text.ToUpper();
        }
    }
}