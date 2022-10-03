using Xamarin.Forms;

namespace Sudoku.Services
{
    public static class DataStoreManager
    {

        public static void SaveInProp(string propName, string data)
        {
            Application.Current.Resources[propName] = data;
        }

        public static object GetFromProp(string propName)
        {
            Application.Current.Resources.TryGetValue(propName, out object data);
            return data;
        }

    }
}
