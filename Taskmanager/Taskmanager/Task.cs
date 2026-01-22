using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("TaskManagerTest")]

namespace TaskManager450LB
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

        public Task(string title, string descrition, DateTime duedate, string status) 
        {
        Title = title;
        Description = descrition;
        DueDate = duedate;
        Status = status;
        }

        public override string ToString() 
        {
            return $"Titel: {Title}, Beschreibung: {Description}, Deadline: {DueDate}, Status: {Status}";
        }

    }
}
