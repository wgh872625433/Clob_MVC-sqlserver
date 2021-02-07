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
using ClobDM_Model.Model;
namespace ClobDM_Mvc.Controllers
{
    /// <summary>
    /// 聚酯切片
    /// </summary>
    public class polyester_chipController : Controller
    {
        //
        // GET: /polyester_chip/
        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        polyester_chipBLL Bll = new polyester_chipBLL();
        //Asp.Net MVC - Htmlhelper:https://www.cnblogs.com/JoeSnail/p/7724341.html


        #region  列表数据
        /// <summary>
        /// 列表数据
        /// </summary>
        /// <param name="pageNum">当前页码数</param>
        /// <param name="numPerPage">每页显示条数</param>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        public ActionResult Index(int? pageNum, int? numPerPage, polyester_chip model)
        {
            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<polyester_chip, bool>> wherelambad = u => 1 == 1;//查询条件;    

            if (!string.IsNullOrWhiteSpace(model.PC_FName))
            {
                wherelambad = wherelambad = u => u.PC_FName.Contains(model.PC_FName);//模糊查找
            }
            if (!string.IsNullOrWhiteSpace(model.PC_CheckUser))
            {
                wherelambad = wherelambad.And(u => u.PC_CheckUser == model.PC_CheckUser);
            }
            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["PC_FName"] = model.PC_FName;
            ViewData["PC_CheckUser"] = model.PC_CheckUser;
            var list = data.ToList();
            return View(list);
        }
        #endregion 

        #region 新增页面
        /// <summary>
        /// 新增页面
        /// </summary>
        /// <param name="OID">编辑的ID</param>
        /// <returns></returns>
        public ActionResult Addpolyester_chip(int? OID)
        {
            var data = Bll.GetEntitysByStrwhere(u => u.ID == OID);
            var list = data.ToList();
            ViewData["OID"] = OID.HasValue ? OID : 0;
            ViewData["PC_ChekTime"] = list != null && list.Count > 0 ?Convert.ToDateTime(list[0].PC_ChekTime).ToString("yyyy-MM-dd") : "";

            ViewData["ChekTime"] = list != null && list.Count > 0 ? list[0].PC_ChekTime : DateTime.Now;

            ViewData["PC_InGoodsNum"] = list != null && list.Count > 0 ? list[0].PC_InGoodsNum.ToString():"";
            ViewData["PC_WetSectionH"] = list != null && list.Count > 0 ? list[0].PC_WetSectionH.ToString() : "";
            ViewData["PC_H1"] = list != null && list.Count > 0 ? list[0].PC_H1.ToString() : "";
            ViewData["PC_H2"] = list != null && list.Count > 0 ? list[0].PC_H2.ToString() : "";
            ViewData["PC_WaterCompent"] = list != null && list.Count > 0 ? list[0].PC_WaterCompent.ToString() : "";
            //厂家信息
            ViewData["PC_FCheckWater"] = list != null && list.Count > 0 ? list[0].PC_FCheckWater.ToString() : "";
            ViewData["PC_FCheckSS"] = list != null && list.Count > 0 ? list[0].PC_FCheckSS.ToString() : "";
            ViewData["PC_HundredW1"] = list != null && list.Count > 0 ? list[0].PC_HundredW1.ToString() : "";
            ViewData["PC_HundredW2"] = list != null && list.Count > 0 ? list[0].PC_HundredW2.ToString() : "";
            ViewData["PC_PCode"] = list != null && list.Count > 0 ? list[0].PC_PCode.ToString() : "";
            ViewData["PC_HeapUPD"] = list != null && list.Count > 0 ? list[0].PC_HeapUPD.ToString() : "";
            ViewData["PC_MeltingP"] = list != null && list.Count > 0 ? list[0].PC_MeltingP.ToString() : "";
            ViewData["PC_FName"] = list != null && list.Count > 0 ? list[0].PC_FName.ToString() : "";
            ViewData["PC_CheckUser"] = list != null && list.Count > 0 ? list[0].PC_CheckUser.ToString() : "";
            ViewData["PC_Remark"] = list != null && list.Count > 0 ? list[0].PC_Remark.ToString() : "";
        
            return View();
        }
        #endregion 

