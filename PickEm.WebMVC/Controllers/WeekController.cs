using Microsoft.AspNet.Identity;
using PickEm.Models.WeekModels;
using PickEm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickEm.WebMVC.Controllers
{
    [Authorize]
    public class WeekController : Controller
    {
        // GET: Week
        public ActionResult Index()
        {
            var service = CreateWeekService();
            var model = service.GetWeeks();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WeekCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateWeekService();

            if (service.CreateWeek(model))
            {
                TempData["SaveResult"] = "Your week was updated.";

                return RedirectToAction("Index");
            }
            return View(model);
        }

        private WeekService CreateWeekService()
        {
            var weekId = Guid.Parse(User.Identity.GetUserId());
            var service = new WeekService(weekId);
            return service;
        }

        private PlayerService CreatePlayerService()
        {
            var playerId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayerService(playerId);
            return service;
        }


        public ActionResult Details(int id)
        {
            var svc = CreateWeekService();
            var model = svc.GetWeekById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateWeekService();
            var detail = service.GetWeekById(id);
            var model =
                new WeekEdit
                {
                    WeekId = detail.WeekId,
                    SeasonNumber = detail.SeasonNumber,
                    SeasonWeek = detail.SeasonWeek,
                    StadiumName = detail.StadiumName,
                    PlayerId = detail.PlayerId,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WeekEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WeekId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateWeekService();

            if (service.UpdateWeek(model))
            {
                TempData["SaveResult"] = "Your week was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your week could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWeekService();
            var model = svc.GetWeekById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateWeekService();

            service.DeleteWeek(id);

            TempData["SaveResult"] = "Your week was deleted";

            return RedirectToAction("Index");
        }
    }
}