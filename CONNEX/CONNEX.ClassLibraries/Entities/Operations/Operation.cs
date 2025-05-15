using CONNEX.ClassLibraries.Entities.OperationReports;
using CONNEX.ClassLibraries.Entities.WorkOrders;
using CONNEX.ClassLibraries.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CONNEX.ClassLibraries.Entities.Operations
{
    public class Operation : IEntityDelete
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Orden")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid WorkOrderId { get; set; }
        public WorkOrder? WorkOrder { get; set; } = null;

        [Display(Name = "Fecha y hora")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Date { get; set; }

        [Display(Name = "Estado")]
        public Guid OperationStatusId { get; set; }
        public OperationStatus? WorkOrderStatus { get; set; } = null;

        [Display(Name = "Reportes")]
        public ICollection<OperationReport>? Reports { get; set; }

        [Display(Name = "Trabajadores")]
        public ICollection<OperationWorker>? Workers { get; set; }
    }
}
