using System;
using System.Collections.Generic;
using System.Diagnostics;
using FileParserNetStandard;
using System.IO;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise {


    public class CsvHandler
    {

        /// <summary>
        /// Takes a list of list of strings applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler)
        {
            FileHandler fh = new FileHandler();

            var data = fh.ReadFile(readFile);

            List<List<string>> data2 = fh.ParseCsv(data);

            fh.WriteFile(writeFile, ',', dataHandler(data2));
        }
        public void CapitaliseCsv(string readFile, string writeFile, Parser parser)
        {
            DataParser dp = new DataParser();

            FileHandler fh = new FileHandler();

            var data = fh.ReadFile(readFile);

            parser += dp.StripQuotes;
            parser += dp.StripWhiteSpace;



        }

        public List<List<string>> Capitalise(List<List<string>> data)
        {
            foreach (var items in data)
            {
                for (var i = 0; i < items.Count; i++)
                {
                    items[i] = items[i].ToUpper();
                }
            }
            return data;
        }
    }
}