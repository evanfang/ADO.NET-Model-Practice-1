using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IDataOperation<T> where T: class, new()
    {
        IEnumerable<T> Get();
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
