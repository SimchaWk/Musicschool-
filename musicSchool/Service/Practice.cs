using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace musicSchool.Service
{
    internal static class Practice
    {
         // 0:
        public static  Func<string, bool> IsStartWith_a = (x) => x[0] == 'a';
        // 1:
        public static  Func<List<string>, bool> IsAnyStartWith_a = 
            (list) => (from str in  list where str[0] == 'a' select str).Any();
        // 2:
        public static Func<List<string>, bool> IsAnyEmptyString = 
            (list) => (from str in list where string.IsNullOrEmpty(str) select str).Any();
        // 3:
        public static Func<List<string>, bool> IsAllcontain_a =
            (list) => list.All(str => str.Contains('a'));
        // 4:
        public static Func<List<string>, List<string>> ListToUpper =
            (list) => list.Select(str => str.ToUpper()).ToList();
        // 5:
        public static Func<List<string>, List<string>> ListToUpperQuery =
            (list) => (from str in list select str.ToUpper()).ToList();
        // 6:
        /*public static Func<List<string>, List<string>> ListLenThreeOrMore = 
            (list) => (from str in list select str)*/
    }
}
