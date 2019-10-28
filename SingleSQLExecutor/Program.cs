using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Sispre.Utils;
using System.IO;
using System.Reflection;

namespace SingleSQLExecutor
{
    class ProgramCmdLineArgs
    {
        public String insqlfn { get; set; }
        public String outfilen { get; set; }
        public String datasource { get; set; }
        public String initial_catalog { get; set; }
    }
    
    class Program
    {
        static void PrintBanner()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("SingleSQLExecutor");
            Console.WriteLine("------------------------------");
        }

        static Dictionary<String, String> GenerateVariableList(System.Collections.IDictionary dict, String prefix = "SP_")
        {
            Dictionary<String, String> retval = new Dictionary<String,String>();

            foreach(String key in dict.Keys)
            {
                if (key.StartsWith(prefix))
                {
                    String keyname = Regex.Replace(key, String.Format("^{0}", prefix), "");
                    retval.Add(keyname, (String)dict[key]);
                }
            }

            return retval;
        }

        static ProgramCmdLineArgs ParseCmdLineArgs(string[] args, String default_datasource = "afrodite", String default_initial_catalog = "ControleProducao_PROD")
        {
            ProgramCmdLineArgs parsedargs = new ProgramCmdLineArgs();

            // Parse arguments -- 2 mandatory inputs + 2 optional
            // insql outfile [datasource="afrodite"] [initial_catalog="ControleProducao_PROD"]

            if (args.Length == 4)
            {
                parsedargs.insqlfn = args[0];
                parsedargs.outfilen = args[1];
                parsedargs.datasource = args[2];
                parsedargs.initial_catalog = args[3];
            }
            else if (args.Length == 2)
            {
                parsedargs.insqlfn = args[0];
                parsedargs.outfilen = args[1];
                parsedargs.datasource = default_datasource;
                parsedargs.initial_catalog = default_initial_catalog;
            }
            else if (args.Length == 1)
            {
                parsedargs.insqlfn = args[0];
                parsedargs.outfilen = args[0] + "_out.txt";
                parsedargs.datasource = default_datasource;
                parsedargs.initial_catalog = default_initial_catalog;
            }
            else
            {
                throw new ArgumentException("Quantidade Inválida de Parâmetros");
            }

            return parsedargs;
        }


        static int Main(string[] args)
        {
            PrintBanner();

            // Parse Commandline Arguments
            ProgramCmdLineArgs parsedargs;
            try
            {
                parsedargs = ParseCmdLineArgs(args);
            }
            catch(ArgumentException e)
            {
                // Get running filename
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                string name = Path.GetFileName(codeBase);

                Console.WriteLine("ERRO: " + e.Message);
                Console.WriteLine();
                Console.WriteLine("Argumentos: {0} datasource initial_catalog sql_in out_filename", name);
                return 1;
            }
            
            // Get all environment variables.
            System.Collections.IDictionary envs = System.Environment.GetEnvironmentVariables();

            // Debug: Manually set environment variables.
            //envs["SP_PERIODO"] = "1";

            // Get all useable variables to substitute in the process.
            Dictionary<String, String> variables = GenerateVariableList(envs);

            // Listar variáveis
            if(Convert.ToBoolean(variables.Count))
            {
                Console.WriteLine("-----------");
                Console.WriteLine("-Variáveis-");
                Console.WriteLine("-----------");
                foreach (KeyValuePair<String, String> kvp in variables)
                {
                    String kvs = String.Format("  {0} = {1}", kvp.Key, kvp.Value);
                    Console.WriteLine(kvs);
                }
                Console.WriteLine("-----------\n");
            }

            // Get SQL Code data
            String sqlcode;
            try
            {
                sqlcode = File.ReadAllText(parsedargs.insqlfn, Encoding.Default);
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("ERRO: " + e.Message);
                return 1;
            }
            
            // Prepare SQLExecutor parameters
            SqlExecutorInParams seip = new SqlExecutorInParams();
            seip.in_filename = parsedargs.insqlfn;
            seip.out_filename = parsedargs.outfilen;
            seip.sqlcode = sqlcode;
            seip.variables = variables;

            // Feed paramaters to SQLExecutor and Execute.
            SqlExecutor se = new SqlExecutor(seip);
            Console.Write("Executing SQL {0}...", parsedargs.insqlfn);
            SqlExecutorResultSet sers = se.Execute();

            // program exit status code.
            int retval = 0; // success

            if(!sers.success)
            {
                Console.WriteLine("Fail.\n");
                String errormsg = String.Format("Error Message: {0}", sers.errormsg);
                Console.WriteLine(errormsg);

                // exit status code = failure
                retval = 1;
            }
            else
            {
                Console.WriteLine("OK!");
            }

            // Write result out -- use out_filename from SqlExecutorResultSet because it might be transformed with variables.
            String out_filename = sers.out_filename;
            Console.WriteLine();
            Console.WriteLine("Writing results to {0}...", out_filename);
            Console.WriteLine("");
            File.WriteAllText(out_filename, sers.resultstring, Encoding.Default);

            // Debug
            //Console.ReadKey();

            return retval;
        }
    }

}
