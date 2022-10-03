using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Services
{
    internal static class SudokuManager
    {
        public static void SaveSudoku(SudokuLib.Sudoku sudoku)
        {

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
