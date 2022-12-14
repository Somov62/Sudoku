using Android.Views;
using Sudoku.Droid;
using Sudoku.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Bookmarks.Droid.DeviceColorManager))]

namespace Bookmarks.Droid
{
    public class DeviceColorManager : IDeviceColorManager
    {
        public void SetNavBarColor(string hex)
        {
            MainActivity.Context.Window.SetNavigationBarColor(Android.Graphics.Color.ParseColor(hex));
        }
        public void SetStatusBarColor(string hex)
        {
            MainActivity.Context.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor(hex));
        }

        public void SetTitleColor(string hex)
        {
            MainActivity.Context.Window.SetTitleColor(Android.Graphics.Color.ParseColor(hex));
        }

        public void SetLightBars()
        {
            MainActivity.Context.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.Visible | SystemUiFlags.LightNavigationBar | SystemUiFlags.LightStatusBar);
        }

        public void SetDarkBars()
        {
            MainActivity.Context.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.Visible);
        }
    }
}