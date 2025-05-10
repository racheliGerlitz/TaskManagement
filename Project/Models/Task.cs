using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Project.Enum;
using Project.Interface;
using Project.Models;

namespace Project.Models
{
    public class Task
    {

        public Stack<ITask> historyStack;
        public Task()
        {
            SubTasks = new List<Task>();
            historyStack = new Stack<ITask>();
        }

       
        private DateTime creationDate;
        public DateTime CreationDate
        {
            get { return creationDate; }
            set
            {

                historyStack.Push(this.CreateBackup());
                creationDate = value;
                ;
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {

                historyStack.Push(this.CreateBackup());
                title = value;

            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                historyStack.Push(this.CreateBackup());
                description = value;
            }
        }

        private User reporter;
        public User Reporter
        {
            get { return reporter; }
            set
            {
                if (_subscribers.Count > 0 && _subscribers.Find(e => e == reporter) != null)
                {
                    _subscribers.Remove(reporter);
                }
                {
                    reporter = value;
                    Subscribe(reporter);
                }
            }
        }

        private User assignee;
        public User Assignee
        {
            get { return assignee; }
            set
            {
                if (_subscribers.Count > 0 && _subscribers.Find(e => e == assignee) != null)
                {
                    _subscribers.Remove(assignee);
                }
                assignee = value;
                Subscribe(assignee);
            }
        }


        private ITaskState taskState;
        public ITaskState TaskState
        {
            get { return taskState; }
            set
            {
                historyStack.Push(this.CreateBackup());
                taskState = value;
            }
        }

        private Priority priority;
        public Priority Priority
        {
            get { return priority; }
            set
            {
                historyStack.Push(this.CreateBackup());
                priority = value;

            }
        }
        public List<Task> SubTasks { get; set; }


        private float _estimationTime;
        public float EstimationTime
        {
            get { return _estimationTime; }
            set
            {
                historyStack.Push(this.CreateBackup());
                _estimationTime = value;
                UpdateEsimatontime();
            }
        }

        private float _loggedTime;
        public float LoggedTime
        {
            get { return UpdateLoggedtime(); }
            set
            {
                historyStack.Push(CreateBackup());
                _loggedTime = value;
            }
        }

        public int Id { get; set; }

        private void UpdateEsimatontime()
        {
            if (SubTasks != null)
            {
                float estimationSum = 0;
                foreach (var sub in SubTasks)
                {
                    estimationSum += sub._estimationTime;
                }
                _estimationTime += estimationSum;
            }
        }

        //composite
        public float UpdateLoggedtime()
        {
            float sum = _loggedTime;
            if (SubTasks != null)
            {
                foreach (var sub in SubTasks)
                {
                    sum += sub.UpdateLoggedtime();
                }
            }
            return sum;
        }

        //memento
        public void Undo()
        {
            if (historyStack == null)
            {
                throw new OutOfMemoryException("you don't have previous state");
            }
            var memento = historyStack.Pop();
            this.Restore(memento);
        }
        public ITask CreateBackup()
        {
            return new TaskDuplicate()
            {
                CreationDate = creationDate,
                Title = title,
                Description = description,
                EstimationTime = _estimationTime,
                LoggedTime = _loggedTime,
            };

        }
        public void Restore(ITask oldTask)
        {
            title = ((TaskDuplicate)oldTask).Title;
            description = ((TaskDuplicate)oldTask).Description;
            _estimationTime = ((TaskDuplicate)oldTask).EstimationTime;
            _loggedTime = ((TaskDuplicate)oldTask).LoggedTime;
            assignee = assignee;
            reporter = Reporter;
            priority = Priority;
            //SubTasks = SubTasks;
        }

        //observer
        List<ISubscriber> _subscribers = new List<ISubscriber>();
        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Emit()
        {
            foreach (ISubscriber subscriber in _subscribers.ToList())
            {
                TaskDuplicate task = (TaskDuplicate)historyStack.Peek();
                subscriber.GetEvent(task.Title);
            }
        }

        //state
        public void ChangeState(ITaskState status)
        {
            this.TaskState = status;
            Emit();
        }
        public void Next()
        {
            TaskState.NextState();
        }
    }
}




