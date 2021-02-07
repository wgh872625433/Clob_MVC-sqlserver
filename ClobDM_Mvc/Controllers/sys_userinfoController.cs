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
    /// 小五-菜鸟测试
    /// </summary>
    public class sys_userinfoController : Controller
    {
        //
        // GET: /sys_userinfo/
        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        sys_userinfoBLL Bll = new sys_userinfoBLL();

        //Lambda表达式使用,https://www.cnblogs.com/ithuo/p/4746289.html


        #region 用户列表
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="numPerPage"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(int? pageNum, int? numPerPage,sys_userinfo model)
        {
            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<sys_userinfo, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (!string.IsNullOrWhiteSpace(model.S_username))
            {
                wherelambad = wherelambad = u => u.S_username.Contains(model.S_username);//模糊查找
            }
            if (!string.IsNullOrWhiteSpace(model.S_realName))
            {
                wherelambad = wherelambad.And( u => u.S_realName==model.S_realName);
            }
            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["S_username"] = model.S_username;
            ViewData["S_realName"] = model.S_realName;
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
        public ActionResult CheckUserInfo(sys_userinfo userinfo)
        {
            string otype = userinfo != null && userinfo.ID == 0 ? "add" : "update";
            var result = 0;
            Expression<Func<sys_userinfo, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (otype == "add")
            {
                if (!string.IsNullOrWhiteSpace(userinfo.S_username))
                {
                    wherelambad = wherelambad = u => u.S_username.Equals(userinfo.S_username);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(userinfo.S_username) && userinfo.ID != 0)
                {
                    wherelambad = wherelambad = u => u.S_username.Equals(userinfo.S_username) && u.ID != userinfo.ID;
                }
            }
            var data = Bll.GetEntitysByStrwhere(wherelambad).ToList().Count();
            if (data != 0)
            {
                return Content(CommonMsg.ErrorAlert(300, "用户名[" + userinfo.S_username + "]已经存在"));
            }
            if (otype == "add")
            {
                userinfo.S_checkUID = 1;
                userinfo.S_roleId = 2;
                userinfo.CreateTime = userinfo.UpdateTime = DateTime.Now;
                userinfo.CreateUser = userinfo.UpdateUser = 10000;
                result = Bll.Addsys_userinfo(userinfo);
            }
            else
            {
                userinfo.UpdateTime = DateTime.Now;
                result = Bll.UpdateSys_userinfo(userinfo);
            }
            if (result != 0)
            {
                string msg = CommonMsg.SuccessAlert(200, "操作成功 ! ", "sys_userinfo", callbackType: "closeCurrent");
                return Content(msg);
            }
            else
            {
                return Content(CommonMsg.ErrorAlert(300, "操作失败"));
            }
        }
        #endregion 


        #region 新增和编辑用户赋值
        /// <summary>
        /// 新增和编辑用户赋值
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public ActionResult AddUserInfo(int? OID)
        {
            var data = Bll.GetEntitysByStrwhere(u => u.ID == OID);
            var list = data.ToList();
            ViewData["OID"] = OID.HasValue ? OID : 0;
            ViewData["S_username"] = list != null && list.Count > 0 ? list[0].S_username : "";
            ViewData["CreateTime"] = list != null && list.Count > 0 ? list[0].CreateTime.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ViewData["S_realName"] = list != null && list.Count > 0 ? list[0].S_realName : "";
            ViewData["S_password"] = list != null && list.Count > 0 ? list[0].S_password : "";
            ViewData["S_checkUID"] = list != null && list.Count > 0 ? list[0].S_checkUID.ToString() : "";
            ViewData["S_roleId"] = list != null && list.Count > 0 ? list[0].S_roleId.ToString() : "";
            return View();
           
        }
        #endregion 



        #region 用户详情
        /// <summary>
        /// 用户详情
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public ActionResult UserInfoDetail(int ? OID)
        {
            //ef使用sql查询语句;
            //var queryData = db.Database.SqlQuery<sys_userinfo>("SELECT * FROM sys_userinfo where id in(" + OID + ")").ToList();
            Expression<Func<sys_userinfo, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (OID!=0)
            {
                wherelambad = wherelambad = u => u.ID==OID;//模糊查找
            }
            var data = Bll.GetEntitysByStrwhere(wherelambad);
            var list = data.ToList();
            return View(list);
        }
        #endregion 


        #region 删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public ActionResult DeleteUserInfo(int? OID,string otype)
        {
            var id = OID.HasValue ? OID : 0;
            var result = 0;
            var data = Bll.GetEntitysByStrwhere(u => u.ID == OID).FirstOrDefault();
            if (data != null)
            {

                data.S_state = (otype == "delete" ? 1 : 0);
                data.ID = Convert.ToInt32(id);
                data.UpdateTime = DateTime.Now;
                result = Bll.UpdateSys_userinfo(data);
            }
            if (result != 0)
            {
                return Content(CommonMsg.SuccessAlert(200, "操作成功", "sys_userinfo"));
            }
            else
            {
                return Content(CommonMsg.ErrorAlert(300, "操作失败"));
            }
        }
        #endregion 



        #region 批量删除
        /// <summary>
        /// 批量删除/2021/2/1
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult DeleteUserInfoByIds(string ids)
        {

            //注意：执行DDL语句(create、alter、drop等)返回值是-1，DML(insert、update、delete)返回的是受影响的行数
            int result = db.Database.ExecuteSqlCommand(@"update sys_userinfo set S_state=1,updatetime='"+DateTime.Now+"' where S_state=0 and   id in(" + ids.Trim().Trim(',') + ")");
            if (result != 0)
            {
                return Content(CommonMsg.SuccessAlert(200, "操作成功", "sys_userinfo"));
            }
            else
            {
                return Content(CommonMsg.ErrorAlert(300, "操作失败"));
            }

        }
        #endregion 



        #region 批量启用
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult RecoverUserInfoByIds(string ids)
        {

            #region ef使用sql更新示例
            // 执行Update语句
            //            string strUpdateSQL = @"UPDATE test SET password=@pwd1 WHERE id=@id1;
            //UPDATE test SET password=@pwd2 WHERE id=@id2;";
            //            SqlParameter[] para =  {
            //                   new  SqlParameter("@pwd1","ceshi12we"),
            //                   new  SqlParameter("@id1",1),
            //                   new  SqlParameter("@pwd2","ceshi127890"),
            //                   new  SqlParameter("@id2",2),
            //                };

            //            int result = entity.Database.ExecuteSqlCommand(strUpdateSQL, para);
            //            if (result > 0)
            //            {
            //                Console.WriteLine("更新成功");
            //            }
            #endregion 


            int result = db.Database.ExecuteSqlCommand(@"update sys_userinfo set S_state=0 where S_state=1 and   id in(" + ids.Trim().Trim(',') + ")");
            if (result != 0)
            {
                return Content(CommonMsg.SuccessAlert(200, "操作成功", "sys_userinfo"));
            }
            else
            {
                return Content(CommonMsg.ErrorAlert(300, "操作失败"));
            }
        }
        #endregion 



        #region 导出数据
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="OID"></param>
        public ActionResult ExportUserinfo(sys_userinfo model)
        {
            string ReturnMsg = "";
            Expression<Func<sys_userinfo, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (!string.IsNullOrWhiteSpace(model.S_username))
            {
                wherelambad = wherelambad = u => u.S_username.Contains(model.S_username);
            }
            if (!string.IsNullOrWhiteSpace(model.S_realName))
            {
                wherelambad = wherelambad.And(u => u.S_realName == model.S_realName);// 多个条件使用and连接
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
                    string FailMsg="";
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
        public bool ExportOrderAllToExcel(List<sys_userinfo> listUserinfo, ref string ReturnMsg)
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
                cellR1.SetCellValue("用户名");
                var cellS1 = row0.GetCell(1);
                cellS1.CellStyle = cellstyle;

                //姓名
                row0.Height = 20 * 20;
                ICell cellR2 = row0.CreateCell(2);
                cellR2.SetCellValue("姓名");
                var cellS2 = row0.GetCell(2);
                cellS2.CellStyle = cellstyle;


                //状态
                row0.Height = 20 * 20;
                ICell cellR3 = row0.CreateCell(3);
                cellR3.SetCellValue("状态");
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
                if (listUserinfo != null && listUserinfo.Count > 0)
                {
                    for (int j = 0; j < listUserinfo.Count;j++ )
                    {
                        rowTest = sh.CreateRow(m);//创建新行

                        var model = listUserinfo[j];
                        #region 基础信息
                        ICell cell0 = rowTest.CreateCell(0);
                        cell0.SetCellValue(model.ID);
                        ICell cell1 = rowTest.CreateCell(1);
                        cell1.SetCellValue(model.S_username);
                        ICell cell2 = rowTest.CreateCell(2);
                        cell2.SetCellValue(model.S_realName);
                        ICell cell3 = rowTest.CreateCell(3);
                        cell3.SetCellValue(model.S_state);
                        ICell cell4 = rowTest.CreateCell(4);
                        cell4.SetCellValue(Convert.ToDateTime(model.CreateTime).ToString("yyyy-MM-dd"));
                        #endregion
                        m++;
                    }

                    //保存
                    string path = "/FileRoot/temp/";
                    string fileName = "用户数据报表" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xls";
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