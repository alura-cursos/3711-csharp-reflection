using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json.Nodes;

namespace ByteBank.Common
{
    public interface IRelatorioDeBoleto<T>
    {
        void Processar(List<T> boletos);
    }

    public class RelatorioDeBoleto : IRelatorioDeBoleto<Boleto>
    {
        private readonly string nomeArquivoSaida;
        private readonly DateTime dataRelatorio = DateTime.Now;

        public RelatorioDeBoleto(string nomeArquivoSaida, DateTime dataRelatorio)
        {
            this.nomeArquivoSaida = nomeArquivoSaida;
            this.dataRelatorio = dataRelatorio;
        }

        public RelatorioDeBoleto(DateTime dataRelatorio)
        {
            this.dataRelatorio = dataRelatorio;
        }

        public RelatorioDeBoleto(string nomeArquivoSaida)
        {
            this.nomeArquivoSaida = nomeArquivoSaida;
        }

        public void Processar(List<Boleto> boletos)
        {
            var boletosPorCedente = PegaBoletosAgrupados(boletos);

            Console.WriteLine(JsonConvert.SerializeObject(boletosPorCedente));
        }

        private List<BoletosPorCedente> PegaBoletosAgrupados(List<Boleto> boletos)
        {
            // Agrupar boletos por cedente
            var boletosAgrupados = boletos.GroupBy(b => new
            {
                b.CedenteNome,
                b.CedenteCpfCnpj,
                b.CedenteAgencia,
                b.CedenteConta
            });

            // Lista para armazenar instâncias de BoletosPorCedente
            List<BoletosPorCedente> boletosPorCedenteList = new List<BoletosPorCedente>();

            // Iterar sobre os grupos de boletos por cedente
            foreach (var grupo in boletosAgrupados)
            {
                // Criar instância de BoletosPorCedente
                BoletosPorCedente boletosPorCedente = new BoletosPorCedente
                {
                    CedenteNome = grupo.Key.CedenteNome,
                    CedenteCpfCnpj = grupo.Key.CedenteCpfCnpj,
                    CedenteAgencia = grupo.Key.CedenteAgencia,
                    CedenteConta = grupo.Key.CedenteConta,
                    Valor = grupo.Sum(b => b.Valor),
                    Quantidade = grupo.Count()
                };

                // Adicionar à lista
                boletosPorCedenteList.Add(boletosPorCedente);
            }

            return boletosPorCedenteList;
        }
    }
}