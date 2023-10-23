using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BCustomer
    {
        public Customer BuscarPorNombre(string name)
        {
            List<Customer> customers = new List<Customer>();
            customers = Dcustomer.ListarClientes();

            foreach (var cust in customers)
            {
                if (cust.Name.Equals(name))
                {
                    return cust;
                }
            }

            return null;
        }
    }
}
