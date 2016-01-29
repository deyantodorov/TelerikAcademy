using System;
using System.IO;
using System.Text;
using System.Web.UI;
using HW07.FileUpload.Models;
using Ionic.Zip;

namespace HW07.FileUpload
{
    public partial class Default : Page
    {
        private const string SuccessMessage = "File uploaded successfully to DB";
        private const string ErrorMessage = "Error in file upload";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (this.FileUploadControl.HasFile && IsCorrectContentType())
            {
                try
                {
                    byte[] fileData = null;
                    Stream fileStream = null;
                    int length = 0;

                    // Fill in Memory
                    length = this.FileUploadControl.PostedFile.ContentLength;
                    fileData = new byte[length + 1];
                    fileStream = this.FileUploadControl.PostedFile.InputStream;
                    fileStream.Read(fileData, 0, length);
                    var zipArchiveMemoryStream = new MemoryStream(fileData);

                    using (var archivedFileMemoryStream = new MemoryStream())
                    {
                        using (ZipFile zip = ZipFile.Read(zipArchiveMemoryStream))
                        {
                            foreach (ZipEntry entry in zip)
                            {
                                entry.Extract(archivedFileMemoryStream);
                            }
                        }

                        var content = Encoding.ASCII.GetString(archivedFileMemoryStream.ToArray());

                        // Save To Db
                        using (var db = new TextFilesDbContext())
                        {
                            db.TextFiles.Add(new TextFile()
                            {
                                Content = content
                            });

                            db.SaveChanges();
                        }

                        this.StatusMessage.Text = SuccessMessage;
                    }

                }
                catch (Exception)
                {
                    this.StatusMessage.Text = ErrorMessage;
                }
            }
            else
            {
                this.StatusMessage.Text = ErrorMessage;
            }
        }

        private bool IsCorrectContentType()
        {
            var currentType = this.FileUploadControl.PostedFile.ContentType.ToString();

            if (currentType == "application/zip"
                || currentType == "application/x-zip-compressed")
            {
                return true;
            }

            return false;
        }

        private string GetCurrentDateAsString()
        {
            var sb = new StringBuilder();

            sb.Append(DateTime.Now.Day);
            sb.Append(DateTime.Now.Month);
            sb.Append(DateTime.Now.Year);
            sb.Append(DateTime.Now.Hour);
            sb.Append(DateTime.Now.Minute);
            sb.Append(DateTime.Now.Second);
            sb.Append(DateTime.Now.Millisecond);

            return sb.ToString();
        }
    }
}