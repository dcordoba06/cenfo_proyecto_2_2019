using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class CustomerManager
    {
        private CustomerCrudFactory crudCustomer;

        public CustomerManager()
        {
            crudCustomer = new CustomerCrudFactory();
        }

        public void Create(Customer customer)
        {
            try
            {
                var c = crudCustomer.Retrieve<Customer>(customer);

                if (c != null)
                {
                    //Customer already exist
                    throw new BussinessException(3);
                }

                if (customer.Age >= 18)
                    crudCustomer.Create(customer);
                else
                    throw new BussinessException(2);
            }
            catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Customer> RetrieveAll()
        {
            return crudCustomer.RetrieveAll<Customer>();
        }

        public Customer RetrieveById(Customer customer)
        {
            return crudCustomer.Retrieve<Customer>(customer);
        }

        internal void Update(Customer customer)
        {
            crudCustomer.Update(customer);
        }

        internal void Delete(Customer customer)
        {
            crudCustomer.Delete(customer);
        }
    }
}
