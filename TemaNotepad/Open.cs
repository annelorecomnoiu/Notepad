using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TemaNotepad
{
    class Open
    {
        public Open() { }
        public void openFile(ref string _opened_file_path, TabControl tabControl)
        {
            TabItem item = new TabItem();
            TextBox text_area = new TextBox() { };

            OpenFileDialog file_dialog = new OpenFileDialog();

            file_dialog.ShowDialog();

            text_area.AppendText(System.IO.File.ReadAllText(file_dialog.FileName).ToString());

            _opened_file_path = System.IO.Path.GetFullPath(file_dialog.FileName);

            item.Header = System.IO.Path.GetFileNameWithoutExtension(file_dialog.FileName);
            item.Content = text_area;

            tabControl.Items.Add(item);
            tabControl.SelectedItem = item;
        }
    }
}
