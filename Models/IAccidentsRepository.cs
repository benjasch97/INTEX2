using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Models
{
    public interface IAccidentsRepository
    {
        IQueryable<Accident> mytable { get; }

        public void Add(Accident a);
        public void Save(Accident a);
        public void Delete(Accident a);
    }
}
