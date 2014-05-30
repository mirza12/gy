using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProject.Models
{
    public interface IApplicationdetails
    {
        int AddApp(Models.app obj);
        Models.app Find(int i);
        int Addshot(string s, int i);
    }
}