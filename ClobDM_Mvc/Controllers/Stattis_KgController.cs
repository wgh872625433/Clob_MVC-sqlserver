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
    public class Stattis_KgController : Controller
    {
        //
        // GET: /Stattis_Kg/
        ClobDM_Model.ClobDBContext db = new ClobDM_Model.ClobDBContext();
        Stattis_KgBLL Bll = new Stattis_KgBLL();

        #region 列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="numPerPage"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(int? pageNum, int? numPerPage, Stattis_Kg model)
        {
            int pageIndex = pageNum.HasValue ? pageNum.Value : 1;
            int pageSize = numPerPage.HasValue && numPerPage.Value > 0 ? numPerPage.Value : 20;
            int recordCount = 0;
            //(q) => q.id,排序的字段
            Expression<Func<Stattis_Kg, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (!string.IsNullOrWhiteSpace(model.sk_name))
            {
                wherelambad = wherelambad = u => u.sk_name == model.sk_name;//模糊查找
            }
            //true,升序,false降序
            var data = Bll.GetPageEntities<DateTime>(pageIndex, pageSize, out recordCount, wherelambad, (q) => q.CreateTime, false);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["recordCount"] = recordCount;
            ViewData["CreateTime"] = model.CreateTime != null && model.CreateTime.ToString() != "0001-01-01 00:00:00" ? model.CreateTime.ToString() : "";
            ViewData["sk_name"] = model.sk_name;
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
        public ActionResult CheckAdd(Stattis_Kg model)
        {
            string otype = model != null && model.ID == 0 ? "add" : "update";
            var result = 0;
            Expression<Func<Stattis_Kg, bool>> wherelambad = u => 1 == 1;//查询条件;    
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
                string msg = CommonMsg.SuccessAlert(200, "操作成功 ! ", "Stattis_Kg", callbackType: "closeCurrent");
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
            Expression<Func<Stattis_Kg, bool>> wherelambad = u => 1 == 1;//查询条件;    
            if (OID != 0)
            {
                wherelambad = wherelambad = u => u.ID == OID;
            }
            var data = Bll.GetEntitysByStrwhere(wherelambad);
            var list = data.ToList();
            return View(list);
        }
        #endregion 



        
        #region 计算克重厚度
        /// <summary>
        /// 计算克重厚度
        /// </summary>
        /// <param name="context"></param>
        /// <param name="otype"></param>
        public void cattKgHd(Stattis_Kg model)
        {
          


            #region 克重和厚度数据

            var sk_kg1 = model.sk_kg1;
            var sk_kg2 = model.sk_kg2;
            var sk_kg3 = model.sk_kg3;
            var sk_kg4 = model.sk_kg4;
            var sk_kg5 = model.sk_kg5;

            var sk_hd1 = model.sk_hd1;
            var sk_hd2 = model.sk_hd2;
            var sk_hd3 = model.sk_hd3;
            var sk_hd4 = model.sk_hd4;
            var sk_hd5 = model.sk_hd5;
            var sk_hd6 = model.sk_hd6;
            var sk_hd7 = model.sk_hd7;
            var sk_hd8 = model.sk_hd8;
            var sk_hd9 = model.sk_hd9;
            var sk_hd10 = model.sk_hd10;

            #endregion 



            double[] kgALlArray = {Convert.ToDouble(sk_kg1), 
                                      Convert.ToDouble(sk_kg2), 
                                      Convert.ToDouble(sk_kg3),
                                      Convert.ToDouble(sk_kg4),
                               Convert.ToDouble(sk_kg5)};
            double kgvag = 0;
            double result1 = StDevDouble(kgALlArray, ref kgvag);

            double result3 = (result1 / kgvag) * 100;


            var kgcv = result3.ToString("0.00");


            double[] HdArray = {Convert.ToDouble(sk_hd1), 
                                      Convert.ToDouble(sk_hd2), 
                                      Convert.ToDouble(sk_hd3),
                                      Convert.ToDouble(sk_hd4),
                                    Convert.ToDouble(sk_hd5),
                                 Convert.ToDouble(sk_hd6),
                                 Convert.ToDouble(sk_hd7),
                                 Convert.ToDouble(sk_hd8),
                                 Convert.ToDouble(sk_hd9),
                                 Convert.ToDouble(sk_hd10)};
            double Hdmin = CatHdMin(HdArray);
            double Hdmax = CatHdMax(HdArray);
            double hdavg = 0;

            double HDcv1 = StDevDouble(HdArray, ref hdavg);
            LogUtil.WiteLog.WriteLogs("hdavg：" + hdavg,"weblog");
            double HDcv2 = (HDcv1 / hdavg) * 100;
            LogUtil.WiteLog.WriteLogs("HDcv2：" + HDcv2,"weblog");
            Response.Write(Math.Round(Convert.ToDecimal(kgcv), 2) + "|" + Math.Round(Convert.ToDecimal(kgvag), 1) + "|" + Math.Round(Convert.ToDecimal(Hdmin), 2) + "|" + Math.Round(Convert.ToDecimal(Hdmax), 2) + "|" + Math.Round(Convert.ToDecimal(HDcv2), 2) + "|" + Math.Round(Convert.ToDecimal(hdavg), 2));
        }

        #endregion



        #region 计算克重厚度2
        /// <summary>
        /// 计算克重厚度2
        /// </summary>
        /// <param name="context"></param>
        /// <param name="otype"></param>
        public ActionResult cattKgHd2(Stattis_Kg model)
        {



            #region 克重和厚度数据

            var sk_kg1 = model.sk_kg1;
            LogUtil.WiteLog.WriteLogs("weblog", "cattKgHd2-sk_kg1:" + sk_kg1);
            var sk_kg2 = model.sk_kg2;
            var sk_kg3 = model.sk_kg3;
            var sk_kg4 = model.sk_kg4;
            var sk_kg5 = model.sk_kg5;

            var sk_hd1 = model.sk_hd1;
            var sk_hd2 = model.sk_hd2;
            var sk_hd3 = model.sk_hd3;
            var sk_hd4 = model.sk_hd4;
            var sk_hd5 = model.sk_hd5;
            var sk_hd6 = model.sk_hd6;
            var sk_hd7 = model.sk_hd7;
            var sk_hd8 = model.sk_hd8;
            var sk_hd9 = model.sk_hd9;
            var sk_hd10 = model.sk_hd10;

            #endregion



            double[] kgALlArray = {Convert.ToDouble(sk_kg1), 
                                      Convert.ToDouble(sk_kg2), 
                                      Convert.ToDouble(sk_kg3),
                                      Convert.ToDouble(sk_kg4),
                               Convert.ToDouble(sk_kg5)};
            double kgvag = 0;
            double result1 = StDevDouble(kgALlArray, ref kgvag);
            LogUtil.WiteLog.WriteLogs("weblog", "kgvag值：" + kgvag);

            double result3 = (result1 / kgvag) * 100;

            LogUtil.WiteLog.WriteLogs("weblog", "kgcv值：" + result3);

            var kgcv = result3.ToString("0.00");

            LogUtil.WiteLog.WriteLogs("weblog", "kgcv2：" + kgcv);

            double[] HdArray = {Convert.ToDouble(sk_hd1), 
                                      Convert.ToDouble(sk_hd2), 
                                      Convert.ToDouble(sk_hd3),
                                      Convert.ToDouble(sk_hd4),
                                    Convert.ToDouble(sk_hd5),
                                 Convert.ToDouble(sk_hd6),
                                 Convert.ToDouble(sk_hd7),
                                 Convert.ToDouble(sk_hd8),
                                 Convert.ToDouble(sk_hd9),
                                 Convert.ToDouble(sk_hd10)};
            double Hdmin = CatHdMin(HdArray);
            LogUtil.WiteLog.WriteLogs("weblog", "Hdmin：" + Hdmin);
            double Hdmax = CatHdMax(HdArray);
            LogUtil.WiteLog.WriteLogs("weblog", "Hdmax：" + Hdmax);
            double hdavg = 0;

            double HDcv1 = StDevDouble(HdArray, ref hdavg);
            LogUtil.WiteLog.WriteLogs("weblog", "hdavg：" + hdavg);
            double HDcv2 = (HDcv1 / hdavg) * 100;
            LogUtil.WiteLog.WriteLogs("weblog", "HDcv2：" + HDcv2);
            return Content(Math.Round(Convert.ToDecimal(kgcv), 2) + "|" + Math.Round(Convert.ToDecimal(kgvag), 1) + "|" + Math.Round(Convert.ToDecimal(Hdmin), 2) + "|" + Math.Round(Convert.ToDecimal(Hdmax), 2) + "|" + Math.Round(Convert.ToDecimal(HDcv2), 2) + "|" + Math.Round(Convert.ToDecimal(hdavg), 2));
        }

        #endregion




        #region C#实现Excel函数STDEV
        /// <summary>
        /// C#实现Excel函数STDEV
        /// </summary>
        /// <param name="arrData"></param>
        /// <returns></returns>
        public static float StDevFloat(float[] arrData) //计算标准偏差
        {
            float xSum = 0F;
            float xAvg = 0F;
            float sSum = 0F;
            float tmpStDev = 0F;
            int arrNum = arrData.Length;
            for (int i = 0; i < arrNum; i++)
            {
                xSum += arrData[i];
            }
            xAvg = xSum / arrNum;//平均值
            for (int j = 0; j < arrNum; j++)
            {
                sSum += ((arrData[j] - xAvg) * (arrData[j] - xAvg));
            }
            tmpStDev = Convert.ToSingle(Math.Sqrt((sSum / (arrNum - 1))).ToString());
            return tmpStDev;
        }

        #endregion


        #region C#实现Excel函数STDEV
        /// <summary>
        /// C#实现Excel函数STDEV
        /// </summary>
        /// <param name="arrData"></param>
        /// <returns></returns>
        public static double StDevDouble(double[] arrData, ref double kgavg) //计算标准偏差
        {
            double xSum = 0F;
            double xAvg = 0F;
            double sSum = 0F;
            double tmpStDev = 0F;
            int arrNum = arrData.Length;
            for (int i = 0; i < arrNum; i++)
            {
                xSum += arrData[i];
            }
            xAvg = xSum / arrNum;//平均值
            kgavg = xAvg;
            for (int j = 0; j < arrNum; j++)
            {
                sSum += ((arrData[j] - xAvg) * (arrData[j] - xAvg));
            }
            tmpStDev = Convert.ToSingle(Math.Sqrt((sSum / (arrNum - 1))).ToString());
            return tmpStDev;
        }

        #endregion


        #region C#实现厚度均值
        /// <summary>
        /// C#实现厚度均值
        /// </summary>
        /// <param name="arrData"></param>
        /// <returns></returns>
        public static double CatHdvag(double[] arrData) 
        {
            double xSum = 0F;
            double xAvg = 0F;
            int arrNum = arrData.Length;
            for (int i = 0; i < arrNum; i++)
            {
                xSum += arrData[i];
            }
            xAvg = xSum / arrNum;//平均值

            return xAvg;
        }

        #endregion



        #region C#实现厚度最小值
        /// <summary>
        ///  C#实现厚度最小值
        /// </summary>
        /// <param name="arrData"></param>
        /// <returns></returns>
        public static double CatHdMin(double[] arrData) //计算标准偏差
        {

            double min = arrData[0];
            for (int i = 0; i < arrData.Length; i++)
            {
                if (min > arrData[i])
                {
                    min = arrData[i];
                }
            }

            return min;
        }

        #endregion


        #region C#实现厚度最大值
        /// <summary>
        /// C#实现厚度最大值
        /// </summary>
        /// <param name="arrData"></param>
        /// <returns></returns>
        public static double CatHdMax(double[] arrData)
        {


            double max = arrData[0];
            for (int i = 0; i < arrData.Length; i++)//这里遍历数组
            {
                if (max < arrData[i])//判断每个数大小
                {
                    max = arrData[i];//最后这里等于最大值
                }
            }

            return max;

        }

        #endregion


	}
}