using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreshMvvm;
using Xamarin.Forms;

namespace Sudoku.PageModels
{
    public class SudokuPageModel : FreshBasePageModel
    {

        public Command SelectNumberCommand { get; }

        public SudokuPageModel()
        {
            SelectNumberCommand = new Command((object value) => SelectNumber = Convert.ToInt32(value));
            Numbers = Enumerable.Range(1, 9).ToList();
        }

        public List<int> Numbers { get; set; }

        private int _selectNumber;
        public int SelectNumber
        {
            get => _selectNumber;
            set
            {
                _selectNumber = value;
                base.RaisePropertyChanged(nameof(SelectNumber));
            }
        }
    }
}
