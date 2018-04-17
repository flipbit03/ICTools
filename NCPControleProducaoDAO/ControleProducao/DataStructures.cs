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
        public String matr_apontador { get; set; }
        public String nome_apontador { get; set; }
        public String equipe { get; set; }
        public String descricao_equipe { get; set; }
    }

    public class Apontador
    {
        public String matricula { get; set; }
        public String nome { get; set; }

        public Apontador(String _matricula, String _nome)
        {
            matricula = _matricula;
            nome = _nome;
        }

        public override string ToString()
        {
            return String.Format("{0}", nome);
        }

        public override bool Equals(object obj)
        {
            if(obj is Apontador)
            {
                Apontador _obj = (Apontador)obj;

                if( (matricula == _obj.matricula) && (nome == _obj.nome) ) {
                    return true;
                } else {
                    return false;
                }
            }

            return base.Equals(obj);
        }
    }

    public class ApropriadosPorApontadorData
    {
        public List<SingleApropriadoPorApontadorData> data = new List<SingleApropriadoPorApontadorData>();

        public List<Apontador> GetApontadores()
        {
            List<Apontador> r = new List<Apontador>();
            foreach(SingleApropriadoPorApontadorData ap in data)
            {
                Apontador newap = new Apontador(ap.matr_apontador, ap.nome_apontador);

                if (!r.Contains(newap))
                {
                    r.Add(newap);
                }
            }

            return r;
        }

        public List<String> GetEquipesPorApontador(Apontador _apontador)
        {
            List<String> r = new List<String>();
            foreach(SingleApropriadoPorApontadorData ap in data)
            {
                if ((r.IndexOf(ap.equipe) == -1) && (ap.nome_apontador == _apontador.nome))
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

        public List<SingleApropriadoPorApontadorData> GetAllApropriadosPorApontador(Apontador _apontador)
        {
            List<SingleApropriadoPorApontadorData> r = new List<SingleApropriadoPorApontadorData>();
            foreach (SingleApropriadoPorApontadorData ap in data)
            {
                if (ap.nome_apontador == _apontador.nome)
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
