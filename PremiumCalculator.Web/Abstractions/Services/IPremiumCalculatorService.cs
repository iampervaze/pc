using PremiumCalculator.Web.Models;

namespace PremiumCalculator.Web.Abstractions.Services
{
    public interface IPremiumCalculatorService
    {
        Task<Premium> CalculateInsurancePremiumAsync(Customer customer);
    }
}
