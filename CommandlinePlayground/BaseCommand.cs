using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.NamingConventionBinder;

namespace CommandlinePlayground;

internal abstract class BaseCommand<TOptions>() where TOptions : IOptions
{
    public abstract void ExecuteAsync(TOptions options);

    public static void Register<T>(IServiceCollection serviceCollection) where T : BaseCommand<TOptions>
    {
        serviceCollection.AddSingleton<BaseCommand<TOptions>, T>();
    }

    public static Command Create(string name, string description)
    {
        var command = new Command(name, description);

        foreach (var option in TOptions.Options)
        {
            command.Add(option);
        }

        foreach (var argument in TOptions.Arguments)
        {
            command.Add(argument);
        }

        command.Action = Handler;
        return command;
    }

    protected static BindingHandler Handler
    {
        get
        {
            return CommandHandler.Create<TOptions, IHost>((options, host) =>
            {
                var thisCommand = host.Services.GetRequiredService<BaseCommand<TOptions>>();
                thisCommand.ExecuteAsync(options);
            });
        }
    }
}
