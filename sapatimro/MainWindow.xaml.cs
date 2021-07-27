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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sapatimro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void auth_btn_Click(object sender, RoutedEventArgs e)
        {
            if (judge_login.Text.Trim() != string.Empty && judge_passwd.Text.Trim() != string.Empty)
            {
                try
                {
                    if (Auth.AuthJudge(judge_login.Text.Trim(), judge_passwd.Text.Trim()))
                    {
                        Dziritadi dz = new Dziritadi();
                        dz.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("ლოგინი ან პასვორდი არასწორია", "გაფრთხილება",
                            MessageBoxButton.OK, 
                            MessageBoxImage.Warning);
                        return;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
                    
            }
            else
            {
                MessageBox.Show("ლოგინი ან პასვორდი არასწორია", "გაფრთხილება", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
        }
    }
}
