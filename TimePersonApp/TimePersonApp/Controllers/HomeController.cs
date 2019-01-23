using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimePersonApp.Models;

namespace TimePersonApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string startYear, string endYear)
        {
            return RedirectToAction("Results", new { startYear, endYear });
        }

        public IActionResult Results(int startYear, int endYear)
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
            return View(people);
        }
    }
}
