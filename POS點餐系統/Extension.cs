using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統
{
    internal static class Extension
    {
        //abc123 => 3,3
        //apple456 =>5,3

        /// <summary>
        /// 計算字串中數字和非數字數量
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static (int, int) CountLettersAndDigits(this string input, bool hasSymbol = true)
        {
            int letters = 0;
            int digits = 0;
            for (int i = 0; i < input.Length; i++)
            {
                letters = !Char.IsDigit(input[i]) ? letters + 1 : letters;
                digits = Char.IsDigit(input[i]) ? digits + 1 : digits;
            }

            return (letters, digits);
        }
    }
}
