using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using AvaloniaApptest.ViewModels;
//using BruTile.Wms;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaApptest.Views;

public partial class LoginView : UserControl
{
    private WindowNotificationManager? _manager;

    public LoginView()
    {
        InitializeComponent();
        WeakReferenceMessenger.Default.Register<UserCheckMessage>(this, (r, m) =>
        {
            if (string.IsNullOrEmpty(m.msg) && _manager != null)
            {
                _manager.IsVisible = false;
            }
            else
            {
                _manager?.Show(new Notification("提示", m.msg, NotificationType.Warning));
            }
        });
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        var topLevel = TopLevel.GetTopLevel(this);
        _manager = new WindowNotificationManager(topLevel) { MaxItems = 1, Position = NotificationPosition.TopRight };
    }

    private void TextBox_GotFocus(object? sender, Avalonia.Input.GotFocusEventArgs e)
    {
        Process[] processes = Process.GetProcesses();
        string processName = "matchbox-keyboard";
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            processName = "matchbox-keyboard";
        }
        else if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            processName = "osk";
        }
        if (!processes.Any(p => p.ProcessName == processName))
        {
            //添加判断是否是鼠标点击
            StartKeyBoard(processName);
        }
    }

    void StartKeyBoard(string processName)
    {
        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                StartOSK();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start(processName);
            }
        }
        catch (Exception exception)
        {
            _manager?.Show(new Notification("提示", exception.Message, NotificationType.Error));
        }
    }

    void StartOSK()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "osk", // 指定要启动的程序
            UseShellExecute = true, // 使用 Shell 执行
            Verb = "runas" // 以管理员权限运行（仅在Windows上有效）
        };

        try
        {
            Process.Start(startInfo); // 启动进程
        }
        catch (Exception ex)
        {
            _manager?.Show(new Notification("提示", ex.Message, NotificationType.Error));
        }
    }

}
