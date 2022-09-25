using Sudoku.Services;
using SudokuLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sudoku.PageModels
{
    public class SudokuPageModel : Base.BaseViewModel
    {

        public Command SelectNumberCommand { get; }
        public Command SetNumberCommand { get; }

        public SudokuPageModel(int difficulty)
        {
            Difficulty = difficulty;
            SelectNumberCommand = new Command((object value) => SelectNumber(value));
            SetNumberCommand = new Command((object value) => SetNumber(value));
        }

        public int Difficulty { get; set; }

        private SudokuLib.Sudoku _sudoku;
        public SudokuLib.Sudoku Sudoku 
        {
            get => _sudoku;
            set => Set(ref _sudoku, value, nameof(Sudoku));
        }


        private List<int> _numbers;

        public List<int> Numbers
        {
            get => _numbers;
            set => Set(ref _numbers, value, nameof(Numbers));
        }

        private int _selectedNumber;
        public int SelectedNumber
        {
            get => _selectedNumber;
            set => Set(ref _selectedNumber, value, nameof(SelectedNumber));
        }


        public List<ThemeEntity> Colors => ThemeManager.Themes;

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


        public void AddNumbers()
        {
            var list = Enumerable.Range(1, 9).ToList();
            list.Add(0);
            Numbers = list;
        }

        public async void CreateSudoku()
        {
            await Task.Run(() => new SudokuLib.Sudoku(3)).ContinueWith(task => Sudoku = task.Result);
        }
    }
}
