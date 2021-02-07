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
   /// 丙烯酸-小五测试-2021/2/8
   /// </summary>
    public class Acroleic_acidController : Controller
    {
        //
        // GET: /Acroleic_acid/
        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        Acroleic_acidBLL Bll = new Acroleic_acidBLL();
        public ActionResult Index(int? pageNum, int? numPerPage, Acroleic_acid model)
        {
            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<Acroleic_acid, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (model.AA_CheckTime != null && model.AA_CheckTime.ToString() != "0001-01-01 00:00:00")
            {
                wherelambad = wherelambad = u => u.AA_CheckTime == model.AA_CheckTime;//模糊查找
            }
            if (!string.IsNullOrWhiteSpace(model.AA_FName))
            {
                wherelambad = wherelambad.And(u => u.AA_FName == model.AA_FName);
            }
            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["AA_CheckTime"] = model.AA_CheckTime != null && model.AA_CheckTime.ToString() != "0001-01-01 00:00:00" ? model.AA_CheckTime.ToString() : "";
            ViewData["AA_FName"] = model.AA_FName;
            var list = data.ToList();
            return View(list);
        }

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
            ViewData["AA_CheckTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].AA_CheckTime).ToString("yyyy-MM-dd") : "";
            ViewData["AA_InGoodNums"] = list != null && list.Count > 0 ? list[0].AA_InGoodNums.ToString() : "";
            ViewData["AA_CheckGoodNums"] = list != null && list.Count > 0 ? list[0].AA_CheckGoodNums.ToString() : "";
            ViewData["AA_CrucibleW"] = list != null && list.Count > 0 ? list[0].AA_CrucibleW.ToString() : "";
            ViewData["AA_ArchFTW1"] = list != null && list.Count > 0 ? list[0].AA_ArchFTW1.ToString() : "";
            ViewData["AA_ArchFTW2"] = list != null && list.Count > 0 ? list[0].AA_ArchFTW2.ToString() : "";
            ViewData["AA_solid"] = list != null && list.Count > 0 ? list[0].AA_solid.ToString() : "";


            ViewData["AA_avg"] = list != null && list.Count > 0 ? list[0].AA_avg.ToString() : "";
            ViewData["AA_PH"] = list != null && list.Count > 0 ? list[0].AA_PH.ToString() : "";
            ViewData["AA_Fsolid"] = list != null && list.Count > 0 ? list[0].AA_Fsolid.ToString() : "";
            ViewData["AA_FPH"] = list != null && list.Count > 0 ? list[0].AA_FPH.ToString() : "";
            ViewData["AA_AddTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].AA_AddTime).ToString("yyyy-MM-dd") : "";
            ViewData["AA_FName"] = list != null && list.Count > 0 ? list[0].AA_FName.ToString() : "";
            ViewData["AA_FIsPass"] = list != null && list.Count > 0 ? list[0].AA_FIsPass.ToString() : "";
            ViewData["AA_FCheckUID"] = list != null && list.Count > 0 ? list[0].AA_FCheckUID.ToString() : "";
            ViewData["AA_FPassMsg"] = list != null && list.Count > 0 ? list[0].AA_FPassMsg.ToString() : "";
            ViewData["AA_FRemark"] = list != null && list.Count > 0 ? list[0].AA_FRemark.ToString() : "";
            ViewData["CreateTime"] = list != null && list.Count > 0 ?Convert.ToDateTime(list[0].CreateTime).ToString("yyyy-MM-dd HH:mm:ss") : "";
            return View();
        }
        #endregion 


        #region 新增和编辑验证
        /// <summary>
        /// 新增和编辑验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult CheckAdd(Acroleic_acid model)
        {
            string otype = model != null && model.ID == 0 ? "add" : "update";
            var result = 0;
            Expression<Func<Acroleic_acid, bool>> wherelambad = u => 1 == 1;//查询条件;    
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
                string msg =CommonMsg.SuccessAlert(200, "操作成功 ! ", "Acroleic_acid", callbackType: "closeCurrent");
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
        public ActionResult Detail(int ?OID)
        {
            Expression<Func<Acroleic_acid, bool>> wherelambad = u => 1 == 1;//查询条件;    
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