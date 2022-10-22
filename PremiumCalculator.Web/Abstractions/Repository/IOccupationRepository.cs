using PremiumCalculator.Web.Models;

namespace PremiumCalculator.Web.Abstractions.Repository
{
    public interface IOccupationRepository
    {
        Task<List<Occupation>> GetOccupationsAsync();
        Task<OccupationRating> GetOccupationRatingAsync(int occupationId);
        Task<decimal> GetOccupationRatingFactorAsync(OccupationRating rating);
    }
}
