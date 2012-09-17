using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace WordExists.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            return View(homeViewModel);
        }

        public JsonResult WordExists(string word, string randomWord)
        {
            var hashSet = GetCachedWords();
            var res = new WordResponse
                {
                    IsValid = hashSet.Contains(word),
                    Word = word,
                    RandomWord = randomWord
                };
            res.IsContained = RandomString.WordIsContainedInSequence(word, randomWord);
            return
                Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        private HashSet<string> GetCachedWords()
        {
            if (HttpContext.Cache["ordliste"] == null) {
                ReadWordsIntoCache();
            }
            return (HashSet<string>) HttpContext.Cache["ordliste"];
        }

        private void ReadWordsIntoCache()
        {
            var path = HttpContext.Server.MapPath("~/App_Data/ordliste.sql");
            var file = new StreamReader(path);
            var ordliste = new HashSet<string>();
            string line;
            while ((line = file.ReadLine()) != null) {
                ordliste.Add(line.Split(',')[1].Trim());
            }
            HttpContext.Cache.Insert("ordliste", ordliste);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}