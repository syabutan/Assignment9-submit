using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class EFMovieRepository : iMovieRepository
    {
        private MovieDbContext _context;
        public EFMovieRepository (MovieDbContext context)
        {
            _context = context;
        }
        public IQueryable<MovieInfo> Movies => _context.Movies;
    }
}
