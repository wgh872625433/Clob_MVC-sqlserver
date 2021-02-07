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
   public class Stattis_HotBLL
    {
       Stattis_HotDAL Dal = new Stattis_HotDAL();
       public IQueryable<Stattis_Hot> GetEntitysByStrwhere(Expression<Func<Stattis_Hot, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
       public int Add(Stattis_Hot model)
        {
            return Dal.Add(model);
        }
        public int Delete(int id)
        {
            return Dal.Delete(id);
        }
        public int Update(Stattis_Hot model)
        {
            return Dal.Update(model);
        }
        public IQueryable<Stattis_Hot> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<Stattis_Hot, bool>> wherelambad, Expression<Func<Stattis_Hot, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
