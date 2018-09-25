using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapper
{
    class Program
    {
        /// <summary>
        /// Делит число любого размера на 2, возвращает пару: частное и остаток
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static (string, string) Div2(string num)
        {
            StringBuilder res = new StringBuilder();
            int rem = num[0] == '1' ? 1 : 0;

            for (int i = rem; i < num.Length; i++)
            {
                int current = int.Parse(num[i].ToString());
                res.Append((current + rem * 10) / 2);
                rem = current % 2;
            }
            return (res.ToString(), rem.ToString());
        }

        /// <summary>
        /// Возвращает двоичное число в строковом формате бесконечно большого числа, записанного в строковом формате в 10-й системе счисления
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ConvertToBinary(string num)
        {
            if (!CheckNum(num))
                return "error: wrong number";
            StringBuilder res = new StringBuilder();
            string rem = "";
            while(num.Length > 0)
            {
                (num, rem) = Div2(num);
                res.Append(rem);
            }
            int halfLength = res.Length / 2;
            for (int i = 0; i < halfLength; i++)
            {
                char t = res[i];
                res[i] = res[res.Length - 1 - i];
                res[res.Length - 1 - i] = t;
            }
            return res.ToString();
        }

        private static bool CheckNum(string num)
        {
            foreach (char c in num)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            var t1 = DateTime.Now;
            Console.WriteLine(ConvertToBinary("4858487703217654168507377107565676789145697178497253677539145555247620343537955749299116772611982962556356527603203744742682135448820545638134012705381689785851604674225344958377377969928942310236199337805399065932982909660659786056259547094494380793146587709009524498386724160055692719747815828234655968636671461350354316223620304956111171025410498514602810746287134775641383930152393933036921599511277388743068766568352667661462097979110006690900253037600818522726237351439443865433159187625289316917268254866954663750093103703327097252478959"));
            Console.WriteLine(DateTime.Now - t1);
        }
    }
}
