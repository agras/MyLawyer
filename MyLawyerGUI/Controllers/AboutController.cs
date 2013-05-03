using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLawyer.GUI.ViewModels;
using MyLawyer.GUI.Helpers;

namespace MyLawyerApp.Controllers
{
    public class AboutController : Controller
    {
        //
        // GET: /About/
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Contact(ContactViewModel contactVM)
        {
            bool state;
            TempData["state"] = null;

            if (!ModelState.IsValid)
            {
                state = false;
                TempData["state"] = false;
                return RedirectToAction("Index");
                // return View(contactVM); Γιατί καλεί την Contact.cshtml??
            }

            var contact = new Contact
            {
                Name = contactVM.Name,
                PhoneNumber = contactVM.PhoneNumber,
                Email = contactVM.Email,
                Message = contactVM.Message,
            };

            new Email().Send(contact);

            TempData["state"] = true;
            return RedirectToAction("Index");
        }

    }
}
