using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Models
{
    public class Oportunidade
    {
        public Oportunidade()
        {
            this.Id = new Guid();
        }
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
        public IEnumerable<Prospect> Prospects { get; set; }
    }
}
