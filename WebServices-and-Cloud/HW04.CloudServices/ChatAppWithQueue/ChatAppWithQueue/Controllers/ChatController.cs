using System.Linq;
using System.Web;
using System.Web.Http;
using ChatAppWithQueue.Infrastructure.RabbitClient;
using ChatAppWithQueue.Models;

namespace ChatAppWithQueue.Controllers
{
    public class ChatController : ApiController
    {
        private IRabbitClient rabbitClient;

        public ChatController()
        {
            this.rabbitClient = new RabbitClient();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = this.rabbitClient.Receive();

            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Send(MessageViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid model state");
            }

            model.Ip = this.GetIp();

            this.rabbitClient.Send(model);

            return this.Ok();
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