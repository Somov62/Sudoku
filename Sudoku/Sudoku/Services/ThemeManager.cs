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
            { Theme.LightYellowTheme,  new ThemeEntity(Theme.LightYellowTheme, new UI.Themes.LightYellowTheme()) },
            { Theme.LightRuddyTheme,  new ThemeEntity(Theme.LightRuddyTheme, new UI.Themes.LightRuddyTheme()) },
            { Theme.DarkBlueTheme, new ThemeEntity(Theme.DarkBlueTheme, new UI.Themes.DarkBlueTheme()) },
            { Theme.DarkYellowTheme, new ThemeEntity(Theme.DarkYellowTheme, new UI.Themes.DarkYellowTheme()) },
            { Theme.DarkGreenTheme, new ThemeEntity(Theme.DarkGreenTheme, new UI.Themes.DarkGreenTheme()) },
            { Theme.DarkVioletTheme, new ThemeEntity(Theme.DarkVioletTheme, new UI.Themes.DarkVioletTheme()) },
            { Theme.DarkOrangeTheme, new ThemeEntity(Theme.DarkOrangeTheme, new UI.Themes.DarkOrangeTheme()) }
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
                theme = Theme.DarkVioletTheme;
                App.Current.Properties[_propertyName] = theme.ToString();
            }
            SetTheme(theme);
        }


        public static void SetTheme(Theme theme)        
        {
            DeleteOldTheme();
            Application.Current.Resources.MergedDictionaries.Add(_themes[theme].Dictionary);
            _themes[theme].IsSelected = true;
            App.Current.Properties[_propertyName] = theme.ToString();
            ColorManager.SetNavBarColor("NavBarColor");
            ColorManager.SetStatusBarColor("StatusBarColor");

            if ((bool)App.Current.Resources["LightStatusBar"])
            {
                ColorManager.SetLightBars();
            }
            else ColorManager.SetDarkBars();
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
        LightYellowTheme,
        LightRuddyTheme,
        DarkBlueTheme,
        DarkYellowTheme,
        DarkGreenTheme,
        DarkVioletTheme,
        DarkOrangeTheme
    }


    public class ThemeEntity
    {
        public ThemeEntity() { }

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
