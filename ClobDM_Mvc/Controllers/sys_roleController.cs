using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClobDM_BLL;
using ClobDM_Model;
using System.Linq.Expressions;
using Common;
namespace ClobDM_Mvc.Controllers
{
    public class sys_roleController : Controller
    {
        //
        // GET: /sys_role/

        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        sys_roleBLL Bll = new sys_roleBLL();

        #region 角色列表
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="numPerPage"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(int? pageNum, int? numPerPage, sys_role model)
        {
            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<sys_role, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (!string.IsNullOrWhiteSpace(model.S_name))
            {
                wherelambad = wherelambad = u => u.S_name.Contains(model.S_name);//模糊查找
            }
            LogUtil.WiteLog.WriteLogs("小五测试abc","testlog");

            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["S_name"] = model.S_name;
            var list = data.ToList();
            return View(list);
        }
        #endregion 


        #region 新增验证
        /// <summary>
        /// 新增验证
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public ActionResult CheckRoleInfo(sys_role RoleInfo)
        {
            string otype = RoleInfo != null && RoleInfo.ID == 0 ? "add" : "update";
            var result = 0;
            Expression<Func<sys_role, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (otype == "add")
            {
                if (!string.IsNullOrWhiteSpace(RoleInfo.S_name))
                {
                    wherelambad = wherelambad = u => u.S_name.Equals(RoleInfo.S_name);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(RoleInfo.S_name) && RoleInfo.ID != 0)
                {
                    wherelambad = wherelambad = u => u.S_name.Equals(RoleInfo.S_name) && u.ID != RoleInfo.ID;
                }
            }
            var data = Bll.GetEntitysByStrwhere(wherelambad).ToList().Count();
            if (data != 0)
            {
                return Content(CommonMsg.ErrorAlert(300, "角色名称[" + RoleInfo.S_name + "]已经存在"));
            }
            if (otype == "add")
            {

                RoleInfo.CreateTime = RoleInfo.UpdateTime = DateTime.Now;
                RoleInfo.CreateUser = RoleInfo.UpdateUser = 10000;
                result = Bll.Addsys_role(RoleInfo);
            }
            else
            {
                RoleInfo.UpdateTime = DateTime.Now;
                result = Bll.UpdateSys_role(RoleInfo);
            }
            if (result != 0)
            {
                string msg = CommonMsg.SuccessAlert(200, "操作成功 ! ", "sys_role", callbackType: "closeCurrent");
                return Content(msg);
            }
            else
            {
                return Content(CommonMsg.ErrorAlert(300, "操作失败"));
            }
        }
        #endregion


        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public ActionResult Add(int? OID)
        {
            var data = Bll.GetEntitysByStrwhere(u => u.ID == OID);
            var list = data.ToList();
            ViewData["OID"] = OID.HasValue ? OID : 0;
            ViewData["S_name"] = list != null && list.Count > 0 ? list[0].S_name : "";
            ViewData["CreateTime"] = list != null && list.Count > 0 ? list[0].CreateTime.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return View();

        }
        #endregion 


        #region 单个删除数据
        /// <summary>
        /// 单个删除数据
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public ActionResult DeleteSysRole(int? OID)
        {
            var id = OID.HasValue ? OID : 0;
            var result = 0;
            var data = Bll.GetEntitysByStrwhere(u => u.ID == OID).FirstOrDefault();
            if (data != null)
            {
                data.S_state = 1;
                data.ID = Convert.ToInt32(id);
                data.UpdateTime = DateTime.Now;
                result = Bll.UpdateSys_role(data);
            }
            if (result != 0)
            {
                return Content(CommonMsg.SuccessAlert(200, "删除成功", "sys_role"));
            }
            else
            {
                return Content(CommonMsg.ErrorAlert(300, "操作失败"));
            }
        }
        #endregion



        #region 单个启用数据
        /// <summary>
        /// 单个启用数据
        /// </summary>
        /// <param name="OID"></param>
        public ActionResult RecoverSysRole(int? OID)
        {
            var id = OID.HasValue ? OID : 0;
            var result = 0;
            var data = Bll.GetEntitysByStrwhere(u => u.ID == OID).FirstOrDefault();
            if (data != null)
            {
                data.S_state = 0;
                data.ID = Convert.ToInt32(id);
                data.UpdateTime = DateTime.Now;
                result = Bll.UpdateSys_role(data);
            }
            if (result != 0)
            {
                return Content(CommonMsg.SuccessAlert(200, "启用成功", "sys_role"));//Content表示的是返回文本数据
            }
            else
            {
                return Content(CommonMsg.ErrorAlert(300, "操作失败"));
            }
        }
        #endregion 


       
        #region  批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult DeleteRoleInfoByIds(string ids)
        {

            var result = db.Database.ExecuteSqlCommand(@"update sys_role set s_state=1 where s_state=0 and   id in(" + ids.Trim().Trim(',') + ")");
            if (result != 0)
            {
                return Content(CommonMsg.SuccessAlert(200, "操作成功", "sys_role"));
            }
            else
            {
                return Content(CommonMsg.ErrorAlert(300, "操作失败"));
            }

        }
        #endregion 

        #region  批量恢复
        /// <summary>
        /// 批量恢复
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult RecoverRoleInfoByIds(string ids)
        {
            var result = db.Database.ExecuteSqlCommand(@"update sys_role set s_state=0 where s_state=1 and   id in(" + ids.Trim().Trim(',') + ")");
            if (result != 0)
            {
                return Content(CommonMsg.SuccessAlert(200, "操作成功", "sys_role"));
            }
            else
            {
                return Content(CommonMsg.ErrorAlert(300, "操作失败"));
            }
        }
        #endregion 


        #region 角色权限
        /// <summary>
        /// 角色权限
        /// </summary>
        /// <returns></returns>
        public ActionResult sys_roleInMenu(int OID)
        {

            var data = Bll.GetEntitysByStrwhere(u => u.ID == OID).FirstOrDefault();
            if (data != null)
            {

                LogUtil.WiteLog.WriteLogs("weblog", "S_name:" + data.S_name);
                ViewData["RoleName"] = data.S_name;
                ViewData["OID"] = OID;
            }
            return View();
        }
        #endregion 


    }
}