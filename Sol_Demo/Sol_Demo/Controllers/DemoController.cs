using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sol_Demo.Controllers
{
    public class DemoController : Controller
    {
        private List<string> LanguageList()
        {
            var listData = new List<String>();
            listData.Add("C++");
            listData.Add("Csharp");
            listData.Add("Java");
            listData.Add("Javascript");
            listData.Add("Typescript");
            listData.Add("Python");
            listData.Add("Objective-C");
            listData.Add("Swift");

            return listData;
        }

        public IActionResult Index()
        {
            ViewBag.OnSelectedPosition = 2;

            return View(this.LanguageList());
        }

        [HttpPost]
        public IActionResult OnItemSelected()
        {
            // get Position of Selected Item
            var selectedPosition =Convert.ToInt32( HttpContext.Request.Form["hidItemSelectedPosition"][0]);

            // get all List Data
            var languageList = this.LanguageList();

            // filter By Position and get the language
            var languageName =
                    languageList
                    ?.AsEnumerable()
                    ?.ToList()[selectedPosition];

            ViewBag.LanguageName = languageName;
                   

            return View();
        }
    }
}