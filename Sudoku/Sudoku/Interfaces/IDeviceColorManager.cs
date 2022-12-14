namespace Sudoku.Interfaces
{
    public interface IDeviceColorManager
    {
        void SetNavBarColor(string hex);

        void SetStatusBarColor(string hex);

        void SetTitleColor(string hex);

        void SetLightBars();

        void SetDarkBars();
    }
}
