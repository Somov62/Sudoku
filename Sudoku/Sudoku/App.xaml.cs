using Sudoku.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sudoku
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ThemeManager.SetStartUpTheme();
            MainPage = new NavigationPage(new Pages.MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
