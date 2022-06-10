using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TemaNotepad
{
    class Save
    {
        public Save() { }
        public void SaveFile(string _opened_file_path, ref TabControl tabControl)
        {
            try
            {
                TabItem tabItem = (TabItem)tabControl.SelectedItem;
               
                var data = (tabItem.Content as TextBox).Text;
                System.IO.File.WriteAllText(_opened_file_path, data);
            }
            catch { }
        }

        public void SaveAsFile(ref TabControl tabControl, ref String data)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
          
                dialog.FileName = "Untiltled";
                dialog.DefaultExt = ".txt";
                dialog.Filter = "Text Documents (.txt) |*.txt";

                dialog.ShowDialog();
                System.IO.File.WriteAllText(dialog.FileName, data);

                data = dialog.FileName;
            }
            catch { }
        }
    }
}
