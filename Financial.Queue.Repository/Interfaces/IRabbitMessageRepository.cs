namespace Financial.Queue.Repositories.Interfaces
{
    public interface IRabbitMessageRepository
    {
        Task SendMessageAsync<T>(T message, string queueName);
    }
}
