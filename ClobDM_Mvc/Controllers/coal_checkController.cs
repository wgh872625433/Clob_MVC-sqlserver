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
    /// 测试--小五
    /// </summary>
    public class coal_checkController : Controller
    {
        //
        // GET: /coal_check/

        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        coal_checkBLL Bll = new coal_checkBLL();


        #region 列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="numPerPage"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(int? pageNum, int? numPerPage, coal_check model)
        {
            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<coal_check, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (model.CC_CheckTime != null && model.CC_CheckTime.ToString() != "0001-01-01 00:00:00")
            {
                wherelambad = wherelambad = u => u.CC_CheckTime == model.CC_CheckTime;//检测日期
            }
            if (!string.IsNullOrWhiteSpace(model.CC_FName))
            {
                wherelambad = wherelambad.And(u => u.CC_FName == model.CC_FName);//厂家名称
            }
            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["CC_CheckTime"] = model.CC_CheckTime != null && model.CC_CheckTime.ToString() != "0001-01-01 00:00:00" ? model.CC_CheckTime.ToString() : "";
            ViewData["CC_FName"] = model.CC_FName;
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
        public ActionResult CheckAdd(coal_check model)
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
                string msg = CommonMsg.SuccessAlert(200, "操作成功 ! ", "coal_check", callbackType: "closeCurrent");
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
            ViewData["CC_CheckTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].CC_CheckTime).ToString("yyyy-MM-dd") : "";


            ViewData["CC_AWcomponent"] = list != null && list.Count > 0 ? list[0].CC_AWcomponent.ToString() : "";
            ViewData["CC_AnalyseSW"] = list != null && list.Count > 0 ? list[0].CC_AnalyseSW.ToString() : "";
            ViewData["CC_GreyC"] = list != null && list.Count > 0 ? list[0].CC_GreyC.ToString() : "";
            ViewData["CC_VolatilizeC"] = list != null && list.Count > 0 ? list[0].CC_VolatilizeC.ToString() : "";
            ViewData["CC_Carbon"] = list != null && list.Count > 0 ? list[0].CC_Carbon.ToString() : "";
            ViewData["CC_Aphosphor"] = list != null && list.Count > 0 ? list[0].CC_Aphosphor.ToString() : "";
            ViewData["CC_PhosphorS"] = list != null && list.Count > 0 ? list[0].CC_PhosphorS.ToString() : "";
            ViewData["CC_Hcalorific"] = list != null && list.Count > 0 ? list[0].CC_Hcalorific.ToString() : "";
            ViewData["CC_RLcalorific"] = list != null && list.Count > 0 ? list[0].CC_RLcalorific.ToString() : "";
            ViewData["CC_CheckUID"] = list != null && list.Count > 0 ? list[0].CC_CheckUID.ToString() : "";
            ViewData["CC_Remark"] = list != null && list.Count > 0 ? list[0].CC_Remark.ToString() : "";
            ViewData["CC_IsPass"] = list != null && list.Count > 0 ? list[0].CC_IsPass : "";
            ViewData["CC_IsPassMsg"] = list != null && list.Count > 0 ? list[0].CC_IsPassMsg.ToString() : "";

            ViewData["CC_FAWcomponent"] = list != null && list.Count > 0 ? list[0].CC_FAWcomponent.ToString() : "";
            ViewData["CC_FAnalyseSW"] = list != null && list.Count > 0 ? list[0].CC_FAnalyseSW.ToString() : "";
            ViewData["CC_FGreyC"] = list != null && list.Count > 0 ? list[0].CC_FGreyC.ToString() : "";

            ViewData["CC_FVolatilizeC"] = list != null && list.Count > 0 ? list[0].CC_FVolatilizeC.ToString() : "";
            ViewData["CC_FCarbon"] = list != null && list.Count > 0 ? list[0].CC_FCarbon.ToString() : "";
            ViewData["CC_FAphosphor"] = list != null && list.Count > 0 ? list[0].CC_FAphosphor.ToString() : "";
            ViewData["CC_FPhosphorS"] = list != null && list.Count > 0 ? list[0].CC_FPhosphorS.ToString() : "";
            ViewData["CC_FHcalorific"] = list != null && list.Count > 0 ? list[0].CC_FHcalorific.ToString() : "";
            ViewData["CC_FRLcalorific"] = list != null && list.Count > 0 ? list[0].CC_FRLcalorific.ToString() : "";
            ViewData["CC_FName"] = list != null && list.Count > 0 ? list[0].CC_FName.ToString() : "";

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

            Expression<Func<coal_check, bool>> wherelambad = u => 1 == 1;//查询条件;    
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