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
    /// 热缩膜检测--小五测试132465
    /// </summary>
    public class Heat_shrinkfController : Controller
    {
        //
        // GET: /Heat_shrinkf/
        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        Heat_shrinkfBLL Bll = new Heat_shrinkfBLL();


        #region 列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="numPerPage"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(int? pageNum, int? numPerPage, Heat_shrinkf model)
        {
            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<Heat_shrinkf, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (model.HS_InTime != null && model.HS_InTime.ToString() != "0001-01-01 00:00:00")
            {
                wherelambad = wherelambad = u => u.HS_InTime==model.HS_InTime;//模糊查找
            }
            if (!string.IsNullOrWhiteSpace(model.HS_Pstandard))
            {
                wherelambad = wherelambad.And(u => u.HS_Pstandard == model.HS_Pstandard);
            }
            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["HS_InTime"] = model.HS_InTime != null && model.HS_InTime.ToString() != "0001-01-01 00:00:00" ? model.HS_InTime.ToString() : "";
            ViewData["HS_Pstandard"] = model.HS_Pstandard;
            var list = data.ToList();
            return View(list);
        }
        #endregion 


        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public ActionResult add(int ?OID)
        {
            var data = Bll.GetEntitysByStrwhere(u => u.ID == OID);
            var list = data.ToList();
            ViewData["OID"] = OID.HasValue ? OID : 0;
            ViewData["HS_InTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].HS_InTime).ToString("yyyy-MM-dd") : "";
            ViewData["CreateTime"] = list != null && list.Count > 0 ? list[0].CreateTime.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ViewData["HS_InGoodsNum"] = list != null && list.Count > 0 ? list[0].HS_InGoodsNum.ToString() : "";
            ViewData["HS_Pstandard"] = list != null && list.Count > 0 ? list[0].HS_Pstandard.ToString() : "";
            ViewData["HS_gm"] = list != null && list.Count > 0 ? list[0].HS_gm.ToString() : "";
            ViewData["HS_mm"] = list != null && list.Count > 0 ? list[0].HS_mm.ToString() : "";
            ViewData["HS_ww"] = list != null && list.Count > 0 ? list[0].HS_ww.ToString() : "";


            ViewData["HS_drawSMD"] = list != null && list.Count > 0 ? list[0].HS_drawSMD.ToString() : "";
            ViewData["HS_drawSMC"] = list != null && list.Count > 0 ? list[0].HS_drawSMC.ToString() : "";
            ViewData["HS_disruptED"] = list != null && list.Count > 0 ? list[0].HS_disruptED.ToString() : "";
            ViewData["HS_disruptEC"] = list != null && list.Count > 0 ? list[0].HS_disruptEC.ToString() : "";
            ViewData["HS_Fmm"] = list != null && list.Count > 0 ? list[0].HS_Fmm.ToString() : "";
            ViewData["HS_Fww"] = list != null && list.Count > 0 ? list[0].HS_Fww.ToString() : "";
            ViewData["HS_FdrawSMD"] = list != null && list.Count > 0 ? list[0].HS_FdrawSMD.ToString() : "";
            ViewData["HS_FdrawSMC"] = list != null && list.Count > 0 ? list[0].HS_FdrawSMC.ToString() : "";


            ViewData["HS_FdisruptED"] = list != null && list.Count > 0 ? list[0].HS_FdisruptED.ToString() : "";
            ViewData["HS_FdisruptEC"] = list != null && list.Count > 0 ? list[0].HS_FdisruptEC.ToString() : "";
            ViewData["HS_FColor"] = list != null && list.Count > 0 ? list[0].HS_FColor.ToString() : "";
            ViewData["HS_FAddTime"] = list != null && list.Count > 0 ? Convert.ToDateTime(list[0].HS_FAddTime).ToString("yyyy-MM-dd") : "";
            ViewData["HS_FName"] = list != null && list.Count > 0 ? list[0].HS_FName.ToString() : "";
            ViewData["HS_FIsPass"] = list != null && list.Count > 0 ? list[0].HS_FIsPass.ToString() : "";
            ViewData["HS_FRemark"] = list != null && list.Count > 0 ? list[0].HS_FRemark.ToString() : "";
            return View();
        }
        #endregion 


        #region 新增和编辑数据验证
        /// <summary>
        /// 新增和编辑数据验证
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckAdd(Heat_shrinkf model)
        {

            string otype = model != null && model.ID == 0 ? "add" : "update";
            var result = 0;
            Expression<Func<Heat_shrinkf, bool>> wherelambad = u => 1 == 1;//查询条件;    
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
                string msg = CommonMsg.SuccessAlert(200, "操作成功 ! ", "Heat_shrinkf", callbackType: "closeCurrent");
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

            Expression<Func<Heat_shrinkf, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (OID != 0)
            {
                wherelambad = wherelambad = u => u.ID == OID;
            }
            var data = Bll.GetEntitysByStrwhere(wherelambad);
            var list = data.ToList();
            return View(list);
        }
        #endregion 


        #region 导出数据
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="OID"></param>
        public ActionResult ExportUserinfo(Heat_shrinkf model)
        {
            string ReturnMsg = "";
            Expression<Func<Heat_shrinkf, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (model.HS_InTime!=null)
            {
                wherelambad = wherelambad = u => u.HS_InTime==model.HS_InTime;
            }
            if (!string.IsNullOrWhiteSpace(model.HS_Pstandard))
            {
                wherelambad = wherelambad.And(u => u.HS_Pstandard == model.HS_Pstandard);// 多个条件使用and连接
            }
            var Userdata = Bll.GetEntitysByStrwhere(wherelambad).ToList();
            string[] FileData = null;
            if (Userdata != null)
            {
                if (ExportOrderAllToExcel(Userdata, ref ReturnMsg))
                {

                    FileData = ReturnMsg.Split(',');
                    if (FileData != null && FileData.Length > 0)
                    {
                        string FilePath = FileData[1] != null ? FileData[1].ToString() : "";
                        if (System.IO.File.Exists(Server.MapPath(FilePath)))
                        {
                            return File(Server.MapPath(FilePath), "application/octet-stream", DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + "xls");
                        }
                        else
                        {
                            return Content("该文件已丢失");
                        }
                    }
                }
                else
                {
                    FileData = ReturnMsg.Split(',');
                    string FailMsg = "";
                    if (FileData != null && FileData.Length > 0)
                    {
                        FailMsg = FileData[1].ToString();
                    }
                    return Content(FailMsg);

                }
            }
            return Content("下载异常");
        }
        #endregion


        #region 导出查询数据
        /// <summary>
        /// 导出查询数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="ReturnMsg"></param>
        /// <returns></returns>
        public bool ExportOrderAllToExcel(List<Heat_shrinkf> listHeat_shrinkf, ref string ReturnMsg)
        {
            try
            {

                IWorkbook wb = new HSSFWorkbook();
                //创建表  
                ISheet sh = wb.CreateSheet("sheet1");

                #region 创建表头

                ICellStyle cellstyle = wb.CreateCellStyle();
                cellstyle.VerticalAlignment = VerticalAlignment.CENTER;
                cellstyle.Alignment = HorizontalAlignment.CENTER;
                IRow row0 = sh.CreateRow(0);
                IRow row1 = sh.CreateRow(1);
                ICell cellR0 = row0.CreateCell(0);
                cellR0.SetCellValue("ID");
                var cellS0 = row0.GetCell(0);
                cellS0.CellStyle = cellstyle;


                row0.Height = 20 * 20;
                ICell cellR1 = row0.CreateCell(1);
                cellR1.SetCellValue("来货日期");
                var cellS1 = row0.GetCell(1);
                cellS1.CellStyle = cellstyle;

                //姓名
                row0.Height = 20 * 20;
                ICell cellR2 = row0.CreateCell(2);
                cellR2.SetCellValue("进货数量");
                var cellS2 = row0.GetCell(2);
                cellS2.CellStyle = cellstyle;


                //状态
                row0.Height = 20 * 20;
                ICell cellR3 = row0.CreateCell(3);
                cellR3.SetCellValue("产品规格");
                var cellS3 = row0.GetCell(3);
                cellS3.CellStyle = cellstyle;

                //创建时间
                sh.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 4, 4));
                row0.Height = 20 * 20;
                ICell cellR4 = row0.CreateCell(4);
                cellR4.SetCellValue("创建时间");
                var cellS4 = row0.GetCell(4);
                cellS4.CellStyle = cellstyle;
                #endregion


                #region 数据写入
                int m = 1;
                IRow rowTest = null;
                if (listHeat_shrinkf != null && listHeat_shrinkf.Count > 0)
                {
                    for (int j = 0; j < listHeat_shrinkf.Count; j++)
                    {
                        rowTest = sh.CreateRow(m);//创建新行

                        var model = listHeat_shrinkf[j];
                        #region 基础信息
                        ICell cell0 = rowTest.CreateCell(0);
                        cell0.SetCellValue(model.ID);
                        ICell cell1 = rowTest.CreateCell(1);
                        cell1.SetCellValue(model.HS_InTime);
                        ICell cell2 = rowTest.CreateCell(2);
                        cell2.SetCellValue(model.HS_InGoodsNum);
                        ICell cell3 = rowTest.CreateCell(3);
                        cell3.SetCellValue(model.HS_Pstandard);
                        ICell cell4 = rowTest.CreateCell(4);
                        cell4.SetCellValue(Convert.ToDateTime(model.CreateTime).ToString("yyyy-MM-dd"));
                        #endregion
                        m++;
                    }

                    //保存
                    string path = "/FileRoot/temp/";
                    string fileName = "热缩膜" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xls";
                    path += fileName;
                    System.IO.FileStream file = new System.IO.FileStream(Server.MapPath(path), System.IO.FileMode.Create);
                    wb.Write(file);
                    //关闭文件，释放对象 
                    file.Close();
                    wb = null;
                    ReturnMsg = "1," + path;//返回文件路径
                    return true;
                }
                else
                {
                    ReturnMsg = "2,没有查到要导出的数据!";
                    return false;
                }

                #endregion
            }
            catch (Exception ex)
            {
                string logMsg = "\r\n报错信息:" + ex.Message.ToString();
                logMsg += "\r\n报错详情:" + ex.StackTrace.ToString();
                // T9.Util.LogUtil.WriteLog(logMsg, "WebLog");
                ReturnMsg = "2,导出数据失败!";
                return false;
            }
        }
        #endregion
    }
}