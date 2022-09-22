using System.ComponentModel;

namespace SudokuLib.Entities
{
    public class Number : INotifyPropertyChanged
    {
        public Number()
        {
            IsDefault = true;
        }

        private int _value;
        /// <summary>
        /// Хранит верное значение ячейки
        /// </summary>
        public int Value 
        {
            get => _value;
            set
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }

        /// <summary>
        /// Метка стандартной цифры.
        /// Такие цифры расставлены на сетке при старте игры.
        /// Запрещает пользователю удалять значение
        /// </summary>
        public bool IsDefault { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
