using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyLawyer.GUI.ViewModels
{
    public class LawyerBaseViewModel
    {
        [Required(ErrorMessage = "Υποχρεωτικό πεδίο.")]
        [StringLength(40, ErrorMessage = "Η τιμή του πεδίου δεν πρέπει να υπερβαίνει τους 40 χαρακτήρες.")]
        [Display(Name = "Ονοματεπώνυμο / Διακριτικός τίτλος*: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο.")]
        [StringLength(50, ErrorMessage = "Η τιμή του πεδίου δεν πρέπει να υπερβαίνει τους 50 χαρακτήρες.")]
        [Display(Name = "Διεύθυνση*: ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο.")]
        [StringLength(40, ErrorMessage = "Η τιμή του πεδίου δεν πρέπει να υπερβαίνει τους 40 χαρακτήρες.")]
        [Display(Name = "Πόλη*: ")]
        public string City { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο.")]
        [StringLength(7, ErrorMessage = "Η τιμή του πεδίου δεν πρέπει να υπερβαίνει τους 7 χαρακτήρες.")]
        [RegularExpression(@"\d{4,7}", ErrorMessage = "Η μορφή του ταχ. κώδ. είναι λανθασμένη")]
        [Display(Name = "Ταχυδρομικός Κώδικας*: ")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο.")]
        [RegularExpression(@"^((\+\s?|0{2}\s?){1}\d{2}\s?)?\d{3}\s?\d{7}", ErrorMessage = "Η μορφή του τηλεφωνου είναι λανθασμένη.")]
        [Display(Name = "Τηλέφωνο Εργασίας*: ")]
        public string PrimaryPhone { get; set; }

        [RegularExpression(@"^((\+\s?|0{2}\s?){1}\d{2}\s?)?\d{3}\s?\d{7}", ErrorMessage = "Η μορφή του τηλεφωνου είναι λανθασμένη.")]
        [Display(Name = "Τηλέφωνο 2/Κινητό: ")]
        public string SecondaryPhone { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο.")]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Η μορφή του email είναι λανθασμένη")]
        [StringLength(60, ErrorMessage = "To Email δεν πρέπει να υπερβαίνει τους 60 χαρακτήρες.")]
        [Display(Name = "Email*: ")]
        public string Email { get; set; }

        [RegularExpression(@"((ht|f)tp(s?)\:\/\/|~/|/)?([w]{2}([\w\-]+\.)+([\w]{2,5}))(:[\d]{1,5})?", ErrorMessage = "To url είναι λανθασμένο.")]
        [DataType(DataType.Url, ErrorMessage = "To url είναι λανθασμένο.")]
        [StringLength(60, ErrorMessage = "To url δεν πρέπει να υπερβαίνει τους 60 χαρακτήρες.")]
        [Display(Name = "Ιστοσελίδα: ")]
        public string Website { get; set; }

        [RegularExpression(@"^((\+\s?|0{2}\s?){1}\d{2}\s?)?\d{3}\s?\d{7}", ErrorMessage = "Η μορφή του τηλεφωνου είναι λανθασμένη.")]
        [Display(Name = "Fax: ")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "Υποχρεωτικό πεδίο.")]
        [Display(Name = "Έτος Εγγραφής στο Δ.Σ.*: ")]
        [Range(1900, 2013, ErrorMessage = "Επιλέξτε ανάμεσα σε 1900 - 2013")]
        public short RegistrationYear { get; set; }

        [Display(Name = "Βιογραφικό: ")]
        [StringLength(500, ErrorMessage = "Βιογραφικό μέχρι 500 χαρακτήρες.")]
        public string Description { get; set; }


        public string FullAddress
        {
            get
            {
                return string.Join(", ", new string[] { this.Address, this.City, this.ZipCode });
            }
        }

        // Unique identifier for this lawyer, corrsponds to the primary key from the db.
        public int Id { get; set; }
    }
}