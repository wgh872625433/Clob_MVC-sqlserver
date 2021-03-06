﻿using System;
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
  public  class Starch_checkBLL
    {
      Starch_checkDAL Dal = new Starch_checkDAL();
      public IQueryable<Starch_check> GetEntitysByStrwhere(Expression<Func<Starch_check, bool>> wherelambad)
        {
            return Dal.GetEntitys(wherelambad);
        }
       public int Add(Starch_check model)
        {
            return Dal.Add(model);
        }
        public int Delete(int id)
        {
            return Dal.Delete(id);
        }
        public int Update(Starch_check model)
        {
            return Dal.Update(model);
        }
        public IQueryable<Starch_check> GetPageEntities<T_key>(int pageIndex, int pageSize, out int total, Expression<Func<Starch_check, bool>> wherelambad, Expression<Func<Starch_check, T_key>> OrderbyLambad, bool IsSort)
        {
            return Dal.GetPageEntities<T_key>(pageIndex, pageSize, out total, wherelambad, OrderbyLambad, IsSort);
        }
    }
}
