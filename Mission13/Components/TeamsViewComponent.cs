using Microsoft.AspNetCore.Mvc;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlerRepository repo { get; set; }
        public TeamsViewComponent (IBowlerRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            if((string)(RouteData?.Values["teams"]) == null)
            {
                ViewBag.TeamName = null;
            }
            else
            {
                ViewBag.TeamName = Int16.Parse((string)(RouteData?.Values["teams"]));

            }
            var teams = repo.Teams
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            return View(teams);
        }
    }
}
