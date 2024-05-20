using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaApptest.ViewModels
{
    public record UserLoggedInMessage(string UserName, bool IsExaminer);
    public record UserLoggedOutMessage(bool IsHome);

    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        public ViewModelBase _activeContent;

        private HomeViewModel _homeViewModel;
        private LoginViewModel _loginViewModel;

        public MainWindowViewModel() { }

        public MainWindowViewModel(HomeViewModel homeViewModel, LoginViewModel loginViewModel)
        {
            _homeViewModel = homeViewModel;
            _loginViewModel = loginViewModel;

            _activeContent = _loginViewModel;
            Messenger.Register<UserLoggedInMessage>(this, (r, m) => ActiveContent = _homeViewModel);
            Messenger.Register<UserLoggedOutMessage>(this, (r, m) =>
            {
                ActiveContent = m.IsHome ? _loginViewModel : _homeViewModel;
            });
        }
    }
}
