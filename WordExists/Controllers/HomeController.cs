using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WordExists.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public JsonResult WordExists(string word)
        {
            var hashSet = (HashSet<string>) HttpContext.Cache["ordliste"];
            var res = new Response
                {
                    IsValid = hashSet.Contains(word),
                    Word = word
                };
            return
                Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Les()
        {
            var path = HttpContext.Server.MapPath("~/App_Data/ordliste.sql");
            var file = new StreamReader(path);
            var ordliste = new HashSet<string>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                ordliste.Add(line.Split(',')[1].Trim());
            }
            HttpContext.Cache.Insert("ordliste", ordliste);
            return null;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
    public class Response
    {
        public bool IsValid { get; set; }
        public string Word { get; set; }
    }
}
