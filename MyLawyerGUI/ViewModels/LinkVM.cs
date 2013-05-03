using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyLawyer.GUI.ViewModels
{
    public class LinkVM
    {
        public string Title { get; set; }
        public string Address { get; set; }
        [Display(Name = "Ιστοσελίδα")]
        public string Website { get; set; }
        public string Phone { get; set; }
        [Display(Name = "Επικοινωνία")]
        public string Email { get; set; }
        public int Type { get; set; }
    }
}