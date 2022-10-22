using PremiumCalculator.Web.Abstractions.Repository;
using PremiumCalculator.Web.Abstractions.Services;
using PremiumCalculator.Web.Models;

namespace PremiumCalculator.Web.Services
{
    public class PremiumCalculatorService : IPremiumCalculatorService
    {
        private readonly IOccupationRepository occupationRepository;
        public PremiumCalculatorService(IOccupationRepository _occupationRepository)
        {
            occupationRepository = _occupationRepository;
        }

        public async Task<Premium> CalculateInsurancePremiumAsync(Customer customer)
        {
            var occupationRating = await occupationRepository.GetOccupationRatingAsync(customer.OccupationId);
            var ratingFactor = await occupationRepository.GetOccupationRatingFactorAsync(occupationRating);
            customer.Age = GetAgeInYears(customer.DateOfBirth);

            var calculatedPremium = ((customer.SumInsured * ratingFactor * customer.Age) / 1000) * 12;

            var premium = new Premium()
            {
                InsurancePremium = Math.Round(calculatedPremium, 2),
                Customer = customer
            };

            return premium;
        }

        private uint GetAgeInYears(DateTime dob)
        {
            int years = DateTime.Now.Year - dob.Year;

            if ((dob.Month > DateTime.Now.Month) || (dob.Month == DateTime.Now.Month && dob.Day > DateTime.Now.Day))
                years--;

            return (uint)years;
        }
    }
}
