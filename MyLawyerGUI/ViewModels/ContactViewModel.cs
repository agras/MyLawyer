using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLawyer.Entities;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyLawyer.GUI.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο.")]
        [Display(Name = "Ονοματεπώνυμο : ")]
        public string Name { get; set; }

        [RegularExpression(@"^((\+\s?|0{2}\s?){1}\d{2}\s?)?\d{3}\s?\d{7}", ErrorMessage = "Η μορφή του τηλεφωνου είναι λανθασμένη.")]
        [Display(Name = "Τηλέφωνο :")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email : ")]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Η μορφή του email είναι λανθασμένη")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο.")]
        [Display(Name = "Το μήνυμα σας : ")]
        public string Message { get; set; }

    }
}