using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Application.Security;

public class JwtProvider
{
    private readonly IConfiguration _configuration;

    public JwtProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Generate(Usuario usuario)
    {
        // 1. Información que va dentro del token (Claims)
        var claims = new Claim[]
        {
            new(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new(ClaimTypes.Email, usuario.CorreoElectronico),
            new(ClaimTypes.Name, usuario.NombreCompleto),
            new("EmpresaId", usuario.EmpresaId.ToString()), // <--- Vital para tus filtros
            new("Departamento", usuario.Departamento.ToString())
        };

        // 2. Crear la llave secreta (la configuraremos en el siguiente paso)
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // 3. Crear el objeto del token
        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(8), // Duración de una jornada laboral
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}