using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreshMvvm;
using SudokuLib.Entities;
using Xamarin.Forms;

namespace Sudoku.PageModels
{
    public class SudokuPageModel : FreshBasePageModel
    {

        public Command SelectNumberCommand { get; }
        public Command SetNumberCommand { get; }

        public SudokuPageModel()
        {
            SelectNumberCommand = new Command((object value) => SelectNumber(value));
            SetNumberCommand = new Command((object value) => SetNumber(value));
            Numbers = Enumerable.Range(1, 9).ToList();
            Numbers.Add(0);
            Sudoku = new SudokuLib.Sudoku(3, 1);
        }

        public SudokuLib.Sudoku Sudoku { get; set; }

        public List<int> Numbers { get; set; }



        private int _selectedNumber;
        public int SelectedNumber
        {
            get => _selectedNumber;
            set
            {
                _selectedNumber = value;
                base.RaisePropertyChanged(nameof(SelectedNumber));
            }
        }

        private void SelectNumber(object value)
        {
            if (value.ToString() == "X")
            {
                SelectedNumber = 0;
                return;
            }
            SelectedNumber = Convert.ToInt32(value);
        }

        private void SetNumber(object value)
        {
            Number number = value as Number;

            if (number.IsDefault)
            {
                SelectedNumber = number.Value;
                return;
            }
            number.Value = SelectedNumber;
        }

    }
}
