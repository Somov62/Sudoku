using Sudoku.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sudoku.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SudokuPage : ContentPage
    {
        private readonly SudokuPageModel _viewModel;
        public SudokuPage(int difficulty)
        {
            InitializeComponent();
            _viewModel = new SudokuPageModel(difficulty);
            this.BindingContext = _viewModel;
            _viewModel.WinEvent += Sudoku_Win;
        }

        private void Sudoku_Win(object sender, EventArgs e)
        {
            var animation = new Animation(v => collectionView.HeightRequest = v, collectionView.Height, 0);
            collectionView.FadeTo(0, 400, Easing.CubicInOut);
            animation.Commit(this, "winGameAnimation", length: 700, easing: Easing.CubicIn);
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            ConfigureTemplateSizes();
            CreateTemplate();
        }

        private async void CreateTemplate()
        {
            await Task.Delay(100);
            _viewModel.AddNumbers();
            _viewModel.CreateSudoku();
        }

        private void ConfigureTemplateSizes()
        {
            numberCV.WidthRequest = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            numberCV.HeightRequest = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;

            int chunkSize = 3;
            int span = (chunkSize * chunkSize + 1) / 2 + (chunkSize * chunkSize + 1) % 2;

            collectionView.WidthRequest = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density - 40;
            collectionView.HeightRequest = collectionView.WidthRequest / span * 2 + 6;
        }
    }
}