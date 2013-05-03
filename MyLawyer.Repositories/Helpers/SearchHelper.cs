using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLawyer.Repositories.Helpers
{
    public class SearchHelper
    {

    }

    public class LawyerCriteria
    {
        public LawyerCriteria()
        {

        }

        public LawyerCriteria(String Label)
        {
            this.Label = Label;
        }

        public string Label { get; set; }
        public string Name { get; set; }
        public int[] LawSectors { get; set; }
        public int? LawBar { get; set; }
        public bool IsEmpty { get{ return ( Name == null && LawSectors == null && LawBar == 0 ); }}
    }
}