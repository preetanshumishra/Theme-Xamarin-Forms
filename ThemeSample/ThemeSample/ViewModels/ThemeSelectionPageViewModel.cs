using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using ThemeSample.Enums;
using ThemeSample.Models;
using ThemeSample.Services.Contracts;

namespace ThemeSample.ViewModels
{
    public class ThemeSelectionPageViewModel : BindableBase
    {
        private string _title = "Select Theme";
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

        private List<ThemeModel> _themes = new List<ThemeModel>()
                                       {
                                           new ThemeModel() { Theme = Theme.Light, ThemeTitle = "Light Theme", Description = "Gives a light theme experience" },
                                           new ThemeModel() { Theme = Theme.Dark, ThemeTitle = "Dark Theme", Description = "Gives a dark theme experience" },
                                           new ThemeModel() { Theme = Theme.Blue, ThemeTitle = "Blue Theme", Description = "Gives a blue theme experience" },
                                           new ThemeModel() { Theme = Theme.Orange, ThemeTitle = "Orange Theme", Description = "Gives an orange theme experience" },
                                           new ThemeModel() { Theme = Theme.White, ThemeTitle = "White Theme", Description = "Gives a white theme experience" }
                                       };
        public List<ThemeModel> Themes
        {
            get
            {
                return _themes;
            }
            set
            {
                RaisePropertyChanged(nameof(Themes));
            }
        }

        private ThemeModel _selectedTheme;
        public ThemeModel SelectedTheme
        {
            get
            {
                return _selectedTheme;
            }
            set
            {
                RaisePropertyChanged(nameof(SelectedTheme));
                if (value != null) { OnThemeSelected(value); }
            }
        }

        private readonly IThemeService _themeService;

        public ThemeSelectionPageViewModel(IThemeService themeService)
        {
            _themeService = themeService;

            var selectedTheme = Themes.FirstOrDefault(x => x.Theme == _themeService.CurrentTheme());
            selectedTheme.IsSelected = true;
        }

        private void OnThemeSelected(ThemeModel selectedTheme)
        {
            foreach (var t in Themes)
            {
                t.IsSelected = t.Theme == selectedTheme.Theme;
            }
            _themeService.ChangeTheme(selectedTheme.Theme);
        }
    }
}