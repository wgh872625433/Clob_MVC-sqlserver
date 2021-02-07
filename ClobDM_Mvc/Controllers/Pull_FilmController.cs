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
    /// 拉伸膜
    /// </summary>
    public class Pull_FilmController : Controller
    {
        //
        // GET: /Pull_Film/
        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        Pull_FilmBLL Bll = new Pull_FilmBLL();

        #region 列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="numPerPage"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(int? pageNum, int? numPerPage, Pull_Film model)
        {
            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<Pull_Film, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (model.PF_InGoodsTime != null && model.PF_InGoodsTime.ToString() != "0001-01-01 00:00:00")
            {
                wherelambad = wherelambad = u => u.PF_InGoodsTime == model.PF_InGoodsTime;//来货日期
            }
            if (!string.IsNullOrWhiteSpace(model.PF_FName))
            {
                wherelambad = wherelambad.And(u => u.PF_FName == model.PF_FName);//厂家名称
            }
            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["PF_InGoodsTime"] = model.PF_InGoodsTime != null && model.PF_InGoodsTime.ToString() != "0001-01-01 00:00:00" ? model.PF_InGoodsTime.ToString() : "";
            ViewData["PF_FName"] = model.PF_FName;
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
        public ActionResult CheckAdd(Pull_Film model)
        {
            string otype = model != null && model.ID == 0 ? "add" : "update";
            var result = 0;
            Expression<Func<Pull_Film, bool>> wherelambad = u => 1 == 1;//查询条件;    
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
                string msg = CommonMsg.SuccessAlert(200, "操作成功 ! ", "Pull_Film", callbackType: "closeCurrent");
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
            ViewData["PF_InGoodsTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].PF_InGoodsTime).ToString("yyyy-MM-dd") : "";
            ViewData["PF_Stand"] = list != null && list.Count > 0 ? list[0].PF_Stand.ToString() : "";
            ViewData["PF_FcleanW"] = list != null && list.Count > 0 ? list[0].PF_FcleanW.ToString() : "";


            ViewData["PF_Fmm"] = list != null && list.Count > 0 ? list[0].PF_Fmm.ToString() : "";
            ViewData["PF_Fww"] = list != null && list.Count > 0 ? list[0].PF_Fww.ToString() : "";
            ViewData["PF_FdrawSM1"] = list != null && list.Count > 0 ? list[0].PF_FdrawSM1.ToString() : "";
            ViewData["PF_FdrawSM2"] = list != null && list.Count > 0 ? list[0].PF_FdrawSM2.ToString() : "";
            ViewData["PF_FdisruptED"] = list != null && list.Count > 0 ? list[0].PF_FdisruptED.ToString() : "";



            ViewData["PF_FchargeS"] = list != null && list.Count > 0 ? list[0].PF_FchargeS.ToString() : "";
            ViewData["PF_Fsticky"] = list != null && list.Count > 0 ? list[0].PF_Fsticky.ToString() : "";


            ViewData["PF_FName"] = list != null && list.Count > 0 ? list[0].PF_FName.ToString() : "";
            ViewData["PF_TWeight"] = list != null && list.Count > 0 ? list[0].PF_TWeight.ToString() : "";
            ViewData["PF_PBox"] = list != null && list.Count > 0 ? list[0].PF_PBox.ToString(): "";
            ViewData["PF_PChannel"] = list != null && list.Count > 0 ? list[0].PF_PChannel.ToString() : "";



            ViewData["PF_CleanW"] = list != null && list.Count > 0 ? list[0].PF_CleanW.ToString() : "";


            ViewData["PF_InGoodNums"] = list != null && list.Count > 0 ? list[0].PF_InGoodNums.ToString() : "";
            ViewData["PF_CheckGoodNums"] = list != null && list.Count > 0 ? list[0].PF_CheckGoodNums.ToString() : "";
            ViewData["PF_gm"] = list != null && list.Count > 0 ? list[0].PF_gm.ToString() : "";


            ViewData["PF_ww"] = list != null && list.Count > 0 ? list[0].PF_ww.ToString() : "";
            ViewData["PF_mm"] = list != null && list.Count > 0 ? list[0].PF_mm.ToString() : "";
            ViewData["PF_PowerW1"] = list != null && list.Count > 0 ? list[0].PF_PowerW1.ToString() : "";
            ViewData["PF_PowerW2"] = list != null && list.Count > 0 ? list[0].PF_PowerW2.ToString() : "";


            ViewData["PF_drawSM1"] = list != null && list.Count > 0 ? list[0].PF_drawSM1.ToString() : "";
            ViewData["PF_drawSM2"] = list != null && list.Count > 0 ? list[0].PF_drawSM2.ToString() : "";
            ViewData["PF_Remark"] = list != null && list.Count > 0 ? list[0].PF_Remark.ToString() : "";
            ViewData["PF_CheckUID"] = list != null && list.Count > 0 ? list[0].PF_CheckUID.ToString() : "";
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
            Expression<Func<Pull_Film, bool>> wherelambad = u => 1 == 1;//查询条件;    
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