using Microsoft.AspNet.Identity;
using PickEm.Models;
using PickEm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickEm.WebMVC.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        // GET: Player
        public ActionResult Index()
        {
            var service = CreatePlayerService();
            var model = service.GetPlayers();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            

            var service = CreatePlayerService();

            if (service.CreatePlayer(model))
            {
                TempData["SaveResult"] = "Your Player was updated.";

                return RedirectToAction("Index");
            }
            return View(model);
        }

        private PlayerService CreatePlayerService()
        {
            var playerId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayerService(playerId);
            return service;
        }

       
        public ActionResult Details(int id)
        {
            var svc = CreatePlayerService();
            var model = svc.GetPlayerById(id);
            
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreatePlayerService();
            var detail = service.GetPlayerById(id);
            var model =
                new PlayerEdit
                {
                    PlayerId = detail.PlayerId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    GroupName = detail.GroupName,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlayerEdit model)
        {
            if(!ModelState.IsValid) return View(model);

            if(model.PlayerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePlayerService();

            if (service.UpdatePlayer(model))
            {
                TempData["SaveResult"] = "Your Player was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Player could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlayerService();
            var model = svc.GetPlayerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlayerService();

            service.DeletePlayer(id);

            TempData["SaveResult"] = "Your player was deleted";

            return RedirectToAction("Index");
        }
    }
}