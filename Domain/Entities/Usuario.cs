using Domain.Enums;

namespace Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;

        // Clasificación por departamento para los reportes diarios
        public Departamento Departamento { get; set; }

        // RELACIÓN CLAVE: El usuario pertenece a una Empresa específica
        // Esto permite que el Asistente y el Vendedor operen en empresas distintas.
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; } = null!;

        // Sincronización con Aspel para eliminar el registro manual
        public string? AspelId { get; set; }
    }
}