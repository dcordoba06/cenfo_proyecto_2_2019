using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Customer : BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Customer()
        {
            
        }

        public Customer(string[] infoArray)
        {
            if(infoArray!=null && infoArray.Length >= 4){
                Id = infoArray[0];
                Name = infoArray[1];
                LastName = infoArray[2];
                var age = 0;
                if (Int32.TryParse(infoArray[3], out age))
                    Age = age;
                else
                    throw new Exception("Age must be a number");
            }
            else
            {
                throw new Exception("All values are require[id,name,last_name,age]");
            }

        }

    }
}
