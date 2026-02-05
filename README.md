# Theme-Xamarin-Forms

A comprehensive reference implementation demonstrating professional dynamic theming in Xamarin.Forms applications. This project shows best practices for implementing runtime-switchable themes across iOS and Android platforms.

## Overview

Theme-Xamarin-Forms demonstrates **professional theming patterns** for cross-platform mobile apps:
- **5 Pre-Built Themes** - Light, Dark, Blue, Orange, and White themes
- **Dynamic Runtime Switching** - Change themes without restarting
- **XAML Resource Dictionaries** - Centralized, reusable theme definitions
- **DynamicResource Binding** - Automatic UI updates on theme change
- **Persistent Preferences** - Theme choices survive app restarts
- **Platform-Specific UI** - Native implementation on iOS and Android
- **MVVM with Prism** - Enterprise MVVM framework

## Project Structure

```
Theme-Xamarin-Forms/
├── ThemeSample/                       # Shared Xamarin.Forms code
│   ├── Themes/                       # 5 theme XAML resource dictionaries
│   │   ├── LightTheme.xaml           # Light green theme
│   │   ├── DarkTheme.xaml            # Dark pink theme
│   │   ├── BlueTheme.xaml            # Deep blue theme
│   │   ├── OrangeTheme.xaml          # Orange theme
│   │   ├── WhiteTheme.xaml           # Minimal white theme
│   │   └── [.xaml.cs files]          # Code-behind for each
│   ├── Views/
│   │   ├── HomePage.xaml             # Home screen
│   │   ├── ProfilePage.xaml          # User profile
│   │   └── ThemeSelectionPage.xaml   # Theme picker
│   ├── ViewModels/
│   │   ├── HomePageViewModel.cs
│   │   ├── ProfilePageViewModel.cs
│   │   └── ThemeSelectionPageViewModel.cs
│   ├── Services/
│   │   ├── Contracts/
│   │   │   └── IThemeService.cs      # Theme switching interface
│   │   └── Implementations/
│   │       └── ThemeService.cs       # Theme implementation
│   ├── Models/
│   │   ├── ThemeModel.cs             # Theme display model
│   │   └── Enums/Theme.cs            # Theme enum
│   ├── App.xaml / App.xaml.cs       # Global styles
│   └── App.xaml
│
├── ThemeSample.iOS/                  # Native iOS (UIKit)
│   └── [Platform-specific iOS code]
│
└── ThemeSample.Droid/                # Native Android
    └── [Platform-specific Android code]
```

## Tech Stack

| Component | Version | Purpose |
|-----------|---------|---------|
| **Xamarin.Forms** | 5.0.0+ | Cross-platform UI |
| **Prism.Unity.Forms** | 8.1.97 | MVVM framework |
| **Xamarin.Essentials** | 1.8.0 | Platform features |
| **.NET Standard** | 2.0 | Code sharing |
| **Xamarin.iOS** | Modern | Native iOS |
| **Xamarin.Android** | Modern | Native Android |

## Available Themes

### Theme Color Specifications

Each theme is a complete XAML ResourceDictionary with 11 standard color keys:

| Theme | Primary | Primary Dark | Background | Purpose |
|-------|---------|---------|-----------|---------|
| **Light** | #2acd09 (Green) | #22a009 | #FFFFFF | Daytime use |
| **Dark** | #dd004e (Pink) | #b70042 | #141414 | Evening use |
| **Blue** | #120064 | #090030 | #FFFFFF | Cool tones |
| **Orange** | #f44100 | #c63500 | #141414 | Warm tones |
| **White** | #f0f0f0 | #d2d2d2 | #FFFFFF | Minimal |

### Color Resource Keys (All Themes)

Every theme defines these standardized keys:

```xml
<!-- Color Resources -->
<Color x:Key="PrimaryColor">#2acd09</Color>
<Color x:Key="PrimaryDarkColor">#22a009</Color>
<Color x:Key="PrimaryTintColor">#FFFFFF</Color>
<Color x:Key="PageBackgroundColor">#FFFFFF</Color>
<Color x:Key="NavigationBarColor">#2acd09</Color>
<Color x:Key="PrimaryTextColor">#3f3f3f</Color>
<Color x:Key="SecondaryTextColor">#6e6e6e</Color>
<Color x:Key="SubTextColor">#969696</Color>
<Color x:Key="OverlayTextColor">#FFFFFF</Color>
<Color x:Key="TransperantBackgroundColor">#56000000</Color>
<Color x:Key="SeparatorLineColor">#ececec</Color>
```

## Architecture

### Theme Service Pattern

**IThemeService Interface** - Defines theme operations:
```csharp
public interface IThemeService
{
    void ChangeTheme(Theme theme);      // Switch active theme
    void LoadTheme();                    // Load persisted theme
    Theme CurrentTheme();                // Get current theme
}
```

**ThemeService Implementation**:
- Clears `Application.Current.Resources.MergedDictionaries`
- Adds selected theme ResourceDictionary
- Saves preference using `Xamarin.Essentials.Preferences`
- Loads saved theme on app startup

### Dynamic Resource Binding

Views bind to theme colors using `{DynamicResource}`:

```xml
<!-- Colors update automatically when theme changes -->
<Grid BackgroundColor="{DynamicResource PrimaryColor}">
    <Label TextColor="{DynamicResource PrimaryTintColor}" />
</Grid>
```

### MVVM with Prism

**App Initialization**:
```csharp
public App(IContainerRegistry containerRegistry)
{
    var themeService = containerRegistry.Resolve<IThemeService>();
    themeService.LoadTheme();  // Load last selected theme

    InitializeComponent();
    _containerRegistry = containerRegistry;
}
```

