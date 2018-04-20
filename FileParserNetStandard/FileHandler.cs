using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FileParserNetStandard {
    public class FileHandler {
       
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) {

            return File.ReadAllLines(filePath).ToList<string>();

        }

        
        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows)
        {
            List<string> data = new List<string>();

            string line = "";

            foreach (var items in rows)
            {
                foreach (var item in items)
                {
                    line += item + delimeter;
                }
                line = line.Trim(delimeter);
                data.Add(line);
                line = "";
            }
            File.WriteAllLines(filePath, data);
        }
        
        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimeter)
        {
           List<List<string>> biglist = new List<List<string>>();

           foreach (var item in data)
                biglist.Add(item.Split(delimeter).ToList());

            return biglist;
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data)
        {
            List<List<string>> biglist = new List<List<string>>();

            foreach (var item in data)
                biglist.Add(item.Split(',').ToList());

            return biglist;
        }
    }
}