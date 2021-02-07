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
   public class Custome_StandBLL
    {
       Custome_StandDAL Dal = new Custome_StandDAL();
       public IQueryable<Custome_Stand> GetEntitysByStrwhere(Expression<Func<Custome_Stand, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
       public int Add(Custome_Stand model)
        {
            return Dal.Add(model);
        }
        public int Delete(int id)
        {
            return Dal.Delete(id);
        }
        public int Update(Custome_Stand model)
        {
            return Dal.Update(model);
        }
        public IQueryable<Custome_Stand> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<Custome_Stand, bool>> wherelambad, Expression<Func<Custome_Stand, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
