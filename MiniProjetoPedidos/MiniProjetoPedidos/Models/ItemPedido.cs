using System.ComponentModel.DataAnnotations;

namespace MiniProjetoPedidos.Models
{
    public class ItemPedido
    {
        [Required]
        public string CodigoProduto { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
        public int Quantidade { get; set; }

        [Required]
        public string DescricaoProduto { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
        public decimal ValorProduto { get; set; }
    }
}
