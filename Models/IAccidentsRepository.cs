using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Models
{
    public interface IAccidentsRepository
    {
        IQueryable<Accident> mytable { get; }

        public void SaveAccident(Accident a);
        public void AddAccident(Accident a);
        public void DeleteAccident(Accident a);
    }
}
