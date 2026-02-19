using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        // Este método orquestará la validación y generación del token
        Task<LoginResponseDto> Login(LoginRequestDto request);
    }
}
