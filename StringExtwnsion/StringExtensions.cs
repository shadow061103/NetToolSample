using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class StringExtensions
    {
        /// <summary>
        /// 轉全形的函數(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(this string input)
        {
            //半形轉全形：
            char[] charArray = input.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == 32)
                {
                    charArray[i] = (char)12288;
                    continue;
                }
                if (charArray[i] < 127)
                    charArray[i] = (char)(charArray[i] + 65248);
            }
            return new string(charArray);
        }

        /// <summary>
        /// 全形空格為12288，半形空格為32
        /// 其他字元半形(33-126)與全形(65281-65374)的對應關係是：均相差65248
        /// ’的ascii code為8217 轉換為'(39)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToDBC(this string input)
        {
            var charArray = input.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == 12288)
                {
                    charArray[i] = (char)32;
                    continue;
                }
                if (charArray[i] == 8217)
                {
                    charArray[i] = (char)39;
                    continue;
                }
                if (charArray[i] > 65280 && charArray[i] < 65375)
                    charArray[i] = (char)(charArray[i] - 65248);
            }
            return new string(charArray);
        }
    }
}