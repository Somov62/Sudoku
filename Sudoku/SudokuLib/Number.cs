namespace SudokuLib
{
    public class Number
    {
        /// <summary>
        /// Хранит верное значение ячейки
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Хранит значение, установленное пользователем
        /// </summary>
        public int UserValue { get; set; }

        /// <summary>
        /// Скрывает значение от пользователя
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Проверяет соответствие правильного значение и догадки пользователя
        /// </summary>
        public bool IsValid => Value == UserValue;

    }
}
