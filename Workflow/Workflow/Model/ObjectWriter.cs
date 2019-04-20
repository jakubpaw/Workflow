using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Model
{
    class ObjectWriter
    {

        private readonly string userTasksTxtFilePath = "txtFiles/userTasks.txt";

        public ObjectWriter()
        {

        }

        public void SaveUserTasksToTxtFiles(ObservableCollection<UserTask> userTaskCollection)
        {
            var writer = new TextFileWriter(userTasksTxtFilePath);
            List<string> userTasks = new List<string>();
            foreach(UserTask task in userTaskCollection)
            {
                userTasks.Add(task.ToString());
            }
            writer.Write(userTasks);
        }
        public void SaveNewUserTaskToTxtFile(UserTask userTask)
        {
            var writer = new TextFileWriter(userTasksTxtFilePath);
            writer.AddOneLine(userTask.ToString());
        }

    }
}