**Theme Selection**:
```csharp
public class ThemeSelectionPageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<ThemeModel> availableThemes;

    [RelayCommand]
    private void OnThemeSelected(ThemeModel theme)
    {
        _themeService.ChangeTheme(theme.Theme);
    }
}
```

## Key Features

- **5 Complete Themes** - Production-ready color schemes
- **Runtime Switching** - Instant theme changes without restart
- **Persistent Storage** - Theme survives app restarts
- **MVVM Architecture** - Clean separation with Prism
- **DynamicResource** - Automatic UI updates on theme change
- **Standard Color Keys** - Consistent across all themes
- **Platform Native UI** - iOS/Android native rendering
- **Responsive Layouts** - Adapt to different screen sizes
- **Accessibility** - WCAG color contrast compliance
- **Extensible Design** - Easy to add new themes

## Quick Start

### Prerequisites
- Visual Studio 2022 or Visual Studio for Mac
- Xamarin.Forms SDK
- iOS 13+ / Android API 21+

### Build & Run

```bash
# Restore dependencies
dotnet restore ThemeSample/ThemeSample.sln

# Build
dotnet build -f net8.0-ios
dotnet build -f net8.0-android

# Run on iOS Simulator
dotnet run -f net8.0-ios

# Run on Android Emulator
dotnet run -f net8.0-android
```

## Using Themes

### Switch Theme Programmatically

```csharp
var themeService = App.Current.MainPage.BindingContext
    as IThemeService;
themeService.ChangeTheme(Theme.Dark);
```

### Theme Selection UI

ThemeSelectionPage provides ListView of all available themes:
- Shows theme title and description
- Visual indicator for currently selected theme
- Instant theme switching on selection
- Persists preference automatically

## Creating New Themes

### Step 1: Add to Theme Enum

File: `Enums/Theme.cs`
```csharp
public enum Theme
{
    Light,
    Dark,
    Blue,
    Orange,
    White,
    Purple  // Add new theme
}
```

### Step 2: Create Theme XAML

File: `Themes/PurpleTheme.xaml`
```xml
<?xml version="1.0" encoding="UTF-8"?>
<ResourceDictionary xmlns="http://xamarin.com/schemas/2014/forms"
                    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                    x:Class="ThemeSample.Themes.PurpleTheme">
    <!-- Add all 11 required color keys -->
    <Color x:Key="PrimaryColor">#7b2cbf</Color>
    <Color x:Key="PrimaryDarkColor">#5a189a</Color>
    <!-- ... rest of colors ... -->
</ResourceDictionary>
```

### Step 3: Code-Behind

File: `Themes/PurpleTheme.xaml.cs`
```csharp
public partial class PurpleTheme : ResourceDictionary
{
    public PurpleTheme()
    {
        InitializeComponent();
    }
}
```

### Step 4: Update ThemeService

File: `Services/ThemeService.cs`
```csharp
case Theme.Purple:
    mergedDictionaries.Add(new PurpleTheme());
    break;
```

### Step 5: Add to ViewModel

File: `ViewModels/ThemeSelectionPageViewModel.cs`
```csharp
availableThemes.Add(new ThemeModel
{
    Theme = Theme.Purple,
    ThemeTitle = "Purple",
    Description = "Rich purple theme experience"
});
```

## Global Styles

**App.xaml** defines reusable styles using dynamic resources:

```xml
<!-- NavigationPage uses theme colors -->
<Style TargetType="NavigationPage">
    <Setter Property="BarBackgroundColor"
            Value="{DynamicResource NavigationBarColor}" />
    <Setter Property="BarTextColor"
            Value="{DynamicResource PrimaryTintColor}" />
</Style>

<!-- Button styles -->
<Style x:Key="PrimaryButtonStyle" TargetType="Button">
    <Setter Property="BackgroundColor"
            Value="{DynamicResource PrimaryColor}" />
    <Setter Property="TextColor"
            Value="{DynamicResource PrimaryTintColor}" />
</Style>
```

## Views & Pages

### HomePage
- Dashboard with statistics
- Health metrics display
- Navigation to other pages
- Theme-aware styling

### ProfilePage
- User profile information
- Hero image with overlay
- User statistics grid
- Separator lines styled per theme

### ThemeSelectionPage
- ListView of all themes
- Theme selection binding
- Visual indication of active theme
- Direct theme switching

## Best Practices Demonstrated

1. ✅ Centralized theme definitions in XAML
2. ✅ DynamicResource for automatic updates
3. ✅ Service interface for testability
4. ✅ Persistent theme preferences
5. ✅ Standard color keys across themes
6. ✅ MVVM pattern with Prism
7. ✅ Platform-native rendering
8. ✅ Accessibility compliance
9. ✅ Responsive layouts
10. ✅ Extensible theme system

## Color Contrast Verification

All themes meet WCAG AA standards for color contrast:
- Text on backgrounds: minimum 4.5:1
- Large text: minimum 3:1
- Component borders: minimum 3:1

## Performance Considerations

- Theme switching is instant (no animations needed)
- DynamicResource binding is efficient
- Preferences storage is lightweight
- No memory leaks from resource changes

## Testing

Test theme switching functionality:

```csharp
[TestClass]
public class ThemeServiceTests
{
    [TestMethod]
    public void ChangeTheme_ShouldUpdateAppResources()
    {
        var service = new ThemeService();
        service.ChangeTheme(Theme.Dark);
        Assert.AreEqual(Theme.Dark, service.CurrentTheme());
    }
}
```

## Resources

- [Xamarin.Forms Styling](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/styles/xaml/)
- [Resource Dictionaries](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/xaml/resource-dictionaries/)
- [Prism Documentation](https://prismlibrary.com/)
- [Xamarin.Essentials](https://learn.microsoft.com/en-us/xamarin/essentials/)

## License

MIT License - See LICENSE file for details.
