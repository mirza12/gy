using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProject.Models
{
    public class user1:Iuser1
    {
        private Database1Entities12 db = new Database1Entities12();
        public Models.user Login(Models.user obj)
        {
            var q = db.users.Select(x => x).Where(y => y.username == obj.username && y.password == obj.password);
            foreach (var x in q)
            {
                return x;

            }
            return null;

        }
        public List<app> getApp()
        {

            return (db.apps.Select(x => x).Where(y => y.status == "a" ).ToList());
        }
        public int SignUp(Models.user obj)
        {
            Models.user u = new Models.user();
            u.username = obj.username;
            u.lname = obj.lname;
            u.fname = obj.fname;
            u.password = obj.password;
            u.email = obj.email;
            u.type = obj.type;
            u.accountno = obj.accountno;
            u.weblink = obj.weblink;
            db.users.Add(u);
            db.SaveChanges();
            var q = db.users.Select(x => x).Where(y => y.username == obj.username);
            foreach (var x in q)
            {
                return x.Id;

            }
            return 0;
        }
        public bool AddInformation(Models.user obj, int i)
        {
            Models.user u =  db.users.Find(i);
            u.dob = obj.dob;
            u.Gender = obj.Gender;
            u.contactno = obj.contactno;
            u.address = obj.address;
            u.pic = obj.pic;
            db.SaveChanges();
            return true;
        }
        public int AddUni(string s)
        {
            Models.uni u = new Models.uni();
            u.uname = s;
            db.unis.Add(u);
            db.SaveChanges();
            var q = db.unis.Select(x => x).Where(y => y.uname == s);
            foreach (var x in q)
            {
                return x.Id;

            }
            return 0;
        }
        public Models.user Find(int i)
        {
            Models.user u = db.users.Find(i);
            if(u != null)
            {
                return u;

            }
            return null;

        }
        public bool Save(Models.user obj, int i)
        {
            Models.user u = db.users.Find(i);
            u.fname = obj.fname;
            u.email = obj.email;
            u.lname = obj.lname;
            u.contactno = obj.contactno;
            u.accountno = obj.accountno;
            u.address = obj.address;
            db.SaveChanges();
            return true;
        }
        public Models.app appFind(int i)
        {
            return (db.apps.Find(i));
        }
        public bool checkValidity(string name)
        {
            var q = db.users.Select(x => x).Where(y => y.username == name);
            foreach (var x in q)
            {
                return true;

            }
            return false;
        }
        public List<Models.app> SerachApp(string pname)
        {
            return (db.apps.Select(x => x).Where(y => y.aname == pname ).ToList());
        }
        public List<Models.app> SerachByCatagoies(string pname)
        {
            return (db.apps.Select(x => x).Where(y => y.catagories == pname).ToList());
        }
        public List<Models.app> SerachByTypes(string pname)
        {
            return (db.apps.Select(x => x).Where(y => y.type == pname).ToList());
        }
        public List<Models.app> AppType(string pname)
        {
            return (db.apps.Select(x => x).Where(y => y.type == pname).ToList());
        }
        public int addcomment(Models.comment obj)
        {
            Models.comment u = new Models.comment();
            u.comment1 = obj.comment1;
            u.appid = obj.appid;
            u.uid = obj.uid;
            db.comments.Add(u);
            db.SaveChanges();

            return 1;

        }
        public int AddLike(Models.app obj)
        {
            Models.app aps = db.apps.Find(obj.Id);
            int i = Convert.ToInt32(aps.like);
            if (aps.like == null)
            {
                aps.like = 1;
            }
            else
            {
                aps.like = i + 1;
                i++;

            }
            
            db.SaveChanges();
            return i;
        }
    }
  
}