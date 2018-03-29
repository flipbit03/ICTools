using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ControleProducaoDAOS
{
    public class HmCadTrabManData
    {
        public Dictionary<String, decimal> hmcadtrab = new Dictionary<string,decimal>();
        public Dictionary<String, decimal> hmcadman = new Dictionary<string, decimal>();

        public decimal sum_hmcadtrab 
        {
            get 
            {
                decimal total = 0;
                foreach(KeyValuePair<String, decimal> kp in hmcadtrab)
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
                foreach(KeyValuePair<String, decimal> kp in hmcadman)
                {
                    total += kp.Value;
                }

                return total;
            }
        }
    }


    public class PeriodoData
    {
        public int? idPeriodo {get; set;}
        public DateTime? dataInicio {get; set;}
        public DateTime? dataFim {get; set;}
        public DateTime? dataFechamento {get; set;}
        public int? mesReferencia { get; set; }
        public int? anoReferencia { get; set; }

        public String Repr1
        {
            get
            {
                String[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", 
                                     "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

                StringBuilder x = new StringBuilder();

                String mes_ano = String.Format("[ {0}/{1} ]", meses[mesReferencia.GetValueOrDefault()-1], anoReferencia.GetValueOrDefault());

                String fechado = dataFechamento.HasValue ? "Fechado" : "Período Aberto -- Dados Incompletos";

                x.Append(mes_ano);
                x.Append(String.Format(" {0} até {1}", String.Format("{0:dd/MM/yyyy}", dataInicio), String.Format("{0:dd/MM/yyyy}", dataFim)));
                x.Append(String.Format(" [{0}]", fechado));

                return x.ToString();
            }
        }
    }

    public class ControleProducaoDAO : GenericDAO
    {
        // Constructor (Connect to Database)
        public ControleProducaoDAO() : base("afrodite", "ControleProducao_PROD") { }

        public HmCadTrabManData HmCadTrabMan(int _idPeriodo)
        {
            HmCadTrabManData r = new HmCadTrabManData();

            String sqlcode = String.Format(@"
            DECLARE @PERIODO AS INT = {0};
            -------------------------------------------------
            -- HMCADTRAB
            -------------------------------------------------
            select
	            maq.matricula EQUIPAMENTO, sum(a.qtdHoraMin)/60.0 HM_TOTAL_TRABALHADO
            from 
	            PeriodoApropriacao p,
	            Maquina maq,
	            Apropriacao a,
	            Atividade ativ
            where
	            -- somente apropriação de MÁQUINA 
	            a.fkTipoApropriacao = 2

	            -- junte máquinas
	            and a.fkMaquina = maq.pkMaquina 
	
	            -- selecione códigos de atividade especificos
	            and a.fkAtividade = ativ.pkAtividade
	            and ativ.codigo in (0, 12, 13, 14, 15, 16, 17, 18, 80)

	            -- escolha o periodo
	            and a.fkPeriodo = p.pkPeriodo
	            and p.pkPeriodo = @PERIODO

            group by maq.matricula
            order by maq.matricula;

            -------------------------------------------------
            -- HMCADTRAB
            -------------------------------------------------
            select
	            sum(a.qtdHoraMin)/60.0 SOMA_HM_TOTAL_TRABALHADO
            from 
	            PeriodoApropriacao p,
	            Maquina maq,
	            Apropriacao a,
	            Atividade ativ
            where
	            -- somente apropriação de MÁQUINA 
	            a.fkTipoApropriacao = 2

	            -- junte máquinas
	            and a.fkMaquina = maq.pkMaquina 
	
	            -- selecione códigos de atividade especificos
	            and a.fkAtividade = ativ.pkAtividade
	            and ativ.codigo in (0, 12, 13, 14, 15, 16, 17, 18, 80)

	            -- escolha o periodo
	            and a.fkPeriodo = p.pkPeriodo
	            and p.pkPeriodo = @PERIODO;

            -------------------------------------------------
            -- HMCADMAN
            -------------------------------------------------
            select
	            maq.matricula EQUIPAMENTO, sum(a.qtdHoraMin)/60.0 HM_TOTAL_MANUT
            from 
	            PeriodoApropriacao p,
	            Maquina maq,
	            Apropriacao a,
	            Atividade ativ
            where
	            -- somente apropriação de MÁQUINA 
	            a.fkTipoApropriacao = 2

	            -- junte máquinas
	            and a.fkMaquina = maq.pkMaquina 
	
	            -- selecione códigos de atividade especificos
	            and a.fkAtividade = ativ.pkAtividade
	            and ativ.codigo in (25)

	            -- escolha o periodo
	            and a.fkPeriodo = p.pkPeriodo
	            and p.pkPeriodo = @PERIODO

            group by maq.matricula
            order by maq.matricula;

            -------------------------------------------------
            -- HMCADTRAB
            -------------------------------------------------
            select
	            sum(a.qtdHoraMin)/60.0 SOMA_HM_TOTAL_MANUT
            from 
	            PeriodoApropriacao p,
	            Maquina maq,
	            Apropriacao a,
	            Atividade ativ
            where
	            -- somente apropriação de MÁQUINA 
	            a.fkTipoApropriacao = 2

	            -- junte máquinas
	            and a.fkMaquina = maq.pkMaquina 
	
	            -- selecione códigos de atividade especificos
	            and a.fkAtividade = ativ.pkAtividade
	            and ativ.codigo in (25)

	            -- escolha o periodo
	            and a.fkPeriodo = p.pkPeriodo
	            and p.pkPeriodo = @PERIODO;", _idPeriodo);

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
            String sqlcode = @"
                select 
                pkPeriodo, dataInicio, dataFim, dataFechamento, mesReferencia, anoReferencia 
                from PeriodoApropriacao
                order by anoReferencia desc, mesReferencia desc;";

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
