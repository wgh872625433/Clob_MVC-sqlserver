using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using ClobDM_BLL;
using ClobDM_Model;
using Common;
using NPOI.HSSF.UserModel;
using System.Diagnostics;
using NPOI.SS.UserModel;
using System.Data;

namespace ClobDM_Mvc.Controllers
{
    public class Custome_StandController : Controller
    {
        //
        // GET: /Custome_Stand/
        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        Custome_StandBLL Bll = new Custome_StandBLL();

        #region 列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="numPerPage"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(int? pageNum, int? numPerPage, Custome_Stand model)
        {
            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<Custome_Stand, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (model.CreateTime != null && model.CreateTime.ToString() != "0001-01-01 00:00:00")
            {
                wherelambad = wherelambad = u => u.CreateTime == model.CreateTime;//模糊查找
            }
            if (!string.IsNullOrWhiteSpace(model.CS_Name))
            {
                wherelambad = wherelambad.And(u => u.CS_Name == model.CS_Name);
            }
            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["CreateTime"] = model.CreateTime != null && model.CreateTime.ToString() != "0001-01-01 00:00:00" ? model.CreateTime.ToString() : "";
            ViewData["CS_Name"] = model.CS_Name;
            var list = data.ToList();
            return View(list);
        }
        #endregion 


        #region 新增页面
        /// <summary>
        /// 新增页面
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public ActionResult Add(int? OID)
        {
            var data = Bll.GetEntitysByStrwhere(u => u.ID == OID);
            var list = data.ToList();
            ViewData["OID"] = OID.HasValue ? OID : 0;
            ViewData["CS_Name"] = list != null && list.Count > 0 ? list[0].CS_Name : "";
            ViewData["CS_Deep"] = list != null && list.Count > 0 ? list[0].CS_Deep.ToString() : "";
            ViewData["CS_DeepS"] = list != null && list.Count > 0 ? list[0].CS_DeepS.ToString() : "";
            ViewData["CS_BreakPowerS1"] = list != null && list.Count > 0 ? list[0].CS_BreakPowerS1.ToString() : "";
            ViewData["CS_BreakPowerS2"] = list != null && list.Count > 0 ? list[0].CS_BreakPowerS2.ToString() : "";
            ViewData["CS_BreakPowerS3"] = list != null && list.Count > 0 ? list[0].CS_BreakPowerS3.ToString() : "";
            ViewData["CS_deformation_rate1"] = list != null && list.Count > 0 ? list[0].CS_deformation_rate1.ToString() : "";
            ViewData["CS_deformation_rate2"] = list != null && list.Count > 0 ? list[0].CS_deformation_rate2.ToString() : "";
            ViewData["CS_deformation_rate3"] = list != null && list.Count > 0 ? list[0].CS_deformation_rate3.ToString() : "";
            ViewData["CreateTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].CreateTime).ToString("yyyy-MM-dd HH:mm:ss") : "";
            return View();
        }
        #endregion


        #region 新增和编辑验证
        /// <summary>
        /// 新增和编辑验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult CheckAdd(Custome_Stand model)
        {
            string otype = model != null && model.ID == 0 ? "add" : "update";
            var result = 0;
            Expression<Func<Custome_Stand, bool>> wherelambad = u => 1 == 1;//查询条件;    
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
                string msg = CommonMsg.SuccessAlert(200, "操作成功 ! ", "Custome_Stand", callbackType: "closeCurrent");
                return Content(msg);
            }
            else
            {
                return Content(CommonMsg.ErrorAlert(300, "操作失败"));
            }
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
            Expression<Func<Custome_Stand, bool>> wherelambad = u => 1 == 1;//查询条件;    
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