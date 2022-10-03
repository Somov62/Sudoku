using System.Threading.Tasks;

namespace Sudoku.Services
{
    internal static class SudokuManager
    {
        public static void SaveSudoku(SudokuLib.Sudoku sudoku)
        {
            SudokuSaver.SaveSudoku(sudoku);
        }

        public static SudokuLib.Sudoku GetSave(int difficultyLevel)
        {
            var sudoku = SudokuSaver.GetSave(difficultyLevel);

            Task.Run(() =>
            {
                SudokuSaver.SaveSudoku(new SudokuLib.Sudoku(difficultyLevel: difficultyLevel));
            });

            return sudoku;

        }

    }
}
