using System;
using System.Linq;
using System.Collections.Generic;

namespace SudokuLib
{
    public class Chunk
    {
        /// <summary>
        /// Длина одного измерения чанка.
        /// Площадь чанка = _size * _size
        /// </summary>
        private readonly int _size;
        public Chunk(int size)
        {
            _size = size;
            ChunkData = new List<Number>(size);
            for (int i = 0; i < size * size; i++)
            {
                ChunkData.Add(new Number());
            }
        }

        /// <summary>
        /// Представление чанков в качестве
        /// коллекции для удобного биндинга
        /// </summary>
        public List<Number> ChunkData { get; }

        public Number this[int row, int column]
        {
            get => ChunkData[row * _size + column];
            set => ChunkData[row * _size + column] = value;
        }

        public bool Validate()
        {
            return ChunkData.Where(p => p.IsValid == false).Count() == 0;
        }

        public int OpenedDigitsCount()
        {
            return ChunkData.Where(p => p.Value == 0).Count();
        }
    }
}
