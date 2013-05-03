using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyLawyer.GUI.ViewModels
{
    public class LawyerSearchResultViewModel: LawyerBaseViewModel
    {
        public string LawBarText { get; set; }
        public int LawBarId { get; set; }
        
        public int StudiesId { get; set; }
        public string StudiesText { get; set; }

        public List<string> LawSectorTexts { get; set; }
        public List<int> LawSectorIds { get; set; } 
    }
}