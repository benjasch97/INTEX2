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
        public IActionResult Accidents(Nullable<float> motorcycle, int pageNum = 1)
        {
            int pageSize = 25000;

            //ViewBag.Months = _repo.mytable
            //    .Select(x => x.MONTH)
            //    .Distinct()
            //    .ToList();

            //ViewBag.Weekdays = _repo.mytable
            //    .Select(x => x.DAY_OF_WEEK)
            //    .Distinct()
            //    .ToList();

            //ViewBag.Hours = _repo.mytable
            //    .Select(x => x.HOUR)
            //    .Distinct()
            //    .OrderBy(x => x)
            //    .ToList();

            var x = new AccidentsViewModel
            {
                mytable = _repo.mytable
                    .Where(a => a.MOTORCYCLE_INVOLVED == motorcycle || motorcycle == null)
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
        public IActionResult Accidents(float motorcycle)
        {
            return RedirectToAction("Accidents", new 
            { 
                motorcycle = motorcycle
            });
        }

        public IActionResult Predictor()
        {
            return View();
        }


        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
