using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Models
{
    public class Endereco
    {
        public Endereco()
        {
            Id = new Guid();
            Numero = "SN";
        }
        public Guid Id { get; set; }
        public Guid ProspectId { get; set; }

        public Prospect Prospect { get; set; }

        [Required(ErrorMessage = "E campo {0} é obrigatório")]
        [StringLength(60, ErrorMessage = "O campo Contato precisa ter entre {1} e {2}", MinimumLength = 3)]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        [Required(ErrorMessage = "E campo {0} é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ter entre {1} e {2}", MinimumLength = 8)]
        public string CEP { get; set; }

        public string UF { get; set; }

        public string Cidade { get; set; }
    }
}
