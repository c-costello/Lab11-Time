using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimePersonApp.Models
{
    public class Person
    {
        public string Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }



        public static List<Person> GetPersons(int startYear, int endYear)
        {
            string csvData = System.IO.File.ReadAllText("C:/Users/clari/source/repos/Lab11-Time/TimePersonApp/TimePersonApp/wwwroot/personOfTheYear.csv");
            List<string> list = new List<string>();
            foreach (var line in csvData.Split('\n'))
            {
                list.Add(line);
            }
            list.RemoveAt(0);
            List<Person> people = new List<Person>();
            foreach (var line in list)
            {

                Person person = new Person();
                person.Year = line.Split(',')[0];
                person.Honor = line.Split(',')[1];
                person.Name = line.Split(',')[2];
                person.Country = line.Split(',')[3];
                person.BirthYear = line.Split(',')[4];
                person.DeathYear = line.Split(',')[5];
                person.Title = line.Split(',')[6];
                person.Category = line.Split(',')[7];
                person.Context = line.Split(',')[8];


                if (Convert.ToInt32(person.Year) >= startYear && Convert.ToInt32(person.Year) <= endYear)
                {
                    people.Add(person);
                }

            }
            return people;
        }
    }
}
