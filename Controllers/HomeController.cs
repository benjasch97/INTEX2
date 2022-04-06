using INTEX2.Models;
using INTEX2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Controllers
{
    public class HomeController : Controller
    {
        private IAccidentsRepository _repo { get; set; }

        public HomeController(IAccidentsRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Accidents(string month, string day, Nullable<int> hour, int pageNum = 1)
        {
            int pageSize = 25000;

            ViewBag.Months = _repo.mytable
                .Select(x => x.MONTH)
                .Distinct()
                .ToList();

            ViewBag.Weekdays = _repo.mytable
                .Select(x => x.DAY_OF_WEEK)
                .Distinct()
                .ToList();

            ViewBag.Hours = _repo.mytable
                .Select(x => x.HOUR)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var x = new AccidentsViewModel
            {
                mytable = _repo.mytable
                    .Where(a => a.MONTH == month || month == null)
                    .Where(a => a.DAY_OF_WEEK == day || day == null)
                    .Where(a => a.HOUR == hour || hour == null)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumAccidents = _repo.mytable.Count(),
                    AccidentsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        [HttpPost]
        public IActionResult Accidents(string month, string day, Nullable<int> hour)
        {
            return RedirectToAction("Accidents", new 
            { 
                month = month,
                day = day,
                hour = hour
            });
        }

        public IActionResult Predictor()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
