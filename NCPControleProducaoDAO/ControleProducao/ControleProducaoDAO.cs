using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using ControleProducaoDAOS.Strings;
using ControleProducaoDAOS.DataStructures;

namespace ControleProducaoDAOS
{
    public class ControleProducaoDAO : GenericDAO
    {
        // Constructor (Connect to Database)
        public ControleProducaoDAO() : base("afrodite", "ControleProducao_PROD") { }

        public ApropriadosPorApontadorData ApropriadosPorApontador()
        {
            ApropriadosPorApontadorData r = new ApropriadosPorApontadorData();

            String sqlcode = CPStrings.sql_apropriadosporapontador();

            DataSet results = ExecuteSQLStatement(sqlcode, "ApropriadosPorApontador");

            // Populate Data
            foreach (DataRow dr in results.Tables[0].Rows)
            {
                SingleApropriadoPorApontadorData ap = new SingleApropriadoPorApontadorData();

                ap.matricula = Convert.ToInt32(dr[0]);
                ap.nome = Convert.ToString(dr[1]);
                ap.funcao = Convert.ToString(dr[2]);
                ap.nome_apontador = Convert.ToString(dr[3]);
                ap.equipe = Convert.ToString(dr[4]);

                r.data.Add(ap);
            }

            return r;
        }

        public ApropriadosPorApontadorData ApropriadosPorAutoApropriador()
        {
            ApropriadosPorApontadorData r = new ApropriadosPorApontadorData();

            String sqlcode = CPStrings.sql_apropriadosporautoapropriador();

            DataSet results = ExecuteSQLStatement(sqlcode, "ApropriadosPorAutoApropriador");

            // Populate Data
            foreach (DataRow dr in results.Tables[0].Rows)
            {
                SingleApropriadoPorApontadorData ap = new SingleApropriadoPorApontadorData();

                ap.matricula = Convert.ToInt32(dr[0]);
                ap.nome = Convert.ToString(dr[1]);
                ap.apelido = Convert.ToString(dr[2]);
                ap.funcao = Convert.ToString(dr[3]);
                ap.matr_apontador = Convert.ToString(dr[4]);
                ap.nome_apontador = Convert.ToString(dr[5]);
                ap.matr_responsavel = Convert.ToString(dr[6]);
                ap.nome_responsavel = Convert.ToString(dr[7]);
                ap.equipe = Convert.ToString(dr[8]);
                ap.descricao_equipe = Convert.ToString(dr[9]);

                r.data.Add(ap);
            }

            return r;
        }
        

        
        public HmCadTrabManData HmCadTrabMan(int _idPeriodo)
        {
            HmCadTrabManData r = new HmCadTrabManData();

            String sqlcode = String.Format(CPStrings.sql_hmcadtrabman(), _idPeriodo);

            DataSet results = ExecuteSQLStatement(sqlcode, "Periodos");

            // Populate TRAB
            foreach(DataRow dr in results.Tables[0].Rows)
            {
                String maq = Convert.ToString(dr[0]);
                decimal horas = (decimal)dr[1];
                r.hmcadtrab.Add(maq, horas);
            }

            // Populate MAN
            foreach (DataRow dr in results.Tables[2].Rows)
            {
                String maq = Convert.ToString(dr[0]);
                decimal horas = (decimal)dr[1];
                r.hmcadman.Add(maq, horas);
            }

            return r;
        }

        public List<PeriodoData> ListaPeriodosApropriacao()
        {
            String sqlcode = CPStrings.sql_listaperiodosapropriacao();

            DataSet results = ExecuteSQLStatement(sqlcode, "Periodos");

            List<PeriodoData> retval = new List<PeriodoData>();

            foreach(DataRow row in results.Tables[0].Rows)
            {
                PeriodoData p = new PeriodoData();

                p.idPeriodo = !Convert.IsDBNull(row[0])
                    ? Convert.ToInt32(row[0]) 
                    : (int?)null;

                p.dataInicio = !Convert.IsDBNull(row[1])
                    ? Convert.ToDateTime(row[1])
                    : (DateTime?)null;

                p.dataFim = !Convert.IsDBNull(row[2])
                    ? Convert.ToDateTime(row[2])
                    : (DateTime?)null;

                p.dataFechamento = !Convert.IsDBNull(row[3])
                    ? Convert.ToDateTime(row[3])
                    : (DateTime?)null;

                p.mesReferencia = !Convert.IsDBNull(row[4])
                    ? Convert.ToInt32(row[4])
                    : (int?)null;

                p.anoReferencia = !Convert.IsDBNull(row[5])
                    ? Convert.ToInt32(row[5])
                    : (int?)null;

                retval.Add(p);
            }

            return retval;
        }
    }
}
