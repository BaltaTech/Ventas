using Application.DTOs;
using Application.Interfaces;
using System.Net.Http.Json;

namespace VentasModulo.Client.Services;

public class EmpresaApiClient : IEmpresaService
{
    private readonly HttpClient _http;
    public EmpresaApiClient(HttpClient http) => _http = http;

    public async Task<IEnumerable<EmpresaDto>> ObtenerEmpresasHabilitadas()
    {
        // Esta ruta debe coincidir con el [HttpGet("empresas")] de tu ProspectosController
        return await _http.GetFromJsonAsync<IEnumerable<EmpresaDto>>("api/prospectos/empresas")
               ?? new List<EmpresaDto>();
    }
}