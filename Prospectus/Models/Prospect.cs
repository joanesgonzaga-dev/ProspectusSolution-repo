using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Models
{
    public class Prospect : Entity
    {

        public Prospect()
        {
            DataVisita = DateTime.Today;
            //Endereco = new Endereco();
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {1} e {2}", MinimumLength = 3)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "E campo {0} é obrigatório")]
        [StringLength(60, ErrorMessage = "O campo {0} precisa ter entre {1} e {2}", MinimumLength = 2)]
        [DisplayName("Contato")]
        public string PessoaContato { get; set; }

        [DisplayName("Data Visita")]
        public DateTime DataVisita { get; set; } //Converter em Data do Evento (Evento)

        [Required(ErrorMessage = "E campo Ramo de Atividade é obrigatório")]
        [StringLength(120, ErrorMessage = "O campo Ramo de Atividade precisa ter entre {1} e {2}", MinimumLength = 3)]
        [DisplayName("Ramo de Atividade")]
        public string Ramo { get; set; }

        public string Oportunidade { get; set; }

        [DisplayName("Receptividade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public RecepcaoEnum Recepcao { get; set; }  //Talvez o nome correto seja Qualificacao

        [DisplayName("Cenário")]
        public bool Cenario { get; set; }

        [DisplayName("Satisfação Atual")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public SatisfacaoCenarioEnum SatisfacaoCenario { get; set; }

        [StringLength(200, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 5)]
        [DisplayName("Observações")]
        public string Observacoes { get; set; }

        [DisplayName("Retorno")]
        public DateTime DataRetorno { get; set; }

        public IEnumerable<Contato> Contatos { get; set; }

        public Guid IndicadorId { get; set; }
        public Indicador Indicador { get; set; }

        [DisplayName("Endereço")]
        public Endereco Endereco { get; set; }
    }
}
