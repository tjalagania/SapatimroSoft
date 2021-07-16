using sapatimro.EF;
using sapatimro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using model = sapatimro.Models;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace sapatimro.Pages
{
    /// <summary>
    /// Interaction logic for BraldebulisDamateba.xaml
    /// </summary>
    public partial class BraldebulisDamateba : Page
    {
        ObservableCollection<EF.Braldebuli> braldebulebi = new ObservableCollection<EF.Braldebuli>();
        public static CorectBraldebuli BraldebulisCorectireba;
        public BraldebulisDamateba()
        {
            InitializeComponent();
            braldebulebi.CollectionChanged += InsetBr;
            BraldebulisCorectireba = braldebuliscorect;
        }

        private void braldebuliscorect(EF.Braldebuli braldebuli)
        {
            for(int i = 0; i < braldebulebi.Count; i++)
            {
                if(braldebulebi[i].braldebuli_id == braldebuli.braldebuli_id)
                {
                    braldebulebi.RemoveAt(i);
                    braldebulebi.Insert(i, braldebuli);
                }
            }
        }

        private void InsetBr(object sender, NotifyCollectionChangedEventArgs e)
        {
            brlsia.ItemsSource = braldebulebi;
            
        }

        private  async void BrDamateba_btn_Click(object sender, RoutedEventArgs e)
        {
            if(sq_nomeri.Text.Trim()!=string.Empty &&
               br_saxeli.Text.Trim()!=string.Empty &&
               br_gvari.Text.Trim()!=string.Empty
               )
            {
                try
                {
                     using(Model1 md = new Model1())
                     {
                        
                        EF.Saqme saqme = new EF.Saqme()
                        {
                            saqme_nomeri = sq_nomeri.Text.Trim(),
                            judge_id = State.JudgeName.ID
                        };
                        
                        md.Saqme.Add(saqme);

                        EF.Braldebuli br = new EF.Braldebuli()
                        {
                            braldebuli_sax = br_saxeli.Text.Trim(),
                            braldebuli_gv = br_gvari.Text.Trim(),
                            brladebuli_msax = br_msaxeli.Text != string.Empty ? br_msaxeli.Text : null,

                            cinasasamartlo = (DateTime)cnsas.SelectedDate,
                            Saqme = saqme,
                            gadasingva = ((DateTime)cnsas.SelectedDate).AddDays(State.SPDay)
                         };
                        
                        saqme.Braldebuli.Add(br);

                        int i = await md.SaveChangesAsync();
                         if(i > 0)
                         {
                           MessageBox.Show("ბრალდებული დაემატა წარმატებით");
                            braldebulebi.Add(br);
                            br_saxeli.Clear();
                            br_gvari.Clear();
                            br_msaxeli.Clear();
                            sq_nomeri.Clear();
                         }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cnsas.SelectedDate = DateTime.Now;
           
            
        }

       /* private void brlsia_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                EF.Braldebuli br = (EF.Braldebuli)brlsia.SelectedItem;
            }
            catch(NullReferenceException ex)
            {
               MessageBox.Show("აუცილებელია ბრალდებულის სტრიქონძე დაკლიკვა",
                   "შენიშვნა",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            
        }*/

        private void corect_btn_Click(object sender, RoutedEventArgs e)
        {
            Button tbn = (Button)sender;
            EF.Braldebuli tmpbr = (EF.Braldebuli)tbn.Tag;
            if (tmpbr != null)
            {
                Corect corect = new Corect(tmpbr);
                corect.ShowDialog();
            }
        }
    }
}
