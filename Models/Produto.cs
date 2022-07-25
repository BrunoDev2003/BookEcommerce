using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEcommerceAPI.Models
{
    public class Produto
    {
        public string ID { get; set; }
        public string Nome { get; set; }

        public int Preco { get; set; }

        public int quantidade { get; set; }

        public string Categoria { get; set; }

        public string img { get; set; }
    }
}