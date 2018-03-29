using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using ControleProducaoDAOS.Formatting;

namespace ControleProducaoDAOS
{
    public class GenericDAO
    {
        protected SqlConnection sqlconn;
        public DataSetFormatter datasetformatter;

        // Constructor (Connect to Database)
        public GenericDAO(String datasource, String initial_catalog)
        {
            String ConnectString_template = "Data Source={0};Initial Catalog={1};Integrated Security=SSPI;";

            String ConnectString = String.Format(ConnectString_template, datasource, initial_catalog);

            // Connect to Database using the Connection String provided in the ClassDef
            this.sqlconn = new SqlConnection(ConnectString);
            this.sqlconn.Open();

            // Instantiate DataSetFormatterClass
            this.datasetformatter = new DataSetFormatter();
        }


        public DataSet ExecuteSQLStatement(String sqlstmt, String datasetname)
        {
            // Prepare sql command and sql data adapter
            SqlCommand cmd = new SqlCommand(sqlstmt, sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Fill Dataset object with result
            DataSet ds = new DataSet(datasetname);
            da.Fill(ds);

            return ds;
        }

        public int ExecuteScalarIntSQLStatement(String sqlstmt)
        {
            SqlCommand cmd = new SqlCommand(sqlstmt, sqlconn);

            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            int value = rdr.GetInt32(0);
            rdr.Close();

            return value;
        }

    }
}
