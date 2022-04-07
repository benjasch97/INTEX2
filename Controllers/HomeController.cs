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
        public IActionResult Accidents(Nullable<float> motorcycle, Nullable<float> pedestrian, Nullable<float> overturn,
            Nullable<float> bicyclist, Nullable<float> unrestrained, Nullable<float> intersection, Nullable<float> dui,
            Nullable<float> night, Nullable<float> roadwaydeparture, Nullable<float> singlevehicle, int pageNum = 1)
        {
            int pageSize = 25000;

            var x = new AccidentsViewModel
            {
                mytable = _repo.mytable
                    .Where(a => a.MOTORCYCLE_INVOLVED == motorcycle || motorcycle == null)
                    .Where(a => a.PEDESTRIAN_INVOLVED == pedestrian || pedestrian == null)
                    .Where(a => a.OVERTURN_ROLLOVER == overturn || overturn == null)
                    .Where(a => a.BICYCLIST_INVOLVED == bicyclist || bicyclist == null)
                    .Where(a => a.UNRESTRAINED == unrestrained || unrestrained == null)
                    .Where(a => a.INTERSECTION_RELATED == intersection || intersection == null)
                    .Where(a => a.DUI == dui || dui == null)
                    .Where(a => a.NIGHT_DARK_CONDITION == night || night == null)
                    .Where(a => a.ROADWAY_DEPARTURE == roadwaydeparture || roadwaydeparture == null)
                    .Where(a => a.SINGLE_VEHICLE == singlevehicle || singlevehicle == null)
                    .OrderBy(a => a.YEAR)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumAccidents = _repo.mytable
                        .Where(a => a.MOTORCYCLE_INVOLVED == motorcycle || motorcycle == null)
                        .Where(a => a.PEDESTRIAN_INVOLVED == pedestrian || pedestrian == null)
                        .Where(a => a.OVERTURN_ROLLOVER == overturn || overturn == null)
                        .Where(a => a.BICYCLIST_INVOLVED == bicyclist || bicyclist == null)
                        .Where(a => a.UNRESTRAINED == unrestrained || unrestrained == null)
                        .Where(a => a.INTERSECTION_RELATED == intersection || intersection == null)
                        .Where(a => a.DUI == dui || dui == null)
                        .Where(a => a.NIGHT_DARK_CONDITION == night || night == null)
                        .Where(a => a.ROADWAY_DEPARTURE == roadwaydeparture || roadwaydeparture == null)
                        .Where(a => a.SINGLE_VEHICLE == singlevehicle || singlevehicle == null)
                        .Count(),
                    AccidentsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        [HttpPost]
        public IActionResult Accidents(Nullable<float> motorcycle, Nullable<float> pedestrian, Nullable<float> overturn,
            Nullable<float> bicyclist, Nullable<float> unrestrained, Nullable<float> intersection, Nullable<float> dui,
            Nullable<float> night, Nullable<float> roadwaydeparture, Nullable<float> singlevehicle)
        {
            return RedirectToAction("Accidents", new 
            { 
                motorcycle = motorcycle,
                pedestrian = pedestrian,
                overturn = overturn,
                bicyclist = bicyclist,
                unrestrained = unrestrained,
                intersection = intersection,
                dui = dui,
                night = night,
                roadwaydeparture = roadwaydeparture,
                singlevehicle = singlevehicle
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
