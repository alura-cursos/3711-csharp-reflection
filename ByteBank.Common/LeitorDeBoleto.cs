using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Common
{
    public class LeitorDeBoleto
    {
        public List<Boleto> LerBoletos(string caminhoArquivo)
        {
            throw new NotImplementedException();
            
            // montar lista de boletos

            // ler arquivo de boletos

                // ler cabeçalho do arquivo CSV

                // para cada linha do arquivo CSV
                    // ler dados
                    // carregar objeto Boleto
                    // adicionar boleto à lista

            // retornar lista de boletos
        }

        private Boleto MapearTextoParaBoleto(string[] nomesPropriedades, string[] valoresPropriedades)
        {
            Boleto instancia = new Boleto();
            instancia.CedenteNome = valoresPropriedades[0];
            instancia.CedenteCpfCnpj = valoresPropriedades[1];
            instancia.CedenteAgencia = valoresPropriedades[2];
            instancia.CedenteConta = valoresPropriedades[3];
            instancia.SacadoNome = valoresPropriedades[4];
            instancia.SacadoCpfCnpj = valoresPropriedades[5];
            instancia.SacadoEndereco = valoresPropriedades[6];
            instancia.Valor = Convert.ToDecimal(valoresPropriedades[7]);
            instancia.DataVencimento = Convert.ToDateTime(valoresPropriedades[8]);
            instancia.NumeroDocumento = valoresPropriedades[9];
            instancia.NossoNumero = valoresPropriedades[10];
            instancia.CodigoBarras = valoresPropriedades[11];
            instancia.LinhaDigitavel = valoresPropriedades[12];
            return instancia;
        }
    }
}
