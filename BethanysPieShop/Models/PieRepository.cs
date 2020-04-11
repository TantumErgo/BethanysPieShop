using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;
        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public void CreatePie(Pie pie)
        {
            _appDbContext.Pies.Add(pie);
            _appDbContext.SaveChanges();
        }

        public Pie GetPieById(int pieId)
        {
            //return _appDbContext.Pies.Include(p => p.PieReviews).FirstOrDefault(p => p.PieId == pieId);
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public void UpdatePie(Pie pie)
        {
            _appDbContext.Pies.Add(pie);
            _appDbContext.SaveChanges();
        }
    }
}
