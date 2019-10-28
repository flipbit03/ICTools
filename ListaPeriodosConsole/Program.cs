using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ControleProducaoDAOS;
using ControleProducaoDAOS.DataStructures;

namespace ListaPeriodosConsole
{
    class Program
    {
        static String FormatNullableDatetime(DateTime? dt)
        {
            return dt.HasValue
                ? String.Format("{0}/{1}/{2}", 
                dt.Value.Day.ToString("d2"),
                dt.Value.Month.ToString("d2"),
                dt.Value.Year.ToString("d2"))
                : "";
        }

        static void Main(string[] args)
        {
            ControleProducaoDAO dao = new ControleProducaoDAO();

            List<PeriodoData> lp =  dao.ListaPeriodosApropriacao();

            Console.WriteLine("Lista de Períodos:");
            foreach(PeriodoData p in lp)
            {
                // estes dados sempre devem estar disponíveis.
                String datainistr = FormatNullableDatetime(p.dataInicio);
                String datafimstr = FormatNullableDatetime(p.dataFim);

                // o mês está fechado?
                String datafechamento = p.dataFechamento.HasValue 
                    ? "Fechado em "+FormatNullableDatetime(p.dataFechamento)
                    : "Período Aberto";

                String sMesReferencia = p.mesReferencia.HasValue ? p.mesReferencia.Value.ToString("d2") : p.mesReferencia.ToString();
                String sAnoReferencia = p.anoReferencia.HasValue ? p.anoReferencia.Value.ToString("d4") : p.anoReferencia.ToString();

                Console.WriteLine("ID={0,-3} [{1,-2}/{2,-4}] [{3,-21}] de {4} até {5}", 
                    p.idPeriodo, 
                    sMesReferencia, sAnoReferencia,
                    datafechamento, datainistr, datafimstr);
            }
            
        }
    }
}
