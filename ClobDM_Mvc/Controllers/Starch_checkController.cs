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
    public class Starch_checkController : Controller
    {
        //
        // GET: /Starch_check/
        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        Starch_checkBLL Bll = new Starch_checkBLL();


        #region 列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="numPerPage"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(int? pageNum, int? numPerPage, Starch_check model)
        {
            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<Starch_check, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (model.SC_CheckTime != null && model.SC_CheckTime.ToString() != "0001-01-01 00:00:00")
            {
                wherelambad = wherelambad = u => u.SC_CheckTime == model.SC_CheckTime;//检测日期
            }
            if (!string.IsNullOrWhiteSpace(model.SC_FName))
            {
                wherelambad = wherelambad.And(u => u.SC_FName == model.SC_FName);//厂家名称
            }
            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["SC_CheckTime"] = model.SC_CheckTime != null && model.SC_CheckTime.ToString() != "0001-01-01 00:00:00" ? model.SC_CheckTime.ToString() : "";
            ViewData["SC_FName"] = model.SC_FName;
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
        public ActionResult CheckAdd(Starch_check model)
        {
            string otype = model != null && model.ID == 0 ? "add" : "update";
            var result = 0;
            Expression<Func<Starch_check, bool>> wherelambad = u => 1 == 1;//查询条件;    
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
                string msg = CommonMsg.SuccessAlert(200, "操作成功 ! ", "Starch_check", callbackType: "closeCurrent");
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
            ViewData["SC_CheckTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].SC_CheckTime).ToString("yyyy-MM-dd") : "";
            ViewData["SC_Ware"] = list != null && list.Count > 0 ? list[0].SC_ware.ToString() : "";
            ViewData["SC_ArchFw"] = list != null && list.Count > 0 ? list[0].SC_ArchFw.ToString() : "";
            ViewData["SC_ArchAw"] = list != null && list.Count > 0 ? list[0].SC_ArchAw.ToString() : "";


            ViewData["SC_Wcontent"] = list != null && list.Count > 0 ? list[0].SC_Wcontent.ToString() : "";
            ViewData["SC_WcontentAvg"] = list != null && list.Count > 0 ? list[0].SC_WcontentAvg.ToString() : "";
            ViewData["SC_SgelationT"] = list != null && list.Count > 0 ? list[0].SC_SgelationT.ToString() : "";
            ViewData["SC_SgelationS"] = list != null && list.Count > 0 ? list[0].SC_SgelationS.ToString() : "";



            ViewData["SC_gelationT"] = list != null && list.Count > 0 ? list[0].SC_gelationT.ToString() : "";
            ViewData["SC_gelationS"] = list != null && list.Count > 0 ? list[0].SC_gelationS.ToString() : "";


            ViewData["SC_FWcontent"] = list != null && list.Count > 0 ? list[0].SC_FWcontent.ToString() : "";
            ViewData["SC_FName"] = list != null && list.Count > 0 ? list[0].SC_FName.ToString() : "";
            ViewData["SC_Fcode"] = list != null && list.Count > 0 ? list[0].SC_Fcode.ToString() : "";
            ViewData["SC_FInGoodNums"] = list != null && list.Count > 0 ? list[0].SC_FInGoodNums.ToString() : "";



            ViewData["SC_FCheckGoodNums"] = list != null && list.Count > 0 ? list[0].SC_FCheckGoodNums.ToString() : "";


            ViewData["SC_FQualityMsg"] = list != null && list.Count > 0 ? list[0].SC_FQualityMsg.ToString() : "";
            ViewData["SC_FCheckUID"] = list != null && list.Count > 0 ? list[0].SC_FCheckUID.ToString() : "";
            ViewData["SC_FRemark"] = list != null && list.Count > 0 ? list[0].SC_FRemark.ToString() : "";


            ViewData["SC_FIsPassMsg"] = list != null && list.Count > 0 ? list[0].SC_FIsPassMsg.ToString() : "";

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
            Expression<Func<Starch_check, bool>> wherelambad = u => 1 == 1;//查询条件;    
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