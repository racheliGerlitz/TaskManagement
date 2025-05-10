using Project.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Status
{
    class ToDoState : ITaskState
    {
        Task _task;
        public ToDoState(Task task)
        {
            _task = task;
        }
        public void NextState()
        {
          
            Console.WriteLine($"status is ToDoState");
            _task.ChangeState(new ProgressState(_task));
            
            
        }
    }
}
