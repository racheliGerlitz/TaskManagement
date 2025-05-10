using Project.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class CodeReviewState : ITaskState
    {
        Task _task;
        public CodeReviewState(Task task)
        {
            _task = task;
        }
        
        public void NextState()
        {

            if (_task.Reporter.Role == Enum.Role.manager)
            {
                Console.WriteLine($"status is CodeReviewState");
                _task.ChangeState(new QAState(_task));
            }
            else
            {
                Console.WriteLine("you can't  qa movin to manager");
                _task.ChangeState(new QAState(_task));
            }
          

        }
        
    }
}
