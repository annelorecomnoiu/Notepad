using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TemaNotepad
{
    public partial class FindWindow : Window
    {
        MainWindow mainWindow;
        Search search;
        FindNextSearch qry = new FindNextSearch();

        public TextBox Editor { get; internal set; }
        internal FindNextSearch Qry { get => qry; set => qry = value; }

        public FindWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            oDown.IsChecked = true;
           // nextBtn.IsEnabled = false;
            search = mainWindow.Search;
            qry.Success = false;
            txtFind.TextChanged += new TextChangedEventHandler(txtFind_TextChanged);

        }
        
        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            nextBtn.IsEnabled = (txtFind.Text.Length > 0) ? true : false;
            Console.WriteLine("aicasuhaosdihasidhaodhaodi");
            UpdateSearchQuery();
        }
       

        public void UpdateSearchQuery()
        {
            qry.SearchString = txtFind.Text;
            qry.Direction = (bool)oUp.IsChecked ? "UP" : "DOWN";
            qry.MatchCase = (bool)chkMatchCase.IsChecked;
            qry.Content = Editor.Text;
            qry.Position = Editor.SelectionStart;

        }

        private void chkMatchCase_CheckedChanged(object sender, RoutedEventArgs e)
        {
            UpdateSearchQuery();
        }

        private void oUp_CheckedChanged(object sender, RoutedEventArgs e)
        {
            UpdateSearchQuery();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Hide();
          //  e.Cancel = true;
          
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateSearchQuery();
            FindNextResult result = search.FindNext(qry);
            if (result.SearchStatus)
                Editor.Select(result.SelectionStart, txtFind.Text.Length);
        }
    }
}
