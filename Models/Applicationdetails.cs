using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProject.Models
{
    public class Applicationdetails :IApplicationdetails
    {
        private Database1Entities12 db = new Database1Entities12();
        public int AddApp(Models.app obj)
        {
            Models.app u = new Models.app();
            u.aname = obj.aname;
            u.discription = obj.discription;
            u.catagories = obj.catagories;
            u.type = obj.type;
            u.afile = obj.afile;
            u.Icon = obj.Icon;
            u.currentversion = obj.currentversion;
            u.newthing = obj.newthing;
            u.uploaddate = obj.uploaddate;
            u.uid = obj.uid;
            u.size = obj.size;
            if(u.type == "paid")
            {
                u.price = obj.price;
            }
            else
            {
                u.price = 0;
            }
            
            db.apps.Add(u);

            db.SaveChanges();

            var q = db.apps.Select(x => x).Where(y => y.aname == obj.aname);
            foreach (var x in q)
            {
                return x.Id;

            }
            return 0;
        }
        public Models.app Find(int i)
        {
            return (db.apps.Find(i));
        }
        public int Addshot(string s, int i)
        {
            Models.screen sh = new Models.screen();
            sh.shot = s;
            sh.appid = i;
            db.screens.Add(sh);
            db.SaveChanges();
            return 0;
        }
    }
}