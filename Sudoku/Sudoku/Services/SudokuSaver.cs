using Newtonsoft.Json;

namespace Sudoku.Services
{
    internal static class SudokuSaver
    {

        public static void SaveSudoku(SudokuLib.Sudoku sudoku)
        {
            string data = JsonConvert.SerializeObject(sudoku);

            DataStoreManager.SaveInProp(sudoku.Difficulty.ToString(), data);
        }
        
        public static SudokuLib.Sudoku GetSave(int difficultyLevel)
        {
            var data = DataStoreManager.GetFromProp(difficultyLevel.ToString());
            if (data == null) return null;
            return data as SudokuLib.Sudoku;
        }

    }
}
