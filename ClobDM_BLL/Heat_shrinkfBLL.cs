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
    public class Heat_shrinkfBLL
    {
        Heat_shrinkfDAL Dal = new Heat_shrinkfDAL();
        public IQueryable<Heat_shrinkf> GetEntitysByStrwhere(Expression<Func<Heat_shrinkf, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
        public int Add(Heat_shrinkf model)
        {
            return Dal.Add(model);
        }
        public int Delete(int id)
        {
            return Dal.Delete(id);
        }
        public int Update(Heat_shrinkf model)
        {
            return Dal.Update(model);
        }
        public IQueryable<Heat_shrinkf> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<Heat_shrinkf, bool>> wherelambad, Expression<Func<Heat_shrinkf, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
