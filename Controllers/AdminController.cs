using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TermProject.Controllers
{
    public class AdminController : Controller
    {
         Models.IAdmin1 a;
        // constructor
        public AdminController(Models.IAdmin1 ad)
        {
            a = ad;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Loginn(Models.Admin obj)
        {
            int i = a.Login(obj);
            if (i!=0)
            {
                    return RedirectToAction("Login");
            }
            else
                return RedirectToAction("Index");
        }
        
        public ActionResult Logout()
        {
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            List<Models.app> app = a.ShowApp();
            if (app != null)
                return View(app);
            else
                return HttpNotFound();
        }
        public ActionResult Add(int id=0)
        {
            int i = a.appFind(id);
            if (i==1)
            {
                return RedirectToAction("Login");
            }
            else
                return RedirectToAction("Index");
        }

    }
}
