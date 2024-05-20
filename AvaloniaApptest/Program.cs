using Avalonia;
using Avalonia.Media;
using System;

namespace AvaloniaApptest
{
    internal sealed class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace()
                .With(new FontManagerOptions
                {
                    // 设置默认字体家族
                    DefaultFamilyName =
                        "avares://AvaloniaApptest/Assets/Fonts/AlibabaPuHuiTi-3-65-Medium.ttf#Alibaba PuHuiTi 3.0",
                    // 设置备用字体家族
                    FontFallbacks = new[]
                    {
                        new FontFallback
                        {
                                 FontFamily =
                                new FontFamily(
                                    "avares://AvaloniaApptest/Assets/Fonts/AlibabaPuHuiTi-3-65-Medium.ttf#Alibaba PuHuiTi 3.0")
                        }
                    }
                });
    }
}
