using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Enum;
using Project.Interface;

namespace Project.Models
{
    public class TaskBuilder
    {
        public DateTime? CreationDate = null;
        public string ?Title = null;
        public string? Description = null;
        public User? Reporter = null;
        public User? Assignee = null;
        public Priority? Priority = null;
        public float? _estimationTime=null;
        public float? LoggedTime = null;
        public List<Task>? SubTasks = null;
         ITaskState _taskState=null;
        public TaskBuilder( string title )
        {
            CreationDate = DateTime.Now;
            Title = title;
            //_taskState = new ToDoState((ITask)this);

        }
        public void BuildDescription(string description)
        {
         Description = description;
        }

        public void BuildReporter(User reporter)
        {
            Reporter = reporter;
        }

        public void BuildAssignee(User assignee)
        {
            Assignee = assignee;
        }

        public void BuildPriority(Priority priority)
        {
            Priority = priority;
        }

        public void BuildSubTasks(Task task)
        {
            if( SubTasks == null )
                SubTasks = new List<Task>();
            SubTasks.Add( task );
        }
        public void BuildLoggedTime()
        {
            LoggedTime = 0;
        }

        public void BuildEstimationTime(float estimationTime)
        {
            _estimationTime = estimationTime;
        }

        public Task build()
        {
            if(Description==null|| Priority==null|| Assignee==null|| Reporter == null)
            {
                throw new Exception("Can't build task");
            }

            return new Task()
            {
                CreationDate=(DateTime)CreationDate,
                Title=(string)Title,
                Description = (string)Description,
                Priority = (Priority)Priority,
                Assignee = (User)Assignee,
                Reporter = (User)Reporter,
                SubTasks = SubTasks,
                LoggedTime =(float)LoggedTime,
                EstimationTime=(float)_estimationTime
               
            };
        }

    }
    }


   

  
   

   
