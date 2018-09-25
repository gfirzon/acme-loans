using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLoans.EFDataAccess
{
    public class StateManager
    {
        public List<State> GetStates()
        {
            AcmeLoansEntitiesEF e = new AcmeLoansEntitiesEF();

            var states = e.States.ToList();
            return states;
        }
    }
}
