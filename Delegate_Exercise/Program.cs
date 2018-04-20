using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;

namespace Delegate_Exercise {
 
    
    internal class Delegate_Exercise
    {
        public static void Main(string[] args)
        {

            DataParser dp = new DataParser();

            Func<List<List<string>>, List<List<string>>> process = dp.StripQuotes;

            process += dp.StripWhiteSpace;
            process += StripHash;

            CsvHandler csv = new CsvHandler();

            csv.ProcessCsv("/Users/STUDENT/Desktop/delegates/data.csv", "/Users/STUDENT/Desktop/delegates/processed_data.csv", process);
        }

        public static List<List<string>> StripHash(List<List<string>> data)
        {
            List<List<string>> newlist = new List<List<string>>();

            foreach (var items in data)
            {
                List<string> vList = new List<string>();

                foreach (var item in items)
                    vList.Add(item.Trim('#'));
                newlist.Add(vList);
            }
            return newlist;
        }
    }
}