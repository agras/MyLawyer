using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLawyer.GUI.ViewModels
{
    public class LinksVM
    {
        public IEnumerable<LinkVM> LinkList { get; set; }
        public IEnumerable<LinkVM> LinkListOfType1 { get; set; }
        public IEnumerable<LinkVM> LinkListOfType2 { get; set; }
    }
}