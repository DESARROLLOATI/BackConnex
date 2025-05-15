using System.ComponentModel.DataAnnotations;

namespace CONNEX.ClassLibraries.Interfaces
{
    public class IEntity
    {
        [Display(Name = "Habilitado")]
        public bool Enabled { get; set; } = true;

        [Display(Name = "Creado")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Display(Name = "Modificado")]
        public DateTime Updated { get; set; } = default(DateTime);
    }
}
