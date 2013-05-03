using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyLawyer.GUI.Builders;
using MyLawyer.GUI.ViewModels;
using MyLawyer.Repositories.Repositories;
using MyLawyer.Entities;
using MyLawyer.GUI.Helpers;

namespace MyLawyerGUI.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Registration/Edit/5
        public ActionResult Register(string membership)
        {
            
            LawBarRepository LawBarRep = new LawBarRepository();
            LawSectorRepository LawSectorRep = new LawSectorRepository();
            BaseRepository<Study> StudyRep = new BaseRepository<Study>();
            KeywordRepository KeywordRep = new KeywordRepository();

            LawyerRegistrationViewModelBuilder builder = new LawyerRegistrationViewModelBuilder(LawBarRep.Fetch(), LawSectorRep.Fetch(), StudyRep.Fetch(), KeywordRep.Fetch());

            LawyerRegistrationViewModel ViewModel = builder.BuildViewModel(new Lawyer());
            ViewModel.Membership = membership;

            if (ViewModel.Membership.Equals("Silver"))
                return View("RegisterSilver", ViewModel);
            else
                return View("RegisterGold", ViewModel);
        }

        //
        // POST: /Registration/Edit/5
        [HttpPost]
        public ActionResult Register(LawyerRegistrationViewModel GetViewModel)
        {
            //if (ModelState.IsValid)
            //{
                LawyerRepository Rep = new LawyerRepository();

                LawyerRegistrationViewModelBuilder Builder = new LawyerRegistrationViewModelBuilder(null, null, null, null);

                Lawyer l = Builder.BuildEntity(GetViewModel);

                ConfirmationEmail cfrmEMail = new ConfirmationEmail();
                cfrmEMail.PrepareRecipient(l);
                cfrmEMail.SendConfirmationEmail(null);

                return RedirectToAction("Index");
            //}
            //// If we got this far, something failed, redisplay form
            //return RedirectToAction("Register");
        }


        [HttpGet]
        public ActionResult Register1()
        {
            LawBarRepository LawBarRep = new LawBarRepository();
            LawSectorRepository LawSectorRep = new LawSectorRepository();

            LawyerRegistrationViewModelBuilder builder = new LawyerRegistrationViewModelBuilder(LawBarRep.Fetch(), LawSectorRep.Fetch(), null,  null);

            LawyerRegistrationViewModel ViewModel = builder.BuildViewModel(new Lawyer());

            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult Register1(LawyerRegistrationViewModel GetViewModel)
        {
            return View("Register2", GetViewModel);
        }


        [HttpPost]
        public ActionResult Register2(LawyerRegistrationViewModel GetViewModel)
        {
            BaseRepository<Study> StudyRep = new BaseRepository<Study>();
            LawyerRegistrationViewModelBuilder builder = new LawyerRegistrationViewModelBuilder(null, null, StudyRep.Fetch(), null);

            return View("Register2", GetViewModel);
        }
    }
}
