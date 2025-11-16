using Microsoft.AspNetCore.Mvc;
using AspNetMvcDemo.Models;

namespace AspNetMvcDemo.Controllers
{
    public class FormController : Controller
    {
        // GET /Form/Index
        public IActionResult Index()
        {
            ViewBag.Message = "Please complete the form and press Submit.";
            return View();
        }

        // POST /Form/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(FormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            // Store Name and Age using TempData (1 redirect lifetime)
            TempData["SubmittedName"] = model.Name;
            TempData["SubmittedAge"] = model.Age;

            // Store Language using Session (persists for user session)
            HttpContext.Session.SetString("LastLanguage", model.FavoriteLanguage ?? "");

            // Redirect (Post-Redirect-Get)
            return RedirectToAction("Result");
        }

        // GET /Form/Result
        public IActionResult Result()
        {
            ViewBag.Name = TempData["SubmittedName"] as string ?? "(no name submitted)";
            ViewBag.Age = TempData["SubmittedAge"]?.ToString() ?? "(no age submitted)";
            ViewBag.Language = HttpContext.Session.GetString("LastLanguage") ?? "(no language stored)";

            return View();
        }
    }
}
