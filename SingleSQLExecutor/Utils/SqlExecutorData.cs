using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sispre.Utils
{

    public struct SqlExecutorInParams
    {
        public String in_filename;
        public String out_filename;
        public String sqlcode;
        public Dictionary<String, String> variables;
    }

    public class SqlExecutorResultSet
    {
        public String in_filename {get; set;}
        public String out_filename {get; set;}
        public String sqlcode {get; set;}
        public DataSet resultdataset {get; set;}
        public String resultstring {get; set;}
        public Boolean success = true;
        public String errormsg = "";
    }

}
