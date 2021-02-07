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
    /// <summary>
    /// 小五-测试/12345454
    /// </summary>
   public class coal_checkBLL
    {
       coal_checkDAL Dal = new coal_checkDAL();
       public IQueryable<coal_check> GetEntitysByStrwhere(Expression<Func<coal_check, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
       public int Add(coal_check model)
        {
            return Dal.Add(model);
        }
        public int Delete(int id)
        {
            return Dal.Delete(id);
        }
        public int Update(coal_check model)
        {
            return Dal.Update(model);
        }
        public IQueryable<coal_check> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<coal_check, bool>> wherelambad, Expression<Func<coal_check, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
