using CONNEX.ClassLibraries.Entities.Settings;
using CONNEX.ClassLibraries.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CONNEX.ClassLibraries.Entities.OperationReports
{
    public class OperationReportData : IEntityDelete
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Reporte")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid OperationReportId { get; set; }
        public OperationReport? OperationReport { get; set; } = null!;

        [Display(Name = "Tipo de documento")]
        public Guid UserDocumentTypeId { get; set; }
        public UserDocumentType? UserDocumentType { get; set; } = null!;

        [Display(Name = "Identificación")]
        public string? Document { get; set; }

        [Display(Name = "Cliente")]
        public string? Customer { get; set; }

        [Display(Name = "Tipo de Cliente")]
        public Guid CustomerTypeId { get; set; }
        public CustomerType? CustomerType { get; set; } = null!;

        [Display(Name = "Teléfono")]
        public string? Phone { get; set; }

        [Display(Name = "Teléfono2")]
        public string? Phone2 { get; set; }

        [Display(Name = "Correo")]
        public string? Email { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(150, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string Address { get; set; } = null!;

        [Display(Name = "Municipio")]
        public string City { get; set; } = null!;

        [Display(Name = "Actividad")]
        public Guid EconomicActivityId { get; set; }
        public EconomicActivity? EconomicActivity { get; set; } = null!;

        [Display(Name = "Firma del cliente")]
        public bool Signature { get; set; }

        [Display(Name = "Url de Firma")]
        public string? SignatureUrl { get; set; }
    }
}
