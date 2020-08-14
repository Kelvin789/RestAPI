using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RESTApi.Models;

namespace RESTApi.Controllers
{
    public class GetLeaderboardController : Controller
    {
        // GET: GetLeaderboard
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Leaderboard> leaderboardList;

            LeaderboardController leaderboard = new LeaderboardController();
            leaderboardList = leaderboard.Get();

            return View(leaderboardList);
        }

        // GET: GetLeaderboard/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GetLeaderboard/Create
        [HttpPost]
        public ActionResult Create(Leaderboard newEntry)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LeaderboardController leaderboard = new LeaderboardController();
                    leaderboard.Create(newEntry);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GetLeaderboard/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            LeaderboardController leaderboard = new LeaderboardController();
            Leaderboard editEntry = leaderboard.FindEntryToEdit(id);

            if (editEntry == null)
            {
                return HttpNotFound();
            }

            return View(editEntry);
        }

        // POST: GetLeaderboard/Edit/5
        [HttpPost]
        public ActionResult Edit(Leaderboard editEntry)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LeaderboardController leaderboard = new LeaderboardController();
                    leaderboard.EditEntry(editEntry);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
