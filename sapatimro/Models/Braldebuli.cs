using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sapatimro.Models
{
   public class Braldebuli
    {
        public int BraldebuliID { get; private set; }
        public string Name { get; private set; }

        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Mname { get; set; }
        public string SqNumber { get; private set; }
        public string Shenishvna { get; private set; }
        public DateTime CinaSS { get; private set; }
        public Braldebuli(int id,string fname,string lname, string sqnumber,DateTime csstarigi)
        {
            Fname = fname;
            Lname = lname;
            Name = $"{Fname} {lname}";
            SqNumber = sqnumber;
            BraldebuliID = id;
            
        }
      
        public string BoloArsebitiSxdoma
        {
           /* get
            {
                if(Sq.arsebitiGanxilva.Count > 0)
                {
                    return Sq.arsebitiGanxilva.Last().ToString("d", CultureInfo.CreateSpecificCulture("ka-GE"));
                }
                return "";
            }
           */
           get { return "dsfa"; }
        }
        public int ArsebititDamateba(DateTime dt)
        {
            /* if (Sq.arsebitisDamateba(dt) == 1)
             {
                 Shenishvna = Sq.Gamotvla();
                 return 1;
             }
             return 0;*/
            return 0;
        }
        public List<DateTime> Arebitebi()
        {
            throw new Exception("exxx");
        }
    }
}
