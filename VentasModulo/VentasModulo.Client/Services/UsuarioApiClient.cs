using Application.DTOs;
using Application.Interfaces;
using System.Net.Http.Json;

namespace VentasModulo.Client.Services;

public class UsuarioApiClient : IUsuarioService
{
    private readonly HttpClient _http;
    public UsuarioApiClient(HttpClient http) => _http = http;

    public async Task<IEnumerable<UsuarioDto>> ObtenerVendedoresActivos()
    {
        // Esta ruta debe coincidir con el [HttpGet("vendedores")] de tu ProspectosController
        return await _http.GetFromJsonAsync<IEnumerable<UsuarioDto>>("api/prospectos/vendedores")
               ?? new List<UsuarioDto>();
    }
}