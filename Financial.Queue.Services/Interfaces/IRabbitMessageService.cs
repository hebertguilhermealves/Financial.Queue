namespace Financial.Queue.Services.Interfaces
{
    public interface IRabbitMessageService
    {
        Task SendMessageAsync<T>(T message, string queueName);
    }
}
