using Domain.Enums;

namespace Domain.Entities;

public class Prospecto
{
    public Guid Id { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    // Datos del Cliente
    public string NombreCliente { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string? Correo { get; set; }

    // El "Origen" sustituye lo que la recepcionista anotaba en Sheets
    public OrigenProspecto Origen { get; set; }

    // Empresa por la que llegó (A o B)
    public int EmpresaId { get; set; }
    public virtual Empresa Empresa { get; set; } = null!;

    // Vendedor asignado por la recepcionista
    public Guid? VendedorId { get; set; }
    public virtual Usuario? Vendedor { get; set; }

    // Estado del seguimiento
    public bool Atendido { get; set; } = false;
    public string? NotasRecepcion { get; set; }
}