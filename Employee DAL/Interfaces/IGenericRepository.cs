using Employee_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Interfaces
{
    public interface IGenericRepository<E> where E : class
    {
        void Add(E entity);
        void AddRange(IEnumerable<E> entities);
        IEnumerable<E> GetAll();
        IEnumerable<E> Find(Expression<Func<E, bool>> expression);
        E GetById(int id);
       

        void Update(E entity);

       

        void Remove(E entity);
        void RemoveRange(IEnumerable<E> entities);





    }
}
