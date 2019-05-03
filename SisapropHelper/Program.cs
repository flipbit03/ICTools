using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using CommandLine;

using ControleProducaoDAOS;
using ControleProducaoDAOS.DataStructures;

namespace SisapropHelper
{
    class Program
    {
        class Options
        {
            [Option('m', "mapname", HelpText = "Mapa a ser listado (autoaprop)", Default = "autoaprop")]
            public String mapname { get; set; }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            CommandLine.Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(opts =>
            {
                String s = GenerateMapOutput(opts.mapname);
                Console.Write(s);
            });
            
        }

        static string GenerateMapOutput(string mapname) {

            if (!(mapname == "autoaprop"))
                return "";

            StringBuilder retval = new StringBuilder();

            ControleProducaoDAO dao = new ControleProducaoDAO();

            ApropriadosPorApontadorData data = dao.ApropriadosPorAutoApropriador();

            foreach (Apontador apontador in data.GetApontadores())
            {
                foreach (string nomeequipe in data.GetEquipesPorApontador(apontador))
                {
                    foreach(SingleApropriadoPorApontadorData a in data.GetApropriadosPorEquipe(nomeequipe))
                    {
                        retval.AppendFormat("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}{10}",
                            a.matricula, a.nome, a.apelido, a.funcao, 
                            a.matr_apontador, a.nome_apontador, 
                            a.matr_responsavel, a.nome_responsavel,
                            a.equipe, a.descricao_equipe, 
                            Environment.NewLine);
                    }
                }
            }

            return retval.ToString();
        }
    }
}
