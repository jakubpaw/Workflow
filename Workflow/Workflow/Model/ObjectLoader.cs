using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Model
{
    class ObjectLoader
    {
        private readonly string userTasksTxtFilePath = "txtFiles/userTasks.txt";

        public ObjectLoader()
        {

        }

        public ObservableCollection<UserTask> LoadUserTasksFromTextFile()
        {
            ObservableCollection<UserTask> userTasksList = new ObservableCollection<UserTask>();
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
