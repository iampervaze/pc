namespace PremiumCalculator.Web.Models
{
    public class Customer
    {
        public string Name { get; set;}
        public uint Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int OccupationId { get; set; }
        public double SumInsured { get; set; }
    }
}
