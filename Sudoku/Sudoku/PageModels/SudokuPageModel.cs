using Sudoku.Services;
using SudokuLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Sudoku.PageModels
{
    public class SudokuPageModel : Base.BaseViewModel
    {
        private readonly System.Timers.Timer _timer;

        public Command SelectNumberCommand { get; }
        public Command SetNumberCommand { get; }


        public SudokuPageModel(int difficulty)
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += Timer_Elapsed;
            Difficulty = difficulty;
            SelectNumberCommand = new Command((object value) => SelectNumber(value));
            SetNumberCommand = new Command((object value) => SetNumber(value));
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ElapsedSeconds++;
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

        private int _elapsedSeconds;

        public int ElapsedSeconds
        {
            get => _elapsedSeconds;
            set => Set(ref _elapsedSeconds, value, nameof(ElapsedSeconds));
        }

        public bool WinState { get; set; }


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
                    if (Sudoku.Validate())
                    {
                        Win();
                        return;
                    }
                }
            }
            SelectedNumber = number.Value;
            if (!_timer.Enabled) _timer.Start();
        }

        public event EventHandler WinEvent;

        private void Win()
        {
            _timer.Stop();
            SelectedNumber = 0;
            WinState = true;
            OnPropertyChanged(nameof(WinState));
            WinEvent?.Invoke(null, null);
        }


        public void AddNumbers()
        {
            var list = Enumerable.Range(1, 9).ToList();
            list.Add(0);
            Numbers = list;
        }

        public void CreateSudoku()
        {
            Sudoku = SudokuManager.GetSave(Difficulty);
        }

        public void OnDisappearing()
        {
            if (!WinState)
            {
                SudokuManager.SaveSudoku(Sudoku);
                return;
            }
            SudokuManager.ClearSave(Difficulty);
        }
    }
}
