using sapatimro.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace sapatimro
{
    /// <summary>
    /// Interaction logic for Dziritadi.xaml
    /// </summary>
    public partial class Dziritadi : Window
    {
        public Dziritadi()
        {
            InitializeComponent();
        }

        private void mwclose_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void mwminize_btn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainfFr.Source = new Uri(@"Pages\Shetkobineba.xaml", UriKind.Relative);
            judgename.Text = State.JudgeName.FullName;
        }

        private void infosShetana_btn_Click(object sender, RoutedEventArgs e)
        {
            mainfFr.Source = new Uri(@"Pages\BraldebulisDamateba.xaml", UriKind.Relative);
            
        }

        private void braldebulebisSia_btn_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, e);
        }

        private void mimidnare_btn_Click(object sender, RoutedEventArgs e)
        {
            mainfFr.Source = new Uri(@"Pages\Mimdinare.xaml", UriKind.Relative);
        }
    }
}
