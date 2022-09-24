using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sudoku.PageModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected void Set<T>(ref T source, T value, string property = null)
        {
            if (source.Equals(value)) return;
            source = value;
            OnPropertyChanged(property);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
