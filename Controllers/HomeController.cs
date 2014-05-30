using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class HomeController : Controller
    {


         Models.Iuser1 u;
        // constructor
        public HomeController(Models.Iuser1 us)
        {
            u = us;
        }

        public ActionResult Index()
        {
            List<Models.app> app = u.getApp();
            if (app != null)
                return View(app);
            else
                return HttpNotFound();
        }

        // login

        [HttpPost]
        public ActionResult login(Models.user obj)
        {  
            Models.user a = u.Login(obj);
            if (a!=null)
            {
                Session["id"] = a.Id;
                if (a.type =="developer")
                {
                    Session["Layout"] = "_homePageLayout.cshtml";
                }
                else
                {
                    Session["Layout"] = "_userLayout.cshtml";
                }
                return Redirect("/Account/Index");
            }
            else
                return RedirectToAction("Index");
        }
        // signup

        [HttpPost]
        public ActionResult SignUp(Models.user obj)
        {
            string s = Request["uname"];
            int id=u.AddUni(s);
            obj.uid =Convert.ToInt32(id);
            int a = u.SignUp(obj);
            if (obj.type == "developer")
            {
                Session["Layout"] = "_homePageLayout.cshtml";
            }
            else
            {
                Session["Layout"] = "_userLayout.cshtml";
            }
            if (a !=0)
            {
                Session["id"] = a;
                return View("~/Views/Home/AddInformation.cshtml");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult AddInformation(Models.user obj)
        {
            int i= Convert.ToInt32( Session["id"]);
            if (Request.Files[0] != null)
            {
                HttpPostedFileBase file = Request.Files[0];
                file.SaveAs(Server.MapPath(@"/userimage/" + file.FileName));
                var path = "/userimage/" + file.FileName;
                obj.pic = path;
            }
            bool a = u.AddInformation(obj,i );
            if (a == true)
            {

                return Redirect("/Account/Index");
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }
        public JsonResult checkValidity()
        {
            string s = Request["ume"];
            if (u.checkValidity(s))
            {
                return this.Json(true, JsonRequestBehavior.AllowGet);
            }
            else
                return this.Json(false, JsonRequestBehavior.AllowGet);
        }

    }
}
