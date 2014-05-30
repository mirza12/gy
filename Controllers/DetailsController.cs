using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TermProject.Controllers
{
    public class DetailsController : Controller
    {
        Models.IApplicationdetails u;
        // constructor
        public DetailsController(Models.IApplicationdetails us)
        {
            u = us;
        }

        public ActionResult AddApplication()
        {
            return View("~/Views/Details/AddApplication.cshtml");
        }
        [HttpPost]
        public ActionResult Add(Models.app obj)
        {
            HttpPostedFileBase app = Request.Files[0];
            app.SaveAs(Server.MapPath(@"/apps/" + app.FileName));
            var path = "/apps/" + app.FileName;
            obj.afile = path;
            HttpPostedFileBase file = Request.Files[1];
            file.SaveAs(Server.MapPath(@"/applicationimage/" + file.FileName));
            var path1 = "/applicationimage/" + file.FileName;
            obj.Icon = path1;
            obj.size = Convert.ToString(app.ContentLength);
            obj.uid = Convert.ToInt32(Session["id"]);
            obj.uploaddate = DateTime.Now.Date;
            
            
            int i = u.AddApp(obj);
            if (i != 0)
            {
                int count = 0;
                foreach (string key in Request.Files)
                {
                    count++;
                    HttpPostedFileBase file1 = Request.Files[key];

                    if (file1.ContentLength != 0 && count > 2)
                    {
                        file1.SaveAs(Server.MapPath(@"/appsshot/" + file.FileName));
                        var p = "/appsshot/" + file.FileName;
                        Console.WriteLine(p);
                        int j = u.Addshot(p, i);
                    }
                }
                return Redirect("/Account/Index");
            }
            else
                return View("~/Views/Details/AddApplication.cshtml");
        }

        //public FileResult Download()
        //{
        //    int i = Convert.ToInt32(Session["appid"]);
        //    Models.application a = u.Find(1);
        //}
    }
}
