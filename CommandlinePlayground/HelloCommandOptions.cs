using System.CommandLine;

namespace CommandlinePlayground;

internal record HelloCommandOptions : IOptions
{
    public static List<Option> Options =>
    [
        new Option<string>("--name") { Required = true },
    ];

    public static List<Argument> Arguments => [];

    public required string Name { get; init; }
}
