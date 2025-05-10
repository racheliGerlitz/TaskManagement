using Project.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Status
{
    internal class ProgressState : ITaskState
    {

        Task _task;
        public ProgressState(Task task)
        {
            _task = task;
        }
        
        public void NextState()
        {
            Console.WriteLine($"status is ProgressState");
            if (_task.Reporter.Role == Enum.Role.manager)
            {
                _task.ChangeState(new CodeReviewState(_task));
            }
            else
            {
                Console.WriteLine("you can't  code review moving to manager");
                _task.ChangeState(new CodeReviewState(_task));
            }
           
        }
    }
}
