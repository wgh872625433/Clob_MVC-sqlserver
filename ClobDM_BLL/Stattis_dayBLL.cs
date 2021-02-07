using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;
using ClobDM_Model;
using ClobDM_DAL;
namespace ClobDM_BLL
{
   public class Stattis_dayBLL
    {
       Stattis_dayDAL Dal = new Stattis_dayDAL();
       public IQueryable<Stattis_day> GetEntitysByStrwhere(Expression<Func<Stattis_day, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
       public int Add(Stattis_day model)
        {
            return Dal.Add(model);
        }
        public int Delete(int id)
        {
            return Dal.Delete(id);
        }
        public int Update(Stattis_day model)
        {
            return Dal.Update(model);
        }
        public IQueryable<Stattis_day> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<Stattis_day, bool>> wherelambad, Expression<Func<Stattis_day, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
