namespace Commissions.Domain.Entities
{
    public class Sales : BaseEntity
    {
        public decimal Total_Sales { get; set; }
        public decimal Discount { get; set; }
        public decimal Total_Commission { get; set; }
        
        public Guid Id_Country { get; set; }
        
        public Country Country{ get; set; } = null!; 
        
        public DateTime CreatedAt { get; set; }
    }
}