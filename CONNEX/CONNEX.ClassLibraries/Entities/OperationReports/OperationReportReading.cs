using CONNEX.ClassLibraries.Entities.Settings;
using CONNEX.ClassLibraries.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CONNEX.ClassLibraries.Entities.OperationReports
{
    public class OperationReportReading : IEntityDelete
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Reporte")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid OperationReportId { get; set; }
        public OperationReport? OperationReport { get; set; } = null!;

        [Display(Name = "Tipo de lectura")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid ReadingTypeId { get; set; }
        public ReadingType? ReadingType { get; set; } = null!;

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Value { get; set; } = 0;

    }
}
