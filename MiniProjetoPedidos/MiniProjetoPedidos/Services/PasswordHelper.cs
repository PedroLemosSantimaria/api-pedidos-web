using System.Security.Cryptography;
using System.Text;

namespace MiniProjetoPedidos.Services
{
    public class PasswordHelper
    {
        public static string Hash(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool Verificar(string password, string hash)
        {
            return Hash(password) == hash;
        }
    }
}
