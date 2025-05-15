namespace CONNEX.ClassLibraries.Entities.WorkOrders
{
    using CONNEX.ClassLibraries.Interfaces;
    using System.ComponentModel.DataAnnotations;

    public class WorkOrder : IEntityDelete
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Code { get; set; } = null;

        [Display(Name = "Tipo")]
        public Guid WorkOrderTypeId { get; set; }
        public WorkOrderType? WorkOrderType { get; set; } = null;

        [Display(Name = "Prioridad")]
        public int Priority { get; set; } = 2;

        [Display(Name = "Descripción")]
        [MaxLength(1000, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Estado")]
        public Guid WorkOrderStatusId { get; set; } 
        public WorkOrderStatus? WorkOrderStatus { get; set; } = null;

    }
}
