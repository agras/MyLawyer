using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyLawyer.Repositories.Repositories;
using MyLawyer.Entities;
using MyLawyer.GUI.Builders;
using MyLawyer.GUI.ViewModels;
using MyLawyer.Repositories.Helpers;
using System.IO;

namespace MyLawyerGUI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Search");
        }


        [HttpGet]
        public ActionResult ImageUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageUpload(ImageUploadVM model)
        {
            //Check server side validation using data annotation
            if (ModelState.IsValid)
            {
                try
                {

                    var extension = Path.GetExtension(model.Photo.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads/"));
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    model.Photo.SaveAs(path + extension);
                    ModelState.Clear();
                }
                catch { }
                return View();
            }
            else
                return View(model);
           
        }
    

        //[HttpPost]
        //public ActionResult ImageUpload(HttpPostedFileBase file)
        //{
        //    var fileName = Path.GetFileName(file.FileName);
        //    var fileExtension = Path.GetExtension(file.FileName); 
        //    var imgExtList = new[] { ".jpg", ".jpeg", ".png", ".bmp"  };
        //    //if(imgExtList.Contains(fileExtension))
        //    //{
        //    //    //...send message that file can't blah blah and return to your view
        //    //}
        //    if (file.ContentLength > 0 && file.ContentLength < 1000000 && imgExtList.Contains(fileExtension))
        //    {
        //        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
        //        file.SaveAs(path);
        //    }
        //    return RedirectToAction("Index");
        //}




        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            LawBarRepository LawBarRep = new LawBarRepository();
            LawSectorRepository LawSectorRep = new LawSectorRepository();

            SearchViewModelBuilder builder_3 = new SearchViewModelBuilder(LawBarRep.Fetch(), LawSectorRep.Fetch());

            return View(builder_3.BuildViewModel(new Lawyer()));
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel vm)
        {
            LawBarRepository LawBarRep = new LawBarRepository();
            LawSectorRepository LawSectorRep = new LawSectorRepository();

            SearchViewModelBuilder builder_3 = new SearchViewModelBuilder(LawBarRep.Fetch(), LawSectorRep.Fetch());

            // Copy search criteria from the GET ViewModel
            var v = builder_3.BuildViewModel(new Lawyer());
            v.SearchLawyerName = vm.SearchLawyerName;
            v.SearchLawBar = vm.SearchLawBar;
            v.SearchLawSector = vm.SearchLawSector;

            // Store the value of the tab we are using for the search
            v.SearchTab = 2;

            // Initiate Lawyer Reporitory to launch lawyer search
            LawyerRepository repos = new LawyerRepository();

            LawyerCriteria criteria = new LawyerCriteria("Lawyer Search");
            criteria.Name = v.SearchLawyerName;
            criteria.LawBar = v.SearchLawBar;
            criteria.LawSectors = v.SearchLawSector;

            // var resultCounter = repos.CountAll();

            var l = repos.SearchLawyerByCriteria(criteria);
            if (l != null)
            {
                List<LawyerSearchResultViewModel> list = new List<LawyerSearchResultViewModel>();

                foreach (Lawyer x in l)
                {
                    LawyerSearchResultViewModel vmm = new LawyerSearchResultViewModelBuilder().BuildViewModel(x);
                    list.Add(vmm);
                }
                v.Lawyers = list;
            }

            return View(v);
        }

        public ActionResult Links()
        {
            BaseRepository<LinkMetaData> LinkRepository = new BaseRepository<LinkMetaData>();
            LinkVMBuilder LinkBuilder = new LinkVMBuilder();

            LinksVM Links = new LinksVM();
            IEnumerable<LinkMetaData> LinkEntities = LinkRepository.Fetch();
            IEnumerable<LinkMetaData> LinkEntitiesType1 = LinkRepository.SearchFor(x => x.Type == 1);
            IEnumerable<LinkMetaData> LinkEntitiesType2 = LinkRepository.SearchFor(x => x.Type == 2);

            Links.LinkList = LinkBuilder.BuildViewModel(LinkEntities);
            Links.LinkListOfType1 = LinkBuilder.BuildViewModel(LinkEntitiesType1);
            Links.LinkListOfType2 = LinkBuilder.BuildViewModel(LinkEntitiesType2);

            return View(Links);
        }

        [HttpGet]
        public ActionResult LegalMarketing()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LawSubjects()
        {
            return View();
        }
    }
}
