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
            if (!CheckNum(num))
                return ("error: wrong number", "error");
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
        /// Делит число любого размера на 17
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
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
        public static string ConvertToBinaryReverse(string num)
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
            //Открыть, для нормального преобразования: 8 -> 1000
            //int halfLength = res.Length / 2;
            //for (int i = 0; i < halfLength; i++)
            //{
            //    char t = res[i];
            //    res[i] = res[res.Length - 1 - i];
            //    res[res.Length - 1 - i] = t;
            //}
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

        /// <summary>
        /// Печать бинарного числа 106 х 17
        /// </summary>
        /// <param name="bin"></param>
        public static void PrintPic(string bin)
        {
            if (bin.Length != 1802)
                Console.WriteLine("error: bin count != 1802");

            for (int i = 16; i >= 0; i--)
            {
                for (int j = 0; j < 106; j++)
                {
                    Console.Write(bin[i + 17 * j] == '1' ? "█" : " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Добавляет нули спереди к бинарному числу до длины 1802 знака
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ToFormat106x17(string num)
        {
            int need = 1802 - num.Length;
            if (need == 0)
                return num;
            if (need < 0)
                return "error: num > 1802";
            StringBuilder res = new StringBuilder();
            return res.Append('0', need).Append(num).ToString();
        }

        static void Main(string[] args)
        {
            Console.WindowWidth = 107;
            string pic = ConvertToBinaryReverse(Div17("4858450636189713423582095962494202044581400587983244549483093085061934704708809928450644769865524364849997247024915119110411605739177407856919754326571855442057210445735883681829823754139634338225199452191651284348332905131193199953502413758765239264874613394906870130562295813219481113685339535565290850023875092856892694555974281546386510730049106723058933586052544096664351265349363643957125565695936815184334857605266940161251266951421550539554519153785457525756590740540157929001765967965480064427829131488548259914721248506352686630476300"));
            PrintPic(pic);
        }
    }
}
