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
    /// 小五--菜鸟--测试12323
    /// </summary>
   public class Acroleic_acidBLL
    {
        Acroleic_acidDAL Dal = new Acroleic_acidDAL();
        public IQueryable<Acroleic_acid> GetEntitysByStrwhere(Expression<Func<Acroleic_acid, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
        public int Add(Acroleic_acid model)
        {
            return Dal.Add(model);
        }
        public int Delete(int id)
        {
            return Dal.Delete(id);
        }
        public int Update(Acroleic_acid model)
        {
            return Dal.Update(model);
        }
        public IQueryable<Acroleic_acid> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<Acroleic_acid, bool>> wherelambad, Expression<Func<Acroleic_acid, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
