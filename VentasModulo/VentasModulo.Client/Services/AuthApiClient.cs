using System.Net.Http.Json;
using Application.DTOs;

namespace VentasModulo.Client.Services;

public class AuthApiClient
{
    private readonly HttpClient _httpClient;

    public AuthApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequest)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginRequest);

        // Si el login falla (401), intentamos leer el mensaje de error del DTO
        if (!response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<LoginResponseDto>()
                   ?? new LoginResponseDto { EsExitoso = false, Mensaje = "Credenciales incorrectas" };
        }

        return (await response.Content.ReadFromJsonAsync<LoginResponseDto>())!;
    }
}