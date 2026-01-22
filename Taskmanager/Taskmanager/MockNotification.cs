using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager450LB;

namespace TaskManagerTest
{
    public class MockNotification : AbstractNotification
    {
        private readonly MockRepository<string> repository = new MockRepository<string>();

        public override void SendNotification(TaskManager450LB.Task task)
        {
            string message = $"Benachrichtigung gesendet: {task.Title}";
            repository.Add(message);
        }

        public List<string> GetNotifications()
        {
            return repository.GetAll();
        }
    }
}
