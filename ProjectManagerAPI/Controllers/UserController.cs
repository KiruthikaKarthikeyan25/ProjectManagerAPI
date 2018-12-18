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
    public class UserController : ApiController
    {

        [Route("Adduser")]
        [AcceptVerbs("POST")]
        public IHttpActionResult post(tblUser item)
        {
            ProjectBL obj = new ProjectBL();
            obj.AddUser(item);
            // obj.AddProject(item1);
            return Ok("Record added");
        }
        [Route("Getallusers")]
        public IHttpActionResult Get()

        {
            ProjectBL obj = new ProjectBL();
            return Ok(obj.GetUser());
        }
        [Route("getbyuserid/{id:int}")]
        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ProjectBL obj = new ProjectBL();
            return Ok(obj.GetUserbyId(id));
        }
        [Route("updatebyuserid/{id}")]
        [AcceptVerbs("PUT")]
        [HttpPut]
        public IHttpActionResult put(tblUser item)
        {
            ProjectBL obj = new ProjectBL();
            obj.UpdateUser(item);
            return Ok("Record Updated");
        }
        [Route("Deleteuser/{id:int}")]
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ProjectBL obj = new ProjectBL();
            obj.DeleteUser(id);
            return Ok("Record is deleted");
        }
    }
    
}
