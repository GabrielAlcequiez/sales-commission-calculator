namespace Commissions.Business.Entities
{
    public class Sales : BaseEntity
    {
        public decimal Total_Sales { get; set; }
        public decimal Discount { get; set; }
        public decimal Total_Commission { get; set; }
        
        public Guid Id_Country { get; set; } // FK
        
        // Propiedad de navegación: Una venta pertenece a un país
        public Country Country{ get; set; } = null!; 
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}