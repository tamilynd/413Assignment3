using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _413Assignment3.Models
{
    public class TempStorage
    {
        private static List<MovieForm> movies = new List<MovieForm>();

        public static IEnumerable<MovieForm> Movies => movies;

        public static void AddMovie(MovieForm movie)
        {
            movies.Add(movie);
        }
        
    }
}
