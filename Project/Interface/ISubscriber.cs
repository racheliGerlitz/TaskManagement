using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Interface
{
    public interface ISubscriber
    {
        public void GetEvent(string eventData);
    }
}
