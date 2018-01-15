﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySharing.Data
{
    public partial class EfRepository<T> :IRepository<T> where T:BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;
        public EfRepository(IDbContext context)
        {
            this._context = context;
        }
        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.Entities.Add(entity);
            this._context.SaveChanges();
        }
        public int InsertReturnID(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.Entities.Add(entity);
            this._context.SaveChanges();
            return entity.Id;
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this._context.SaveChanges();
        }
        public void Update(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            this._context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
        }
        public void Delete(IEnumerable<T> entities);
        public IQueryable<T> Table { get; }
        public void Insert(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var item in entities)
            {
                this.Entities.Add(item);
            }
            this._context.SaveChanges();
        }
        /// <summary>
        /// 批量插入，sqlConnection方法
        /// </summary>
        /// <param name="entities"></param>
        public void InsertMany(IEnumerable<T> entities);
        /// <summary>
        /// 暂未实现
        /// </summary>
        public void UpdateMany();
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        public void DeleteMany(IEnumerable<T> entities);
        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}