using Newtonsoft.Json;

namespace Sudoku.Services
{
    internal static class SudokuSaver
    {

        public static void SaveSudoku(SudokuLib.Sudoku sudoku)
        {
            string data = JsonConvert.SerializeObject(sudoku);

            DataStoreManager.SaveInProp("Sudoku" + sudoku.Difficulty.ToString(), data);
        }
        
        public static SudokuLib.Sudoku GetSave(int difficultyLevel)
        {
            var data = DataStoreManager.GetFromProp("Sudoku" + difficultyLevel.ToString());
            if (data == null) return null;
            string json = data.ToString();
            return JsonConvert.DeserializeObject<SudokuLib.Sudoku>(json);
        }

    }
}
