using System.CommandLine;

namespace CommandlinePlayground;

internal interface IOptions
{
    public static abstract List<Option> Options { get; }
    public static abstract List<Argument> Arguments { get; }
}
