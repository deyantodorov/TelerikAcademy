using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using T02.Chat.Data;
using T02.Chat.Models;

namespace T02.Chat
{
    public partial class Default : Page
    {
        private readonly ChatDbContext db = new ChatDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewChatMessages.DataBind();
        }

        public IQueryable<ChatMessage> GetMessages()
        {
            return db.ChatMessages.OrderByDescending(x => x.CreatedOn).Take(100);
        }
        
        protected void LinkButtonAddMessage_OnClick(object sender, EventArgs e)
        {
            var chatMessage = new ChatMessage
            {
                CreatedOn = DateTime.Now,
                Text = Server.HtmlEncode(this.TextBoxMessageText.Text)
            };

            if (this.ModelState.IsValid)
            {
                this.db.ChatMessages.Add(chatMessage);
                this.db.SaveChanges();
            }

            this.TextBoxMessageText.Text = string.Empty;
        }
    }
}