using Employee_DAL.ContextData;
using Employee_DAL.Entities;
using Employee_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Repositories
{
    public class GenericRepository<E> : IGenericRepository<E> where E : class

    {
        protected readonly EmployeeContext _context;
       
        public GenericRepository(EmployeeContext context)
        {
            _context = context;
        }

       

        public void Add(E entity)
        {
            _context.Set<E>().Add(entity);
            _context.SaveChanges();

        }

        public void Remove(E entity)
        {
            _context.Set<E>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<E> GetAll()
        {
            return _context.Set<E>().ToList();
        }

        public void Update(E entity)
        {
            _context.Set<E>().Update(entity);
            _context.SaveChanges();

        }

        



        public void AddRange(IEnumerable<E> entities)
        {
            _context.Set<E>().AddRange(entities);
            _context.SaveChanges();
        }

        
      
        public void RemoveRange(IEnumerable<E> entities)
        {
            _context.Set<E>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public E GetById(int id)
        {
            return _context.Set<E>().Find(id);
        }

        public IEnumerable<E> Find(Expression<Func<E, bool>> expression)
        {
            return _context.Set<E>().Where(expression);
            
        }
    }
}
