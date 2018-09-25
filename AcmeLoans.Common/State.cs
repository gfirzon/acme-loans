using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLoans.Common
{
    public class State
        {
        public int StateID { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", StateCode, StateName);
        }
    }
}
