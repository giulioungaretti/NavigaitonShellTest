using System;

namespace NavigationShellTest.Pages;

/// <summary>
/// Page is a record is used to define each page in the app
/// </summary>
public record Pages
{
    public record BlankPage1() : Pages();
    public record BlankPage2() : Pages();

    public (string tag, string name) Details() => this switch
    {
        BlankPage1 _ => (nameof(BlankPage1), nameof(BlankPage1)),
        BlankPage2 _ => (nameof(BlankPage2), nameof(BlankPage2)),
        _ => ("NotFound", "Page not found")
    };
    public static Type GetView(string tag) => tag switch
    {
        nameof(BlankPage1) => typeof(Views.BlankPage1),
        nameof(BlankPage2) => typeof(Views.BlankPage2),
        // TODO: make this go to a not found page
        _ => throw new ArgumentException($"Unknown page {tag}", nameof(tag)),
    };
    public static Type GetView(Pages tag) => tag switch
    {
        BlankPage1 => typeof(Views.BlankPage1),
        BlankPage2 => typeof(Views.BlankPage2),
        // TODO: make this go to a not found page
        _ => throw new ArgumentException($"Unknown page {tag}", nameof(tag)),
    };

    private Pages() { } // private constructor can prevent derived cases from being defined elsewhere
}