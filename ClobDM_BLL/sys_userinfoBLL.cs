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
    public class sys_userinfoBLL
    {
        sys_userinfoDAL Dal = new sys_userinfoDAL();
        public IQueryable<sys_userinfo> GetEntitysByStrwhere(Expression<Func<sys_userinfo, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
        public int Addsys_userinfo(sys_userinfo userinfo)
        {
            return Dal.Add(userinfo);
        }
        public int DeleteSys_userinfo(int id)
        {
            return Dal.Delete(id);
        }
        public int UpdateSys_userinfo(sys_userinfo model)
        {
            return Dal.Update(model);
        }
        public IQueryable<sys_userinfo> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<sys_userinfo, bool>> wherelambad, Expression<Func<sys_userinfo,T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
