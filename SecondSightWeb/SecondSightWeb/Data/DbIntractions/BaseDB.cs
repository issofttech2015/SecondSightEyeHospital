using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.DbIntractions
{
    public class BaseDB<T> where T : class
    {
        private readonly SecondSightDbContext _dataContext;
        private IDbSet<T> dbset;
        string errorMessage = string.Empty;
        public BaseDB()
        {
            _dataContext = new SecondSightDbContext();
        }
        public virtual T Add(T entity)
        {

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity is null");
                }
                this.Entities.Add(entity);
                this._dataContext.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }
        public virtual T Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity is null");
                }
                var entry = this._dataContext.Entry(entity);
                if (entry.State == EntityState.Detached || entry.State == EntityState.Modified)
                {
                    entry.State = EntityState.Modified;
                    this._dataContext.Set<T>().Attach(entity);
                    this._dataContext.Entry(entity).State = EntityState.Modified;
                    this._dataContext.SaveChanges();
                }
                return entity;

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw new Exception(errorMessage, dbEx);
            }
        }
        public virtual bool Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity is null");
                }

                this.Entities.Remove(entity);
                this._dataContext.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }
        public bool Delete(Func<T, Boolean> where)
        {
            try
            {

                IEnumerable<T> objects = this.Entities.Where<T>(where).AsEnumerable();
                foreach (T obj in objects)
                {
                    this.Entities.Remove(obj);
                }
                this._dataContext.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }
        public virtual T GetById(object id)
        {
            return this.Entities.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return this.Entities.ToList();
        }
        public virtual IEnumerable<T> GetMany(Func<T, bool> where)
        {
            return this.Entities.Where(where).ToList();
        }
        public T Get(Func<T, Boolean> where)
        {
            return this.Entities.Where(where).FirstOrDefault<T>();
        }
        private IDbSet<T> Entities
        {
            get
            {
                if (dbset == null)
                {
                    dbset = _dataContext.Set<T>();
                }
                return dbset;
            }
        }
    }
}
