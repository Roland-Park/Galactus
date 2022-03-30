using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using ReactionsServiceApi.Infrastructure.Configs;
using ReactionsServiceApi.Infrastructure.Services.AsynchronousData.Interfaces;
using ReactionsServiceApi.Models.Moods;
using System.Text;
using System.Text.Json;

namespace ReactionsServiceApi.Infrastructure.Services.AsynchronousData;

public class RabbitMqMessageBus : IMessageBus
{
    private IConnection connection;
    private IModel channel;
    private readonly RabbitMQConfig config;

    public RabbitMqMessageBus(IOptions<RabbitMQConfig> configFileSettings)
    {
        config = configFileSettings.Value;

        var factory = new ConnectionFactory()
        {
            HostName = config.Host,
            Port = int.Parse(config.Port)
        };

        try
        {
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: config.ReactionbotMoodExchangeName, type: ExchangeType.Fanout);

            connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

            Console.WriteLine($"Connected to RabbitMQ successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to RabbitMQ: {ex}");
        }
    }

    public void PublishMood(PublishReactionbotMoodModel model)
    {
        var message = JsonSerializer.Serialize(model);

        if (connection != null && connection.IsOpen)
        {
            try
            {
                Send(message);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error publishing reactionbot's mood to queue: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"RabbitMQ connection closed. Mood: {model.Name}");
        }
    }

    public void Dispose()
    {
        Console.WriteLine($"MessageBus disposed");
        if (channel.IsOpen)
        {
            channel.Close();
            connection.Close();
        }
    }

    private void Send(string message)
    {
        Console.WriteLine($"Sending message: {message}");

        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(
            exchange: config.ReactionbotMoodExchangeName,
            routingKey: "",
            basicProperties: null,
            body: body);

        Console.WriteLine($"Message sent.");

    }

    private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
    {
        Console.WriteLine($"RabbitMQ connection TERMINATED");
    }
}
