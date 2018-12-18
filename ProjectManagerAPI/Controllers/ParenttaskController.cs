using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManagerDL;
using ProjectManagerBL;
namespace ProjectManagerAPI.Controllers
{
    public class ParenttaskController : ApiController
    {

        [Route("GetallParenttask")]
        public IHttpActionResult Get()
        {
            ProjectBL obj = new ProjectBL();
            return Ok(obj.GetParentTask());
        }
        [Route("Addparenttask")]
        public IHttpActionResult post(tblParent item)
        {
            ProjectBL obj = new ProjectBL();
            obj.AddParentTask(item);
            return Ok("Record added");
        }

        [Route("getbyparenttaskid/{id:int}")]
        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id == 0)
            {
                return null;
            }
            ProjectBL obj = new ProjectBL();
            return Ok(obj.GetparenttaskbyId(id));
        }
        [Route("updatebyparenttaskid/{id}")]
        [AcceptVerbs("PUT")]
        [HttpPut]
        public IHttpActionResult put(tblParent item)
        {
            ProjectBL obj = new ProjectBL();
            obj.UpdateParentTask(item);
            return Ok("Record Updated");
        }
        [Route("Deleteparenttask/{id:int}")]
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ProjectBL obj = new ProjectBL();
            obj.Deleteparenttask(id);
            return Ok("Record is deleted");
        }
    }
}
