using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using AutoMapper;
using MyLawyer.Entities;
using MyLawyer.GUI.ViewModels;


namespace MyLawyerGUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Use LocalDB for Entity Framework by default
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            AutoMapperWebConfiguration.Configure(); // Auto Mapper
        }
    }

    //Auto Mapper


    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new CustomProfile());

            });
        }
    }

    public class CustomProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "CustomProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Lawyer, LawyerSearchResultViewModel>()
                .ForMember(lvm => lvm.LawBarId, l => l.MapFrom(o => o.LawBarId))
                .ForMember(lvm => lvm.StudiesId, l => l.MapFrom(o => o.StudiesId))
                .ForMember(lvm => lvm.FullAddress, l => l.MapFrom(o => o.Address + ", " + o.City + ", " + o.ZipCode))
                .ForMember(lvm => lvm.LawBarText, l => l.Ignore())
                .ForMember(lvm => lvm.LawSectorIds, l => l.Ignore())
                .ForMember(lvm => lvm.LawSectorTexts, l => l.Ignore())
                ;

            Mapper.CreateMap<LawyerRegistrationViewModel, Lawyer>()
                .ForMember(l => l.LawBarId, lrvm => lrvm.MapFrom(o => o.SelectedLawBar))
                //.ForMember(l => l.StudiesId, lrvm => lrvm.MapFrom(o => o.SelectedStudies))
                .ForMember(l => l.StudiesId, lrvm => lrvm.Ignore())
                .ForMember(l => l.RegistrationTimeStamp, lrvm => lrvm.Ignore())
                .ForMember(l => l.Id, lrvm => lrvm.Ignore())
                .ForMember(l => l.LawBar, lrvm => lrvm.Ignore())
                .ForMember(l => l.Study, lrvm => lrvm.Ignore())
                .ForMember(l => l.Memberships, lrvm => lrvm.Ignore())
                .ForMember(l => l.Keywords, lrvm => lrvm.Ignore())
                .ForMember(l => l.LawSectors, lrvm => lrvm.Ignore())
                .ForMember(l => l.LogoUrl, lrvm => lrvm.Ignore())
                .ForMember(l => l.Url, lrvm => lrvm.Ignore())
                ;

            Mapper.CreateMap<LinkMetaData, LinkVM>()
                ;

            Mapper.CreateMap<LawSector, SelectListItem>()
                .ForMember(x => x.Value, opt => opt.MapFrom(o => o.Id))
                .ForMember(x => x.Text, opt => opt.MapFrom(o => o.Text))
                ;

            Mapper.CreateMap<LawBar, SelectListItem>()
                .ForMember(x => x.Value, opt => opt.MapFrom(o => o.Id))
                .ForMember(x => x.Text, opt => opt.MapFrom(o => o.Text))
                ;

            Mapper.CreateMap<Keyword, SelectListItem>()
                .ForMember(x => x.Value, opt => opt.MapFrom(o => o.Id))
                .ForMember(x => x.Text, opt => opt.MapFrom(o => o.Text))
                ;

            Mapper.CreateMap<Study, SelectListItem>()
                .ForMember(x => x.Value, opt => opt.MapFrom(o => o.Id))
                .ForMember(x => x.Text, opt => opt.MapFrom(o => o.Text))
                ;
        }
    }

    //Auto Mapper
}