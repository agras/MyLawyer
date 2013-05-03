using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyLawyerGUI.Validations
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LawBarValidation : ValidationAttribute
    {
        string defaultValue = "Επιλέξτε";

        public LawBarValidation() : base("Υποχρεωτικό πεδίο.")
        {
        }

        public override bool IsValid(object value)
        {
            SelectListItem item = (SelectListItem)value;
            if (item.Text.ToUpper().Contains(defaultValue.ToUpper()))
                return false;
            return true;
        }
    }
}