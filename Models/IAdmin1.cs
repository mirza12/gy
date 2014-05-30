using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public interface IAdmin1
    {
        int Login(Models.Admin obj);
        List<Models.app> ShowApp();
        int appFind(int i);
    }
}
