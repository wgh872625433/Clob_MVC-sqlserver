using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Reflection;
using ClobDM_Model.Model;
namespace ClobDM_DAL
{
    public class BaseDAL<T> where T : class
    {
        ClobDM_Model.ClobDBContext dbcontext = new ClobDM_Model.ClobDBContext();
        /// <summary>
        /// IQueryable延迟加载集合，调用时才回去加载到内存
        /// List查找会立即加载到内存
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetEntitys(Expression<Func<T, bool>> Lambdawhere)
        {
            return dbcontext.Set<T>().Where(Lambdawhere);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(T entity)
        {
            dbcontext.Set<T>().Add(entity);
            return dbcontext.SaveChanges();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            //通过ID查询这个实体
            T entity = dbcontext.Set<T>().Find(id);
            dbcontext.Set<T>().Remove(entity);
            return dbcontext.SaveChanges();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Update(T entity)
        {
            //设置当前实体粘状态
            dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return dbcontext.SaveChanges();
        }

        /// <summary>
        /// 修改2/add/2020/11/16
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Update2(T entity)
        {
            dbcontext.Set<T>().Attach(entity);
            PropertyInfo[] props = entity.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(entity, null) != null)
                {
                    if (prop.GetValue(entity, null).ToString() == " ")
                        dbcontext.Entry(entity).Property(prop.Name).CurrentValue = null;
                    dbcontext.Entry(entity).Property(prop.Name).IsModified = true;
                }
            }
            return dbcontext.SaveChanges();
        }



        #region 分页查询/add/2020/11/16
        /// <summary>
        /// Entities的分页数据查询
        /// </summary>
        /// <typeparam name="S">Orderby根据排序的元素数据类型</typeparam>
        /// <param name="pageIndex">要查询到页码</param>
        /// <param name="pageSize">每页的条数</param>
        /// <param name="total">总条数</param>
        /// <param name="whereLambda">过滤数据的Lambda表达式</param>
        /// <param name="orderByLambda">指定排序规则的Lambda表达式</param>
        /// <param name="IsAsc">是否是升序排序？</param>
        /// <returns></returns>
        public IQueryable<T> GetPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool IsAsc)
        {
            total = dbcontext.Set<T>().Where(whereLambda).Count();
            if (IsAsc)
            {
                return dbcontext.Set<T>().Where(whereLambda).OrderBy<T, S>(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable();

            }
            else
            {
                return dbcontext.Set<T>().Where(whereLambda).OrderByDescending<T, S>(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable();

            }
        }

        #endregion
    }
}
