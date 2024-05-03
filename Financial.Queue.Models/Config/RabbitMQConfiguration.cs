namespace Financial.Queue.Models.Config
{
    public class RabbitMQConfiguration
    {
        public string HostName { get; set; } = "localhost"; // Use "host.docker.internal" se estiver rodando no Docker para Windows ou Mac
        public string UserName { get; set; } = "admin";
        public string Password { get; set; } = "123456";
        public int Port { get; set; } = 15672;
    }
}
