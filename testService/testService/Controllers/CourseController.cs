using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testService.Models;

namespace testService.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var result = Courseware.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet, Route("{id}")]//можно указать какой тип id
        public IHttpActionResult GetById(string id)
        {
            //valideate id
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = Courseware.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }
    }

}
