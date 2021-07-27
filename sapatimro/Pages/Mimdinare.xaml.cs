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
        private List<EF.Braldebuli> braldebulebi;
        private string FiltriSaqmeNomer;
        private string FiltriBraldebuliSaxeli;
        private string FiltriBraldebulGvari;
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
            braldebulebi = new List<EF.Braldebuli>();
        }

        private async
        Task
        SeachBr(DateTime ldt, DateTime rdt)
        {
            if(braldebulebi.Count > 0)
            {
                braldebulebi.Clear();
            }
            try
            {
                using (EF.Model1 md = new EF.Model1())
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


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async void search_btn_Click(object sender, RoutedEventArgs e)
        {
            await SeachBr((DateTime)leftDate.SelectedDate,(DateTime)rightDate.SelectedDate);
            listView.ItemsSource = braldebulebi;
            saqme_number_cmb.ItemsSource = braldebulebi;
            brald_gv_cmb.ItemsSource = braldebulebi;
            brald_saxeli_cmb.ItemsSource = braldebulebi;
        }

        private void fiter_btn_Click(object sender, RoutedEventArgs e)
        {
            if ( !string.IsNullOrEmpty(FiltriSaqmeNomer) &&
              !string.IsNullOrEmpty(FiltriBraldebuliSaxeli) &&  !string.IsNullOrEmpty(FiltriBraldebulGvari))
            {
                Filter.FilterGrid(FiltriSaqmeNomer, FiltriBraldebuliSaxeli, FiltriBraldebulGvari, braldebulebi, listView);
                return;
            }
            if(!string.IsNullOrEmpty(FiltriSaqmeNomer) && !string.IsNullOrEmpty(FiltriBraldebuliSaxeli))
            {
                Filter.FilterGrid(FiltriSaqmeNomer, FiltriBraldebuliSaxeli, braldebulebi, listView);
                return;
            }
            if( !string.IsNullOrEmpty(FiltriSaqmeNomer))
            {
                Filter.FilterGrid(FiltriSaqmeNomer, braldebulebi, listView);
                return;
            }
            if(!string.IsNullOrEmpty(FiltriBraldebuliSaxeli) && !string.IsNullOrEmpty(FiltriBraldebulGvari))
            {
                Filter.FilterFrombraldebuli(FiltriBraldebuliSaxeli, FiltriBraldebulGvari, braldebulebi, listView);
                return;
            }
            if (!string.IsNullOrEmpty(FiltriBraldebuliSaxeli))
            {
                Filter.FilterFrombraldebuli(FiltriBraldebuliSaxeli, braldebulebi, listView,true);
                return;
            }
            if (!string.IsNullOrEmpty(FiltriBraldebulGvari))
            {
                Filter.FilterFrombraldebuli(FiltriBraldebulGvari, braldebulebi, listView, false);
                return;
            }
        }

        private void saqme_number_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (saqme_number_cmb.SelectedItem != null)
            {
                FiltriSaqmeNomer = ((EF.Braldebuli)saqme_number_cmb.SelectedItem).Saqme.saqme_nomeri;
            }
            else
                FiltriSaqmeNomer = null;
            
        }

        private void brald_saxeli_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (brald_saxeli_cmb.SelectedItem != null)
            {
                FiltriBraldebuliSaxeli = ((EF.Braldebuli)brald_saxeli_cmb.SelectedItem).braldebuli_sax;
            }
            else
                FiltriBraldebuliSaxeli = null;
        }

        private void brald_gv_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (brald_gv_cmb.SelectedItem != null)
            {
                FiltriBraldebulGvari = ((EF.Braldebuli)brald_gv_cmb.SelectedItem).braldebuli_gv;
            }
            else
                FiltriBraldebulGvari = null;
        }

        private void corectBtn_Click(object sender, RoutedEventArgs e)
        {
            EF.Braldebuli br = (EF.Braldebuli)listView.SelectedItem;
            Corect cr = new Corect(br);
            cr.ShowDialog();
        }
    }
}
