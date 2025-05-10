using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Enum;
using Project.Interface;

namespace Project.Models
{     //singelton
    public class User:ISubscriber
    {
        private INotify _notify;
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public User(string name, string email, Role role, INotify notify)
        {
            Name = name;
            Email = email;
            Role = role;
            _notify = notify;
        }

        public void GetEvent(string change)
        {
            _notify.Notify($"{Name} got message about change in {change}");
        }
    }
}

