using CONNEX.ClassLibraries.Entities.Operations;
using CONNEX.ClassLibraries.Entities.Settings;
using CONNEX.ClassLibraries.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CONNEX.ClassLibraries.Entities.OperationReports
{
    public class OperationReport : IEntityDelete
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Operación")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid OperationId { get; set; }
        public Operation? Operation { get; set; } = null!;

        [Display(Name = "Fecha y hora")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Date { get; set; }

        [Display(Name = "Hora de inicio")]
        public TimeSpan? TimeStart { get; set; }

        [Display(Name = "Hora de fin")]
        public TimeSpan? TimeEnd { get; set; }

        [Display(Name = "Armario Interno Externo")]
        public string AIE { get; set; } = null!;

        [Display(Name = "Novedad")]
        public Guid? NoveltyId { get; set; } = null;
        public Novelty? Novelty { get; set; } = null!;

        [Display(Name = "Hallazgo")]
        public Guid? FindingId { get; set; } = null;
        public Finding? Finding { get; set; } = null!;

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

        [Display(Name = "Firma")]
        public bool Signature { get; set; }

        [Display(Name = "Url de Firma")]
        public string? SignatureUrl { get; set; }

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

        [Display(Name = "Lecturas")]
        public ICollection<OperationReportReading>? Readings { get; set; }

        [Display(Name = "Evidencias")]
        public ICollection<OperationReportEvidence>? Evidences { get; set; }

        [Display(Name = "Observaciones")]
        public ICollection<OperationReportObservation>? Observations { get; set; }

    }
}
