using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergDAL.Repository.Interface
{
    public interface IRepository<T>
    {
        List<T> ReadAll();

        void Add(T item);

        T Find(int id);
        void Delete(int id);

        void Edit(T item);
    }
}
