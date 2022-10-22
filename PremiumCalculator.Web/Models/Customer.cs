namespace PremiumCalculator.Web.Models
{
    public class Customer
    {
        public string Name { get; set;}
        public int Age { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int OccupationId { get; set; }
        public decimal SumInsured { get; set; }
    }
}
