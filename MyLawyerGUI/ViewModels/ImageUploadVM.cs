using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLawyerGUI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MyLawyer.GUI.ViewModels
{
    public class ImageUploadVM
    {
        //[FileExtensions(Extensions = "csv", ErrorMessage = "Specify a CSV file. (Comma-separated values)")]
        [Display(Name = "Upload Proof of Address")]
        [ValidateFileAttribute( ErrorMessage = "Invalid File")]
        public HttpPostedFileBase Photo { get; set; }
    }
}