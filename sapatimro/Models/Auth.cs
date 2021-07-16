using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sapatimro.EF;
namespace sapatimro.Models
{
    public class Auth
    {
        public static bool AuthJudge(string login,string passwd)
        {
            try
            {

            
            using(Model1 md = new Model1())
            {
                Judge judge = md.Judge.SingleOrDefault(jd => jd.judge_login == login && jd.judge_passwd == passwd);
                    if (judge != null)
                    {
                        State.JudgeName = new SPJudge()
                        {
                            FullName = judge.judge_name,
                            ID = judge.judge_id
                        };
                        return true;
                    }
                    else
                        return false;
            }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
