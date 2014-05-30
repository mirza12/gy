using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProject.Models
{
    public class Admin1:IAdmin1
    {
        private Database1Entities12 db = new Database1Entities12();
        public int Login(Models.Admin obj)
        {
            var q = db.Admins.Select(x => x).Where(y => y.adminname == obj.adminname && y.password == obj.password);
            foreach (var x in q)
            {
                return x.Id;

            }
            return 0;

        }

        public List<Models.app> ShowApp()
        {
            return db.apps.Select(x=>x).Where(y=>y.status== null).ToList();

        }
        public int appFind(int i)
        {
            Models.app ap = db.apps.Find(i);
            ap.status = "a";
            db.SaveChanges();
            return 1;
        }
    }
}