using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF = sapatimro.EF;
namespace sapatimro.Models
{
    public delegate void CorectBraldebuli(EF.Braldebuli braldebuli);
    public class State
    {
        public static SPJudge JudgeName {get;set;}
        public static readonly int SPDay = 60;
        public static readonly int LeftDays = 15;
        public static List<string> Shedegi = new List<string>()
        {
            "შეეფარდა გირაო"
        };
        public static readonly string Title = "პატიმრობის გადასინჯვის პროგრამა";
        public static int CompareDate(EF.Braldebuli br1,EF.Braldebuli br2)
        {
            return br1.gadasingva.CompareTo(br2.gadasingva);
        }
        
    }
}
