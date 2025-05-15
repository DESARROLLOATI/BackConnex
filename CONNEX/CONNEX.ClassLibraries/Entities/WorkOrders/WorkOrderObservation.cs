using CONNEX.ClassLibraries.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CONNEX.ClassLibraries.Entities.WorkOrders
{
    public class WorkOrderObservation : IEntityDelete
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Orden")]
        public Guid WorkOrderId { get; set; }
        public WorkOrder? WorkOrder { get; set; } = null;

        [Display(Name = "Observación")]
        [MaxLength(1000, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; } = null!;
    }
}
