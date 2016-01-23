using System;
using System.Web.UI;

namespace T02.Escaping
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitUserInput_Click(object sender, EventArgs e)
        {
            this.inputResult.Visible = true;
            this.inputLabel.Visible = true;

            this.inputResult.Text = Server.HtmlDecode(this.userInput.Value);
            this.inputLabel.Text = Server.HtmlEncode(this.userInput.Value);
        }
    }
}