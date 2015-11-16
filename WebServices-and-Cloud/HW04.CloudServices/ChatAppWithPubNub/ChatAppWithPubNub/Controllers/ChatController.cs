using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using ChatAppWithPubNub.Infrastructure.PubNub;
using ChatAppWithQueue.Models;

namespace ChatAppWithPubNub.Controllers
{
    public class ChatController : ApiController
    {
        private const string Channel = "SimpleChat";
        private PubNubApi pubNub;

        public ChatController()
        {
            this.pubNub = new PubNubApi(
                "pub-c-2f999838-b696-4abb-a28c-08e2d0f801da",               // PUBLISH_KEY
                "sub-c-1f9e38f8-8c48-11e5-83e3-02ee2ddab7fe",               // SUBSCRIBE_KEY
                "sec-c-Y2VhZmM4YzctMzkwMC00NGFjLWE5N2MtMzM5NzAxYzYwOWY5",   // SECRET_KEY
                false                                                        // SSL_ON?
            );
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<object> result = this.pubNub.History(Channel, 40);
            var data = this.FormatMessages(result);

            return this.Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Send(MessageViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid model state");
            }

            model.Ip = this.GetIp();

            var builder = new StringBuilder();

            builder.Append(model.Ip);
            builder.Append(";");
            builder.Append(model.Message);

            this.pubNub.Publish(Channel, builder.ToString());

            return this.Ok();
        }

        private List<MessageViewModel> FormatMessages(List<object> data)
        {
            var result = new List<MessageViewModel>();

            // Skip first two message, cause not in appropriate format
            for (int i = 2; i < data.Count; i++)
            {
                var current = data[i].ToString().Split(';');

                result.Add(new MessageViewModel()
                {
                    Ip = current[0],
                    Message = current[1]
                });
            }

            return result;
        }

        private string GetIp(bool CheckForward = false)
        {
            string ip = null;
            if (CheckForward)
            {
                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                // Using X-Forwarded-For last address
                ip = ip.Split(',')
                       .Last()
                       .Trim();
            }

            return ip;
        }
    }
}