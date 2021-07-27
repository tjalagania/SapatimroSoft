using sapatimro.Pages;
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
using EF = sapatimro.EF;
namespace sapatimro
{
    /// <summary>
    /// Interaction logic for Corect.xaml
    /// </summary>
    public partial class Corect : Window
    {
        private EF.Braldebuli Braldebuli;
        private bool Arsebiti;
        public Corect(EF.Braldebuli braldebuli)
        {
            InitializeComponent();
            Braldebuli = braldebuli;
            
            mainGrid.DataContext = Braldebuli;
        }
       

        private async void corect_btn_Click(object sender, RoutedEventArgs e)
        {
            string mamissaxeli = "";
            if(saqmis_nomeri.Text !=string.Empty &&
               braldebuli_saxeli.Text !=string.Empty &&
               braldebuli_gvari.Text != string.Empty &&
               ganxilvisTarigi.SelectedDate !=null)
            {
                if(braldebuli_msaxeli.Text == string.Empty)
                {
                   MessageBoxResult res =  MessageBox.Show("გსურთ ინფორმაციის კორექტირება მამის სახელის გარეშე?",
                        "გაფრთხილება", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if(res == MessageBoxResult.Yes)
                    {
                        mamissaxeli = braldebuli_msaxeli.Text.Trim();
                        
                        
                    }
                   
                }
                using (EF.Model1 md = new EF.Model1())
                {
                    EF.Braldebuli br = md.Braldebuli.SingleOrDefault(b => b.braldebuli_id == Braldebuli.braldebuli_id);
                    if (br != null)
                    {
                        br.braldebuli_sax = braldebuli_saxeli.Text.Trim();
                        br.braldebuli_gv = braldebuli_gvari.Text.Trim();
                        br.cinasasamartlo = (DateTime)ganxilvisTarigi.SelectedDate;
                        br.Saqme.saqme_nomeri = saqmis_nomeri.Text.Trim();
                        br.brladebuli_msax = mamissaxeli;
                        br.arsebiti = arsganxilvisTarigi.SelectedDate;
                        int i = await md.SaveChangesAsync();
                        if(i > 0)
                        {
                            MessageBox.Show("ბრალდებული დაკორექტირდა წარმატებით");
                            BraldebulisDamateba.BraldebulisCorectireba?.Invoke(br);
                        }
                    }
                }
            }
        }
    }
}
