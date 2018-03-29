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
