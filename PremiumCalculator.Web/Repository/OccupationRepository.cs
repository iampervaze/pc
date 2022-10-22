using PremiumCalculator.Web.Abstractions.Repository;
using PremiumCalculator.Web.Models;

namespace PremiumCalculator.Web.Repository
{
    public class OccupationRepository : IOccupationRepository
    {
        private readonly List<Occupation> _occupations;
        private readonly Dictionary<int, OccupationRating> _occupationRatings;
        private readonly Dictionary<OccupationRating, double> _occupationRatingFactors;

        public OccupationRepository()
        {
            _occupations = new List<Occupation>()
            {
                new Occupation()
                {
                    Id = 1,
                    Name = "Doctor"
                },
                new Occupation()
                {
                    Id=2,
                    Name = "Cleaner"
                },
                new Occupation()
                {
                    Id =3,
                    Name = "Author"
                },
                new Occupation()
                {
                    Id=4,
                    Name = "Farmer"
                },
                new Occupation()
                {
                    Id=5,
                    Name = "Mechanic"
                },
                new Occupation()
                {
                    Id=6,
                    Name = "Florist"
                },
            };

            _occupationRatings = new Dictionary<int, OccupationRating>()
            {
                {1, OccupationRating.Professional },
                {2, OccupationRating.LightManual },
                {3, OccupationRating.WhiteCollar },
                {4, OccupationRating.HeavyManual },
                {5, OccupationRating.HeavyManual },
                {6, OccupationRating.LightManual }
            };

            _occupationRatingFactors = new Dictionary<OccupationRating, double>()
            {
                {OccupationRating.Professional, 1.0 },
                {OccupationRating.WhiteCollar, 1.25 },
                {OccupationRating.LightManual, 1.5 },
                {OccupationRating.HeavyManual, 1.75 }
            };
        }

        public async Task<OccupationRating> GetOccupationRatingAsync(int occupationId)
        {
            if (_occupationRatings.TryGetValue(occupationId, out OccupationRating rating))
            {
                return await Task.FromResult(rating);
            }

            throw new ArgumentException($"Occupation {occupationId} not supported");
        }

        public async Task<double> GetOccupationRatingFactorAsync(OccupationRating rating)
        {
            if (_occupationRatingFactors.TryGetValue(rating, out double ratingFactor))
            {
                return await Task.FromResult(ratingFactor);
            }

            throw new ArgumentException($"Rating factor not available for rating {rating}");
        }

        public async Task<List<Occupation>> GetOccupationsAsync()
        {
            return await Task.FromResult(_occupations);
        }
    }
}
