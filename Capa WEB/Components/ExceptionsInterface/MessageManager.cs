using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsInterface
{
    public class MessageManager
    {

        public MessageManager()
        {

        }

        public List<AppMessage> RetrieveAllMessages()
        {
            var crud = new AppMessagesCrudFactory();

            return crud.RetrieveAll<AppMessage>();

        }

    }
}
