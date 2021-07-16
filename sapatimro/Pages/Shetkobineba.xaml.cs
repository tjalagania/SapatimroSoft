using EF =  sapatimro.EF;
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
    /// Interaction logic for Shetkobineba.xaml
    /// </summary>
    public partial class Shetkobineba : Page
    {
        private EF.Braldebuli Braldebuli;
        
       
        public Shetkobineba()
        {
            InitializeComponent();
            
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            arsebitiDate.SelectedDate = new DateTime(dt.Year, dt.Month, dt.Day);
            patshedegi.ItemsSource = State.Shedegi;
            
            List<EF.Braldebuli>brlist =  await SerchBraldebui(dt);
            /*using (EF.Model1 md = new EF.Model1())
            {

               foreach(EF.Braldebuli b in md.Braldebuli)
                {

                if (b.gadasingva.Subtract(new DateTime(dt.Year,dt.Month,dt.Day)).Days <=State.SPDay && b.Saqme.judge_id == State.JudgeName.ID)
                    brlist.Add(b);
                }

            }*/
            brlist.Sort(State.CompareDate);
            brlist_view.ItemsSource = brlist;

           
           
            
        }
        private async Task<List<EF.Braldebuli>> SerchBraldebui(DateTime dt)
        {
            List<EF.Braldebuli> brlist = new List<EF.Braldebuli>();
            using (EF.Model1 md = new EF.Model1())
            {

                foreach (EF.Braldebuli b in md.Braldebuli)
                {

                    if (b.gadasingva.Subtract(new DateTime(dt.Year, dt.Month, dt.Day)).Days <= State.SPDay &&
                        b.Saqme.judge_id == State.JudgeName.ID && b.Saqme.mimdinare == 0)
                        brlist.Add(b);
                }

            }
            return brlist;
        }
        private void brlist_view_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EF.Braldebuli braldebuli = (EF.Braldebuli)brlist_view.SelectedItem;
            Braldebuli = braldebuli;
            archBraldebuli.Text = braldebuli.FullName;
        }

        private async void arsbitisDamateba_btn_Click(object sender, RoutedEventArgs e)
        {
           if(Braldebuli == null)
            {
                MessageBox.Show("მონიშნეთ ბრალდებული","შენიშვნა",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
                return;
            }
           try
            {
                using(EF.Model1 md = new EF.Model1())
                   {
                        EF.Braldebuli br = md.Braldebuli.SingleOrDefault(bral => bral.braldebuli_id == Braldebuli.braldebuli_id);
                        if(br != null)
                        {
                            br.arsebiti = (DateTime)arsebitiDate.SelectedDate;
                            br.gadasingva = ((DateTime)arsebitiDate.SelectedDate).AddDays(State.SPDay);
                            await md.SaveChangesAsync();
                            Braldebuli = null;
                        }
                        else
                        {
                            MessageBox.Show("მოხდა პროგრამული შეცდომა, დაუკავშირდით ადმინისტრატორს");
                        }
                   }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private async Task<int> SaqmisDamtavreba(DateTime endDate,string shedegi)
        {
            int i = 0;
            if (Braldebuli != null)
            {
                using (EF.Model1 md = new EF.Model1())
                {
                    EF.Braldebuli tmpbr = md.Braldebuli.SingleOrDefault(b => b.braldebuli_id == Braldebuli.braldebuli_id);
                    if (tmpbr != null)
                    {
                        tmpbr.Saqme.dasrulebi_tarigi = endDate;
                        tmpbr.Saqme.shedegi = shedegi;
                        tmpbr.Saqme.mimdinare = 1;
                        i = await md.SaveChangesAsync();
                    }
                }
            }
            return i;
        }
        private async void endCase_btn_Click(object sender, RoutedEventArgs e)
        {
            if (endDatePicker.SelectedDate != null &&
                patshedegi.SelectedItem != null
                )
            {
                DateTime tmpdate = (DateTime)endDatePicker.SelectedDate;
                string shed = patshedegi.SelectedItem.ToString();

                int i = await SaqmisDamtavreba(tmpdate, shed);

                if(i > 0)
                {
                    MessageBox.Show("საქმე გადავიდა დამთავრებულებში წარმატებით");
                    Braldebuli = null;
                    List<EF.Braldebuli> tmpbr = await SerchBraldebui(DateTime.Now);
                    tmpbr.Sort(State.CompareDate);
                    brlist_view.ItemsSource = tmpbr;
                }
            }
        }
    }
}
