using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaApptest.Service;
using AvaloniaApptest.ViewModels;
using AvaloniaApptest.Views;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace AvaloniaApptest
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);

                var services = new ServiceCollection();
                services.AddSingleton<MainWindowViewModel>()
                .AddSingleton<HomeViewModel>()
                .AddSingleton<LoginViewModel>()
                .AddSingleton<NavigationViewModel>()
                .AddSingleton<SystemManageViewModel>()
                .AddSingleton<ExamManageViewModel>()
                .AddSingleton<BlankViewModel>()
                .AddSingleton<RadorManageViewModel>()
                .AddSingleton<MapsuiViewModel>()
                .AddSingleton<ILoginService, LoginService>()
                .AddSingleton(provider =>
                {
                    // 在这里可以获取其他已注册的服务或执行其他逻辑
                    var address = "http://localhost:3389/";
                    return new HttpRestClient(address);
                });

                
                var provider = services.BuildServiceProvider();

                desktop.MainWindow = new MainWindow
                {
                    DataContext = provider.GetRequiredService<MainWindowViewModel>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}