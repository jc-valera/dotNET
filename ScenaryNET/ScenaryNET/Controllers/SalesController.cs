using Jcvalera.Core.BLL;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ScenaryNET.Controllers
{
    public class SalesController : Controller
    {
        public SalesBLL SalesBLL;

        public SalesController()
        {
            SalesBLL = new SalesBLL();
        }

        // GET: Sales
        public async Task<ActionResult> Index()
        {
            var sales = await SalesBLL.GetSalesCustomer();

            return View(sales);
        }

        // GET: Sales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<FileResult> GetReportSalesCustomer()
        {
            var reportData = await SalesBLL.GetReportSalesCustomer();

            return File(reportData, "text/csv", "Report_Sales_Customer.xlsx");
        }

        public ActionResult SendReportSalesCustomer()
        {
            SalesBLL.SendEmailReport();

            return RedirectToAction("Index");
        }
    }
}
