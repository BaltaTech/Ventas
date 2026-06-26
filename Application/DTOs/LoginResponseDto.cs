using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class LoginResponseDto
    {
        public bool EsExitoso { get; set; }
        public string? Token { get; set; }  
        public string? Mensaje { get; set; }
        public string? NombreCompleto { get; set; }
        public int EmpresaId { get; set; }
        public string? Departamento { get; set; }
    }
}
