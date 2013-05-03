using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.Entities;
using MyLawyer.GUI.ViewModels;
using MyLawyer.Repositories.Repositories;

namespace MyLawyer.GUI.Builders
{
    public class LawyerSearchResultViewModelBuilder : ViewModelBuilder<Lawyer, LawyerSearchResultViewModel>
    {
        public override Lawyer BuildEntity(LawyerSearchResultViewModel viewModel)
        {
            return null;
        }

        public override LawyerSearchResultViewModel BuildViewModel(Lawyer entity)
        {
            LawyerSearchResultViewModel ViewModel = base.BuildViewModel(entity);
            
            ViewModel.LawBarText = entity.LawBar.Text;
            ViewModel.LawBarId = entity.LawBarId;
            if (entity.LawSectors != null)
            {
                ViewModel.LawSectorTexts = entity.LawSectors.Select(x => x.Text).ToList();
                ViewModel.LawSectorIds = entity.LawSectors.Select(x => x.Id).ToList();
            }
            if (entity.Study != null)
            {
                ViewModel.StudiesText = entity.Study.Text;
                ViewModel.StudiesId = (int)entity.StudiesId;
            }
            
            return ViewModel;
        }
    }
}
