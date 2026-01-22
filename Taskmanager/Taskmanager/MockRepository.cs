using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using TaskManager450LB;


[assembly: InternalsVisibleTo("HZ5MockRepositoryTest")]
[assembly: InternalsVisibleTo("HZ5TaskManagerTest")]
[assembly: InternalsVisibleTo("HZ2MockDatabaseTest")]

namespace TaskManagerTest
{
    internal class MockRepository<T>: IRepository<T>
    {
        private List<T> _items = new List<T>();


        public void Add(T item)
        {
            _items.Add(item);
            Console.WriteLine($"{typeof(T).Name} hinzugefügt: {item}");
        }

        public void Remove(T item)
        {
            _items.Remove(item);
            Console.WriteLine($"{typeof(T).Name} entfernt: {item}");
        }

        public List<T> GetAll()
        {
            return _items;
        }

    }
}
