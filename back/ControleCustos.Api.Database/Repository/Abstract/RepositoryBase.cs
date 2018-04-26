using Microsoft.EntityFrameworkCore;
using ControleCustos.Api.Database.Entity.Base;
using ControleCustos.Api.Domain.Entities.Base;
using ControleCustos.Api.Domain.Interfaces.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using ControleCustos.Api.Domain.Seletores;

namespace ControleCustos.Api.Database.Repository.Abstract
{
    public abstract class RepositoryBase<TEntity, TDomain, TSeletor> : IRepositoryBase<TDomain, TSeletor>
		where TEntity : EntityBase
		where TDomain : DomainBase
		where TSeletor : SeletorBase
	{
		//protected Context Context;

  //      public RepositoryBase(Context context)
  //      {
  //          Context = context;
  //      }

		public RepositoryBase()
		{
			this.Context = new Context();
		}

		public Context Context { get; private set; }

		public virtual TDomain Insert(TDomain obj)
        {
            TEntity entity = MapperToEntity(obj);
            Context.Set<TEntity>().Add(entity);
			this.Save();
			return MapperToDomain(entity);
		}

        public virtual TDomain InsertWithSave(TDomain obj)
        {
            TEntity entity = MapperToEntity(obj);
            Context.Set<TEntity>().Add(entity);
            Save();
            return MapperToDomain(entity);
        }

        public virtual TDomain Update(TDomain obj)
        {
            TEntity entity = MapperToEntity(obj);
            Context.Entry(entity).State = EntityState.Modified;
			this.Save();

			return MapperToDomain(entity);
        }

        public virtual void Delete(TDomain obj)
        {
            TEntity entity = MapperToEntity(obj);
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual IQueryable<TDomain> Get()
        {
            var query = Context.Set<TEntity>()
                .Select(x => MapperToDomain(x))
                .AsQueryable();

            return query;
        }

        public virtual bool Exist(Expression<Func<object, bool>> expression)
        {
            var query = Context.Set<TEntity>()
                .Where(expression)
                .Count();

            if (query > 0)
                return true;

            return false;
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        protected virtual TEntity MapperToEntity(object dto)
        {
            var domainClass = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            TEntity entity = Newtonsoft.Json.JsonConvert.DeserializeObject<TEntity>(domainClass);

            return entity;
        }

        protected virtual TDomain MapperToDomain(TEntity entity)
        {
            var entityClass = Newtonsoft.Json.JsonConvert.SerializeObject(entity);
            TDomain dto = Newtonsoft.Json.JsonConvert.DeserializeObject<TDomain>(entityClass);

            return dto;
        }

        protected virtual List<T> DataReaderMapToList<T>(System.Data.Common.DbDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (System.Reflection.PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

		public List<TDomain> GetList(TSeletor seletor)
		{
			IQueryable<TEntity> query = Context.Set<TEntity>().AsNoTracking().AsQueryable();

			query = this.CreateParameters(seletor, query);
			query = this.CreateOrder(seletor, query);
			query = this.CreateLimit(seletor, query);

			List<TDomain> lista = query.ToList().Select(x => MapperToDomain(x)).ToList();

			return lista;
		}

		public int TotalRows(TSeletor seletor)
		{
			IQueryable<TEntity> query = Context.Set<TEntity>().AsNoTracking().AsQueryable();
			query = this.CreateParameters(seletor, query);

			int count = query.Count();

			return count;
		}


		public IQueryable<TEntity> CreateOrder(TSeletor seletor, IQueryable<TEntity> query)
		{

			query = query.OrderBy(y => 1);

			string[] fields = seletor.OrderBy.Split(',');

			foreach (string fieldWithOrder in fields)
			{

				string[] fieldParam = fieldWithOrder.Split(' ');

				OrderBy order = fieldParam.Length > 1 ? (OrderBy)Enum.Parse(typeof(OrderBy), fieldParam[1]) : seletor.OrderByOrder;

				string orderBy = "ThenBy";
				if (order == OrderBy.DESC)
				{
					orderBy = "ThenByDescending";
				}

				ParameterExpression x = Expression.Parameter(query.ElementType, "x");
				LambdaExpression exp = Expression.Lambda(Expression.PropertyOrField(x, fieldParam[0].Trim()), x);
				query = (IQueryable<TEntity>)query.Provider.CreateQuery(Expression.Call(typeof(Queryable), orderBy, new Type[] {
					query.ElementType, exp.Body.Type
				}, query.Expression, exp));
			}

			return query;
		}
		public IQueryable<TEntity> CreateLimit(TSeletor seletor, IQueryable<TEntity> query)
		{
			if (seletor.Pagina < 0)
			{
				seletor.Pagina = 1;
			}

			int skip = ((seletor.Pagina - 1) * seletor.RegistroPorPagina);
			int take = seletor.RegistroPorPagina;
			query = query.Skip(skip).Take(take);

			return query;
		}

		public abstract IQueryable<TEntity> CreateParameters(TSeletor seletor, IQueryable<TEntity> query);

	}
}
