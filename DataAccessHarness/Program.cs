using AcmeLoans.Common;
using AcmeLoans.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

            LoanTypeManager accessor = new LoanTypeManager();

            List<LoanType> list = accessor.GetLoanTypes();

            foreach (LoanType item in list)
            {
                //Console.WriteLine("ID: {0} Desc: {1}", item.LoanTypeId, item.Description);
                Console.WriteLine(item);
            }
            */
            StateManager accessor = new StateManager();
            List<State> list = accessor.GetStates();

            foreach (State item in list)
            {
                Console.WriteLine("ID: {0} State Code: {1} State Name: {2}", item.StateID, item.StateCode, item.StateName);
               // Console.WriteLine(item);
            }
            Console.WriteLine("Press any key to contine...");
            Console.ReadKey();
        }
    }
}
