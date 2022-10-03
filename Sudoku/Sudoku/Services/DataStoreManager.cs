using System.Linq;
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
            var dictionarylist = Application.Current.Resources.MergedDictionaries;
            dictionarylist.FirstOrDefault(p => p.GetType().ToString().Contains("Page1")).TryGetValue(propName, out object data);
            return data;
        }

    }
}
