using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Web.UI;

namespace T05.WebCounter
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddLoad_Click(object sender, EventArgs e)
        {
            Application.Lock();
            Application["Counter"] = (int)Application["Counter"] + 1;
            Application.UnLock();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            Application.Lock();

            if (Application["Counter"] == null)
            {
                Application["Counter"] = 0;
            }

            Application.UnLock();

            var counter = Application["Counter"].ToString();
            var image = CreateBitmapImage("Counter: " + counter);

            image.Save(Server.MapPath("~/") + "image.gif", ImageFormat.Gif);
            this.LabelLoad.Text = counter;
            this.ImageCounter.ImageUrl = "image.gif";
        }

        private Bitmap CreateBitmapImage(string text)
        {
            Bitmap bitmapImage = new Bitmap(1, 1);

            var width = 0;
            var height = 0;

            Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);

            Graphics graphics = Graphics.FromImage(bitmapImage);

            width = (int)graphics.MeasureString(text, font).Width;
            height = (int)graphics.MeasureString(text, font).Height;

            bitmapImage = new Bitmap(bitmapImage, new Size(width, height));

            graphics = Graphics.FromImage(bitmapImage);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 0);

            return bitmapImage;
        }
    }
}