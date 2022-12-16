using GeekShopping.MessageBus;
using GeekShopping.PaymentAPI.Messages;

namespace GeekShopping.PaymentAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage);
    }
}
