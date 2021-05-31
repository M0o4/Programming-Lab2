using MyLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace WpfLab2.MVVM.Models
{
	class Invenory : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
        public static string DefaultPathToFile { get; } = "Data\\Elements.xml";

        public static IList<Test> Tests { get; set; } 

		public static string[] SplitWithComma(string str) => str.Split(',');

        public static async Task<bool> SerializeElement<T>(string filename,
           T listOfElements)
        {

            var result = await Task.Run(() =>
            {
                string TempError = "";
                try
                {
                    if (!Directory.Exists("Data"))
                    {
                        Directory.CreateDirectory("Data");
                    }
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    using (TextWriter writer = new StreamWriter(filename, false))
                    {
                        ser.Serialize(writer, listOfElements);
                        writer.Close();
                        TempError = "";
                        return true;
                    }
                }
                catch (Exception exp)
                {
                    TempError = exp.Message ?? "";
                    MessageBox.Show(TempError);
                    return false;
                }
            });
            return result;
        }

        public static async Task<T> DeserializeElement<T>(string filename)
        {
            return await Task.Run(() => {
                string Error;
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (FileStream fs = new FileStream(filename, FileMode.Open))
                    {
                        T res = (T)serializer.Deserialize(fs);
                        Error = "";
                        return res;
                    }
                }
                catch (Exception exp)
                {
                    Error = exp.Message;
                    return default(T);
                }
            });
        }
    }
}
