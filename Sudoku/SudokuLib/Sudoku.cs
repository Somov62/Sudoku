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
        public int CountChunksInDimension { get; }
        public int Difficulty { get; }
        public int[,] Matrix { get; }
        public List<Chunk> Chunks { get;  }

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
