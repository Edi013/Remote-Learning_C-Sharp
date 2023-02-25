using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Business
{
    public class PaymentMethod
    {
        public int Id { get; }
        public string Name { get; }

        public PaymentMethod(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
