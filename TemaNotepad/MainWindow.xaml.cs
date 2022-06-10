using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Drawing;

namespace TemaNotepad
{

    public partial class MainWindow : Window
    {
        File file = new File();
        Search search ;
        DirectoryStructure dir = new DirectoryStructure();
        FindWindow findWindow;
        TextBox txtArea;
        internal Search Search { get => search; set => search = value; }

        public MainWindow()
        {
            InitializeComponent();
            file.AddNewFile(tabControl);
            findWindow = new FindWindow(this);


            TabItem tabItem = (TabItem)tabControl.SelectedItem;
            var txtArea = (tabItem.Content as TextBox);
          
            findWindow.Editor = txtArea;
            Console.WriteLine("test" + tabItem.Name);
            txtArea.IsInactiveSelectionHighlightEnabled = false;

            //Main.Window.find.Editor = tabControl.SelectedItem.ToString;

        }
        private new void MouseDown(object sender, RoutedEvent e)
        {
            TabItem tabItem = (TabItem)tabControl.SelectedItem;
            var data = (tabItem.Content as TextBox).Text;
           
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            file.AddNewFile(tabControl);
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            file.openExistingFile(tabControl);
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            file.SaveFile(ref tabControl);
        }
        private void save_as_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = (TabItem)tabControl.SelectedItem;
            var data = (tabItem.Content as TextBox).Text;
            file.SaveAsFile(tabControl, ref data);
            string name="";
            for(int i=0; i<data.Length; i++)
            {
                if (data[i] == '\\')
                    name=name.Remove(0);
                else
                    name = name + data[i];
                    

            }
            tabItem.Header =name;
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            file.Exit();
        }
        private void about_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            FindWindow find = new FindWindow(this);
            find.Editor = txtArea;
            find.Show();

            
            //if(find == null)
            //{
            //    find = new FindWindow();
                //TabItem tabItem = (TabItem)tabControl.SelectedItem;
                //var data = (tabItem.Content as TextBox);
            //    find.Editor = data;
            //}
            //find.Show();



            //TabItem tabItem = (TabItem)tabControl.SelectedItem;
            //var data = (tabItem.Content as TextBox);
            //find.UpdateSearchQuery();
            //if (find.Qry.SearchString.Length == 0)
            //{
            //    find.Show();
            //}
            //else
            //{
            //    FindNextResult result = search.FindNext(find.Qry);
            //    if (result.SearchStatus)
            //       data.Select(result.SelectionStart, find.Qry.SearchString.Length);
            //}

        }
        private void Replace_Click(object sender, RoutedEventArgs e)
        {
            Replace replace = new Replace();
            replace.Show();
        }
        private void Replace_all_Click(object sender, RoutedEventArgs e)
        {
            ReplaceAll replaceAll = new ReplaceAll();
            replaceAll.Show();
        }
        private void showFolderBtn_Click(object sender, RoutedEventArgs e)
        {
            dir.ListDirectory(treeView);
        }
        private void openFileBtn_Click(object sender, RoutedEventArgs e)
        {
            dir.openFile(treeView);

        }
        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = (TabItem)tabControl.SelectedItem;
            var data = tabItem.Content as TextBox;
            data.Copy();
            Paste.IsEnabled = true;
        }
        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = (TabItem)tabControl.SelectedItem;
            var data = tabItem.Content as TextBox;
            data.Cut();
            Paste.IsEnabled = true;
        }
        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = (TabItem)tabControl.SelectedItem;
            var data = tabItem.Content as TextBox;
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                data.Paste();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = (TabItem)tabControl.SelectedItem;
            var data = tabItem.Content as TextBox;
            Cut.IsEnabled = data.SelectedText.Length > 0 ? true : false;
            Copy.IsEnabled = data.SelectedText.Length > 0 ? true : false;
            Paste.IsEnabled = Clipboard.GetDataObject().GetDataPresent(DataFormats.Text);
            Uppercase.IsEnabled = data.SelectedText.Length > 0 ? true : false;
            Lowercase.IsEnabled = data.SelectedText.Length > 0 ? true : false;
        }
        private void Edit_MouseEnter(object sender, MouseEventArgs e)
        {
            Edit_Click(sender, e);
        }
        private void UpperCase_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = (TabItem)tabControl.SelectedItem;
            var data = (tabItem.Content as TextBox);
            data.SelectedText = data.SelectedText.ToUpper();
        }
        private void LowerCase_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = (TabItem)tabControl.SelectedItem;
            var data = (tabItem.Content as TextBox);
            data.SelectedText = data.SelectedText.ToLower();
        }
    }
}
