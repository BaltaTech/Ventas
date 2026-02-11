using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Marca
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        // Agregar descripción por si no hay not    as especificas

        public string? Descripcion { get; set; }

    }
}

// FLEXIBILIDAD: Si una razon social crece, obtiene licencia de una nueva marca
// solo tengo que agregar un registro a la base de datos 

// AISLAMIENTO: La logica de "quien puede vender que" vive dentro de la entidad Empresa

// MULTITENENCY: Al logearse, el sistema carga la "Empresa Activa" y sus "Marcas Permitidas"
