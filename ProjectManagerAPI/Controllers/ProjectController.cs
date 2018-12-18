using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManagerBL;
using ProjectManagerDL;

namespace ProjectManagerAPI.Controllers
{
    public class ProjectController : ApiController
    {
        [Route("Addproject")]
        public IHttpActionResult post(tblProject item)
        {
            ProjectBL obj = new ProjectBL();
            obj.AddProject(item);
            return Ok("Record added");
        }
        [Route("Getallprojects")]
        public IHttpActionResult Get()
        {
            ProjectBL obj = new ProjectBL();
            List<tblProject> projects = obj.GetProject();
            return Ok(projects);
        }
        [Route("getbyprojectid/{id:int}")]
        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ProjectBL obj = new ProjectBL();
            return Ok(obj.GetProjectbyId(id));
        }
        [Route("updatebyprojectid/{id}")]
        [AcceptVerbs("PUT")]
        [HttpPut]
        public IHttpActionResult put(tblProject item)
        {
            ProjectBL obj = new ProjectBL();
            obj.Updateproject(item);
            return Ok("Record Updated");

        }
        [Route("Deleteproject/{id:int}")]
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ProjectBL obj = new ProjectBL();
            obj.DeleteProject(id);
            return Ok("Record is deleted");
        }
        [Route("suspendprojectbyid/{id}")]
        [AcceptVerbs("PUT")]
        [HttpPut]
        public IHttpActionResult put(int id)
        {
            ProjectBL obj = new ProjectBL();
            obj.Suspendtask(id);
            return Ok("Record Updated");
        }
    }
}
