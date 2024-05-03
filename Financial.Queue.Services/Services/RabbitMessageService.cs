using Financial.Queue.Repositories.Interfaces;
using Financial.Queue.Services.Interfaces;

namespace Financial.Queue.Services.Services
{
    public class RabbitMessageService : IRabbitMessageService
    {
        private readonly IRabbitMessageRepository _rabbitMessageRepository;
        public RabbitMessageService(IRabbitMessageRepository rabbitMessageRepository)
        {
            _rabbitMessageRepository = rabbitMessageRepository;
        }

        public Task SendMessageAsync<T>(T message, string queueName)
        {
            return _rabbitMessageRepository.SendMessageAsync(message, queueName);
        }
    }
}
