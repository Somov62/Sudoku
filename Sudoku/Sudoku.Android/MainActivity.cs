using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;

namespace Sudoku.Droid
{
    [Activity(Label = "Sudoku", Icon = "@mipmap/ic_launcher", RoundIcon = "@mipmap/ic_launcher_round", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize, ScreenOrientation = ScreenOrientation.Portrait )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Context { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            // var uiOptions = SystemUiFlags.LightNavigationBar | SystemUiFlags.LightStatusBar;
            var uiOptions = SystemUiFlags.Visible;
          //SystemUiFlags.HideNavigation |
          //SystemUiFlags.LayoutHideNavigation |
          //SystemUiFlags.LayoutFullscreen |
          //SystemUiFlags.Fullscreen |
          //SystemUiFlags.LayoutStable |
          //SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            Context = this;
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}