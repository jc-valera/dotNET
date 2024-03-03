using Jcvalera.Core.BLL;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudWebMvcEntity.Controllers
{
    public class UserController : Controller
    {
        //private UserBLL UserBLL;

        //public UserController(UserBLL userBLL)
        //{
        //    UserBLL = userBLL;
        //}

        private IUserBLL UserBLL;

        public UserController(IUserBLL userBLL)
        {
            UserBLL = userBLL;
        }

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var users = await UserBLL.GetAllUsers();

            return View(users);
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var user = await UserBLL.GetUser(id);

            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User collection)
        {
            try
            {
                await UserBLL.CreateUser(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await UserBLL.GetUser(id);

            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, User user)
        {
            try
            {
                await UserBLL.UpdateUser(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var user = await UserBLL.GetUser(id);

            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await UserBLL.DeleteUser(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
