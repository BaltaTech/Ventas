using Domain.Enums;

namespace Domain.Entities;

public class Prospecto
{
    public Guid Id { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public string NombreCliente { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string? Correo { get; set; }
    public OrigenProspecto Origen { get; set; }
    public int EmpresaId { get; set; }
    public virtual Empresa Empresa { get; set; } = null!;
    public Guid? VendedorId { get; set; }
    public virtual Usuario? Vendedor { get; set; }
    public bool Atendido { get; set; } = false;
    public string? NotasRecepcion { get; set; }
}