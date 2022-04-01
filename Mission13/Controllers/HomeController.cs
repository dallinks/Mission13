using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlerRepository _repo { get; set; }
        public HomeController(IBowlerRepository temp)
        {   
            _repo = temp;
        }
        public IActionResult Index(int? teams)
        {
            var bowlers = _repo.Bowlers.Where(x => x.TeamID == teams || teams == null);
            if (teams != null)
            {
                ViewBag.Team = _repo.Teams.FirstOrDefault(x => x.TeamID == teams).TeamName;
            }
            return View(bowlers);
        }
        [HttpGet]
        public IActionResult Add()
        {
            
            return View(new Bowler());
        }
        [HttpPost]
        public IActionResult Add(Bowler b)
        {
            var li = new List<int>();
            foreach(Bowler bo in _repo.Bowlers)
            {
                li.Add(bo.BowlerID);
            }
            b.BowlerID = li.Max() + 1;
            _repo.AddBowler(b);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == id);

            return View("Add",bowler);
        }
        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _repo.EditBowler(b);
            int teams = b.TeamID;
            return RedirectToAction("Index", teams);
        }
        public IActionResult Delete(int id)
        {
            var b = _repo.Bowlers.FirstOrDefault(x => x.BowlerID == id);
            _repo.DeleteBowler(b);
            return RedirectToAction("Index");
        }
    }
}
