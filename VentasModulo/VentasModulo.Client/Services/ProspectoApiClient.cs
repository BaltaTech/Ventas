using Application.DTOs;
using Application.Interfaces;
using System.Net.Http.Json;

namespace VentasModulo.Client.Services;

public class ProspectoApiClient : IProspectoService
{
    private readonly HttpClient _http;

    public ProspectoApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task Crear(ProspectoDto prospectoDto)
    {
        await _http.PostAsJsonAsync("api/prospectos", prospectoDto);
    }

    // --- NUEVO MÉTODO PARA LA LISTA ---
    public async Task<IEnumerable<ProspectoDto>> ObtenerTodos()
    {
        // Esto traerá a Saul Baltazar y todos los registros de aire acondicionado
        return await _http.GetFromJsonAsync<IEnumerable<ProspectoDto>>("api/prospectos")
               ?? new List<ProspectoDto>();
    }

    public async Task<IEnumerable<EmpresaDto>> ObtenerEmpresasHabilitadas()
    {
        return await _http.GetFromJsonAsync<IEnumerable<EmpresaDto>>("api/prospectos/empresas") ?? new List<EmpresaDto>();
    }

    public async Task<IEnumerable<UsuarioDto>> ObtenerVendedoresActivos()
    {
        return await _http.GetFromJsonAsync<IEnumerable<UsuarioDto>>("api/prospectos/vendedores") ?? new List<UsuarioDto>();
    }

    // Implementaciones básicas para evitar errores de compilación
    public async Task<IEnumerable<ProspectoDto>> ObtenerPendientesPorVendedor(Guid vendedorId)
    {
        return await _http.GetFromJsonAsync<IEnumerable<ProspectoDto>>($"api/prospectos/vendedor/{vendedorId}") ?? new List<ProspectoDto>();
    }

    public async Task<IEnumerable<ProspectoDto>> ObtenerTodosPorEmpresa(int empresaId)
    {
        return await _http.GetFromJsonAsync<IEnumerable<ProspectoDto>>($"api/prospectos/empresa/{empresaId}") ?? new List<ProspectoDto>();
    }

    public async Task MarcarComoAtendido(Guid prospectoId)
    {
        await _http.PutAsJsonAsync($"api/prospectos/{prospectoId}/atender", new { });
    }
}