        #region 新增验证
        /// <summary>
        /// 新增验证
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public ActionResult Checkpolyester_chip(polyester_chip model)
        {

            #region sqlserver时间格式
            //时间格式转换错误,https://blog.csdn.net/mini_joyce/article/details/58082853
            //SQL Server中DateTime与DateTime2的区别
            //DateTime字段类型对应的时间格式是 yyyy-MM-dd HH:mm:ss.fff ，3个f，精确到1毫秒(ms)，示例 2014-12-03 17:06:15.433 。
            //DateTime2字段类型对应的时间格式是 yyyy-MM-dd HH:mm:ss.fffffff ，7个f，精确到0.1微秒(μs)，示例 2014-12-03 17:23:19.2880929 。
            //如果用SQL的日期函数进行赋值，DateTime字段类型要用 GETDATE() ，DateTime2字段类型要用 SYSDATETIME() 。
            #endregion 


            LogUtil.WiteLog.WriteLogs("ID:" + model.ID,"testlog");
            string otype = model != null && model.ID == 0 ? "add" : "update";
            var result = 0;
            Expression<Func<polyester_chip, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (otype == "add")
            {
                model.CreateTime = model.UpdateTime = DateTime.Now;
                model.CreateUser = model.UpdateUser = 10000;
                result = Bll.Add(model);
            }
            else
            {
                  var  modelNew = db.polyester_chip.Where(a => a.ID == model.ID).FirstOrDefault();//根据ID查询数据,再次重新赋值,这样DateTime类型就不会出现错误??
                  modelNew.UpdateTime = DateTime.Now;
                  modelNew.PC_ChekTime = model.PC_ChekTime;
                  modelNew.PC_InGoodsNum = model.PC_InGoodsNum;
                  modelNew.PC_WetSectionH = model.PC_WetSectionH;
                  modelNew.PC_H1 = model.PC_H1;
                  modelNew.PC_H2 = model.PC_H2;
                  modelNew.PC_WaterCompent = model.PC_WaterCompent;
                  modelNew.PC_FCheckWater = model.PC_FCheckWater;
                  modelNew.PC_FCheckSS = model.PC_FCheckSS;
                  modelNew.PC_HundredW1 = model.PC_HundredW1;
                  modelNew.PC_HundredW2 = model.PC_HundredW2;
                  modelNew.PC_CheckUser = model.PC_CheckUser;
                  modelNew.PC_FName = model.PC_FName;
                  modelNew.PC_PCode = model.PC_PCode;
                  modelNew.PC_HeapUPD = model.PC_HeapUPD;
                  modelNew.PC_MeltingP = model.PC_MeltingP;
                  modelNew.PC_Remark = model.PC_Remark;
                  modelNew.PC_PassMsg = model.PC_PassMsg;
                  result = Bll.Update(modelNew);
            }
            if (result != 0)
            {
                string msg = CommonMsg.SuccessAlert(200, "操作成功 ! ", "polyester_chip", callbackType: "closeCurrent");
                return Content(msg);
            }
            else
            {
                return Content(CommonMsg.ErrorAlert(300, "操作失败"));
            }
        }
        #endregion 

        #region 导出excel
        /// <summary>
        /// 导出excel
        /// </summary>
        /// <returns></returns>
        public ActionResult Exportpolyester_chip()
        {

            return View();
        }
        #endregion 

        #region  详情
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public ActionResult polyester_chipDetail(int ? OID)
        {
            Expression<Func<polyester_chip, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (OID != 0)
            {
                wherelambad = wherelambad = u => u.ID == OID;
            }
            var data = Bll.GetEntitysByStrwhere(wherelambad);
            var list = data.ToList();
            return View(list);
        }
        #endregion 

        #region sql server DateTime与DateTime2的区别
        //sql server DateTime与DateTime2的区别
        //每天学一点整理一点

        //DateTime字段类型对应的时间格式是 yyyy-MM-dd HH:mm:ss.fff ，3个f，精确到1毫秒(ms)，示例 2014-12-03 17:06:15.433 。
        //DateTime2字段类型对应的时间格式是 yyyy-MM-dd HH:mm:ss.fffffff ，7个f，精确到0.1微秒(μs)，示例 2014-12-03 17:23:19.2880929 。
        //如果用SQL的日期函数进行赋值，DateTime字段类型要用 GETDATE() ，DateTime2字段类型要用 SYSDATETIME() 。
        //datetime2支持datetime.minvalue，即0001/01/01
        #endregion 
    }
}