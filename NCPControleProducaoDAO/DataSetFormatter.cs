using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ControleProducaoDAOS
{

namespace Formatting
{
    public class DataSetFormatter
    {
        public DataSetFormatter() { }

        public String FormatDataSetAsString(DataSet ds)
        {
            StringBuilder retval = new StringBuilder();

            foreach (DataTable dt in ds.Tables)
            {
                StringBuilder s = new StringBuilder();

                // Column Names
                foreach (DataColumn dc in dt.Columns)
                {
                    s.Append(String.Format("{0}|", dc.ColumnName));
                }
                s.Append("\r\n");

                // Rows
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (object o in dr.ItemArray)
                    {
                        s.Append(String.Format("{0}|", o.ToString()));
                    }
                    s.Append("\r\n");

                }
                s.Append("\r\n");

                retval.Append(s);
            }

            return retval.ToString();
        }
    }
}


}

