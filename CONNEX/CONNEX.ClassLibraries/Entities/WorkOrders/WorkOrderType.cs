using CONNEX.ClassLibraries.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CONNEX.ClassLibraries.Entities.WorkOrders
{
    public class WorkOrderType : IEntityDelete
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Descripción")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;
    }
}
