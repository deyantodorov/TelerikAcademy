using System;
using System.Collections.Generic;
using System.Web.UI;

namespace T02.Session
{
    public partial class Default : Page
    {
        private readonly List<string> input = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var value = this.TextBoxInput.Text;

            if (!string.IsNullOrEmpty(value))
            {
                var current = value;
                input.Add(current);
                Session.Add("input", input);
            }

            var list = (List<string>)Session["input"];

            foreach (var item in list)
            {
                this.LabelResult.Text += item + "<br />";
            }
        }
    }
}