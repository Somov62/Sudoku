using Sudoku.PageModels;
using Sudoku.Services;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Sudoku.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainPageModel();
            this.BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.Level = _viewModel.Level;
        }

        private async void NewGame_Clicked(object sender, EventArgs e)
        {
            SudokuManager.ClearSave(_viewModel.Level);
            await this.Navigation.PushAsync(new SudokuPage(_viewModel.Level));
        }

        private async void Resume_Clicked(object sender, EventArgs e)
        {
            SudokuManager.LoadResumeSave(_viewModel.Level);
            await this.Navigation.PushAsync(new SudokuPage(_viewModel.Level));
        }
    }
}
