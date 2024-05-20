using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApptest.ViewModels
{
    public record ManageMessage(string ModuleName);
    public partial class NavigationViewModel : ViewModelBase
    {
        [RelayCommand]
        public void SystemManage()
        {
            Messenger.Send(new ManageMessage("系统管理"));
        }

        [RelayCommand]
        public void ExamManage()
        {
            Messenger.Send(new ManageMessage("标绘考核"));
        }

        [RelayCommand]
        public void RadorManage()
        {
            Messenger.Send(new ManageMessage("雷达标绘"));
        }

        [RelayCommand]
        public void BlankManage()
        {
            Messenger.Send(new ManageMessage("xx管理"));
        }

        public NavigationViewModel()
        {

        }
    }
}
