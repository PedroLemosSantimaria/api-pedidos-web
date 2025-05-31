using System.ComponentModel.DataAnnotations;

namespace MiniProjetoPedidos.Models
{
    public class Pedido
    {
        [Required]
        public string NumeroPedido { get; set; }

        [Required]
        public DateTime DataSolicitacao { get; set; }

        [Required]
        public DateTime DataEntrega { get; set; }
        
        public string Observacao { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Adicione pelo menos um item ao pedido")]
        public List<ItemPedido> Itens { get; set; }
    }
}
