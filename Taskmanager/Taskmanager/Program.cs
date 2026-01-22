using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using TaskManagerTest;

[assembly: InternalsVisibleTo("TaskManagerTest")]

namespace TaskManager450LB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Wird zur Speicherung und Verwaltung von Aufgaben genutzt IoC
            var datebase = new MockDatabase();

            //Simuliert das Senden von Benachrichtigungen. IoC
            var notification = new MockNotification();
            var taskRepository = new MockRepository<Task>();
            var taskmanager = new TaskManager(datebase, notification,taskRepository);
            

            StartUI(taskmanager);
        }

        static void StartUI(TaskManager taskmanager) 
        {
            while (true) 
            {
                Console.WriteLine("\n--- TaskManager ---");
                Console.WriteLine("Wähle eine Option:  ");
                Console.WriteLine("1. Aufgabe hinzufügen");
                Console.WriteLine("2. Aufgabe anzeigen");
                Console.WriteLine("3. Aufgabe bearbeiten");
                Console.WriteLine("4. Aufgabe löschen");
                Console.WriteLine("5. Taskmanager beenden");
                
                string option = Console.ReadLine();

                switch (option) 
                {
                    case "1":
                    AddTask(taskmanager);
                    break;

                    case "2":
                    taskmanager.DisplayTasks();
                    break;

                    case "3":
                    UpdateTask(taskmanager);
                    break;

                    case "4":
                    DeleteTask(taskmanager);
                    break;

                    case "5":
                    Console.WriteLine("Taskmanager beendet");
                    return;

                    default:
                    Console.WriteLine("Ungültige Option, versuchen Sie es erneut");
                    break;
                }

                static void AddTask(TaskManager taskmanager) 
                {
                    string title;
                    do
                    {
                        Console.WriteLine("Titel der Aufgabe:  ");
                        title = Console.ReadLine();

                        if (string.IsNullOrEmpty(title))
                        {
                            Console.WriteLine("Titel darf nicht leer sein, bitte geben sie erneut ein");
                        }
                    }
                    while (string.IsNullOrEmpty(title));

                    string description;
                    do 
                    {
                        Console.WriteLine("Beschreibung der Aufgabe:  ");
                        description = Console.ReadLine();

                        if (string.IsNullOrEmpty(description)) 
                        {
                        Console.WriteLine("Beschreibung darf nicht leer sein, bitte geben sie erneut ein");
                        }
                    }
                    while (string.IsNullOrEmpty(description));

                    Console.WriteLine("Deadline (yyyy.MM.dd):  ");
                    DateTime dueDate;
                    while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
                    {
                        Console.Write("Ungültiges Datum. Bitte erneut eingeben (yyyy.MM.dd): ");
                    }

                    string status;
                    do
                    {
                        Console.Write("Status der Aufgabe(z.B. Erledigt, Nicht Erledigt):  ");
                        status = Console.ReadLine();

                        if (status != "Erledigt" && status != "Nicht Erledigt") //Hier habe ich den Breakingpoint gesetzt für Teilauftrag 6
                        {
                            Console.WriteLine("Ungültiger Status, bitte geben sie es erneut ein");
                        }
                    }
                    while (status != "Erledigt" && status != "Nicht Erledigt");

                    var task = new Task(title, description, dueDate, status);
                    taskmanager.AddTask(task);

                    Console.WriteLine("Aufgabe Erfolgreich hinzugefügt");
                }

                static void UpdateTask(TaskManager taskmanager) 
                {
                    Console.WriteLine("Aktuelle Aufgaben");
                    taskmanager.DisplayTasks();

                    Console.Write("Wähle eine Aufgabe aus basieriend auf die Nummer (angefangen mit 0):  ");
                    int index;
                    while (!int.TryParse(Console.ReadLine(), out index)) 
                    {
                    Console.WriteLine("Ungültige Eingabe, bitte versuchen Sie es erneut:  ");
                    }

                    Console.WriteLine("Neuer Titel:  ");
                    string newTitle = Console.ReadLine();

                    Console.WriteLine("Neue Beschreibung:  ");
                    string newDescription = Console.ReadLine();

                    Console.WriteLine("Neuer Status:  ");
                    string newStatus = Console.ReadLine();


                    var tasks = taskmanager.GetTasks();
                    if (index >= 0 && index < tasks.Count)
                    {
                        
                        Console.WriteLine("Aufgabe erfolgreich aktualisiert.");
                    }
                    else
                    {
                        Console.WriteLine("Ungültiger Index.");
                    }
                }

                static void DeleteTask (TaskManager taskmanager) 
                {
                Console.WriteLine("Aktuelle Aufgaben:  ");
                taskmanager.DisplayTasks();

                    Console.WriteLine("Wähle eine Aufgabe aus basieriend auf die Nummer (angefangen mit 0):  ");
                    int index;
                    while (!int.TryParse(Console.ReadLine(), out index))
                    {
                        Console.WriteLine("Ungültige Eingabe, bitte versuchen Sie es erneut:  ");
                    }

                    var tasks = taskmanager.GetTasks();
                    if (index >= 0 && index < tasks.Count)
                    {
                        taskmanager.DeleteTask(tasks[index]);
                        Console.WriteLine("Aufgabe erfolgreich gelöscht");
                    }
                    else 
                    {
                    Console.WriteLine("Ungültiger Index");
                    }
                    
                }
                
            }
            




        }
    }
}
