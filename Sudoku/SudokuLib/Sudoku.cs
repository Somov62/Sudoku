using SudokuLib.Entities;
using SudokuLib.GeneratorTools;
using System.Collections.Generic;

namespace SudokuLib
{
    public class Sudoku
    {
        public Sudoku() { }
        public Sudoku(int countChunksInDimension = 3, int difficultyLevel = 2)
        {
            Difficulty = difficultyLevel;
            CountChunksInDimension = countChunksInDimension;
            Matrix = new Generator().GenerateSudoku(CountChunksInDimension, difficultyLevel);

            ChunksArchiver archiver = new ChunksArchiver();
            Chunks = archiver.PackInChunks(Matrix);
        }
        public int CountChunksInDimension { get; set; }
        public int Difficulty { get; set; }
        public int[,] Matrix { get;  }
        public List<Chunk> Chunks { get; set; }

        public int FreeSeatsCount()
        {
            int count = 0;
            foreach (var item in Chunks)
            {
                count += item.FreeSeatsCount();
            }
            return count;
        }

        public bool Validate()
        {
            SudokuChecker checker = new SudokuChecker();
            return checker.ValidateSudoku(Chunks);
        }
    }
}
