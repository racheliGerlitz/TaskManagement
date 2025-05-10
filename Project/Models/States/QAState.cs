using Project.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class QAState:ITaskState
    {
        Task _task;
        public QAState(Task task)
        {
            _task = task;
        }

        public void NextState()
        {

            if (_task.Reporter.Role == Enum.Role.qa)
            {
                Console.WriteLine($"status is QAState");
                _task.ChangeState(new DoneState(_task));
            }
            else
            {
                Console.WriteLine("you can't  done moving to qa");
                _task.ChangeState(new DoneState(_task));
            }
           
        }
        
    }
}
