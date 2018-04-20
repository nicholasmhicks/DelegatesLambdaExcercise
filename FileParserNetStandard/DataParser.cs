using System.Collections.Generic;
using System.Linq;

namespace FileParserNetStandard {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {

            List<List<string>> newlist = new List<List<string>>();

            foreach (var items in data)
            {
                for (var i = 0;i < items.Count();i++)
                {
                    items[i] = items[i].Trim();
                }
            }

            return data;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {
            List<List<string>> newlist = new List<List<string>>();

            foreach (var items in data)
            {
                for (var i = 0; i < items.Count(); i++)
                {
                    items[i] = items[i].Trim('"');
                }
            }
            return data;
        }

    }
}