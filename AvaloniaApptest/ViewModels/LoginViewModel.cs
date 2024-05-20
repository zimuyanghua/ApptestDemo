using Apptest.Shared.Dtos;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Shapes;
using AvaloniaApptest.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApptest.ViewModels
{
    public record UserCheckMessage(string msg);

    public partial class LoginViewModel : ViewModelBase
    {
        [ObservableProperty] private string _userName = "";
        [ObservableProperty] private string _password = "";
        [ObservableProperty] private bool _isLogin;

        private readonly ILoginService loginService;
        public LoginViewModel(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [RelayCommand]
        public async void login()
        {
            IsLogin = true;

            Process[] processes = Process.GetProcesses();
            string processName = "matchbox-keyboard";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                processName = "matchbox-keyboard";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                processName = "osk";
            }
            if (processes.Any(p => p.ProcessName == processName))
            {
                // Process is already running
                // You can add your logic here
                //将该进程置于顶层
                //Process.GetProcessesByName(processName)[0].CloseMainWindow();
                //Process.GetProcessesByName(processName)[0].Close();
                //Process.GetProcessesByName(processName)[0].Dispose();
                Process.GetProcessesByName(processName)[0].Kill();

            }

            //判断用户名和密码是否为空
            if (string.IsNullOrEmpty(_userName)
                || string.IsNullOrEmpty(_password))
            {
                Messenger.Send(new UserCheckMessage("账号或密码不能为空!"));
                IsLogin = false;
                return;
            }

            var loginResult = await loginService.Login(new UserDto()
            {
                Account = _userName,
                UserName = _userName,
                PassWord = _password
            });

            if (!loginResult.Status)
            {
                Messenger.Send(new UserCheckMessage("账号或密码错误！"));
                IsLogin = false;
                return;
            }

            //使用_manager发送通知
            Messenger.Send(new UserCheckMessage(""));
            //需增加判断是否考官，暂时用admin判断
            Messenger.Send(new UserLoggedInMessage(UserName, UserName.Equals("admin")));
            IsLogin = false;
        }


        [RelayCommand]
        private void Exit()
        {
            //关闭应用
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopApp)
            {
                desktopApp.Shutdown();
            }
        }
    }
}
