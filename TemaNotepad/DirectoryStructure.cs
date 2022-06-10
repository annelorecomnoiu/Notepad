using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TemaNotepad
{
    class DirectoryStructure
    {
        private String path = "C:\\Users\\User\\Desktop\\annelore\\ANUL 2";
        public DirectoryStructure() { }

        public void ListDirectory(TreeView treeView)
        {
            treeView.Items.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);

            treeView.Items.Add(CreateDirectoryItem(rootDirectoryInfo));

        }
        private static TreeViewItem CreateDirectoryItem(DirectoryInfo directoryInfo)
        {
            TreeViewItem view_item = new TreeViewItem();
            view_item.Header = directoryInfo.Name;

            foreach (var directory in directoryInfo.GetDirectories())
                view_item.Items.Add(CreateDirectoryItem(directory));

            foreach (var file in directoryInfo.GetFiles())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = file.Name;
                view_item.Items.Add(item);
            }

            return view_item;
        }

        public void openFile(TreeView treeView)
        {
            String view_item_name = treeView.SelectedItem.ToString().Replace("System.Windows.Controls.TreeViewItem Header:", String.Empty);
            view_item_name = view_item_name.Replace("Items.Count:", String.Empty);
            String aux = view_item_name.Remove(view_item_name.Length - 1, 1);
            MessageBox.Show(path + "\\" + aux);
            System.Diagnostics.Process.Start(path + "\\" + aux);
        }

    }
}
