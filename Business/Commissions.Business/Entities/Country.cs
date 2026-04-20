namespace Commissions.Business.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Commission { get; set; }
        public bool IsActive { get; set; } = true;

        // Propiedad de navegación: Un país tiene muchas ventas
        public ICollection<Sales> Sales { get; set; } = new List<Sales>();
    }
}