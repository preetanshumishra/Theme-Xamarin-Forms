using ThemeSample.Enums;
using ThemeSample.Services.Contracts;
using ThemeSample.Themes;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ThemeSample.Services.Implementations
{
    public class ThemeService : IThemeService
    {
        public void ChangeTheme(Theme theme)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                Preferences.Set("SelectedTheme", (int)theme);

                switch (theme)
                {
                    case Theme.Light:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                    case Theme.Dark:
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case Theme.Blue:
                        mergedDictionaries.Add(new BlueTheme());
                        break;
                    case Theme.Orange:
                        mergedDictionaries.Add(new OrangeTheme());
                        break;
                    case Theme.White:
                        mergedDictionaries.Add(new WhiteTheme());
                        break;
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }

        /// <summary>
        /// Reads current theme id from the local storage and loads it.
        /// </summary>
        public void LoadTheme()
        {
            Theme currentTheme = CurrentTheme();
            ChangeTheme(currentTheme);
        }

        /// <summary>
        /// Gives current/last selected theme from the local storage.
        /// </summary>
        /// <returns></returns>
        public Theme CurrentTheme()
        {
            return (Theme)Preferences.Get("SelectedTheme", (int)Theme.Light);
        }
    }
}