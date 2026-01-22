using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("TaskManagerTest")]

namespace TaskManager450LB
{
    public interface IRepository<T>
    {
        void Add(T item);
        List<T> GetAll();
        void Remove(T item);
    }
}
