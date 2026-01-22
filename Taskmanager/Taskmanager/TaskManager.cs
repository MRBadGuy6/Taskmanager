using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
[assembly: InternalsVisibleTo("TaskManagerTest")]

namespace TaskManager450LB
{
    public class TaskManager
    {
        //Da der Taskmanager nicht die genauen Implementierungen kennt arbeitet der mit den zwei Abstrakten Klassen (IoC) 
        private readonly AbstractDatabase _database;
        private readonly AbstractNotification _notification;
        private readonly IRepository<Task> _taskRepository;

        public TaskManager (AbstractDatabase database, AbstractNotification notification, IRepository<Task> taskRepository)
        {
            _database = database;
            _notification = notification;
            _taskRepository = taskRepository;
        }

        public void AddTask(Task task)
        {
            _database.Save(task);
            _notification.SendNotification(task);
            _taskRepository.Add(task);
        }

        private readonly TaskEditor taskEditor = new TaskEditor();
        public void UpdateTask(Task task, string newTitle, string newDescription,System.DateTime newDueDate, string newStatus)
        {
            taskEditor.UpdateTask(task, newTitle, newDescription, newStatus);
        }

        public void DeleteTask(Task task) 
        {
        _database.Delete(task);
        _taskRepository.Remove(task);
        }

        public void DisplayTasks() 
        {
            var tasks = _database.LoadAll();
            Console.WriteLine("Aktuelle Aufgaben");
            foreach (var currenttask in tasks) 
            {
            Console.WriteLine($"Titel: {currenttask.Title}, Beschreibung: {currenttask.Description}, Deadline: {currenttask.DueDate}, Status: {currenttask.Status}");
            }

         
    }

        public List<Task> GetTasks()
        {
            var tasksFromDb = _database.LoadAll();
            var tasksFromRepo = _taskRepository.GetAll();
            return tasksFromDb.Concat(tasksFromRepo).ToList();
        }

        
    }

}
