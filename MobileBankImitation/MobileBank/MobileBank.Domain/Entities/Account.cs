 using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MobileBank.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public DateTime OpenDate { get; set; }


        //navigation properties
        public Customer Customer { get; set; }
        public List<Transaction> DebitTransactions { get; set; }
        public List<Transaction> CreditTransactions{ get; set; }
    }
}
