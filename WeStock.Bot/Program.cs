using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using WeStock.Bot;
using WeStock.Domain;
using WeStock.Infra;

var factory = new ConnectionFactory { HostName = MessageBrokerConstants.HOST };
using var connection = factory.CreateConnection();

var serviceCollection = new ServiceCollection();
BotInjections.Register(serviceCollection);

var serviceProvider = serviceCollection.BuildServiceProvider();

var queueEventHandler = serviceProvider.GetRequiredService<BotQueueEventHandlers>();

queueEventHandler.Register(connection);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();