using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectManagerBL;
using ProjectManagerDL;
using System.Web.Http;

namespace ProjectManagetTest
{
    public class Test
    {
        [Test]
        public void Getall()
        {
            ProjectBL obj = new ProjectBL();
            int count = obj.GetTask().Count();
            Assert.Greater(count, 0);
        }
        [Test]
        public void Getbytask()
        {
            ProjectBL obj = new ProjectBL();
            List<tblTask> Ts = obj.GetTask();            
            tblTask count = obj.GetTaskbyId(Ts[0].TaskId);
            Assert.IsNotNull(count);
            
        }
        [Test]
        public void AddTask()
        {
            ProjectBL obje = new ProjectBL();
            int count = obje.GetTask().Count();            
            tblTask T = (new tblTask { TaskName = "Working", TStartDate = DateTime.Now, TEndDate = DateTime.Now, TPriority = 10, TStatus = false, ParentTaskName = "Cleaning", UserId = 1 });
            obje.AddTask(T);
            int count1 = obje.GetTask().Count();
            Assert.AreEqual(count1, count + 1);
        }
        [Test]
        public void updateTask()
        {
            ProjectBL obj = new ProjectBL();
            List<tblTask> Ts = obj.GetTask();
            tblTask Taskgetbyid = obj.GetTaskbyId(Ts[0].TaskId);
            int count = obj.GetTask().Count();            
            tblTask T = (new tblTask { TaskId = Ts[0].TaskId, TaskName = "Cooking", TStartDate = DateTime.Now, TEndDate = DateTime.Now, TPriority = 10, TStatus = false, ParentTaskName = "Cleaning", UserId = 1 });
            obj.UpdateTask(T);
            int count1 = obj.GetTask().Count();
            List<tblTask> TS1 = obj.GetTask();
            Assert.AreEqual(count1, count);            
        }
        [Test]
        public void DeleteTask()
        {
            ProjectBL obj = new ProjectBL();
            List<tblTask> Ts = obj.GetTask();
            tblTask Taskgetbyid = obj.GetTaskbyId(Ts[0].TaskId);
            int count1 = obj.GetTask().Count();
            obj.DeleteTask(Taskgetbyid.TaskId);
            int count2 = obj.GetTask().Count();
            Assert.AreEqual(count2, count1 - 1);
        }
    }
}
