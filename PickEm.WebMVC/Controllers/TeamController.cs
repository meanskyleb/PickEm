using PickEm.Models.TeamModels;
using PickEm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickEm.WebMVC.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        //// GET: Team
        //public ActionResult Index()
        //{
        //    var model = new TeamListItem[0];
        //    return View();
        //}

        ////GET
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public ActionResult Create(TeamCreate model)
        //{
        //    if (!ModelState.IsValid) return View(model);


        //    var service = CreateTeamService();

        //    if (service.CreateTeam(model))
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        //private TeamService CreateTeamService()
        //{
        //    var teamId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new TeamService(teamId);
        //    return service;
        //}

        //public ActionResult Details(int id)
        //{
        //    var svc = CreateTeamService();
        //    var model = svc.GetTeamById(id);

        //    return View(model);
        //}
    }
}