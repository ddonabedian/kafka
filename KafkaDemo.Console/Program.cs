// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Thread.Sleep(3000);
CreateHostBuilder(args).Build().Run();


static IHostBuilder CreateHostBuilder(string[] args) => 
    Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, collection)=>
    {
        collection.AddHostedService<KafkaProducerHostedService>();
});
