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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class CustomerController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/customer
        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new CustomerManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }
        [HttpGet]
        public IHttpActionResult GetStatistic(string type)
        {

            apiResp = new ApiResponse();
            var mng = new CustomerManager();

            if (type.Equals("millenials"))
            {
                var millenials = 0;
                var noMillenias = 0;
                foreach (Customer c in mng.RetrieveAll())
                {
                    if (c.Age < 36)
                    {
                        millenials++;
                    }
                    else
                    {
                        noMillenias++;
                    }
                }
                var lst = new List<int>
            {
                millenials,
                noMillenias
            };

                apiResp.Data = lst;

            }
            else
            {
                apiResp.Message = "Statistic not found";
            }


            return Ok(apiResp);
        }


        // GET api/customer/5
        // Retrieve by id
        public IHttpActionResult Get(string id)
        {
            try
            { 
                var mng = new CustomerManager();
                var customer = new Customer
                {
                    Id = id
                };

                customer = mng.RetrieveById(customer);
                apiResp = new ApiResponse();
                apiResp.Data = customer;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Customer customer)
        {

            try
            {
                var mng = new CustomerManager();
                mng.Create(customer);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" 
                    + bex.AppMessage.Message));
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(Customer customer)
        {
            try
            {
                var mng = new CustomerManager();
                mng.Update(customer);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE ==
        public IHttpActionResult Delete(Customer customer)
        {
            try
            {
                var mng = new CustomerManager();
                mng.Delete(customer);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
