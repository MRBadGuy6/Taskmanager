using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
[assembly: InternalsVisibleTo("TaskManagerTest")]

namespace TaskManager450LB
{
    public class TaskEditor
    {
        public void UpdateTask(Task task, string newTitle, string newDescription, string newStatus) 
        {
            task.Title = newTitle;
            task.Description = newDescription;
            task.Status = newStatus;
            Console.WriteLine($"Aufgabe wurde aktualisiert zu: {task}");
        }

        internal void UpdateTask(Task task, string newTitle, string newDescription, DueDate newDueDate, string newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
