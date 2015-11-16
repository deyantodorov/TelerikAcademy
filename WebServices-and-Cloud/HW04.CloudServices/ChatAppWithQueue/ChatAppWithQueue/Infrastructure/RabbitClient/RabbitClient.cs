using System.Collections.Generic;
using System.Text;
using ChatAppWithQueue.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ChatAppWithQueue.Infrastructure.RabbitClient
{
    public class RabbitClient : IRabbitClient
    {
        private readonly ConnectionFactory connectionFactory = new ConnectionFactory()
        {
            Uri = "amqps://fispaufu:5wBFf2NmvePNUnjZlt19rhvgD4Np1UgP@spotted-monkey.rmq.cloudamqp.com/fispaufu"
        };

        public void Send(MessageViewModel model)
        {
            using (var connection = this.connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "chatapp",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var builder = new StringBuilder();
                    builder.Append(model.Ip);
                    builder.Append(";");
                    builder.Append(model.Message);

                    var data = Encoding.UTF8.GetBytes(builder.ToString());

                    channel.BasicPublish(exchange: "",
                        routingKey: "chatapp",
                        basicProperties: null,
                        body: data);
                }
            }
        }

        public List<MessageViewModel> Receive()
        {
            using (var connection = this.connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "chatapp",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var consumer = new EventingBasicConsumer(channel);

                    var messages = new List<MessageViewModel>();

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;

                        if (body != null)
                        {
                            var message = Encoding.UTF8.GetString(body).Split(';');
                            messages.Add(new MessageViewModel()
                            {
                                Ip = message[0],
                                Message = message[1]
                            });
                        }
                    };

                    channel.BasicConsume(queue: "chatapp",
                                 noAck: false,
                                 consumer: consumer);


                    return messages;
                }
            }
        }
    }
}