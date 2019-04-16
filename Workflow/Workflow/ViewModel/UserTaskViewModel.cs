using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Model;
using System.Collections.ObjectModel;

namespace Workflow.ViewModel
{
    class UserTaskViewModel
    {
        private ObservableCollection<UserTask> _tasks;
        public ObservableCollection<UserTask> Tasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                _tasks = value;
            }
        }


        public UserTaskViewModel()
        {
            LoadNewTaskList();
        }

        public bool AddTask(string taskName)
        {
            foreach (var task in _tasks)
            {
                if (taskName == task.Name)
                    return false;
            }
            _tasks.Add(new UserTask(taskName));
            return true;
        }

        public void LoadNewTaskList()
        {
            try
            {
                ObjectLoader loader = new ObjectLoader();
                _tasks = new ObservableCollection<UserTask>(loader.LoadUserTasksFromTextFile());
            }
            catch (FileNotFoundException e)
            {
                SendNoFileErrorMessage(e.FileName);
            }
        }

        public void LoadAndAddTaskList()
        {
            try
            {
                ObjectLoader loader = new ObjectLoader();
                List<UserTask> userTasksList = loader.LoadUserTasksFromTextFile();
                foreach(UserTask uTask in userTasksList)
                {
                    _tasks.Add(uTask);
                }
            }
            catch (FileNotFoundException e)
            {
                SendNoFileErrorMessage(e.FileName);
            }
        }







        public void SaveTaskListToTextFile()
        {
            throw new NotImplementedException();
        }
   
        private void SendNoFileErrorMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
