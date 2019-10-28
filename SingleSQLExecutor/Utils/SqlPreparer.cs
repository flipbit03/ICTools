using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sispre.Utils
{
    public class SQLPreparer
    {
        private Dictionary<String, String> _variables;
        private String _delimiter;

        public SQLPreparer(Dictionary<String, String> variables, String delimiter = "@@") 
        {
            // Save variables
            _variables = variables;
            _delimiter = delimiter;
        }

        public Dictionary<String, String> GetVariablesInText(String sqlcode)
        {

            Dictionary<String, String> retval = new Dictionary<String, String>();

            // Define a regular expression for repeated words.
            String delimregex = String.Format(@"{0}(.*){0}", _delimiter);
            Regex rx = new Regex(delimregex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            
            // Find matches.
            MatchCollection matches = rx.Matches(sqlcode);

            // Report on each match.
            foreach (Match match in matches)
            {
                // Save key and delimiter-stripped key 
                retval[match.Groups[0].Value] = match.Groups[1].Value;
            }

            return retval;
        
        }

        public String Prepare(String sqlcode)
        {
            String retval = sqlcode;

            foreach(KeyValuePair<String, String> keypair in _variables)
            {
                // Iterate over keylist, and apply replace on all existing variables
                String preparedkey = String.Format("{0}{1}{0}", _delimiter, keypair.Key);
                retval = retval.Replace(preparedkey, keypair.Value);
            }

            return retval;
        }

    }
}
