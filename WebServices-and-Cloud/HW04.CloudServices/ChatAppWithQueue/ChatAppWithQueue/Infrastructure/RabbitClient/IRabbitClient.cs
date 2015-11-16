using System.Collections.Generic;
using ChatAppWithQueue.Models;

namespace ChatAppWithQueue.Infrastructure.RabbitClient
{
    public interface IRabbitClient
    {
        void Send(MessageViewModel model);

        List<MessageViewModel> Receive();
    }
}
