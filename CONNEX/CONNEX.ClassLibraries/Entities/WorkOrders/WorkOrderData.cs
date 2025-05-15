using System.ComponentModel.DataAnnotations;

namespace CONNEX.ClassLibraries.Entities.WorkOrders
{
    public class WorkOrderData
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Orden")]
        public Guid WorkOrderId { get; set; }
        public WorkOrder? WorkOrder { get; set; } = null;

        [Display(Name = "Cuenta")]
        public string Account { get; set; } = null!;

        [Display(Name = "Medidor")]
        public string Meter { get; set; } = null!;

        [Display(Name = "Transformador")]
        public string? Transformer { get; set; } = null!;

        [Display(Name = "Dirección")]
        public string Address { get; set; } = null!;

        [Display(Name = "Municipio")]
        public string City { get; set; } = null!;

        [Display(Name = "Latitude")]
        public decimal? Latitude { get; set; } = 0;

        [Display(Name = "Longitude")]
        public decimal? Longitude { get; set; } = 0;

        [Display(Name = "Altitude")]
        public decimal? Altitude { get; set; } = 0;
    }
}
