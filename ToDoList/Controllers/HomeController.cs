using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string ThisUserId = User.Identity.GetUserId();
            if (ThisUserId != null)
            {
                return RedirectToAction("Index", "UserTasks");
            }
            else
            {
                return View();
            }
            
        }

    }
}