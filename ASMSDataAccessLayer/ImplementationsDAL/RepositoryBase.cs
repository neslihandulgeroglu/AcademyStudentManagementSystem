using ASMSDataAccessLayer.ContractsDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASMSDataAccessLayer.ImplementationsDAL
{
    public class RepositoryBase<T, Id> : IRepositoryBase<T, Id> where T : class, new()

    {
        protected readonly MyContext _myContext;
        public RepositoryBase(MyContext myContext)
        {
            _myContext = myContext;
        }
        //dependens injeksion nedir?
        public bool Add(T entity)
        {
            try
            {
                bool result = false;
                _myContext.Set<T>().Add(entity);
                result = _myContext.SaveChanges() >0?true : false;
                return result;
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(T entity)
        {
            try
            {

               
                _myContext.Set<T>().Add(entity);
                return _myContext.SaveChanges() > 0 ? true : false;
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IQueryable<T>> orderBy = null, string includeEntities = null)
        {
            try
            {
                IQueryable<T> query = _myContext.Set<T>();
                if (filter!=null)
                {
                    query = query.Where(filter);
                }
                if (includeEntities!=null)
                {
                    foreach(var item in includeEntities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(item);
                    }
                }
                if (orderBy!=null)
                {
                    return orderBy(query);
                }
                return query;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T GetById(Id id)
        {
            try {

                return _myContext.Set<T>().Find(id);


            }
            catch (Exception)
            {

                throw;
            }
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeEntities = null)
        {
            try
            {
                IQueryable<T> query = _myContext.Set<T>();
                if(filter!=null)
                {
                    query = query.Where(filter);
                }
                if (includeEntities != null)
                {
                
                    foreach (var item in includeEntities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(item);
                    }
                }
                return query.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(T entity)
        {
            _myContext.Set<T>().Update(entity);
          
            return _myContext.SaveChanges() > 0 ? true : false;

        }
    }
}
