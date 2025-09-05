using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaTemplate.Android;

[Activity(
    Label = "AvaloniaTemplate.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<AndroidApp>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
            .WithInterFont();
    }
}

public class AndroidApp : App
{
    private readonly string[] _manifestResourceNames = Assembly
        .GetExecutingAssembly()
        .GetManifestResourceNames();

    protected override string ReadResourceFile(string resourceName)
    {
        using var stream = ReadResourceStream(resourceName);
        using var streamReader = new StreamReader(stream);
        return streamReader.ReadToEnd();
    }

    private Stream ReadResourceStream(string resourceName)
    {
        var appsettingsResName = _manifestResourceNames.FirstOrDefault(r => r.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase));
        if (appsettingsResName is null)
        {
            throw new FileNotFoundException($" The configuration file '{resourceName}' was not found and is not optional.");
        }
        var resourceStream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream(appsettingsResName);
        ArgumentNullException.ThrowIfNull(resourceStream);
        return resourceStream;
    }

    protected override void RegisterPlatformServices(IServiceCollection services)
    {
    }

    protected override void PlatformConfiguration(ConfigurationBuilder builder)
    {
        builder.AddJsonStream(ReadResourceStream("appsettings.json"));
    }
}
