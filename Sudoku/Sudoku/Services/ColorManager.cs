using Sudoku.Interfaces;
using Xamarin.Forms;

namespace Sudoku.Services
{
    internal static class ColorManager
    {
        public static void SetNavBarColor(string appResourceColorName)
        {
            string hex = GetHexColor(appResourceColorName);
            DependencyService.Get<IDeviceColorManager>().SetNavBarColor(hex);
        }

        public static void SetStatusBarColor(string appResourceColorName)
        {
            string hex = GetHexColor(appResourceColorName);
            DependencyService.Get<IDeviceColorManager>().SetStatusBarColor(hex);
        }

        public static void SetTitleColor(string appResourceColorName)
        {
            string hex = GetHexColor(appResourceColorName);
            DependencyService.Get<IDeviceColorManager>().SetTitleColor(hex);
        }

        public static void SetLightBars()
        {
            DependencyService.Get<IDeviceColorManager>().SetLightBars();
        } 
        public static void SetDarkBars()
        {
            DependencyService.Get<IDeviceColorManager>().SetDarkBars();
        }


        private static string GetHexColor(string appResourceColorName)
        {
            Color color = GetColorFromResource(appResourceColorName);
            return string.Format("#{0:X2}{1:X2}{2:X2}", (int)(color.R * 255), (int)(color.G * 255), (int)(color.B * 255));
        }

        public static Color GetColorFromResource(string appResourceColorName, ResourceDictionary dictionary = null)
        {
            if (dictionary == null) dictionary = Application.Current.Resources;
            dictionary.TryGetValue(appResourceColorName, out var resource);
            return (Color)resource;
        }
    }
}
