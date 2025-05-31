using System.Text.Json;
using MiniProjetoPedidos.Models;

namespace MiniProjetoPedidos.Auxiliares
{
    public class Storage
    {
        private static readonly string filePath = "pedidos.txt";

        
        public static List<Pedido> CarregaPedidos()
        {
            if (!File.Exists(filePath))
                return new List<Pedido>();

            var content = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Pedido>>(content) ?? new List<Pedido>();
        }

        public static void SalvaPedido(Pedido novo)
        {
            var pedidos = CarregaPedidos();
            pedidos.Add(novo);
            File.WriteAllText(filePath, JsonSerializer.Serialize(pedidos, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
