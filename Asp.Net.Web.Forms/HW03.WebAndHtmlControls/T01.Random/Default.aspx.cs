using System;
using System.Web.UI;

namespace T01.Random
{
    public partial class Default : Page
    {
        private static readonly System.Random Rand = new System.Random();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Generate_Click(object sender, EventArgs e)
        {
            try
            {
                var min = int.Parse(this.minValue.Value);
                var max = int.Parse(this.maxValue.Value);
                var value = Rand.Next(min, max + 1);

                this.randomValue.Attributes.Remove("class");
                this.randomValue.Attributes.Add("class", "card-panel teal lighten-2");
                this.randomValue.InnerText = value.ToString();
            }
            catch (Exception ex)
            {
                this.randomValue.Attributes.Add("class", "card-panel red accent-4");
                this.randomValue.InnerText = ex.Message;
            }
        }

        protected void GenerateRandomValue_Click(object sender, EventArgs e)
        {
            try
            {
                var min = int.Parse(this.minValue2.Text);
                var max = int.Parse(this.maxValue2.Text);
                var value = Rand.Next(min, max + 1);

                this.randomValue2.Attributes.Remove("class");
                this.randomValue2.Attributes.Add("class", "card-panel teal lighten-2");
                this.randomValue2.InnerText = value.ToString();
            }
            catch (Exception ex)
            {
                this.randomValue2.Attributes.Add("class", "card-panel red accent-4");
                this.randomValue2.InnerText = ex.Message;
            }
        }
    }
}