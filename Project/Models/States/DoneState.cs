using Project.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class DoneState:ITaskState
    {

        Task _task;
        public DoneState(Task task)
        {
            _task = task;
        }

        public void NextState()
        {
            Console.WriteLine($"status is DoneState");
            Console.WriteLine("Task is already completed.");
        }
      

    }
}
