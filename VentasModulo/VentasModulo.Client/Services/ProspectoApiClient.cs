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
        var response = await _http.PostAsJsonAsync("api/prospectos", prospectoDto);
        response.EnsureSuccessStatusCode();
    }

    public async Task<IEnumerable<ProspectoDto>> ObtenerTodos()
    {
        return await _http.GetFromJsonAsync<IEnumerable<ProspectoDto>>("api/prospectos")
               ?? new List<ProspectoDto>();
    }

    public async Task MarcarComoAtendido(Guid prospectoId)
    {
        // Usamos PUT porque estamos actualizando un recurso existente
        // Enviamos un contenido vacío (new { }) ya que el ID va en la URL
        var response = await _http.PutAsJsonAsync($"api/prospectos/{prospectoId}/atender", new { });

        // Es buena práctica verificar que el servidor respondió correctamente
        response.EnsureSuccessStatusCode();
    }

    public async Task<IEnumerable<ProspectoDto>> ObtenerPendientesPorVendedor(Guid vendedorId)
    {
        return await _http.GetFromJsonAsync<IEnumerable<ProspectoDto>>($"api/prospectos/vendedor/{vendedorId}")
               ?? new List<ProspectoDto>();
    }

    public async Task<IEnumerable<ProspectoDto>> ObtenerTodosPorEmpresa(int empresaId)
    {
        return await _http.GetFromJsonAsync<IEnumerable<ProspectoDto>>($"api/prospectos/empresa/{empresaId}")
               ?? new List<ProspectoDto>();
    }

    // Métodos auxiliares para los combos del formulario
    public async Task<IEnumerable<EmpresaDto>> ObtenerEmpresasHabilitadas()
    {
        return await _http.GetFromJsonAsync<IEnumerable<EmpresaDto>>("api/prospectos/empresas")
               ?? new List<EmpresaDto>();
    }

    public async Task<IEnumerable<UsuarioDto>> ObtenerVendedoresActivos()
    {
        return await _http.GetFromJsonAsync<IEnumerable<UsuarioDto>>("api/prospectos/vendedores")
               ?? new List<UsuarioDto>();
    }
}