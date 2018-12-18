using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using ProjectManagerBL;
using ProjectManagerDL;

namespace ProjectManagerNbench
{
    public class Nbench
    {
        private Counter _opcounter;
        private ProjectManagerBL.ProjectBL TaskBL;
        [PerfSetup]
        public void SetUp(BenchmarkContext context)
        {
            TaskBL = new ProjectManagerBL.ProjectBL();
            _opcounter = context.GetCounter("MyCounter");
        }
        [PerfBenchmark(NumberOfIterations = 13, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
        [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void benchmarkmethod(BenchmarkContext context)
        {
            var bytes = new byte[1024];
            _opcounter.Increment();
            tblTask Task = (new tblTask { TaskName = "Cooking", TStartDate = DateTime.Now, TEndDate = DateTime.Now, TPriority = 10, TStatus = false, ParentTaskName = "Buying vegetables", UserId = 1 });
            tblParent Parent = (new tblParent { ParentId = 1, parentName="Washing" });
            tblProject Project = (new tblProject { ProjectId = 1,ProjectName="Buying Vegetables", PStartDate = DateTime.Now, PEndDate = DateTime.Now, PPriority = 10, PStatus = false, ManagerId = 1 });
            tblUser user = (new tblUser { UserId =1, FirstName = "FirstName", LastName = "LastName",EmployeeId = "Emp011" });

            TaskBL.GetProject();
            TaskBL.GetTask();
            TaskBL.GetUser();
            TaskBL.GetParentTask();

            TaskBL.DeleteUser(user.UserId);
            TaskBL.DeleteTask(Task.TaskId);
            TaskBL.DeleteProject(Project.ProjectId);
            TaskBL.Deleteparenttask(Parent.ParentId);

            TaskBL.UpdateUser(user);
            TaskBL.UpdateTask(Task);
            TaskBL.Updateproject(Project);
            TaskBL.UpdateParentTask(Parent);

            TaskBL.GetUserbyId(user.UserId);
            TaskBL.GetTaskbyId(Task.TaskId);
            TaskBL.GetProjectbyId(Project.ProjectId);
            TaskBL.GetparenttaskbyId(Parent.ParentId);

            TaskBL.AddUser(user);
            TaskBL.AddTask(Task);
            TaskBL.AddProject(Project);
            TaskBL.AddParentTask(Parent);

        }
    }
}

