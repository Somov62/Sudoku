using Newtonsoft.Json;
using SudokuLib;

namespace Sudoku.Services
{
    internal static class SudokuSaver
    {
        private const string _propName = "Sudoku";

        public static void Save(SudokuLib.Sudoku sudoku)
        {
            string data = JsonConvert.SerializeObject(sudoku);

            DataStoreManager.SaveInProp(_propName + "Save" + sudoku.Difficulty.ToString(), data);
        }

        public static void SaveNew(SudokuLib.Sudoku sudoku)
        {
            string data = JsonConvert.SerializeObject(sudoku);

            DataStoreManager.SaveInProp(_propName + sudoku.Difficulty.ToString(), data);
        }

        public static SudokuLib.Sudoku Get(int difficultyLevel)
        {
            var data = DataStoreManager.GetFromProp(_propName + difficultyLevel.ToString());
            if (data == null) return null;
            return JsonConvert.DeserializeObject<SudokuLib.Sudoku>(data.ToString());
        }

        public static SudokuLib.Sudoku GetSave(int difficultyLevel)
        {
            var data = DataStoreManager.GetFromProp(_propName + "Save" + difficultyLevel.ToString());
            if (data == null) return null;
            return JsonConvert.DeserializeObject<SudokuLib.Sudoku>(data.ToString());
        }

        public static bool SaveExists(int difficultyLevel)
        {
            return DataStoreManager.GetFromProp(_propName + "Save" + difficultyLevel.ToString()) != null;
        }

        public static void ClearSave(int difficultyLevel)
        {
            DataStoreManager.SaveInProp(_propName + "Save" + difficultyLevel, null);
        }
    }
}
