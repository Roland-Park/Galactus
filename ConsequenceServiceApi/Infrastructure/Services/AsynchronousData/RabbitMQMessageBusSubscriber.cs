using ConsequenceServiceApi.Infrastructure.Configs;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ConsequenceServiceApi.Infrastructure.Services.AsynchronousData;

public class RabbitMQMessageBusSubscriber : BackgroundService
{
    ///NOTE: For some reason the RabbitMQConfig configs being read from appsettings are always null,
    ///NOTE: so I just hard coded them here. Not sure why... probably something stupid
    private readonly RabbitMQConfig config;
    private IConnection connection;
    private IModel channel;
    private string queueName;

    public RabbitMQMessageBusSubscriber(IOptions<RabbitMQConfig> opt)
    {
        config = opt.Value;

        InitializeRabbitMQ();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (ModuleHandle, ea) =>
        {
            Console.WriteLine("EVENT RECEIVED: ");
            var body = ea.Body;
            var notificationMessage = Encoding.UTF8.GetString(body.ToArray());

            Console.WriteLine(notificationMessage);
        };

        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        return Task.CompletedTask;
    }

    private void InitializeRabbitMQ()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "rabbitmq-clusterip-srv",
            Port = 5672
        };

        connection = factory.CreateConnection();
        channel = connection.CreateModel();

        channel.ExchangeDeclare(exchange: "ReactionMood", type: ExchangeType.Fanout);
        queueName = channel.QueueDeclare().QueueName;
        channel.QueueBind(queue: queueName, exchange: "ReactionMood", routingKey: "");

        Console.WriteLine("Message bus listener set up.");

        connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
    }

    private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
    {
        Console.WriteLine("Message bus listener connection EXTERMINATED.");
    }

    public override void Dispose()
    {
        if (channel.IsOpen)
        {
            channel.Close();
            connection.Close();
        }

        base.Dispose();
    }
}
