using Microsoft.Extensions.Logging;

namespace CommandlinePlayground;

internal class HelloCommand : BaseCommand<HelloCommandOptions>
{
    private readonly ISayHelloService _sayHelloService;
    private readonly ILogger<HelloCommand> _logger;

    public HelloCommand(
        ISayHelloService sayHelloService,
        ILogger<HelloCommand> logger)
    {
        _sayHelloService = sayHelloService;
        _logger = logger;
    }

    public override void ExecuteAsync(HelloCommandOptions options)
    {
        _logger.LogInformation("Executing HelloCommand with name: {name}", options.Name);
        _sayHelloService.SayHello(options.Name);
    }
}
