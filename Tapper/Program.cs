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

        public static string Div17(string num)
        {
            if (!CheckNum(num))
                return "error: wrong number";
            StringBuilder res = new StringBuilder();
            int rem = int.Parse(num[0].ToString());

            for (int i = 1; i < num.Length; i++)
            {
                int current = int.Parse(num[i].ToString()) + rem * 10;
                res.Append(current / 17);
                rem = current % 17;
            }

            return res.ToString();
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

        /// <summary>
        /// Проверка числа в строковом формате на наличие сторонних элементов
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static bool CheckNum(string num)
        {
            foreach (char c in num)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static string ToFormat106x17(string num)
        {
            int need = 1802 - num.Length;
            if (need == 0)
                return num;
            StringBuilder res = new StringBuilder();
            return res.Append('0', need).Append(num).ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Div17("88002000600"));
        }
    }
}
