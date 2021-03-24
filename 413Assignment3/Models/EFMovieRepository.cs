using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _413Assignment3.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MoviesDBContext _context;

        //constructor
        public EFMovieRepository(MoviesDBContext context)
        {
            _context = context;
        }
        public IQueryable<Movie> Movies => _context.Movies;

    }
}
