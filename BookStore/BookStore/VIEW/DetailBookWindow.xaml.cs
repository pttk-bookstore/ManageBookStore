using BookStore.DTO;
using BookStore.VIEW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookStore.VIEW
{
    /// <summary>
    /// Interaction logic for DetailBookWindow.xaml
    /// </summary>
    public partial class DetailBookWindow : Window
    {
       
        public DetailBookWindow()
        {
            InitializeComponent();
        }

        public DetailBookWindow(CBook DeltailBook)
        {
            InitializeComponent();
            this.DataContext = new DetailsBookWindowVM(DeltailBook);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
