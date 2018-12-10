using Microsoft.AspNet.Identity;
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
        public ActionResult Index()
        {
            var service = CreateTeamService();
            var model = service.GetTeams();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateTeamService();

            if (service.CreateTeam(model))
            {
                TempData["SaveResult"] = "Your Team was updated.";

                return RedirectToAction("Index");
            }
            return View(model);
        }

        private TeamService CreateTeamService()
        {
            var teamId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamService(teamId);
            return service;
        }


        public ActionResult Details(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateTeamService();
            var detail = service.GetTeamById(id);
            var model =
                new TeamEdit
                {
                    TeamId = detail.TeamId,
                    TeamName = detail.TeamName,
                    TeamCity = detail.TeamCity,
                    TeamConference = detail.TeamConference,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeamEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TeamId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTeamService();

            if (service.UpdateTeam(model))
            {
                TempData["SaveResult"] = "Your team was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your team could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTeamService();

            service.DeleteTeam(id);

            TempData["SaveResult"] = "Your team was deleted";

            return RedirectToAction("Index");
        }
    }
}