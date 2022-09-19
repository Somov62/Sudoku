using System;

namespace SudokuLib.GeneratorTools
{
    internal static class SigletonRandom
    {
        private static Random _random;

        public static Random GetInstance()
        {
            if (_random == null) 
                _random = new Random();
            return _random;
        }
    }
}
