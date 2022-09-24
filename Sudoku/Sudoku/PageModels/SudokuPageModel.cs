using SudokuLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Sudoku.PageModels
{
    public class SudokuPageModel : Base.BaseViewModel
    {

        public Command SelectNumberCommand { get; }
        public Command SetNumberCommand { get; }

        public SudokuPageModel(int difficulty)
        {
            
            SelectNumberCommand = new Command((object value) => SelectNumber(value));
            SetNumberCommand = new Command((object value) => SetNumber(value));
            Numbers = Enumerable.Range(1, 9).ToList();
            Numbers.Add(0);
            Sudoku = new SudokuLib.Sudoku(3, difficulty);
        }

        public SudokuLib.Sudoku Sudoku { get; set; }

        public List<int> Numbers { get; set; }

        private int _selectedNumber;
        public int SelectedNumber
        {
            get => _selectedNumber;
            set => Set(ref _selectedNumber, value, nameof(SelectedNumber));
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

            if (!number.IsDefault)
            {
                number.Value = SelectedNumber;
                if (Sudoku.FreeSeatsCount() == 0)
                {
                    if (Sudoku.Validate()) Win();
                }
            }
            SelectedNumber = number.Value;
        }

        private void Win()
        {
            bool a = true;
        }

    }
}
