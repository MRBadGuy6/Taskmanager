using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("TaskManagerTest")]

namespace TaskManager450LB
{
    public abstract class AbstractDatabase
    {
        public abstract void Save(Task task);
        public abstract void Delete(Task task);

        public abstract List<Task> LoadAll();
    }
}
