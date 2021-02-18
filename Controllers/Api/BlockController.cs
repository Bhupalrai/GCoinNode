using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GcoinNode.Controllers
{
    public class BlockController : Controller
    {
        // GET: BlockController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BlockController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlockController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlockController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlockController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlockController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlockController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlockController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
