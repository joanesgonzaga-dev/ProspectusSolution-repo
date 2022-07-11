using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Models
{
    public class Produto : Item
    {
        public Produto()
        {
            this.isAtivo = true;
        }

        public string Nome { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [StringLength(3, ErrorMessage = "O campo {0} deve ter {1} caracteres")]
        public string Unidade { get; set; }

        public string Imagem { get; set; }

        [DisplayName("Cadastrado em")]
        public DateTime DataCadastro { get; set; }

        //Segundo o instrutor, as props decimais nao precisam ser mapeadas, a menos que se queira precisar casas decimais
        [DisplayName("Preço de Compra")]
        public decimal PrecoCompra { get; set; }
        [DisplayName("Preço de Custo")]
        public decimal PrecoCusto { get; set; }
        [DisplayName("Preço de Venda")]
        public decimal PrecoVenda { get; set; }

        [DisplayName("Ativado?")]
        public bool isAtivo { get; set; }

        [DisplayName("Excluído?")]
        public bool isExcluido { get; set; }

        [StringLength(8, ErrorMessage = "O campo {0} deve ter {1} caracteres numéricos", MinimumLength = 8)]
        public string NCM { get; set; }

        public Guid OportunidadeId { get; set; }

        public Oportunidade Oportunidade { get; set; }

    }
}
