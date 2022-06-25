using System.ComponentModel.DataAnnotations;

namespace CryptoApi.Model
{
    public class Coins
    {
        [Key]
        public int CoinId { get; set; }
        public String? Descripcion { get; set; }
        public Double? Valor { get; set; }
        public String? ImagenUrl { get; set; }
    }
}
