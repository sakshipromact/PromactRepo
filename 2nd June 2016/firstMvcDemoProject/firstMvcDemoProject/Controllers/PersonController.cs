using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace firstMvcDemoProject.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Message()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
    }
}