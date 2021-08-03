using GraphQLSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSample.Data
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovieByIdAsync(Guid id);
        Task<Movie> AddReviewToMovieAsync(Guid id, Review review);
    }
}
}
