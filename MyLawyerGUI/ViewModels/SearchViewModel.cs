using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace MyLawyer.GUI.ViewModels
{
    public class SearchViewModel
    {
        [Display(Name = "Δικηγορικός Σύλλογος: ")]
        public IEnumerable<SelectListItem> LawBars { get; set; }
        
        [Display(Name = "Τομέας Δικαίου: ")]
        public IEnumerable<SelectListItem> LawSectors { get; set; }

        [Display(Prompt = "Επωνυμία ή όνομα δικηγόρου", Name = "Ονοματεπώνυμο / Επωνυμία: "), StringLength(40, ErrorMessage = "Η τιμή του πεδίου δεν πρέπει να υπερβαίνει τους 40 χαρακτήρες.")]
        public string SearchLawyerName { get; set; }

        public int SearchLawBar { get; set; }
        public int[] SearchLawSector { get; set; } 

        [Display(Name = "Αποτελέσματα Αναζήτησης")]
        public IEnumerable<LawyerSearchResultViewModel> Lawyers { get; set; }

        // To determine which search tab is used
        public int SearchTab { get; set; }
    }

}