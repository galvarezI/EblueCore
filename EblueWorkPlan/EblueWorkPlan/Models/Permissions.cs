using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EblueWorkPlan.Models
{
    public class Permissions
    {

        [Key]
        public int Id { get; set; }

        // 🔗 Relación directa con la tabla AspNetRoles (IdentityRole)
        [Required]
        [ForeignKey("Role")]
        public string RoleId { get; set; }

        public virtual IdentityRole Role { get; set; }

        // Permisos de CRUD
        public bool PuedeCrear { get; set; }
        public bool PuedeEditar { get; set; }
        public bool PuedeEliminar { get; set; }
        public bool PuedeVer { get; set; }

        // Permisos de flujo de aprobación
        public bool PuedeAprobar { get; set; }
        public bool PuedeRechazar { get; set; }
        public bool PuedeComentar { get; set; }

        // Permisos administrativos
        public bool PuedeAsignarRoles { get; set; }
        public bool PuedeAdministrarTodo { get; set; }

        // Permisos especiales de flujo
        public bool PuedeReenviar { get; set; }
        public bool PuedeModificarTrasRechazo { get; set; }


       
    }
}
