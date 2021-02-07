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
   public class Continue_SolidBLL
    {
       Continue_SolidDAL Dal = new Continue_SolidDAL();
       public IQueryable<Continue_Solid> GetEntitysByStrwhere(Expression<Func<Continue_Solid, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
       public int Add(Continue_Solid model)
        {
            return Dal.Add(model);
        }
        public int Delete(int id)
        {
            return Dal.Delete(id);
        }
        public int Update(Continue_Solid model)
        {
            return Dal.Update(model);
        }
        public IQueryable<Continue_Solid> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<Continue_Solid, bool>> wherelambad, Expression<Func<Continue_Solid, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
