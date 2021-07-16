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

namespace sapatimro.Pages
{
    /// <summary>
    /// Interaction logic for Mimdinare.xaml
    /// </summary>
    public partial class Mimdinare : Page
    {
        private DateTime curentDate;
        private DateTime previusDate;
        public Mimdinare()
        {
            InitializeComponent();
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            curentDate = new DateTime(DateTime.Now.Year,
            DateTime.Now.Month,
            DateTime.Now.Day+1
            );

            previusDate = new DateTime(curentDate.Year, curentDate.Month - 2, curentDate.Day);
            leftDate.SelectedDate = previusDate;
            rightDate.SelectedDate = curentDate;
        }

        private async Task<List<EF.Braldebuli>>SeachBr(DateTime ldt,DateTime rdt)
        {
            List<EF.Braldebuli> braldebulebi = new List<EF.Braldebuli>();
            try
            {
                using(EF.Model1 md = new EF.Model1())
                {
                    var tmpbraldebulebi = md.Braldebuli.Where(
                        b => b.cinasasamartlo >= ldt && b.cinasasamartlo <= rdt
                        && b.Saqme.mimdinare == 0

                    );
                    foreach (EF.Braldebuli br in tmpbraldebulebi)
                    {
                        string sq = br.Saqme.saqme_nomeri;
                        braldebulebi.Add(br);
                    }
                        
                    return braldebulebi;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async void search_btn_Click(object sender, RoutedEventArgs e)
        {
            
            listView.ItemsSource = await SeachBr((DateTime)leftDate.SelectedDate,(DateTime)rightDate.SelectedDate);
        }
    }
}
