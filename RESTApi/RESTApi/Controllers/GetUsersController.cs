using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RESTApi.Models;

namespace RESTApi.Controllers
{
    public class GetUsersController : Controller
    {
        // GET: GetUsers
        [HttpGet]
        public ActionResult Index()
        {
            // To get all users

            IEnumerable<User> usersList;

            UserController user = new UserController();
            usersList = user.Get();

            return View(usersList);
        }

        // GET: GetUsers/SearchByUserId
        [HttpGet]
        public ActionResult SearchByUserId()
        {
            // Action to display the user input page

            return View();
        }

        // GET: GetUsers/GetSearchedUserId
        [HttpGet]
        public ActionResult GetSearchedUserId()
        {
            // Action to display the retrieved search list

            return View();
        }

        // POST: GetUsers/GetSearchedUserId
        [HttpPost]
        public ActionResult GetSearchedUserId(int id)
        {
            // Action to make the api call to get searched user by id

            UserController user = new UserController();

            return View(user.Get(id));
        }

        // GET: GetUsers/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GetUsers/Create
        [HttpPost]
        public ActionResult Create(User newUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserController user = new UserController();

                    // User id assignment: adds 1 onto the a count api call (total users in db + 1)
                    int count = user.GetTotalUserCount();
                    newUser.UserId = count + 1;

                    user.Create(newUser);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GetUsers/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            UserController user = new UserController();
            User editUser = user.FindUserToEdit(id);

            if (editUser == null)
            {
                return HttpNotFound();
            }

            return View(editUser);
        }

        // POST: GetAllUsers/Edit/5
        [HttpPost]
        public ActionResult Edit(User editUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserController user = new UserController();
                    user.EditUser(editUser);
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
