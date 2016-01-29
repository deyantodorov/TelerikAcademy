using System.Data.Entity;
using T02.Chat.Migrations;
using T02.Chat.Models;

namespace T02.Chat.Data
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext()
            : base("name=ChatDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChatDbContext, Configuration>());
        }


        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }
    }
}