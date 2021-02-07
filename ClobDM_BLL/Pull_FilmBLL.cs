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
   public class Pull_FilmBLL
    {
       Pull_FilmDAL Dal = new Pull_FilmDAL();
       public IQueryable<Pull_Film> GetEntitysByStrwhere(Expression<Func<Pull_Film, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
       public int Add(Pull_Film model)
        {
            return Dal.Add(model);
        }
        public int Delete(int id)
        {
            return Dal.Delete(id);
        }
        public int Update(Pull_Film model)
        {
            return Dal.Update(model);
        }
        public IQueryable<Pull_Film> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<Pull_Film, bool>> wherelambad, Expression<Func<Pull_Film, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
