using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Sudoku.Services
{
    internal static class ThemeManager
    {
        private const string _propertyName = "ThemeName";

        private static readonly Dictionary<Theme, ThemeEntity> _themes = new Dictionary<Theme, ThemeEntity>()
        {
            { Theme.LightBlueTheme,  new ThemeEntity(Theme.LightBlueTheme, new UI.Themes.LightBlueTheme()) },
            { Theme.DarkBlueTheme, new ThemeEntity(Theme.DarkBlueTheme, new UI.Themes.DarkBlueTheme()) }
        };


        public static List<ThemeEntity> Themes => _themes.Values.ToList();

        public static Theme GetCurrentTheme()
        {
            ResourceDictionary themeProperty = GetCurrentResource();
            if (themeProperty == null)
            {
                SetTheme(Theme.LightBlueTheme);
                return Theme.LightBlueTheme;
            }

            if (!Enum.TryParse(themeProperty.GetType().Name, out Theme theme))
            {
                theme = Theme.LightBlueTheme;
            }
            return theme;
        }


        public static void SetStartUpTheme()
        {
            App.Current.Properties.TryGetValue(_propertyName, out object property);
            if (!Enum.TryParse(property?.ToString(), out Theme theme))
            {
                theme = Theme.LightBlueTheme;
                App.Current.Properties[_propertyName] = theme.ToString();
            }
            SetTheme(theme);
        }


        public static void SetTheme(Theme theme)        
        {
            DeleteOldTheme();
            switch (theme)
            {
                case Theme.LightBlueTheme:
                    Application.Current.Resources.MergedDictionaries.Add(new UI.Themes.LightBlueTheme());
                    break;
                case Theme.DarkBlueTheme:
                    Application.Current.Resources.MergedDictionaries.Add(new UI.Themes.DarkBlueTheme());
                    break;
            }
            _themes[theme].IsSelected = true;
            App.Current.Properties[_propertyName] = theme.ToString();
            ColorManager.SetNavBarColor("NavBarColor");
            ColorManager.SetStatusBarColor("StatusBarColor");
        }

        private static void DeleteOldTheme()
        {
            ResourceDictionary theme = GetCurrentResource();
            if (theme == null) return;
            _themes[GetCurrentTheme()].IsSelected = false;
            Application.Current.Resources.MergedDictionaries.Remove(theme);
        }

        private static ResourceDictionary GetCurrentResource()
        {
            return Application.Current.Resources.MergedDictionaries.FirstOrDefault(p => p.GetType().ToString().Contains("Theme"));
        }

    }

    public enum Theme
    {
        LightBlueTheme,
        DarkBlueTheme
    }


    public class ThemeEntity
    {
        public ThemeEntity(Theme theme, ResourceDictionary dictionary)
        {
            Theme = theme;
            Dictionary = dictionary;
            MainColor = ColorManager.GetColorFromResource("MainBackgroundColor", Dictionary);
            ColorAccent = ColorManager.GetColorFromResource("AccentColor", Dictionary);
        }
        public Theme Theme { get; set; }

        public ResourceDictionary Dictionary { get; set; }

        public Color MainColor{ get; set; }
        public Color ColorAccent { get; set; }

        public bool IsSelected { get; set; }
    }
}
