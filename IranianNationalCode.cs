using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    public static class IranianNationalCode
    {
        public static bool Check(string code)
        {
            if (Regex.IsMatch(code, @"^\d{10}$") && Regex.IsMatch(code, @"^(\d)(?!\1+$)\d{9}$"))
            {
                int contor = int.Parse(code.Substring(9, 1));
                int res = GetRes(code);
                return res <= 2 ? res == contor : (11 - res) == contor;
            }
            return false;
        }
        public static string Build(string codeCity)
        {
            string codeB = codeCity + new Random().Next(100000, 999999).ToString();
            int res = GetRes(codeB);
            string code = res <= 2 ? codeB + res : codeB + (11 - res);
            return Check(code) ? code : "Please Try Again";
        }
        private static int GetRes(string code)
        {
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (10 - i) * int.Parse(code.Substring(i, 1));
            return sum % 11;
        }
    }
}
