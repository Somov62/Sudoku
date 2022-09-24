using Sudoku.PageModels;
using System;
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new SudokuPage(_viewModel.Level));
        }
    }
}
