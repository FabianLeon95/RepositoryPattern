using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RepositoryMVC.Models;

namespace RepositoryMVC.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        protected readonly EmployeeDBContext Context;
        protected readonly DbSet<T> Table;

        public GenericRepository()
        {
            Context = new EmployeeDBContext();
            Table = Context.Set<T>();
        }

        public GenericRepository(EmployeeDBContext context)
        {
            Context = context;
            Table = Context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(object id)
        {
            return Table.Find(id);

        }

        public void Insert(T element)
        {
            Table.Add(element);
        }

        public void Update(T element)
        {

            Table.Attach(element);
            Context.Entry(element).State = EntityState.Modified;
        }

        public void Delete(object id)
        { 
            var element = Table.Find(id);
            Table.Remove(element);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}