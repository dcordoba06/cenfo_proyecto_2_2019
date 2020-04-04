
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
        private static ListManager _instance;
        //private ListCrudFactory crudCustomer;

        private ListManager()
        {
            LoadDictionary();
            //crudCustomer = new ListCrudFactory();
        }

        public static ListManager GetInstance()
        {
            if (_instance == null)            
                _instance = new ListManager();

            return _instance;
        }


        private void LoadDictionary()
        {
            dicListOptions = new Dictionary<string, List<OptionList>>();
            //TODO: ESTO DEBE VENIR DE ELA BASE DE DATOS
            var crudList = new ListOptionCrudFactory();

            var lists=crudList.RetrieveAll<OptionList>();

            var lstId = lists[0].ListId;
            var lstOptions = new List<OptionList>();

            for(int i=0; i< lists.Count; i++)
            {
                var l = lists[i];
                lstOptions.Add(new OptionList { ListId = l.ListId, Value = l.Value, Description = l.Description });

                if (i==lists.Count-1 || !lists[i + 1].ListId.Equals(l.ListId))
                {
                    dicListOptions[l.ListId] = lstOptions;
                    lstOptions = new List<OptionList>();
                    lstId = l.ListId;
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
