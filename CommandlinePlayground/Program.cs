using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.Hosting;
using CommandlinePlayground;


var rootCommand = new RootCommand()
{
    HelloCommand.Create(
        name: "hello",
        description: "Say hello to someone"),
};

var config = new CommandLineConfiguration(rootCommand);

config.UseHost(
    _ => Host.CreateDefaultBuilder(),
    host =>
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<ISayHelloService, SayHelloService>();
            services.AddSingleton<IGreetingService, GreetingService>();

            HelloCommand.Register<HelloCommand>(services);
        });
    });

return await config.InvokeAsync(["hello", "--name", "World"]);
