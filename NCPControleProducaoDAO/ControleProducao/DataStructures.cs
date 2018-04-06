using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleProducaoDAOS.DataStructures
{
    public class SingleApropriadoPorApontadorData
    {
        public int matricula { get; set; }
        public String nome { get; set; }
        public String funcao { get; set; }
        public String apontador { get; set; }
        public String equipe { get; set; }
    }

    public class ApropriadosPorApontadorData
    {
        public List<SingleApropriadoPorApontadorData> data = new List<SingleApropriadoPorApontadorData>();

        public List<String> GetApontadores()
        {
            List<String> r = new List<String>();
            foreach(SingleApropriadoPorApontadorData ap in data)
            {
                if (r.IndexOf(ap.apontador) == -1)
                {
                    r.Add(ap.apontador);
                }
            }

            return r;
        }

        public List<String> GetEquipesPorApontador(String _apontador)
        {
            List<String> r = new List<String>();
            foreach(SingleApropriadoPorApontadorData ap in data)
            {
                if ((r.IndexOf(ap.equipe) == -1) && (ap.apontador == _apontador))
                {
                    r.Add(ap.equipe);
                }
            }
            return r;
        }

        public List<SingleApropriadoPorApontadorData> GetApropriadosPorEquipe(String _EquipeNome)
        {
            List<SingleApropriadoPorApontadorData> r = new List<SingleApropriadoPorApontadorData>();
            foreach (SingleApropriadoPorApontadorData ap in data)
            {
                if(ap.equipe == _EquipeNome)
                {
                    r.Add(ap);
                }
            }
            return r;
        }

        public List<SingleApropriadoPorApontadorData> GetAllApropriadosPorApontador(String _apontador)
        {
            List<SingleApropriadoPorApontadorData> r = new List<SingleApropriadoPorApontadorData>();
            foreach (SingleApropriadoPorApontadorData ap in data)
            {
                if (ap.apontador == _apontador)
                {
                    r.Add(ap);
                }
            }
            return r;
        }

    }
    
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

        private String[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", 
                                     "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

        public String ReprSimples
        {
            get
            {

                StringBuilder x = new StringBuilder();

                String mes_ano = String.Format("{0}/{1} :", meses[mesReferencia.GetValueOrDefault() - 1].Substring(0,3), anoReferencia.GetValueOrDefault());

                String fechado = dataFechamento.HasValue ? "Fechado" : "Aberto";

                x.Append(mes_ano);
                x.Append(String.Format(" {0} até {1}", String.Format("{0:dd/MM/yyyy}", dataInicio), String.Format("{0:dd/MM/yyyy}", dataFim)));
                x.Append(String.Format(" [{0}]", fechado));

                return x.ToString();
            }
        }

        public String Repr1
        {
            get
            {

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
