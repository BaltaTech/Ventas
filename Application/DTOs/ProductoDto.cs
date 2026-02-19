namespace Application.DTOs
{
    public class ProductoDto
    {
        // Usamos int para coincidir con la Entidad Producto del Dominio
        public int Id { get; set; }

        // Mapeado desde 'Modelo' en la Entidad
        public string Nombre { get; set; } = string.Empty;

        // Mapeado desde 'PrecioFinal' (el que ya tiene el 20% de margen)
        public decimal Precio { get; set; }

        // Mapeado desde 'Marca.Nombre'
        public string NombreMarca { get; set; } = string.Empty;

        // --- Propiedades adicionales útiles para el vendedor ---

        public string Sku { get; set; } = string.Empty;

        // Esto ayuda al vendedor a confirmar el equipo rápidamente
        public double Tonelaje { get; set; }

        public string Tipo { get; set; } = string.Empty; // Ej: MiniSplit, Cassette
    }
}