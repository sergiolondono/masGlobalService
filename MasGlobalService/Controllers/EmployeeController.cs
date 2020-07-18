using MasGlobalService.DAL;
using MasGlobalService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MasGlobalService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var employees = new EmployeeDomain().getEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var employee = new EmployeeDomain().getEmployeeById(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
