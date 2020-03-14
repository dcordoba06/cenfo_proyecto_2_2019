
using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ListManager : BaseManager
    {
        private Dictionary<string, List<OptionList>> dicListOptions;
        //private ListCrudFactory crudCustomer;

        public ListManager()
        {
            LoadDictionary();
            //crudCustomer = new ListCrudFactory();
        }

        private void LoadDictionary()
        {
            dicListOptions = new Dictionary<string, List<OptionList>>();
            //TODO: ESTO DEBE VENIR DE ELA BASE DE DATOS
            var crudList = new ListOptionCrudFactory();

            var lists=crudList.RetrieveAll<OptionList>();

            var lstId = "";
            var lstOptions = new List<OptionList>();

            foreach(var l in lists)
            {
                if (!lstId.Equals(l.ListId))
                {
                    dicListOptions[l.ListId] = lstOptions;
                    lstOptions = new List<OptionList>();
                    lstId = l.ListId;
                }
                else
                {
                    lstOptions.Add(new OptionList { ListId = l.ListId, Value = l.Value, Description = l.Description });
                }
                
            }                      
        }

        public List<OptionList> RetrieveById(OptionList option)
        {
           
            try
            {
                if (dicListOptions.ContainsKey(option.ListId))
                {
                    return dicListOptions[option.ListId];
                }
                else
                {
                    //    //BUSCA EN OTRO MANAGER
                    if (option.ListId.Equals("LST_CUSTOMER"))
                    {
                        var crudCustomer = new CustomerCrudFactory();
                        var lst = crudCustomer.RetrieveAll<Customer>();

                        var lstResult = new List<OptionList>();

                        foreach( var c in lst)
                        {
                            var newOption = new OptionList { ListId = option.ListId, Value = c.Id, Description = c.Name + " " +  c.LastName };
                            lstResult.Add(newOption);
                        }
                        return lstResult;

                    }
                    //    //retrieve de monedas
                    //    //foreach creo los list option, con cada pojo de moneda

                }

            }
            catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return new List<OptionList>(); ;
        }

       
    }
}
