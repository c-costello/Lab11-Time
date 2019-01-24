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
        /// <summary>
        /// Load homepage
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Send form input to results
        /// </summary>
        /// <param name="startYear">int</param>
        /// <param name="endYear">int</param>
        /// <returns>Redirect to Results</returns>
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            return RedirectToAction("Results", new { startYear, endYear });
        }

        /// <summary>
        /// Generate results and send to results page
        /// </summary>
        /// <param name="startYear">int</param>
        /// <param name="endYear">int</param>
        /// <returns></returns>
        public IActionResult Results(int startYear, int endYear)
        { 
            List<Person> people = Person.GetPersons(startYear, endYear);
            return View(people);
        }
    }
}
