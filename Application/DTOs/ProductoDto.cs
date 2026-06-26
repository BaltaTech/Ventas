namespace Application.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string NombreMarca { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public double Tonelaje { get; set; }
        public string Tipo { get; set; } = string.Empty; 
    }
}