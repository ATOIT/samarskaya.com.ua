using System.Collections.Generic;
using Domain.Entityes;

namespace Domain.Abstrac
{
    public interface IReviewsRepository
    {
        IEnumerable<Reviews>Reviewses { get; }
        void SaveReview(Reviews reviews);
        void RemoveReview(Reviews reviews);
    }
}