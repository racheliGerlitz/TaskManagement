using Project.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ConsoleNotify : INotify
    {
        private static ConsoleNotify _instance;
        private ConsoleNotify()
        {
        }
        public static ConsoleNotify Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConsoleNotify();
                }
                return _instance;
            }
        }

        public void Notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}

