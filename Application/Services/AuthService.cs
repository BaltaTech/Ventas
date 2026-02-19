using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration; // Añadido para leer appsettings
using Microsoft.IdentityModel.Tokens;     // Añadido para JWT
using System.IdentityModel.Tokens.Jwt;    // Añadido para JWT
using System.Security.Claims;
using System.Text;

namespace Application.Security;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepo;
    private readonly PasswordHasher _hasher;
    private readonly IConfiguration _config; // Inyectamos la configuración

    public AuthService(IUsuarioRepository usuarioRepo, PasswordHasher hasher, IConfiguration config)
    {
        _usuarioRepo = usuarioRepo;
        _hasher = hasher;
        _config = config;
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto request)
    {
        var usuario = await _usuarioRepo.GetByEmailAsync(request.Correo);

        if (usuario == null || !_hasher.Verify(request.Password, usuario.PasswordHash))
        {
            return new LoginResponseDto { EsExitoso = false, Mensaje = "Correo o contraseña incorrectos" };
        }

        // --- GENERACIÓN DEL TOKEN REAL ---
        var token = GenerarJwtToken(usuario);

        return new LoginResponseDto
        {
            EsExitoso = true,
            NombreCompleto = usuario.NombreCompleto,
            EmpresaId = usuario.EmpresaId,
            Departamento = usuario.Departamento.ToString(),
            Token = token // Ahora devuelve el token cifrado
        };
    }

    private string GenerarJwtToken(Domain.Entities.Usuario usuario)
    {
        var jwtSettings = _config.GetSection("JwtSettings");

        // Leemos directamente usando la clave entre corchetes []
        var secretKey = jwtSettings["Secret"];
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];
        var expiryMinutes = int.Parse(jwtSettings["ExpiryMinutes"] ?? "480");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
        new Claim(ClaimTypes.Email, usuario.CorreoElectronico),
        new Claim(ClaimTypes.Name, usuario.NombreCompleto),
        new Claim("EmpresaId", usuario.EmpresaId.ToString()),
        new Claim("Departamento", usuario.Departamento.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(expiryMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}