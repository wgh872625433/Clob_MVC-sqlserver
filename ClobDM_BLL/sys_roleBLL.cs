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
   public class sys_roleBLL
    {
       sys_roleDAL Dal = new sys_roleDAL();
       public IQueryable<sys_role> GetEntitysByStrwhere(Expression<Func<sys_role, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
       public int Addsys_role(sys_role userinfo)
        {
            return Dal.Add(userinfo);
        }
       public int DeleteSys_role(int id)
        {
            return Dal.Delete(id);
        }
        public int UpdateSys_role(sys_role model)
        {
            return Dal.Update(model);
        }
        public IQueryable<sys_role> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<sys_role, bool>> wherelambad, Expression<Func<sys_role, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
