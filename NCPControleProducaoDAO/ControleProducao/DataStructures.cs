using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleProducaoDAOS.DataStructures
{
    public class HmCadTrabManData
    {
        public Dictionary<String, decimal> hmcadtrab = new Dictionary<string, decimal>();
        public Dictionary<String, decimal> hmcadman = new Dictionary<string, decimal>();

        public decimal sum_hmcadtrab
        {
            get
            {
                decimal total = 0;
                foreach (KeyValuePair<String, decimal> kp in hmcadtrab)
                {
                    total += kp.Value;
                }

                return total;
            }
        }
        public decimal sum_hmcadman
        {
            get
            {
                decimal total = 0;
                foreach (KeyValuePair<String, decimal> kp in hmcadman)
                {
                    total += kp.Value;
                }

                return total;
            }
        }
    }

    public class PeriodoData
    {
        public int? idPeriodo { get; set; }
        public DateTime? dataInicio { get; set; }
        public DateTime? dataFim { get; set; }
        public DateTime? dataFechamento { get; set; }
        public int? mesReferencia { get; set; }
        public int? anoReferencia { get; set; }

        public String Repr1
        {
            get
            {
                String[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", 
                                     "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

                StringBuilder x = new StringBuilder();

                String mes_ano = String.Format("[ {0}/{1} ]", meses[mesReferencia.GetValueOrDefault() - 1], anoReferencia.GetValueOrDefault());

                String fechado = dataFechamento.HasValue ? "Fechado" : "Período Aberto -- Dados Incompletos";

                x.Append(mes_ano);
                x.Append(String.Format(" {0} até {1}", String.Format("{0:dd/MM/yyyy}", dataInicio), String.Format("{0:dd/MM/yyyy}", dataFim)));
                x.Append(String.Format(" [{0}]", fechado));

                return x.ToString();
            }
        }
    }
}
