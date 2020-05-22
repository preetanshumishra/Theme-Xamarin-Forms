using Prism.Mvvm;
using ThemeSample.Enums;

namespace ThemeSample.Models
{
    public class ThemeModel : BindableBase
    {
        public Theme Theme { get; set; }

        public string ThemeTitle { get; set; }

        public string Description { get; set; }

        private bool _isSelected = false;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                RaisePropertyChanged(nameof(IsSelected));
            }
        }
    }
}