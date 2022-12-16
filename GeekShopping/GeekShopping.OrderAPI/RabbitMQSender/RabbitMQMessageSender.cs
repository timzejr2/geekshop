using GeekShopping.MessageBus;
using GeekShopping.OrderAPI.Messages;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace GeekShopping.OrderAPI.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;

        public RabbitMQMessageSender()
        {
            _hostName = "localhost";
            _password = "guest";
            _userName = "guest";
        }

        public void SendMessage(BaseMessage baseMessage, string queueName)
        {
            try
            {
                if (ConnectionExists())
                {
                    using var channel = _connection.CreateModel();
                    channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
                    byte[] body = GetMessageAsByteArray(baseMessage);
                    channel.BasicPublish(
                        exchange: "", routingKey: queueName, basicProperties: null, body: body);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private byte[] GetMessageAsByteArray(BaseMessage baseMessage)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize<PaymentVO>((PaymentVO)baseMessage, options);
            return Encoding.UTF8.GetBytes(json);
        }

        private bool ConnectionExists()
        {
            if (_connection != null) return true;
            CreateConnection();
            return _connection != null;
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password,
                };

                _connection = factory.CreateConnection();
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }
    }
}