
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

            var lst = new List<OptionList>();
            var option = new OptionList
            {
                ListId = "LST_GENERO",
                Value = "M",
                Description = "Masculino"
            };
            lst.Add(option);
            option = new OptionList
            {
                ListId = "LST_GENERO",
                Value = "F",
                Description = "Femenino"
            };
            lst.Add(option);
            option = new OptionList
            {
                ListId = "LST_GENERO",
                Value = "O",
                Description = "Otros"
            };
            lst.Add(option);
            dicListOptions.Add("LST_GENERO", lst);

        }

        public List<OptionList> RetrieveById(OptionList option)
        {
           
            try
            {
                if (dicListOptions.ContainsKey(option.ListId))
                {
                    return dicListOptions[option.ListId];
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
