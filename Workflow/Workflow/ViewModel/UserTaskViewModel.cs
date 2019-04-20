using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Model;
using System.Collections.ObjectModel;
using MVVMDemo;
using System.Windows;

namespace Workflow.ViewModel
{
    class UserTaskViewModel
    {
        private UserTask _selectedUserTask;
        public UserTask SelectedUserTask
        {
            get
            {
                return _selectedUserTask;
            }
            set
            {
                _selectedUserTask = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public MyICommand DeleteCommand { get; set; }

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
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
        }

        private void OnDelete()
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć "+SelectedUserTask.Name+"?", "Workflow", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    DeleteTask();
                    MessageBox.Show("Dotychczasowe dane dotyczące tego zlecenia, zostały zarchiwizowane", "Workflow");
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private bool CanDelete()
        {
            return SelectedUserTask != null;
        }
        private void DeleteTask()
        {
            archive(SelectedUserTask);
            Tasks.Remove(SelectedUserTask);
            SaveTaskListToTextFile();
        }

        public bool AddTask(string taskName)
        {
            foreach (var task in _tasks)
            {
                if (taskName == task.Name)
                    return false;
            }
            var newTask = new UserTask(taskName);
            _tasks.Add(newTask);
            SaveNewTaskToTextFile(newTask);
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
                Tasks = loader.LoadUserTasksFromTextFile();
            }
            catch (FileNotFoundException e)
            {
                SendNoFileErrorMessage(e.FileName);
            }
        }
        public void archive(UserTask selectedUserTask)
        {

        }






        public void SaveTaskListToTextFile()
        {
            var writer = new ObjectWriter();
            writer.SaveUserTasksToTxtFiles(Tasks);
        }

        private void SaveNewTaskToTextFile(UserTask task)
        {
            var writer = new ObjectWriter();
            writer.SaveNewUserTaskToTxtFile(task);
        }
   
        private void SendNoFileErrorMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
