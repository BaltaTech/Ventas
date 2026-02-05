using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Sku { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public decimal? PrecioBase { get; set; }
        public decimal PrecioFinal => (PrecioBase ?? 0) * 1.20m;

        //Relacion con Marca 

        public int MarcaId { get; set; }
        public Marca Marca { get; set; } = null!;

        // Especificaciones Tecnicas 

        public int CapacidadBTU { get; set; }
        public TipoEquipo Tipo {  get; set; }

        public ModoOperacion Modo {  get; set; }
        public Voltaje Voltaje { get; set; }

        // Propiedad calculada para mostrar en la UI 
        public double Tonelaje => CapacidadBTU / 12000.0;


    }
}
