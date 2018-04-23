using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ObjectLibrary;

namespace FileParserNetStandard {

    public class PersonHandler {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people)
        {
            People = new List<Person>();
            foreach (var items in people.Skip(1))
            {
                Person vNew = new Person(Int32.Parse(items[0]), items[1], items[2], new DateTime(Int64.Parse(items[3])));
                this.People.Add(vNew);
            }
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest()
        {
            List<Person> newList = this.People.Where(x => x.Dob == 
            this.People.OrderBy(
                z => z.Dob)
                .First()
                .Dob)
                .ToList();
            return newList; //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id)
        {
            return People.Find(x => x.Id == id)
                .ToString();  //-- return result here
        }

        public List<Person> GetOrderBySurname() {
            List<Person> newList = this.People.OrderBy(x => x.Surname).ToList();
            return newList;  //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive)
        {
            return this.People.Where(
                x => x.Surname
                .StartsWith(searchTerm, !caseSensitive, null))
                .ToList()
                .Count();  //-- return result here
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate()
        {
            List<string> result = new List<string>();

            this.People
                .OrderBy(x => x.Dob)
                .GroupBy(y => y.Dob).ToList()
                .ForEach(z => result.Add(z.Key + "\t" + z.Count()));

            return result;  //-- return result here
        }
    }
}