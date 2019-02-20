using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanThatCode.Community.Common
{
    // Your job is to implement this class
    public static class StringHelpers
    {
        // Instead of spaces it should be separated with dots, e.g. Hello World -> Hello.World
        public static string ToDotSeparatedString(this string str)
        {   
            str = str.Replace(" ", ".");
            return str;
        }
        
        // All words in the string should be capitalized, e.g. teenage mutant ninja turtles -> Teenage Mutant Ninja Turtles
        public static string CapitalizeAllWords(this string str)
        {
            var split = str.Split(' ');
            List<String> li = new List<String>();

            foreach(string s in split)
            {
                li.Add(char.ToUpper(s[0]) + s.Substring(1));
            }
            str = String.Join(" ", li);
            return str;
        }

        // The words should be reversed in the string, e.g. Hi Ho Silver Away! -> Away! Silver Ho Hi
        public static string ReverseWords(this string str)
        {
            return String.Join(" ", str.Split(' ').Reverse());
        }
    }
}