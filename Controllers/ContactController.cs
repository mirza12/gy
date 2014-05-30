using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace TermProject.Controllers
{
    public class ContactController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult email()
        {
            string name = Request["name"];
            string email = Request["mail"];
            string comment = Request["comment"];
            if (email != null)
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("appstocker@hotmail.com");
                mail.To.Add("appstocker1@gmail.com");
                mail.Subject = "Contact Us";
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = "<p>Name: " + name + "</p>";
                htmlBody += "<p>Email: " + email + "</p>";
                htmlBody += "<p>Message: " + comment + "</p>";
                mail.Body = htmlBody;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("appstocker@hotmail.com", "imking21");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
