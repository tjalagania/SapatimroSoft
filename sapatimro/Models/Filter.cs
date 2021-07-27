using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using EF = sapatimro.EF;

namespace sapatimro.Models
{
    
    public class Filter
    {
        public static void FilterGrid(string saqmisnomer,string braldebulisSaxeli,string braldebulisGvari, List<EF.Braldebuli>braldebulebi, DataGrid grid)
        {
       
                grid.ItemsSource = braldebulebi.Where(br => br.Saqme.saqme_nomeri == saqmisnomer &&
                 br.braldebuli_sax == braldebulisSaxeli && br.braldebuli_gv == braldebulisGvari).ToList();
            
        }
        public static void FilterGrid(string saqmisnomer, string braldebulisSaxeli, List<EF.Braldebuli> braldebulebi, DataGrid grid)
        {
            

            grid.ItemsSource = braldebulebi.Where(br => br.Saqme.saqme_nomeri == saqmisnomer &&
             br.braldebuli_sax == braldebulisSaxeli ).ToList();

        }
        public static void FilterGrid(string saqmisnomer, List<EF.Braldebuli> braldebulebi, DataGrid grid)
        {
           

            grid.ItemsSource = braldebulebi.Where(br => br.Saqme.saqme_nomeri == saqmisnomer).ToList();

        }

        public static void FilterFrombraldebuli(string saxeli,string gvari,List<EF.Braldebuli> braldebulebi,DataGrid grid)
        {
            grid.ItemsSource = braldebulebi.Where(br => br.braldebuli_sax == saxeli && br.braldebuli_gv == gvari).ToList();
        }
        public static void FilterFrombraldebuli(string saxeli,List<EF.Braldebuli> braldebulebi,DataGrid grid,bool tagSaxeli)
        {
            if(tagSaxeli)
                grid.ItemsSource = braldebulebi.Where(br => br.braldebuli_sax == saxeli).ToList();
            else
                grid.ItemsSource = braldebulebi.Where(br => br.braldebuli_gv == saxeli).ToList();

        }
    }
}
