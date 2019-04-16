using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Model
{
    class ObjectLoader
    {
        private string userTasksTxtFilePath = "txtFiles/userTasks.txt";

        public ObjectLoader()
        {

        }

        public List<UserTask> LoadUserTasksFromTextFile()
        {
            List<UserTask> userTasksList = new List<UserTask>();
            try
            {
                TextFileReader fileReader = new TextFileReader(userTasksTxtFilePath);
                string[] userTasksNames = fileReader.readLines();

                foreach (string userTaskName in userTasksNames)
                {
                    userTasksList.Add(new UserTask(userTaskName));
                }
            }
            catch(FileNotFoundException e)
            {
                throw e;
            }
            return userTasksList;
        }
    }
}
