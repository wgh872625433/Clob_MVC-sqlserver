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
   public class Stattis_KgBLL
    {
       Stattis_KgDAL Dal = new Stattis_KgDAL();
       public IQueryable<Stattis_Kg> GetEntitysByStrwhere(Expression<Func<Stattis_Kg, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
       public int Add(Stattis_Kg model)
        {
            return Dal.Add(model);
        }
        public int Delete(int id)
        {
            return Dal.Delete(id);
        }
        public int Update(Stattis_Kg model)
        {
            return Dal.Update(model);
        }
        public IQueryable<Stattis_Kg> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<Stattis_Kg, bool>> wherelambad, Expression<Func<Stattis_Kg, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
