using Application.DTOs;
using Application.Interfaces;
using System.Net.Http.Json;

namespace VentasModulo.Client.Services;

public class UsuarioApiClient : IUsuarioService
{
    private readonly HttpClient _http;

    public UsuarioApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<UsuarioDto>> ObtenerVendedoresActivos()
    {
        try
        {
            // Se conecta al endpoint GET del servidor
            var vendedores = await _http.GetFromJsonAsync<IEnumerable<UsuarioDto>>("api/prospectos/vendedores");
            return vendedores ?? new List<UsuarioDto>();
        }
        catch (Exception)
        {
            // Retorna lista vacía si hay error para no romper la UI
            return new List<UsuarioDto>();
        }
    }

    public async Task CrearVendedor(UsuarioDto usuarioDto)
    {
        // El DTO ya debe incluir 'CorreoElectronico' para evitar el error CS1061
        var response = await _http.PostAsJsonAsync("api/prospectos/vendedores", usuarioDto);

        // Validamos que el servidor haya procesado el registro correctamente
        if (!response.IsSuccessStatusCode)
        {
            var errorMsg = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Error al registrar vendedor: {errorMsg}");
        }
    }
}