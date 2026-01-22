# Theme-Xamarin-Forms

A comprehensive guide to implementing dynamic theming in Xamarin.Forms applications using XAML resource dictionaries for cross-platform iOS and Android support.

## Overview

This project demonstrates professional theming techniques for Xamarin.Forms:
- **XAML Resource Dictionaries** - Centralized theme definitions
- **Dynamic Theme Switching** - Change themes at runtime
- **Cross-Platform Support** - Unified themes for iOS and Android
- **Resource Dictionary Merging** - Organized theme composition
- **Native Platform Styling** - Platform-specific refinements

## Tech Stack

- Xamarin.Forms
- Xamarin.iOS (UIKit native)
- Xamarin.Android (Android native)
- XAML markup language
- C# business logic

## Project Structure

```
ThemeSample/              # Shared Xamarin.Forms code
ThemeSample.iOS/          # Native iOS implementation
ThemeSample.Droid/        # Native Android implementation
```

## Quick Start

```bash
# Open solution in Visual Studio or Visual Studio for Mac
open ThemeSample/ThemeSample.sln

# Build for iOS
dotnet build -f net8.0-ios

# Build for Android
dotnet build -f net8.0-android
```

## Key Features

- Multiple theme resource dictionaries
- Runtime theme switching with UI updates
- Shared colors, fonts, and styles across platforms
- Platform-specific style overrides
- XAML-based theme definitions for easy maintenance
- Responsive layout handling

## Learning Resources

This project serves as an educational reference for:
- XAML resource dictionary organization
- Theme inheritance and composition
- Cross-platform styling strategies
- Resource dictionary binding and updates

## License

MIT License - See LICENSE file for details.
