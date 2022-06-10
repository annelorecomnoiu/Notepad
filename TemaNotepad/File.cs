using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TemaNotepad
{
    class File
    {
        private New newFile = new New();
        private Open openFile = new Open();
        private Save saveFile = new Save();
      
        private string _opened_file_path;

        public string Opened_file_path
        {
            get
            {
                return _opened_file_path;
            }

            set
            {

            }
        }
        public File() { }
        public void AddNewFile(TabControl tabControl)
        {
            newFile.NewFile(tabControl);
        }
        public void openExistingFile(TabControl tabControl)
        {
            openFile.openFile(ref _opened_file_path, tabControl);
        }
        public void SaveFile(ref TabControl tabControl)
        {
            saveFile.SaveFile(_opened_file_path, ref tabControl); 
        }
        public void SaveAsFile(TabControl tabControl, ref String data)
        {
            saveFile.SaveAsFile(ref tabControl, ref data);
        }
        public void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
