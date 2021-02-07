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
    /// 水性固化剂
    /// </summary>
    public class Water_solidController : Controller
    {
        //
        // GET: /Water_solid/
        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        Water_solidBLL Bll = new Water_solidBLL();


        #region 列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="numPerPage"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(int? pageNum, int? numPerPage, Water_solid model)
        {

            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<Water_solid, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (model.WS_CheckTime != null && model.WS_CheckTime.ToString() != "0001-01-01 00:00:00")
            {
                wherelambad = wherelambad = u => u.WS_CheckTime == model.WS_CheckTime;//来货日期
            }
            if (!string.IsNullOrWhiteSpace(model.WS_FName))
            {
                wherelambad = wherelambad.And(u => u.WS_FName == model.WS_FName);//厂家名称
            }
            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["WS_CheckTime"] = model.WS_CheckTime != null && model.WS_CheckTime.ToString() != "0001-01-01 00:00:00" ? model.WS_CheckTime.ToString() : "";
            ViewData["WS_FName"] = model.WS_FName;
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
        public ActionResult CheckAdd(Water_solid model)
        {
            string otype = model != null && model.ID == 0 ? "add" : "update";
            var result = 0;
            Expression<Func<Water_solid, bool>> wherelambad = u => 1 == 1;//查询条件;    
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
                string msg =CommonMsg.SuccessAlert(200, "操作成功 ! ", "Water_solid", callbackType: "closeCurrent");
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
       /// 
       /// </summary>
       /// <param name="OID"></param>
       /// <returns></returns>
        public ActionResult Add(int? OID)
        {
            var data = Bll.GetEntitysByStrwhere(u => u.ID == OID);
            var list = data.ToList();
            ViewData["OID"] = OID.HasValue ? OID : 0;
            ViewData["WS_CheckTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].WS_CheckTime).ToString("yyyy-MM-dd") : "";
            ViewData["WS_InGoodNums"] = list != null && list.Count > 0 ? list[0].WS_InGoodNums.ToString() : "";
            ViewData["WS_CheckGoodNums"] = list != null && list.Count > 0 ? list[0].WS_CheckGoodNums.ToString() : "";
            ViewData["WS_CrucibleW"] = list != null && list.Count > 0 ? list[0].WS_CrucibleW.ToString() : "";
            ViewData["WS_ArchFTW1"] = list != null && list.Count > 0 ? list[0].WS_ArchFTW1.ToString() : "";
            ViewData["WS_ArchFTW2"] = list != null && list.Count > 0 ? list[0].WS_ArchFTW2.ToString() : "";


            ViewData["WS_solid"] = list != null && list.Count > 0 ? list[0].WS_solid.ToString() : "";
            ViewData["WS_avg"] = list != null && list.Count > 0 ? list[0].WS_avg.ToString() : "";
            ViewData["WS_PH"] = list != null && list.Count > 0 ? list[0].WS_PH.ToString() : "";
            ViewData["WS_Fsolid"] = list != null && list.Count > 0 ? list[0].WS_Fsolid.ToString() : "";
            ViewData["WS_FPH"] = list != null && list.Count > 0 ? list[0].WS_FPH.ToString() : "";
            ViewData["WS_FCheckS"] = list != null && list.Count > 0 ? list[0].WS_FCheckS.ToString() : "";
            ViewData["WS_AddTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].WS_AddTime).ToString("yyyy-MM-dd") : "";
            ViewData["WS_FName"] = list != null && list.Count > 0 ? list[0].WS_FName.ToString() : "";



            ViewData["WS_FIsPass"] = list != null && list.Count > 0 ? list[0].WS_FIsPass.ToString() : "";
            ViewData["WS_FCheckUID"] = list != null && list.Count > 0 ? list[0].WS_FCheckUID.ToString() : "";
            ViewData["WS_FPassMsg"] = list != null && list.Count > 0 ? list[0].WS_FPassMsg.ToString() : "";
            ViewData["WS_FRemark"] = list != null && list.Count > 0 ? list[0].WS_FRemark.ToString() : "";
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

            Expression<Func<Water_solid, bool>> wherelambad = u => 1 == 1;//查询条件;    
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