using System.Collections.Generic;
using Xamarin.Forms;

namespace Sudoku.PageModels
{
    public class MainPageModel : Base.BaseViewModel
    {
        public List<string> Levels { get; set; } = new List<string>() { "Beginner", "Easy", "Medium", "Hard", "Extreme" };

        public Command PreviousLevel { get; }
        public Command NextLevel { get; }


        public MainPageModel()
        {
            PreviousLevel = new Command(() => { if (Level != 0) Level--; });
            NextLevel = new Command(() => { if (Level < Levels.Count - 1) Level++; });
        }


        private int _level;
        public int Level 
        {
            get => _level;
            set => Set(ref _level, value, nameof(Level));
        }

    }
}
