using System;
using System.IO;
using System.Web.UI;
using AjaxControlToolkit;

namespace T02.Chat
{
    public partial class PhotoAlbum : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AsyncFileUploadField_OnUploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            System.Threading.Thread.Sleep(3000);

            var strPath = MapPath("~/Uploads/") + Path.GetFileName(e.GetHashCode() + "_" + e.FileName);

            if (!Directory.Exists(MapPath("~/Uploads/")))
            {
                Directory.CreateDirectory(MapPath("~/Uploads/"));
            }

            AsyncFileUploadField.SaveAs(strPath);
        }
    }
}