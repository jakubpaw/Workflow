using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Model
{
    class UserTask:ILoadable
    {
        private string name;

        public string Name {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public UserTask(string taskName)
        {
            name = taskName;
        }
    }
}
