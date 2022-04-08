using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// we use this so that we can pull in the Accident model as well as the PageInfo to work with pagination

namespace INTEX2.Models.ViewModels
{
    public class AccidentsViewModel
    {
        public IQueryable<Accident> mytable { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
