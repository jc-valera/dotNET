using Jcvalera.Core.BLL;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudWebMvcDapper.Controllers
{
    public class UserController : Controller
    {
        public IUserBLL UserBLL;

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
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                await UserBLL.CreateUser(user);

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
                await UserBLL.UpdateUser(id, user);

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
