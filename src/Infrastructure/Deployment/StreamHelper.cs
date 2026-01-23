using System;

namespace Commergent.Dw.DemoApp;

internal class StreamHelper
{
    private static readonly string ResourcePrefix = typeof(StreamHelper).Namespace + ".UI.Views.";

    public static Stream GetViewsStream(string name)
    {
        var resourceName = ResourcePrefix + name.Replace("/", ".");

        var assembly = typeof(StreamHelper).Assembly;

        var stream = assembly.GetManifestResourceStream(resourceName) ?? throw new InvalidOperationException($"Resource '{resourceName}' not found.");

        return stream;
    }
}
