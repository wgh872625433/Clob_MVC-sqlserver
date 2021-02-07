using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using ClobDM_BLL;
using ClobDM_Model;
using Common;
using NPOI.HSSF.UserModel;
using System.Diagnostics;
using NPOI.SS.UserModel;
using System.Data;
namespace ClobDM_Mvc.Controllers
{
    /// <summary>
    /// 延伸剂/2021/2/7--小五测试
    /// </summary>
    public class Continue_SolidController : Controller
    {
        //
        // GET: /Continue_Solid/
        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        Continue_SolidBLL Bll = new Continue_SolidBLL();


        #region 列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="numPerPage"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(int? pageNum, int? numPerPage, Continue_Solid model)
        {
            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<Continue_Solid, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (model.CS_CheckTime != null && model.CS_CheckTime.ToString() != "0001-01-01 00:00:00")
            {
                wherelambad = wherelambad = u => u.CS_CheckTime == model.CS_CheckTime;//检测日期
            }
            if (!string.IsNullOrWhiteSpace(model.CS_name))
            {
                wherelambad = wherelambad.And(u => u.CS_name == model.CS_name);//厂家名称
            }
            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["CS_CheckTime"] = model.CS_CheckTime != null && model.CS_CheckTime.ToString() != "0001-01-01 00:00:00" ? model.CS_CheckTime.ToString() : "";
            ViewData["CS_name"] = model.CS_name;
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
        public ActionResult CheckAdd(Continue_Solid model)
        {
            string otype = model != null && model.ID == 0 ? "add" : "update";
            var result = 0;
            Expression<Func<sys_userinfo, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (otype == "add")
            {

                model.CreateTime = model.UpdateTime = DateTime.Now;
                model.CreateUser = model.UpdateUser = 1;
                result = Bll.Add(model);
            }
            else
            {
                model.UpdateTime = DateTime.Now;
                result = Bll.Update(model);
            }
            if (result != 0)
            {
                string msg = CommonMsg.SuccessAlert(200, "操作成功 ! ", "Continue_Solid", callbackType: "closeCurrent");
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
            ViewData["CS_CheckTime"] = list != null && list.Count > 0 ?Convert.ToDateTime(list[0].CS_CheckTime).ToString("yyyy-MM-dd") : "";
            ViewData["CS_InGoodNums"] = list != null && list.Count > 0 ? list[0].CS_InGoodNums.ToString() : "";
            ViewData["CS_CheckGoodNums"] = list != null && list.Count > 0 ? list[0].CS_CheckGoodNums.ToString() : "";
            ViewData["CS_CrucibleW"] = list != null && list.Count > 0 ? list[0].CS_CrucibleW.ToString() : "";
            ViewData["CS_ArchFTW1"] = list != null && list.Count > 0 ? list[0].CS_ArchFTW1.ToString() : "";
            ViewData["CS_ArchFTW2"] = list != null && list.Count > 0 ? list[0].CS_ArchFTW2.ToString() : "";


            ViewData["CS_solid"] = list != null && list.Count > 0 ? list[0].CS_solid.ToString() : "";
            ViewData["CS_avg"] = list != null && list.Count > 0 ? list[0].CS_avg.ToString() : "";
            ViewData["CS_PH"] = list != null && list.Count > 0 ? list[0].CS_PH.ToString() : "";
            ViewData["CS_Fsolid"] = list != null && list.Count > 0 ? list[0].CS_Fsolid.ToString() : "";
            ViewData["CS_FPH"] = list != null && list.Count > 0 ? list[0].CS_FPH.ToString() : "";
            ViewData["CS_name"] = list != null && list.Count > 0 ? list[0].CS_name.ToString() : "";
            ViewData["CS_addTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].CS_addTime).ToString("yyyy-MM-dd") : "";
            ViewData["CS_IsPass"] = list != null && list.Count > 0 ? list[0].CS_IsPass.ToString() : "";



            ViewData["CS_Remark"] = list != null && list.Count > 0 ? list[0].CS_Remark.ToString() : "";
            ViewData["CS_CheckUID"] = list != null && list.Count > 0 ? list[0].CS_CheckUID.ToString() : "";
            ViewData["CS_IsPassMsg"] = list != null && list.Count > 0 ? list[0].CS_IsPassMsg.ToString() : "";
            ViewData["CreateTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].CreateTime).ToString("yyyy-MM-dd HH:mm:ss") : "";


            return View();

        }
        #endregion

        #region 详情
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public ActionResult Detail(int? OID)
        {

            Expression<Func<Continue_Solid, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (OID != 0)
            {
                wherelambad = wherelambad = u => u.ID == OID;
            }
            var data = Bll.GetEntitysByStrwhere(wherelambad);
            var list = data.ToList();
            return View(list);
        }
        #endregion

	}
}