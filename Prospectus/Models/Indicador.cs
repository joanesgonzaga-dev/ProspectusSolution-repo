using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Models
{
    public class Indicador : Entity
    {
        public string Nome { get; set; }

        public IEnumerable<Prospect> Prospects { get; set; }

    }
}
