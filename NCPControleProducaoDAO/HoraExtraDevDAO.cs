using ControleProducaoDAOS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ControleProducaoDAOS
{

    public class TurnoRow
    {
        public DateTime di { get; set; }
        public DateTime df { get; set; }
        public string turno { get; set; }
        public string matr { get; set; }
        public string nome { get; set; }
        public string depto { get; set; }
        public string cargo { get; set; }
        public string os { get; set; }
    }

    public class HoraExtraDevDAO : GenericDAO
    {
        // Constructor (Connect to Database)
        public HoraExtraDevDAO() : base("afrodite", "HoraExtraDev") { }

        #region Pé de Galinha

        public int TotalPeDeGalinhaAdm(int _dia, int _mes, int _ano)
        {
            String sqlcode = String.Format(@"select count(*) from 
                                            VW_HORA_EXTRA_INDUSTRIAL where 
                                            tipo = 'Hora Extra' and fl_ativo = 'S' and 
                                            horaEntrada = '16:40' and horaSaida = '18:40' and
                                            dataInicio = '{0}-{1}-{2}';", _ano, _mes, _dia);


            SqlCommand cmd = new SqlCommand(sqlcode, sqlconn);

            SqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            int value = rdr.GetInt32(0);

            rdr.Close();

            return value;
        }

        public Dictionary<string, int> PeDeGalinhaPorCargo(int _dia, int _mes, int _ano)
        {
            String sqlcode = String.Format(@"
                                            select v.CARGO cargo, count(*) from 
                                            VW_HORA_EXTRA_INDUSTRIAL v where 
                                            tipo = 'Hora Extra' and fl_ativo = 'S' and 
                                            horaEntrada = '16:40' and horaSaida = '18:40' and
                                            dataInicio = '{0}-{1}-{2}'

                                            group by CARGO
                                            ORDER BY CARGO;", _ano, _mes, _dia);


            SqlCommand cmd = new SqlCommand(sqlcode, sqlconn);

            SqlDataReader rdr = cmd.ExecuteReader();

            Dictionary<string, int> retval = new Dictionary<string, int>();

            while (rdr.Read())
            {
                retval.Add(rdr.GetString(0), rdr.GetInt32(1));
            }

            rdr.Close();

            return retval;
        }

        public Dictionary<string, int> PeDeGalinhaPorDepto(int _dia, int _mes, int _ano)
        {
            String sqlcode = String.Format(@"
                                            select v.CCUSTO depto, count(*) from 
                                            VW_HORA_EXTRA_INDUSTRIAL v where 
                                            tipo = 'Hora Extra' and fl_ativo = 'S' and 
                                            horaEntrada = '16:40' and horaSaida = '18:40' and
                                            dataInicio = '{0}-{1}-{2}'

                                            group by CCUSTO
                                            ORDER BY CCUSTO;", _ano, _mes, _dia);


            SqlCommand cmd = new SqlCommand(sqlcode, sqlconn);

            SqlDataReader rdr = cmd.ExecuteReader();

            Dictionary<string, int> retval = new Dictionary<string, int>();

            while (rdr.Read())
            {
                retval.Add(rdr.GetString(0), rdr.GetInt32(1));
            }

            rdr.Close();

            return retval;
        }

        # endregion

        #region Turnos
        public int Total2o1oTurno(int _dia, int _mes, int _ano)
        {
            String sqlcode = String.Format(@"
                select 
	                count(matEmpregado)
                from 
	                VW_HORA_EXTRA_INDUSTRIAL 
                where 
	                tipo = 'Turno' and
	                pkTurno in (2,1) and
	                fl_ativo = 'S' and
	                dataInicio = '{0}-{1}-{2}';", _ano, _mes, _dia);


            return this.ExecuteScalarIntSQLStatement(sqlcode);
        }

        public DataSet GetEscaladosEmTurnos(int _dia, int _mes, int _ano)
        {
            String sqlcode = String.Format(@"
                select 
	                dataInicio di, dataFim df, DESCRICAOTURNO turno, 
	                matEmpregado matr, Nome nome, CCUSTO depto, CARGO cargo, 
	                PROJETO_DESC os  
                from 
	                VW_HORA_EXTRA_INDUSTRIAL 
                where 
	                tipo = 'Turno' and
	                pkTurno in (2,1) and
	                fl_ativo = 'S' and
	                dataInicio = '{0}-{1}-{2}'
                order by
	                dataInicio, pkTurno, CARGO, matEmpregado;
                                                    ", _ano, _mes, _dia);

            return this.ExecuteSQLStatement(sqlcode, "TurnoRowDataset");
        }

        #endregion

    }
}
