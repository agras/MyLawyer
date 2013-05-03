using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.GUI.ViewModels;
using MyLawyer.Entities;
using System.Web.Mvc;


namespace MyLawyer.GUI.Builders
{
    public class SearchViewModelBuilder : ViewModelBuilder<Object, SearchViewModel>
    {
        IEnumerable<LawBar> law_bars;
        IEnumerable<LawSector> law_sectors;


        public SearchViewModelBuilder(IEnumerable<LawBar> law_bars, IEnumerable<LawSector> law_sectors)
        {
            this.law_sectors = law_sectors;
            this.law_bars = law_bars;
        }

        public override SearchViewModel BuildViewModel(Object obj)
        {
            LawBarSelectListItemBuilderNotRequired BuilderLawBar = new LawBarSelectListItemBuilderNotRequired();
            LawSectorSelectListItemBuilder BuilderLawSector = new LawSectorSelectListItemBuilder();

            var ViewModel = new SearchViewModel();

            ViewModel.LawBars = BuilderLawBar.BuildViewModel(law_bars);
            ViewModel.LawSectors = BuilderLawSector.BuildViewModel(law_sectors);
            
            return ViewModel;
        }

        public override object BuildEntity(SearchViewModel viewModel)
        {
            return null;
        }

    }
}
