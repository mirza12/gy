using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TermProject.Controllers
{
    public class AccountController : Controller
    {
        Models.Iuser1 u;
        // constructor
        public AccountController(Models.Iuser1 us)
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
        public ActionResult ManageProfile()
        {
            int i = Convert.ToInt32(Session["id"]);
            Models.user a = u.Find(i);
            if (a != null)
            {
                return View(a);
            }
            return View(a);
            
        }
        [HttpPost]
        public ActionResult SaveChanges(Models.user obj)
        {
            int i = Convert.ToInt32(Session["id"]);
            bool a = u.Save(obj, i);
            if (a == true)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("~/Views/Account/ManageProfile.cshtml");
            }
        }
        
        public ActionResult AppDetails(int id = 0)
        {
            Models.app ap = u.appFind(id);
            if (ap != null)
            {
                return View(ap);
            }
            else
                return RedirectToAction("Index");
        }
        public JsonResult search()
        {

            string apname = Request["sea"];
            List<Models.app> data = u.SerachApp(apname);
            if (data != null)
            {
                return this.Json(data.Select(e => new
                {
                    e.Icon,
                    e.Id,
                    e.aname,
                    e.type
                }), JsonRequestBehavior.AllowGet);
            }
            else
                return this.Json(false, JsonRequestBehavior.AllowGet);
        }
        public JsonResult searchCatagories()
        {

            string apname = Request["cata"];
            List<Models.app> data = u.SerachByCatagoies(apname);
            if (data != null)
            {
                return this.Json(data.Select(e => new { e.Icon,
                e.Id,e.aname,e.type}), JsonRequestBehavior.AllowGet);
            }
            else
                return this.Json(false, JsonRequestBehavior.AllowGet);
        }
        public JsonResult searchTypes()
        {

            string apname = Request["cata"];
            List<Models.app> data = u.SerachByTypes(apname);
            if (data != null)
            {
                return this.Json(data.Select(e => new
                {
                    e.Icon,
                    e.Id,
                    e.aname,
                    e.type
                }), JsonRequestBehavior.AllowGet);
            }
            else
                return this.Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AppType()
        {
            
            List<Models.app> data = u.AppType("Games");
            if (data != null)
                    return View(data);
                else
                    return HttpNotFound();
        }
        
        public JsonResult Comment()
        {
            Models.comment obj = new Models.comment();
            string cmt = Request["cmmt"];
            obj.comment1 = cmt;
            int i = Convert.ToInt32(Session["appid"]);
            obj.appid = i;
            obj.uid = Convert.ToInt32(Session["id"]);
            int a = u.addcomment(obj);
            
            if (a == 1)
            {

                return this.Json(a, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json(a, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Like()
        {
            Models.app obj = new Models.app();
            int i = Convert.ToInt32(Session["appid"]);
            obj.Id = i;
            int a = u.AddLike(obj);
            return this.Json(a, JsonRequestBehavior.AllowGet);
          
        }
        
    }
}
