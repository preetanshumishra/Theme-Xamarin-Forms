using Prism;
using Prism.Ioc;
using Prism.Unity;
using ThemeSample.Services.Contracts;
using ThemeSample.Services.Implementations;
using ThemeSample.ViewModels;
using ThemeSample.Views;

namespace ThemeSample
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            var themeService = Container.Resolve<IThemeService>();
            themeService.LoadTheme();

            // Navigate to First Screen.
            NavigationService.NavigateAsync("/CustomNavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register ViewModels for Navigation
            containerRegistry.RegisterForNavigation<CustomNavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<ThemeSelectionPage, ThemeSelectionPageViewModel>();

            // Register Services for Injection
            containerRegistry.Register<IThemeService, ThemeService>();
        }
    }
}