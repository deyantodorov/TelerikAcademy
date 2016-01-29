using System.Data.Entity;
using HW07.FileUpload.Models;

namespace HW07.FileUpload
{
    public class TextFilesDbContext : DbContext
    {
        // Your context has been configured to use a 'TextFilesDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HW7.FileUpload.TextFilesDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TextFilesDb' 
        // connection string in the application configuration file.
        public TextFilesDbContext()
            : base("name=TextFilesDb")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<TextFile> TextFiles { get; set; }
    }
}