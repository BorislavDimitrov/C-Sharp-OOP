using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Dictionary<int, ITransaction> dict = new Dictionary<int, ITransaction>();
            ITransaction transaction = new Transaction( 12, TransactionStatus.Failed, "Stoqn", "Nikolai", 45);
            transaction.Status = TransactionStatus.Successfull;
            dict.Add(12, transaction);
            Console.WriteLine(dict[12].Status);
        }
    }
}
