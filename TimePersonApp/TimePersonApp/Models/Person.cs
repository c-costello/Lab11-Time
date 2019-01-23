using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

namespace TimePersonApp.Models
{
    public class Person
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }



        public static List<Person> GetPersons(int startYear, int endYear)
        {
            string path = "~/wwwroot/personsOfTheYear.csv";
            string csvData = File.ReadAllText("C:/Users/clari/source/repos/Lab11-Time/TimePersonApp/TimePersonApp/wwwroot/personOfTheYear.csv");
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
                string year = line.Split(',')[0];
                if (year == "")
                {
                    person.Year = 0;
                } else
                {
                    person.Year = Convert.ToInt32(year);
                }
                person.Honor = line.Split(',')[1];
                person.Name = line.Split(',')[2];
                person.Country = line.Split(',')[3];
                year = line.Split(',')[4];
                if (year == "")
                {
                    person.BirthYear = 0;
                }
                else
                {
                    person.BirthYear = Convert.ToInt32(year);
                }
                year = line.Split(',')[5];
                if (year == "")
                {
                    person.DeathYear = 0;
                }
                else
                {
                    person.DeathYear = Convert.ToInt32(year);
                }
                person.Title = line.Split(',')[6];
                person.Category = line.Split(',')[7];
                person.Context = line.Split(',')[8];

                if(person.Year >= startYear && person.Year <= endYear)
                {
                    people.Add(person);
                }
            }

            return people;
        }
    }
}
