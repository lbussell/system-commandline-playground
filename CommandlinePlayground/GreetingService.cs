namespace CommandlinePlayground;

public interface IGreetingService
{
    public string Greeting(string name);
}

public class GreetingService : IGreetingService
{
    public string Greeting(string name) => $"Hello, {name}!";
}
