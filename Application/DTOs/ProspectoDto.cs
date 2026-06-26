using Domain.Enums;

namespace Application.DTOs
{
    public class ProspectoDto
    {
        public Guid Id { get; set; }
        public DateTime FechaRegistro { get; set; }

        // --- Datos del Cliente ---
        public string NombreCliente { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Correo { get; set; }

        // --- Clasificación y Origen ---
        public OrigenProspecto Origen { get; set; }
        public string OrigenNombre => Origen.ToString();

        // --- Vinculación con Empresa (A o B) ---
        public int EmpresaId { get; set; }
        public string RazonSocial { get; set; } = string.Empty;

        // --- Asignación de Vendedor ---
        public Guid? VendedorId { get; set; }
        public string NombreVendedor { get; set; } = string.Empty;

        // --- Estado del Lead ---
        public bool Atendido { get; set; }
        public string? NotasRecepcion { get; set; }
    }
}