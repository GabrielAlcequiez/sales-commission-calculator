namespace Commissions.Data.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Commission { get; set; }
        public bool IsActive { get; set; } = true;

        // Propiedad de navegación: Un país tiene muchas ventas
        public ICollection<Sales> Sales { get; set; } = new List<Sales>();
    }
}