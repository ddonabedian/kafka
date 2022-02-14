// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class KafkaProducerHostedService : IHostedService
{
    private readonly ILogger<KafkaProducerHostedService> _logger;
    private IProducer<Null, string> _producer;

    public KafkaProducerHostedService(ILogger<KafkaProducerHostedService> logger)
    {
        _logger = logger;
        var config = new ProducerConfig()
        {
            BootstrapServers = "localhost:9092"
        }; 
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 300; i++)
        {
            var value = $"Hello World{i}";
            _logger.LogInformation(value);
            await _producer.ProduceAsync(topic: "demo", new Message<Null, string> 
            { 
                Value = value 
            }, cancellationToken);
        }

        _producer.Flush(timeout: TimeSpan.FromSeconds(10));
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _producer.Dispose();
        return Task.CompletedTask;
    }
}