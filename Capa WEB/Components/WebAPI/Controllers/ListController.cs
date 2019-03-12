using CoreAPI;
using Entities_POJO;
using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ListController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/list/5
        public IHttpActionResult Get(string id)
        {
            try
            { 
                var mng = new ListManager();
                var option = new OptionList
                {
                    ListId="LST_GENERO"
                };

                var lstOptions = mng.RetrieveById(option);        
                return Ok(lstOptions);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}
