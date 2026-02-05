using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazonSocial{ get; set; } = string.Empty;

        public bool VendeTodasLasMarcas { get; set; }

        //Relacion UNO a MUCHOS: Una empresa tiene muchas marcas permitidas

        public List<Marca> MarcasPermitidas { get; set; } = new();

        //REGLA DE NEGOCIO: Centralizar la Validacion

        public bool PuedeComercializar(int marcaId)
        { 
           // Si la lista está vacía ¿Vende todo o nada?
           //Si no hay marcas asignadas, no vende ninguna por seguridad

            if (VendeTodasLasMarcas) return true;

            return MarcasPermitidas.Any(m => m.Id == marcaId);
        
           // FLEXIBILIDAD: Si una razón social crece y obtiene licencia de una marca, solo agrego un registro en la base de datos
           // AISLAMIENTO: La logica de "quien puede vender que" vive dentro de la entidad "Empresa"
           // MULTITENANCY: Al logearse, el sistema carga la "Empresa Activa" y sus "Marcas Permitidas".
           // ... apartir de ahí  todos los filtros se vuelven automaticos. 


        }       

    }
}
