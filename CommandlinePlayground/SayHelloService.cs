using Microsoft.Extensions.Logging;

namespace CommandlinePlayground;

public interface ISayHelloService
{
    void SayHello(string name);
}

public class SayHelloService(
    IGreetingService greetingService,
    ILogger<SayHelloService> logger) : ISayHelloService
{
    private readonly IGreetingService _greetingService = greetingService;
    private readonly ILogger<SayHelloService> _logger = logger;

    public void SayHello(string name)
    {
        var greeting = _greetingService.Greeting(name);
        _logger.LogInformation("{greeting}", greeting);
    }
}
