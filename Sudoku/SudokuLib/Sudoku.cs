using System;
using System.Collections.Generic;
using System.Linq;
using SudokuLib.Realization_1;

namespace SudokuLib
{
    public class Sudoku
    {
        public Sudoku(int countChunksInDimension = 3, int difficultyLevel = 2)
        {
            CountChunksInDimension = countChunksInDimension;
            ChunkMatrix = new Generator().GenerateSudoku(CountChunksInDimension, difficultyLevel);
            ChunkList = MatrixToList();
        }
        public int CountChunksInDimension { get; set; }
        public Chunk[,] ChunkMatrix { get; set; }
        public List<Chunk> ChunkList { get; set; }

        public bool Validate()
        {
            return ChunkList.Where(p => p.Validate() == false).Count() == 0;
        }

        private List<Chunk> MatrixToList()
        {
            List<Chunk> list = new List<Chunk>(CountChunksInDimension * CountChunksInDimension);
            for (int i = 0; i < CountChunksInDimension; i++)
            {
                for (int j = 0; j < CountChunksInDimension; j++)
                {
                    list.Add(ChunkMatrix[i, j]);
                }
            }
            return list;
        }
    }
}
