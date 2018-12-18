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
    public class TaskController : ApiController
    {

        [Route("Addtask")]
        public IHttpActionResult post(tblTask item)
        {
            ProjectBL obj = new ProjectBL();
            obj.AddTask(item);
            return Ok("Record added");
        }

        [Route("Getalltasks")]
        public IHttpActionResult Get()
        {
            ProjectBL obj = new ProjectBL();
            return Ok(obj.GetTask());
        }

        [Route("getbytaskid/{id:int}")]
        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id == 0)
            {
                return null;
            }
            ProjectBL obj = new ProjectBL();
            return Ok(obj.GetTaskbyId(id));
        }
        [Route("updatebytaskid/{id}")]
        [AcceptVerbs("PUT")]
        [HttpPut]
        public IHttpActionResult put(tblTask item)
        {
            ProjectBL obj = new ProjectBL();
            obj.UpdateTask(item);
            return Ok("Record Updated");
        }
        [Route("Deletetask/{id:int}")]
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ProjectBL obj = new ProjectBL();
            obj.DeleteTask(id);
            return Ok("Record is deleted");
        }
        [Route("Endtask/{id:int}")]
        [AcceptVerbs("PUT")]
        [HttpDelete]
        public IHttpActionResult put(int id)
        {
            ProjectBL obj = new ProjectBL();
            obj.Endtask(id);
            return Ok("Record is deleted");
        }
    }
}
