using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Interface;

namespace Project.Models
{
    public class TaskDuplicate : ITask
    {
        public DateTime CreationDate { get; set; }
        public float LoggedTime { get; set; }
        public float EstimationTime { get; set; }
        public ITaskState TaskState { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
