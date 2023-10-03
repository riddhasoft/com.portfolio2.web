using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.portfolio2.web.Controllers
{
    public class RWController : Controller
    {
        // GET: RWController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RWController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RWController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RWController/Create
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

        // GET: RWController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RWController/Edit/5
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

        // GET: RWController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RWController/Delete/5
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
