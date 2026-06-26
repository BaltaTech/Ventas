using Domain.Enums;

namespace Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;
        public Departamento Departamento { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; } = null!;
        public string? AspelId { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
    }
}