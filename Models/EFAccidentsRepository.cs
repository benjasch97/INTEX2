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

        public void SaveAccident(Accident a)
        {
            _context.SaveChanges();
        }

        public void AddAccident(Accident a)
        {
            _context.Add(a);
            _context.SaveChanges();
        }

        public void DeleteAccident(Accident a)
        {
            _context.Remove(a);
            _context.SaveChanges();
        }
    }
}
