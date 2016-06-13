using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondMvcDemoProject.Controllers
{
    public class userController : Controller
    {
        // GET: user
        public ActionResult login()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
    }
}