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
    /// 纸管检测
    /// </summary>
    public class PaperBox_checkController : Controller
    {
        //
        // GET: /PaperBox_check/
        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        PaperBox_checkBLL Bll = new PaperBox_checkBLL();


        #region 列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="numPerPage"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(int? pageNum, int? numPerPage, PaperBox_check model)
        {
            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<PaperBox_check, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (model.PBC_CheckTime != null && model.PBC_CheckTime.ToString() != "0001-01-01 00:00:00")
            {
                wherelambad = wherelambad = u => u.PBC_CheckTime == model.PBC_CheckTime;//检测日期
            }
            if (!string.IsNullOrWhiteSpace(model.PBC_FName))
            {
                wherelambad = wherelambad.And(u => u.PBC_FName == model.PBC_FName);//厂家名称
            }
            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["PBC_CheckTime"] = model.PBC_CheckTime != null && model.PBC_CheckTime.ToString() != "0001-01-01 00:00:00" ? model.PBC_CheckTime.ToString() : "";
            ViewData["PBC_FName"] = model.PBC_FName;
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
        public ActionResult CheckAdd(PaperBox_check model)
        {
            string otype = model != null && model.ID == 0 ? "add" : "update";
            var result = 0;
            Expression<Func<PaperBox_check, bool>> wherelambad = u => 1 == 1;//查询条件;    
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
                string msg = CommonMsg.SuccessAlert(200, "操作成功 ! ", "PaperBox_check", callbackType: "closeCurrent");
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
            ViewData["PBC_CheckTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].PBC_CheckTime).ToString("yyyy-MM-dd") : "";
            ViewData["PBC_Stand"] = list != null && list.Count > 0 ? list[0].PBC_Stand.ToString() : "";
            ViewData["PBC_mm"] = list != null && list.Count > 0 ? list[0].PBC_mm.ToString() : "";

            ViewData["PBC_mm1"] = list != null && list.Count > 0 ? list[0].PBC_mm1.ToString() : "";
            ViewData["PBC_mm2"] = list != null && list.Count > 0 ? list[0].PBC_mm2.ToString() : "";
            ViewData["PBC_PressAvg"] = list != null && list.Count > 0 ? list[0].PBC_PressAvg.ToString() : "";


            ViewData["PBC_PressMin"] = list != null && list.Count > 0 ? list[0].PBC_PressMin.ToString() : "";
            ViewData["PBC_PressMax"] = list != null && list.Count > 0 ? list[0].PBC_PressMax.ToString() : "";



            ViewData["PBC_Fmm"] = list != null && list.Count > 0 ? list[0].PBC_Fmm.ToString() : "";
            ViewData["PBC_Fmm1"] = list != null && list.Count > 0 ? list[0].PBC_Fmm1.ToString() : "";
            ViewData["PBC_Fmm2"] = list != null && list.Count > 0 ? list[0].PBC_Fmm2.ToString() : "";
            ViewData["PBC_FPressP"] = list != null && list.Count > 0 ? list[0].PBC_FPressP.ToString() : "";
            ViewData["PBC_FInGoodNums"] = list != null && list.Count > 0 ? list[0].PBC_FInGoodNums.ToString() : "";
            ViewData["PBC_FCheckGoodNums"] = list != null && list.Count > 0 ? list[0].PBC_FCheckGoodNums.ToString() : "";



            ViewData["PBC_FName"] = list != null && list.Count > 0 ? list[0].PBC_FName.ToString() : "";
            ViewData["PBC_FQualityMsg"] = list != null && list.Count > 0 ? list[0].PBC_FQualityMsg.ToString() : "";
            ViewData["PBC_FCheckUID"] = list != null && list.Count > 0 ? list[0].PBC_FCheckUID.ToString() : "";

            ViewData["PBC_FRemark"] = list != null && list.Count > 0 ? list[0].PBC_FRemark.ToString() : "";
            ViewData["PBC_FIsPassMsg"] = list != null && list.Count > 0 ? list[0].PBC_FIsPassMsg.ToString() : "";

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

            Expression<Func<PaperBox_check, bool>> wherelambad = u => 1 == 1;//查询条件;    
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