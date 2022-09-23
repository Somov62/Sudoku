using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;

namespace Sudoku.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SudokuPage : ContentPage
    {
        public SudokuPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            numberCV.WidthRequest = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            numberCV.HeightRequest = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;

            int chunkSize = 3;
            int span = (chunkSize * chunkSize + 1) / 2 + (chunkSize * chunkSize + 1) % 2;

            cwLayout.Span = span;
            collectionView.WidthRequest = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density - 40;
            collectionView.HeightRequest = collectionView.WidthRequest / span * 2 + (span * 5 - span);

        }

    }
}