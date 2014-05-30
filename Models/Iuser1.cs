using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProject.Models
{
    public interface Iuser1
    {
        Models.user Login(Models.user obj);
        int SignUp(Models.user obj);
        bool AddInformation(Models.user obj,int i);
        Models.user Find(int i);
        bool Save(Models.user obj, int i);
        List<app> getApp();
        Models.app appFind(int i);
        bool checkValidity(string name);
        List<Models.app> SerachApp(string pname);
        List<Models.app> AppType(string pname);
        int addcomment(Models.comment obj);
        List<Models.app> SerachByCatagoies(string pname);
        List<Models.app> SerachByTypes(string pname);
        int AddLike(Models.app obj);
        int AddUni(string s);
       
    }

}