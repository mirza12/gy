using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TermProject.Controllers
{
    public class ServiceController : ApiController
    {

        public string[] GET()
        {

            return new string[] { "hello", "hi" };
        }

    }
}
