using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApptest.ViewModels
{
    public record NavigationBackMessage();
    public partial class HomeViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _userName;
        [ObservableProperty]
        private string _title;
        [ObservableProperty]
        private bool _isHome;
        [ObservableProperty]
        private string _backTag;
        //是否考官
        [ObservableProperty]
        private bool _isExaminer;
        [ObservableProperty]
        public ViewModelBase _activeContent;

        private NavigationViewModel _navigationViewModel;
        private SystemManageViewModel _systemManageViewModel;
        private ExamManageViewModel _examManageViewModel;
        private RadorManageViewModel _radarManageViewModel;
        private BlankViewModel _blankViewModel;

        public HomeViewModel(NavigationViewModel navigationViewModel,
            SystemManageViewModel systemManageViewModel,
            ExamManageViewModel examManageViewModel,
            BlankViewModel blankViewModel,
            RadorManageViewModel radarManageViewModel)
        {
            Messenger.Register<UserLoggedInMessage>(this, (r, m) =>
            {
                UserName = m.UserName;
                IsExaminer = m.IsExaminer;
            });
            _navigationViewModel = navigationViewModel;
            _systemManageViewModel = systemManageViewModel;
            _examManageViewModel = examManageViewModel;
            _radarManageViewModel = radarManageViewModel;
            _blankViewModel = blankViewModel;


            ActiveContent = _navigationViewModel;
            Title = "";
            IsHome = true;
            BackTag = "退出";
            Messenger.Register<ManageMessage>(this, (r, m) =>
            {
                ActiveContent = m.ModuleName switch
                {
                    "系统管理" => _systemManageViewModel,
                    "标绘考核" => _examManageViewModel,
                    "雷达标绘" => _radarManageViewModel,
                    "xx管理" => _blankViewModel,
                    _ => ActiveContent
                };
                Title = m.ModuleName;
                IsHome = false;
                BackTag = "返回";
            });
            Messenger.Register<NavigationBackMessage>(this, (r, m) =>
            {
                ActiveContent = _navigationViewModel;
                Title = "";
                IsHome = true;
                BackTag = "退出";
            });
            _blankViewModel = blankViewModel;
        }

        [RelayCommand]
        public void loginOut()
        {
            Messenger.Send(new UserLoggedOutMessage(IsHome));
            Messenger.Send(new NavigationBackMessage());
        }
    }
}
