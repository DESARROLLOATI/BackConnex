using System.ComponentModel.DataAnnotations;

namespace CONNEX.ClassLibraries.Interfaces
{
    public class IEntityDelete : IEntity
    {
        [Display(Name = "Eliminado")]
        public DateTime? Deleted { get; set; } = null;
    }
}
