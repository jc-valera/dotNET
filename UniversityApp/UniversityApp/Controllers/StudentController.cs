using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Core.Common.Entities;
using University.Core.Common.Services;

namespace UniversityApp.Controllers
{
    public class StudentController : Controller
    {
        public IStudentBLL StudentBLL;

        public IEnumerable<Genders> Genders;
        public IEnumerable<Carrers> Carrers;
        public IEnumerable<MaximunLevelStudies> LevelStudies;
        public IEnumerable<CivilStatus> CivilStatus;
        public IEnumerable<StudentStatus> StudenStatus;

        public StudentController(IStudentBLL studentBLL)
        {
            StudentBLL = studentBLL;
        }

        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            await GetValuesCatalogs();

            var students = await StudentBLL.GetAllStudents();

            return View(students);
        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            await GetValuesCatalogs();

            var student = await StudentBLL.GetStudent(id);

            return View(student);
        }

        // GET: StudentController/Create
        public async Task<ActionResult> Create()
        {
            await GetValuesCatalogs();

            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student student)
        {
            try
            {
                await StudentBLL.SaveStudent(student);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            await GetValuesCatalogs();

            var student = await StudentBLL.GetStudent(id);

            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student student)
        {
            try
            {
                await StudentBLL.UpdateStudent(id, student);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await GetValuesCatalogs();

            var student = await StudentBLL.GetStudent(id);

            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Student student)
        {
            try
            {
                await StudentBLL.DeleteStudent(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task GetValuesCatalogs()
        {
            Genders = await StudentBLL.GetAllGenders();
            Carrers = await StudentBLL.GetAllCarrers();
            LevelStudies = await StudentBLL.GetAllMaximunLevelStudies();
            CivilStatus = await StudentBLL.GetAllCivilStatus();
            StudenStatus = await StudentBLL.GetAllStudentStatus();

            ViewBag.Genders = Genders;
            ViewBag.Carrers = Carrers;
            ViewBag.LevelStudies = LevelStudies;
            ViewBag.CivilStatus = CivilStatus;
            ViewBag.StudentStatus = StudenStatus;
        }
    }
}
