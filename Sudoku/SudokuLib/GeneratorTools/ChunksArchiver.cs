using SudokuLib.Entities;
using System;
using System.Collections.Generic;

namespace SudokuLib.GeneratorTools
{
    internal class ChunksArchiver
    {
        /// <summary>
        /// Упаковка матрицы чисел в матрицу чанков
        /// </summary>
        /// <returns>Матрица чанков</returns>
        public List<Chunk> PackInChunks(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return null;
            int chunkSize = (int)Math.Sqrt(matrix.GetLength(0));

            List<Chunk> chunks = new List<Chunk>(chunkSize * chunkSize);

            for (int i = 0; i < chunkSize; i++)
                for (int j = 0; j < chunkSize; j++)
                    chunks.Add(PackInChunk(i * chunkSize, j * chunkSize));
            return chunks;

            Chunk PackInChunk(int chunkRow, int chunkColumn)
            {
                Chunk chunk = new Chunk(chunkSize);
                for (int i = 0; i < chunkSize; i++)
                    for (int j = 0; j < chunkSize; j++)
                    {
                        chunk[i, j].Value = matrix[i + chunkRow, j + chunkColumn];
                        if (chunk[i, j].Value == 0) chunk[i, j].IsDefault = false;
                    }    
                return chunk;
            }
        }

        /// <summary>
        /// Преобразование коллекции чанков в матрицу чисел
        /// </summary>
        /// <param name="chunks">Коллекция чанков</param>
        /// <returns>Матрица чисел</returns>
        public int[,] ExtractChunks(List<Chunk> chunks)
        {
            int chunkSize = (int)Math.Sqrt(chunks.Count);

            int[,] matrix = new int[chunkSize * chunkSize, chunkSize * chunkSize];

            int row = 0;
            int column = 0 - chunkSize;

            for (int i = 0; i < chunks.Count; i++)
            {
                column += chunkSize;
                if (column == matrix.GetLength(0))
                {
                    column = 0;
                    row += chunkSize;
                }
                for (int j = 0; j < chunks[i].ChunkData.Count; j++)
                {
                    if (j != 0 && j % chunkSize == 0)
                    {
                        row++;
                        column -= chunkSize;
                    }
                    matrix[row, column] = chunks[i].ChunkData[j].Value;
                    column++;
                }
                column -= chunkSize;
                row -= chunkSize - 1;

            }

            return matrix;
        }

    }
}
