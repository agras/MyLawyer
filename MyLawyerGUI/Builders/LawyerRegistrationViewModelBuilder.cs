using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.Entities;
using MyLawyer.Repositories.Repositories;
using MyLawyer.GUI.ViewModels;
using AutoMapper;

namespace MyLawyer.GUI.Builders
{
    public class LawyerRegistrationViewModelBuilder : ViewModelBuilder<Lawyer, LawyerRegistrationViewModel>
    {
        IEnumerable<LawBar> law_bars;
        IEnumerable<LawSector> law_sectors;
        IEnumerable<Study> studies;
        IEnumerable<Keyword> keywords;

        public LawyerRegistrationViewModelBuilder(IEnumerable<LawBar> law_bars, IEnumerable<LawSector> law_sectors, IEnumerable<Study> studies, IEnumerable<Keyword> keywords)
        {
            this.law_sectors = law_sectors;
            this.law_bars = law_bars;
            this.studies = studies;
            this.keywords = keywords;
        }

        public override LawyerRegistrationViewModel BuildViewModel(Lawyer entity)
        {
            LawBarSelectListItemBuilder BuilderLawBar = new LawBarSelectListItemBuilder();
            LawSectorSelectListItemBuilder BuilderLawSector = new LawSectorSelectListItemBuilder();
            StudySelectListItemBuilder BuilderStudy = new StudySelectListItemBuilder();
            KeywordSelectListItemBuilder BuilderKeyword = new KeywordSelectListItemBuilder();

            var ViewModel = new LawyerRegistrationViewModel();

            if( studies != null )
                ViewModel.Studies = BuilderStudy.BuildViewModel(studies);
            if( law_bars != null )
                ViewModel.LawBars = BuilderLawBar.BuildViewModel(law_bars);
            if( law_sectors != null )
                ViewModel.LawSectors = BuilderLawSector.BuildViewModel(law_sectors);
            if (keywords != null)
                ViewModel.Keywords = BuilderKeyword.BuildViewModel(keywords);

            return ViewModel;
        }

        public override Lawyer BuildEntity(LawyerRegistrationViewModel ViewModel)
        {
            Lawyer l = base.BuildEntity(ViewModel);

            LawyerRepository rep = new LawyerRepository();
            l.LawSectors = new List<LawSector>();
            rep.RegisterLawBar(l, ViewModel.SelectedLawBar);
            if (ViewModel.SelectedLawSectors != null)
                rep.RegisterLawSectors(l, ViewModel.SelectedLawSectors.ToList());
            if (ViewModel.SelectedStudies != null && ViewModel.SelectedStudies != 0)
                rep.RegisterStudies(l, ViewModel.SelectedStudies);
            if (ViewModel.SelectedKeywords != null)
                rep.RegisterKeywords(l, ViewModel.SelectedKeywords.ToList());
            rep.Insert(l);
            rep.SaveChanges();

            return l;
        }
    }
}
