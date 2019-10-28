using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ControleProducaoDAOS;
using ControleProducaoDAOS.Formatting;
using System.Data;
using System.Data.SqlClient;

namespace Sispre.Utils
{

    public class SqlExecutor
    {
        private SQLPreparer _preparer;
        private bool _production;
        private DataSetFormatter _formatter;
        private SqlExecutorInParams _parameters;

        private GenericDAO ConnectToDb(bool production = true)
        {
            String initial_catalog = "ControleProducao_PROD";
            if (!production)
                initial_catalog = "ControleProducao";

            // Initialize DB Connection
            return new GenericDAO("afrodite", initial_catalog);
        }

        public SqlExecutor(SqlExecutorInParams parameters, bool production = true)
        { 
            // Save execution parameters
            _parameters = parameters;

            // Save production flag
            _production = production;

            // Init preparer
            _preparer = new SQLPreparer(_parameters.variables);

            // Init DataSet formatter
            _formatter = new DataSetFormatter();
        }

        public DataSet ExecuteSQLAsDataSet(String datasetname = "SQL")
        {
            // Process sql with variables
            String prepared_sql = _preparer.Prepare(_parameters.sqlcode);

            // Get DAO
            GenericDAO dao = ConnectToDb(_production);

            // Execute SQL.
            return dao.ExecuteSQLStatement(prepared_sql, datasetname);

        }

        public String ExecuteAsString()
        {
            // Return the DataSet formatted as string.
            return _formatter.FormatDataSetAsString(ExecuteSQLAsDataSet());
        }


        public SqlExecutorResultSet Execute()
        {
            SqlExecutorResultSet retval = new SqlExecutorResultSet();

            retval.in_filename = _parameters.in_filename;
            
            // Use the preparer to also transform the output file name using the provided variables.
            retval.out_filename = _preparer.Prepare(_parameters.out_filename);

            // Execute the query.
            try
            {
                retval.resultdataset = ExecuteSQLAsDataSet();
                retval.resultstring = _formatter.FormatDataSetAsString(retval.resultdataset);
                retval.success = true;
            }
            catch (SqlException e)
            {
                // set success to False and log error msg
                retval.success = false;
                retval.errormsg = String.Format("Error executing SQL {0}: {1}", retval.in_filename, e.Message);
                retval.resultstring = retval.errormsg;
            }

            return retval;
        }

    }
}
