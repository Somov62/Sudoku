using FreshMvvm;
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
            var mainPage = FreshPageModelResolver.ResolvePageModel<PageModels.SudokuPageModel>();
            var navigationPage = new FreshNavigationContainer(mainPage);
            MainPage = navigationPage;
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
