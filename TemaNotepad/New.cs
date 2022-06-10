using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace TemaNotepad
{
    class New
    {
        public New() { }
        private int tab_index = 1;
        public void NewFile(TabControl tabControl)
        {
            
            TabItem item = new TabItem();
            TextBox text_area = new TextBox() { };
            text_area.AcceptsTab = true;
            text_area.AcceptsReturn = true;

            item.Header = "*File" + tab_index + " x";
          
            tab_index++;
            item.Content = text_area;

            tabControl.Items.Add(item);
            tabControl.SelectedItem = item;
        }
    }
}

