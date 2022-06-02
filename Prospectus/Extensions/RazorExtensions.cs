using Microsoft.AspNetCore.Mvc.Razor;
using Prospectus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataDocumento(this RazorPage page, int tipoPessoa, string documento)
        {

            return tipoPessoa == 1 ? Convert.ToUInt64(documento).ToString(format: @"000\.000\.000-00") : Convert.ToUInt64(documento).ToString(format: @"00\.000\.000\/0000-00");
        }

        public static string FormataSatisfacaoCenario(this RazorPage page, SatisfacaoCenarioEnum nivelSatisfacao)
        {
            string satisfacao = "";

            switch (nivelSatisfacao)
            {
                case SatisfacaoCenarioEnum.Pessimo:
                    satisfacao = "Péssimo";
                    break;
                case SatisfacaoCenarioEnum.Ruim:
                    satisfacao = "Ruim";
                    break;
                case SatisfacaoCenarioEnum.Regular:
                    satisfacao = "Regular";
                    break;
                case SatisfacaoCenarioEnum.Bom:
                    satisfacao = "Bom";
                    break;
                case SatisfacaoCenarioEnum.Otimo:
                    satisfacao = "Ótimo";
                    break;
                default:
                    satisfacao = "Indefinido";
                    break;
            }

            return satisfacao;
        }

        public static string FormataReceptividade(this RazorPage page, RecepcaoEnum recepcaoEnum)
        {
            string recepcao = "";

            switch (recepcaoEnum)
            {
                case RecepcaoEnum.Hostil:
                    recepcao = "Hostil";
                    break;
                case RecepcaoEnum.NenhumInteresse:
                    recepcao = "Nenhum Interesse";
                    break;
                case RecepcaoEnum.PoucoInteressado:
                    recepcao = "Pouco Interesse";
                    break;
                case RecepcaoEnum.Interessado:
                    recepcao = "Interessado";
                    break;
                case RecepcaoEnum.MuitoInteressado:
                    recepcao = "Muito Interessado";
                    break;
                default:
                    recepcao = "Indefinido";
                    
                    break;
            }

            return recepcao;
        }
    }
}
