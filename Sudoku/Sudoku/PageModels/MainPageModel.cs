using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Sudoku.PageModels
{
    public class MainPageModel : FreshBasePageModel
    {
        public List<string> Levels { get; set; } = new List<string>() { "Beginner", "Easy", "Medium", "Hard", "Extreme" };

        public Command PreviousLevel { get; }
        public Command NextLevel { get; }

        public Command ToSudokuPage { get; }

        public MainPageModel()
        {
            PreviousLevel = new Command(() => { if (Level != 0) Level--; });
            NextLevel = new Command(() => { if (Level < Levels.Count - 1) Level++; });
            ToSudokuPage = new Command(async () => await base.CoreMethods.PushPageModel<SudokuPageModel>());
        }


        private int _level;
        public int Level 
        {
            get => _level;
            set
            {
                _level = value;
                RaisePropertyChanged(nameof(Level));
            }
        }

    }
}
