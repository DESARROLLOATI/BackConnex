using CONNEX.ClassLibraries.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CONNEX.ClassLibraries.Entities.Operations
{
    public class OperationWorker : IEntityDelete
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Operación")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid OperationId { get; set; }
        public Operation? Operation { get; set; } = null;

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string UserId { get; set; } = null!;

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; } = null!;

        [Display(Name = "Trabajador")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Worker { get; set; } = null!;

        [Display(Name = "Lider")]
        public bool Leader { get; set; } = false;
    }
}
