using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyLawyer.Entities;
using System.Web.Mvc;
using MyLawyer.GUI.ViewModels;

namespace MyLawyer.GUI.Builders
{
    /// <summary>
    /// Abstract implementation of Auto Mapper
    /// </summary>
    /// <typeparam name="TEntity">Domain Entity. Can also be collection</typeparam>
    /// <typeparam name="TViewModel">View Model. Can also be collection</typeparam>
    /// Note: This maps type to type. E.g. collection of TEntity to collection of TViewModel and vise versa
    public abstract class ViewModelBuilder<TEntity, TViewModel>
    {
        /*
         Don't forget the mapping to global.asax.cs
         */


        /// <summary>
        /// Build entity to vm
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual TEntity BuildEntity(TViewModel viewModel)
        {
            var DomailModels = Mapper.Map<TViewModel, TEntity>(viewModel);
            return DomailModels;
        }

        /// <summary>
        /// Build vm to entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// 
        public virtual TViewModel BuildViewModel(TEntity entity)
        {
            var ViewModels = Mapper.Map<TEntity, TViewModel>(entity);
            return ViewModels;
        }
    }

    /// <summary>
    /// Create a model for binding to dropdown: Note type of IEnumerable<SelectListItem>
    /// </summary>
    public class LawSectorSelectListItemBuilder : ViewModelBuilder<IEnumerable<LawSector>, IEnumerable<SelectListItem>>
    {

    }

    /// <summary>
    /// Create a model for binding to dropdown: Note type of IEnumerable<SelectListItem>
    /// </summary>
    public class LawBarSelectListItemBuilder : ViewModelBuilder<IEnumerable<LawBar>, IEnumerable<SelectListItem>>
    {
        public override IEnumerable<SelectListItem> BuildViewModel(IEnumerable<LawBar> entity)
        {
            IEnumerable<SelectListItem> lookup = base.BuildViewModel(entity);
            return lookup;
        }
    }

    /// <summary>
    /// Create a model for binding to dropdown: Note type of IEnumerable<SelectListItem>
    /// </summary>
    public class LawBarSelectListItemBuilderNotRequired : ViewModelBuilder<IEnumerable<LawBar>, IEnumerable<SelectListItem>>
    {
        public override IEnumerable<SelectListItem> BuildViewModel(IEnumerable<LawBar> entity)
        {
            IEnumerable<SelectListItem> lookup = base.BuildViewModel(entity);
            SelectListItem item = new SelectListItem();
            item.Text = "Επιλέξτε";
            item.Value = "0";
            item.Selected = true;

            var newLookUp = lookup.Concat(new[] { item }).OrderBy(x => x.Value);
            return newLookUp;
        }
    }

    /// <summary>
    /// Create a model for binding to dropdown: Note type of IEnumerable<SelectListItem>
    /// </summary>
    public class KeywordSelectListItemBuilder : ViewModelBuilder<IEnumerable<Keyword>, IEnumerable<SelectListItem>>
    {
        public override IEnumerable<SelectListItem> BuildViewModel(IEnumerable<Keyword> entity)
        {
            IEnumerable<SelectListItem> lookup = base.BuildViewModel(entity);
            SelectListItem item = new SelectListItem();
            item.Text = "Επιλέξτε";
            item.Value = "0";
            item.Selected = true;

            var newLookUp = lookup.Concat(new[] { item }).OrderBy(x => x.Value);
            return newLookUp;
        }

    }

    /// <summary>
    /// Create a model for binding to dropdown: Note type of IEnumerable<SelectListItem>
    /// </summary>
    public class StudySelectListItemBuilder : ViewModelBuilder<IEnumerable<Study>, IEnumerable<SelectListItem>>
    {
        public override IEnumerable<SelectListItem> BuildViewModel(IEnumerable<Study> entity)
        {
            IEnumerable<SelectListItem> lookup = base.BuildViewModel(entity);
            SelectListItem item = new SelectListItem();
            item.Text = "Επιλέξτε";
            item.Value = "0";
            item.Selected = true;

            var newLookUp = lookup.Concat(new[] { item }).OrderBy(x => x.Value);
            return newLookUp;
        }
    }

    public class LinkVMBuilder : ViewModelBuilder<IEnumerable<LinkMetaData>, IEnumerable<LinkVM>>
    {
        public override IEnumerable<LinkVM> BuildViewModel(IEnumerable<LinkMetaData> entity)
        {
            IEnumerable<LinkVM> links = base.BuildViewModel(entity);
            return links;
        }
        public override IEnumerable<LinkMetaData> BuildEntity(IEnumerable<LinkVM> viewModel)
        {
            return null;
        }
    }
}
