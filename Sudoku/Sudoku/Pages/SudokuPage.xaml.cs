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

        private void CollectionView_SizeChanged(object sender, EventArgs e)
        {
            var item = sender as CollectionView;
            var a = item.Width;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            numberCV.WidthRequest = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            numberCV.HeightRequest = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
        }
    }
}