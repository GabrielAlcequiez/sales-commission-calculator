using Commissions.Data.Entities;

namespace Commissions.Data.Entities
{
    public class Sales
    {
        public Guid Id { get; set; }
        public decimal Total_Sales { get; set; }
        public decimal Discount { get; set; }
        public decimal Total_Commission { get; set; }
        
        public Guid Id_Country { get; set; } // FK
        
        // Propiedad de navegación: Una venta pertenece a un país
        public Country Country{ get; set; } = null!; 
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}