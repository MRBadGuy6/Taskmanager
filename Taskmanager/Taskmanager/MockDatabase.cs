using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TaskManager450LB;

namespace TaskManagerTest
{
    public class MockDatabase : AbstractDatabase
    {
        private readonly MockRepository<TaskManager450LB.Task> repository = new MockRepository<TaskManager450LB.Task>();

        public override void Save(TaskManager450LB.Task task)
        {
            repository.Add(task);
        }

        public override void Delete(TaskManager450LB.Task task)
        {
            repository.Remove(task);
        }

        public override List<TaskManager450LB.Task> LoadAll()
        {
            return repository.GetAll();
        }

    }
}
