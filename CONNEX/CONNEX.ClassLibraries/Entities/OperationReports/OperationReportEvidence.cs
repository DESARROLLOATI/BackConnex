using CONNEX.ClassLibraries.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CONNEX.ClassLibraries.Entities.OperationReports
{
    public class OperationReportEvidence : IEntityDelete
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Operación")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid OperationReportId { get; set; }
        public OperationReport? OperationReport { get; set; } = null!;

        [Display(Name = "Fecha y hora")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Date { get; set; }

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

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid OperationReportEvidenceTypeId { get; set; }
        public OperationReportEvidenceType? OperationReportEvidenceType { get; set; } = null!;

        [Display(Name = "Url")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Url { get; set; } = null!;

        [Display(Name = "Latitude")]
        public decimal? Latitude { get; set; } = 0;

        [Display(Name = "Longitude")]
        public decimal? Longitude { get; set; } = 0;

        [Display(Name = "Altitude")]
        public decimal? Altitude { get; set; } = 0;

        [Display(Name = "Precisión")]
        public decimal? Accuracy { get; set; } = 0;

        [Display(Name = "Precisión Altitude")]
        public decimal? AltitudeAccuracy { get; set; } = 0;
    }
}
