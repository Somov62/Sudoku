using System.Threading.Tasks;

namespace Sudoku.Services
{
    internal static class SudokuManager
    {
        public static void SaveSudoku(SudokuLib.Sudoku sudoku)
        {
            SudokuSaver.Save(sudoku);
        }

        public static SudokuLib.Sudoku GetSave(int difficultyLevel)
        {
            var sudoku = SudokuSaver.Get(difficultyLevel);

            Task.Run(() =>
            {
                SudokuSaver.SaveNew(new SudokuLib.Sudoku(difficultyLevel: difficultyLevel));
            });

            return sudoku;
        }

        public static void LoadResumeSave(int difficultyLevel)
        {
            SudokuSaver.SaveNew(SudokuSaver.GetSave(difficultyLevel));
        }

        public static void ClearSave(int difficultyLevel)
        {
            SudokuSaver.ClearSave(difficultyLevel);
        }
    }
}
