using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace ThemeSample.ViewModels
{
    public class HomePageViewModel : BindableBase
    {
        private string _title = "Dashboard";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                RaisePropertyChanged(nameof(Title));
            }
        }

        public DelegateCommand ThemeSelectionPageCommand { get; set; }
        public DelegateCommand GoToProfilePageCommand { get; set; }

        private readonly INavigationService _navigationService;

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ThemeSelectionPageCommand = new DelegateCommand(ThemeSelectionPageCommandExecute);
            GoToProfilePageCommand = new DelegateCommand(GoToProfilePageCommandExecute);
        }

        private async void ThemeSelectionPageCommandExecute()
        {
            await _navigationService.NavigateAsync("ThemeSelectionPage");
        }

        private async void GoToProfilePageCommandExecute()
        {
            await _navigationService.NavigateAsync("ProfilePage");
        }
    }
}