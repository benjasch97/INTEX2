using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// this is used to implement the pagination in the Accidents page

namespace INTEX2.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumAccidents { get; set; }
        public int AccidentsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int) Math.Ceiling((double) TotalNumAccidents / AccidentsPerPage);
    }
}
