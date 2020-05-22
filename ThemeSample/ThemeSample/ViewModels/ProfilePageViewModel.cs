using Prism.Mvvm;

namespace ThemeSample.ViewModels
{
    public class ProfilePageViewModel : BindableBase
    {
        private string _title = "My Profile";
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

        public ProfilePageViewModel()
        {

        }
    }
}