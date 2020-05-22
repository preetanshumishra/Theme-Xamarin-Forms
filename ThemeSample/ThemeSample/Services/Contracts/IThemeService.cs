using ThemeSample.Enums;

namespace ThemeSample.Services.Contracts
{
    public interface IThemeService
    {
        void ChangeTheme(Theme theme);

        void LoadTheme();

        Theme CurrentTheme();
    }
}