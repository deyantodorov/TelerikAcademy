using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Web;

namespace ImageHandler.Handlers
{
    public class ImageHandler : IHttpHandler
    {
        public bool IsReusable { get; }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";
            var text = context.Request.FilePath
                .Substring(1, context.Request.FilePath.Length - 5)
                .Replace('-', ' ');

            var image = CreateBitmapImage(text);
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);

            context.Response.BinaryWrite(ms.ToArray());
        }


        private Bitmap CreateBitmapImage(string imageText)
        {
            Bitmap objBmpImage = new Bitmap(1, 1);

            int intWidth = 0;
            int intHeight = 0;

            // Create the Font object for the image text drawing.
            Font objFont = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);

            // Create a graphics object to measure the text's width and height.
            Graphics objGraphics = Graphics.FromImage(objBmpImage);

            // This is where the bitmap size is determined.
            intWidth = (int)objGraphics.MeasureString(imageText, objFont).Width;
            intHeight = (int)objGraphics.MeasureString(imageText, objFont).Height;

            // Create the bmpImage again with the correct size for the text and font.
            objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

            // Add the colors to the new bitmap.
            objGraphics = Graphics.FromImage(objBmpImage);

            // Set Background color
            objGraphics.Clear(Color.White);
            objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            objGraphics.DrawString(imageText, objFont, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 0);
            objGraphics.Flush();

            return (objBmpImage);
        }
    }
}