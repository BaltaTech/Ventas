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
        public List<Marca> MarcasPermitidas { get; set; } = new();

        public bool PuedeComercializar(int marcaId)
        { 
            if (VendeTodasLasMarcas) return true;

            return MarcasPermitidas.Any(m => m.Id == marcaId);
        }       

    }
}
