using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Models
{
    public class EFAccidentsRepository : IAccidentsRepository
    {
        private AccidentsDbContext _context { get; set; }

        public EFAccidentsRepository (AccidentsDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Accident> mytable => _context.mytable;

        public void Add(Accident a)
        {
            _context.Add(a);
            _context.SaveChanges();
        }

        public void Save(Accident a)
        {
            _context.SaveChanges();
        }

        public void Delete(Accident a)
        {
            _context.Remove(a);
            _context.SaveChanges();
        }
    }
}
