using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagerDL;

namespace ProjectManagerBL
{
    public class ProjectBL
    {
        ProjectManagerDBEntities db = new ProjectManagerDBEntities();
        public void AddUser(tblUser item)
        {
            using (ProjectManagerDBEntities db1 = new ProjectManagerDBEntities())
            {
                try
                {
                    db1.tblUsers.Add(item);
                    db1.SaveChanges();
                }
                catch { };
            }
        }
        public void AddTask(tblTask item)
        {
            try
            {
                using (ProjectManagerDBEntities db1 = new ProjectManagerDBEntities())
                {
                    var projectupdate = db1.tblProjects.Where(x => x.ProjectId == item.ProjectId).ToList();
                    projectupdate.ForEach(m => m.Nooftasks = m.Nooftasks + 1);
                    item.TStatus = false;
                    db1.tblTasks.Add(item);
                    db1.SaveChanges();
                }
            }
            catch { };
        }
        public void AddParentTask(tblParent item)
        {
            using (ProjectManagerDBEntities db1 = new ProjectManagerDBEntities())
            {
                try
                {
                    db1.tblParents.Add(item);
                    db1.SaveChanges();
                }
                catch { };
            }
        }
        public void AddProject(tblProject item)
        {
            using (ProjectManagerDBEntities db1 = new ProjectManagerDBEntities())
            {
                try
                {
                    item.Nooftasks = 0;
                    item.completed = 0;
                    item.PStatus = false;
                    db1.tblProjects.Add(item);
                    db1.SaveChanges();
                }
                catch { };
            }
        }
        public List<tblUser> GetUser()
        {
            try
            {
                {
                    return db.tblUsers.ToList();
                }
            }
            catch { return null; }
        }
        public List<tblTask> GetTask()
        {
            try
            {
                return db.tblTasks.ToList();
            }
            catch { return null; }

        }
        public List<tblParent> GetParentTask()
        {
            return db.tblParents.ToList();

        }
        public List<tblProject> GetProject()
        {
            try
            {
                if (db.tblProjects != null)
                {                    
                    return db.tblProjects.ToList();
                }
                return null;
            }
            catch { return null; }
            
        }      
        public tblUser GetUserbyId(int id)
        {
            try
            {
                return db.tblUsers.SingleOrDefault(k => k.UserId == id);
            }
            catch { return null; }
        }
        public tblTask GetTaskbyId(int id)
        {

            return db.tblTasks.SingleOrDefault(k => k.TaskId == id);

        }
        public tblProject GetProjectbyId(int id)
        {

            return db.tblProjects.SingleOrDefault(k => k.ProjectId == id);

        }
        public tblParent GetparenttaskbyId(int id)
        {

            return db.tblParents.SingleOrDefault(k => k.ParentId == id);

        }
        public void DeleteUser(int Id)
        {
            try
            {
                using (ProjectManagerDBEntities db1 = new ProjectManagerDBEntities())
                {
                    tblUser us = db1.tblUsers.Where(d => d.UserId == Id).First();
                    var projectupdate = db1.tblProjects.Where(x => x.ManagerId == Id).ToList();
                    projectupdate.ForEach(m => m.ManagerId = 0);
                    var taskupdate = db1.tblTasks.Where(x => x.UserId == Id).ToList();
                    taskupdate.ForEach(m => m.UserId = 0);
                    db1.tblUsers.Remove(us);
                    db1.SaveChanges();
                }
            }
            catch { }
        }
        public void DeleteTask(int TaskId)
        {
            try
            {
                using (ProjectManagerDBEntities db1 = new ProjectManagerDBEntities())
                {
                    tblTask ts = db1.tblTasks.Where(d => d.TaskId == TaskId).FirstOrDefault();
                    var projectupdate = db1.tblProjects.Where(x => x.ProjectId == ts.ProjectId).ToList();
                    projectupdate.ForEach(m => m.completed = m.completed - 1);
                    db1.tblTasks.Remove(ts);
                    db1.SaveChanges();
                }
            }
            catch { };
        }
        public void DeleteProject(int Id)
        {
            try
            {
                using (ProjectManagerDBEntities db1 = new ProjectManagerDBEntities())
                {
                    tblProject ts = db1.tblProjects.Where(d => d.ProjectId == Id).FirstOrDefault();
                    db1.tblProjects.Remove(ts);
                    db1.SaveChanges();
                }
            }
            catch { }
        }
        public void Deleteparenttask(int Id)
        {
            try
            {
                using (ProjectManagerDBEntities db1 = new ProjectManagerDBEntities())
                {
                    tblParent par = db1.tblParents.Where(d => d.ParentId == Id).First();
                    db1.tblParents.Remove(par);
                    db1.SaveChanges();
                }
            }
            catch { }
        }
        public void UpdateUser(tblUser useritem)
        {
            try
            {
                using (ProjectManagerDBEntities db1 = new ProjectManagerDBEntities())
                {
                    tblUser userupdate = db1.tblUsers.SingleOrDefault(x => x.UserId == useritem.UserId);
                    userupdate.FirstName = useritem.FirstName;
                    userupdate.LastName = useritem.LastName;
                    userupdate.EmployeeId = useritem.EmployeeId;
                    db1.SaveChanges();
                }
            }
            catch { }
        }
        public void UpdateTask(tblTask taskitem)
        {
            try
            {
                using (ProjectManagerDBEntities db1 = new ProjectManagerDBEntities())
                {
                    tblTask taskupdate = db1.tblTasks.SingleOrDefault(x => x.TaskId == taskitem.TaskId);
                    tblProject projectupdate = db1.tblProjects.SingleOrDefault(x => x.ProjectId == taskupdate.ProjectId);
                    projectupdate.Nooftasks = projectupdate.Nooftasks - 1;
                    taskupdate.TaskName = taskitem.TaskName;
                    taskupdate.TStartDate = taskitem.TStartDate;
                    taskupdate.TEndDate = taskitem.TEndDate;
                    taskupdate.TPriority = taskitem.TPriority;
                    taskupdate.TStatus = taskitem.TStatus;                  
                    taskupdate.ParentId = taskitem.ParentId;
                    taskupdate.ProjectId = taskitem.ProjectId;
                    taskupdate.UserId = taskitem.UserId;
                    taskupdate.ParentTaskName = taskitem.ParentTaskName;                    
                    tblProject projectupdate1 = db1.tblProjects.SingleOrDefault(x => x.ProjectId == taskitem.ProjectId);
                    projectupdate1.Nooftasks = projectupdate1.Nooftasks + 1;
                    db1.SaveChanges();
                }
            }
            catch { }
        }
        public void Updateproject(tblProject projectitem)
        {
            try
            {
                using (ProjectManagerDBEntities db1 = new ProjectManagerDBEntities())
                {

                    tblProject projectupdate = db1.tblProjects.SingleOrDefault(x => x.ProjectId == projectitem.ProjectId);

                    projectupdate.ProjectName = projectitem.ProjectName;
                    projectupdate.PStartDate = projectitem.PStartDate;
                    projectupdate.PEndDate = projectitem.PEndDate;
                    projectupdate.PPriority = projectitem.PPriority;
                    projectupdate.ManagerId = projectitem.ManagerId;                   
                    db1.SaveChanges();
                }
                using (ProjectManagerDBEntities db2 = new ProjectManagerDBEntities())
                {
                    var projectupdate = db2.tblProjects.Where(x => x.ProjectId == projectitem.ProjectId).ToList();
                    // projectupdate.ForEach(m=>m.Nooftasks=()
                }
            }
            catch { }
        }
        public void UpdateParentTask(tblParent taskitem)
        {
            using (ProjectManagerDBEntities db1 = new ProjectManagerDBEntities())
            {
                tblParent taskupdate = db1.tblParents.SingleOrDefault(x => x.ParentId == taskitem.ParentId);
                taskupdate.parentName = taskitem.parentName;
                db1.SaveChanges();
            }
        }
        public void Endtask(int id)
        {
            using (ProjectManagerDBEntities db = new ProjectManagerDBEntities())
            {
                tblTask ts = db.tblTasks.SingleOrDefault(x => x.TaskId == id);
                var projectupdate = db.tblProjects.Where(x => x.ProjectId == ts.ProjectId).ToList();
                projectupdate.ForEach(m => m.Nooftasks = m.Nooftasks - 1);
                projectupdate.ForEach(m => m.completed = m.completed + 1);
                ts.TStatus = true;
                ts.TEndDate = DateTime.Now;
                db.SaveChanges();
            }
        }
        public void Suspendtask(int id)
        {
            using (ProjectManagerDBEntities db = new ProjectManagerDBEntities())
            {
                tblProject tp = db.tblProjects.SingleOrDefault(x => x.ProjectId == id);
                if (tp.PStatus == false)
                {
                    tp.PStatus = true;
                }
                else
                    tp.PStatus = false;
              
                db.SaveChanges();
            }
        }
    }
}