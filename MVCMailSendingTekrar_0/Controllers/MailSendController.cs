using MVCMailSendingTekrar_0.CustomTools;
using MVCMailSendingTekrar_0.DesignPatterns.SingletonPattern;
using MVCMailSendingTekrar_0.Models.Context;
using MVCMailSendingTekrar_0.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMailSendingTekrar_0.Controllers
{
    public class MailSendController : Controller
    {

        MyContext _db;

        public MailSendController()
        {
            _db = DBTool.DBInstance;
        }

        // GET: MailSend
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUser appUser)
        {
            MailService.Send(appUser.Email, body: "Hello World!!", subject: ":)");
            ViewBag.Message = "Mail Başarılı bir şekilde gönderilmiştir";
            return View();
        }
    }
}