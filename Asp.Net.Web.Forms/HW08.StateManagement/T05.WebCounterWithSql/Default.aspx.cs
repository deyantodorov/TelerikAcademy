using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Web.UI;
using T05.WebCounterWithSql.Data;
using T05.WebCounterWithSql.Models;

namespace T05.WebCounterWithSql
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddLoad_Click(object sender, EventArgs e)
        {
            using (var db = new CounterDbContext())
            {
                if (db.Counters.FirstOrDefault() == null)
                {
                    db.Counters.Add(new Counter()
                    {
                        Visits = 0
                    });
                }
                else
                {
                    var firstOrDefault = db.Counters.FirstOrDefault();

                    if (firstOrDefault != null)
                    {
                        firstOrDefault.Visits += 1;
                    }
                }

                db.SaveChanges();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            var db = new CounterDbContext();

            if (db.Counters.FirstOrDefault() == null)
            {
                db.Counters.Add(new Counter()
                {
                    Visits = 0
                });

                db.SaveChanges();
            }

            var firstOrDefault = db.Counters.FirstOrDefault();

            if (firstOrDefault != null)
            {
                var counter = firstOrDefault.Visits.ToString();
                var image = CreateBitmapImage("Counter: " + counter);

                image.Save(Server.MapPath("~/") + "image.gif", ImageFormat.Gif);
                this.LabelLoad.Text = counter;
            }

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