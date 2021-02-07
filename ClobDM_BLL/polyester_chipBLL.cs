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
   public class polyester_chipBLL
    {
       polyester_chipDAL Dal = new polyester_chipDAL();
       public IQueryable<polyester_chip> GetEntitysByStrwhere(Expression<Func<polyester_chip, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
        public int Add(polyester_chip model)
        {
            return Dal.Add(model);
        }
        public int Delete(int id)
        {
            return Dal.Delete(id);
        }
        public int Update(polyester_chip model)
        {
            return Dal.Update(model);
        }
        public IQueryable<polyester_chip> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<polyester_chip, bool>> wherelambad, Expression<Func<polyester_chip, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
