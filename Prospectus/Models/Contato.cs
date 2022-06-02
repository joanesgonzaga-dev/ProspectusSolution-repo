using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Models
{
    public partial class Contato
    {
        public Guid Id { get; set; }

        public Contato()
        {
            Id = new Guid();
        }

        [Required(ErrorMessage = "E campo {0} é obrigatório")]
        //[StringLength(60, ErrorMessage = "O campo Contato precisa ter entre {1} e {2}", MinimumLength = 2)] //Como ele obedece à Mascara?
        [DisplayName("Contato")]
        public string Valor { get; set; }

        public int TipoContatoId { get; set; }
        public TipoContato TipoContato { get; set; }


        public Guid ProspectId { get; set; }
        public Prospect Prospect { get; set; }
    }
}
