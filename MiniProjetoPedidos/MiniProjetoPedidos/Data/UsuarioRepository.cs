using MiniProjetoPedidos.Models;
using System.Text.Json;

namespace MiniProjetoPedidos.Data
{
    public class UsuarioRepository
    {
        private readonly string filePath = "usuarios.json";

        public List<Usuario> GetUsuarios()
        {
            if (!File.Exists(filePath))
                return new List<Usuario>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
        }

        public void SalvarUsuarios(List<Usuario> usuarios)
        {
            var json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            var lista = GetUsuarios();
            lista.Add(usuario);
            SalvarUsuarios(lista);
        }

        public Usuario? BuscarUsuario(string username)
        {
            return GetUsuarios().FirstOrDefault(u => u.Username == username);
        }
    }
}
