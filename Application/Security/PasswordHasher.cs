using BCrypt.Net;

namespace Application.Security;

public class PasswordHasher
{
    // Encriptar al crear usuario
    public string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    // Verificar al loguear
    public bool Verify(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
}