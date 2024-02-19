using Jcvalera.Core.BLL;
using Jcvalera.Core.Common.Entities;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CrudWebMvcFramework.Controllers
{
    public class UserController : Controller
    {
        private UserBLL userBLL;

        public UserController()
        {
            userBLL = new UserBLL();
        }

        // GET: User
        public async Task<ActionResult> Index()
        {
            var users = await userBLL.GetUsers();

            return View(users);
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var user = await userBLL.GetUser(id);

            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: User/Create
        [HttpPost]
        public async Task<ActionResult> Create(User collection)
        {
            try
            {
                // TODO: Add insert logic here
                await userBLL.CreateUser(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await userBLL.GetUser(id);

            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, User collection)
        {
            try
            {
                // TODO: Add update logic here
                await userBLL.UpdateUser(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var user = await userBLL.GetUser(id);

            return View(user);
        }

        //POST: User/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                await userBLL.DeleteUser(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
