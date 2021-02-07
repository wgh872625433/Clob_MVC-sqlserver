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
   public  class Water_solidBLL
    {
       Water_solidDAL Dal = new Water_solidDAL();
       public IQueryable<Water_solid> GetEntitysByStrwhere(Expression<Func<Water_solid, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
       public int Add(Water_solid model)
        {
            return Dal.Add(model);
        }
        public int Delete(int id)
        {
            return Dal.Delete(id);
        }
        public int Update(Water_solid model)
        {
            return Dal.Update(model);
        }
        public IQueryable<Water_solid> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<Water_solid, bool>> wherelambad, Expression<Func<Water_solid, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
