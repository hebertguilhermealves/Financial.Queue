namespace Financial.Queue.Models.Request
{
    public class MessageRequest
    {
        public string QueueName { get; set; }
        public object Message { get; set; }
    }

}
