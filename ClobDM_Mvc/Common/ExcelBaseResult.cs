using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
namespace ClobDM_Mvc.Common
{
    public abstract class ExcelBaseResult<T> : ActionResult
    {

        #region 属性
        /// <summary>
        /// 数据实体
        /// </summary>
        public IList<T> Entity { get; set; }
        /// <summary>
        /// 下载文件名称(不包含扩展名)
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 是否显示标题
        /// </summary>
        public bool ShowTitle { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// ContentType
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        public string ExtName { get; set; }
        /// <summary>
        /// 获取下载文件全名
        /// </summary>
        public string FullName { get { return FileName + ExtName; } }

        #endregion

        #region 构造函数
        public ExcelBaseResult(IList<T> entity, string fileName, bool showTitle, string title)
        {
            this.Entity = entity;
            this.FileName = fileName;
            this.ShowTitle = showTitle;
            this.Title = title;
        }
        #endregion

        #region 抽象方法
        public abstract MemoryStream GetExcelStream();
        #endregion

        #region 重写ExecuteResult
        /// <summary>
        /// 重写ExecuteResult
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            using (MemoryStream ms = GetExcelStream())
            {
                context.HttpContext.Response.AddHeader("Content-Length", ms.Length.ToString());
                context.HttpContext.Response.ContentType = ContentType;
               // context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + FullName.EncodingDownloadFileName());

                context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + FullName);
                ms.Seek(0, SeekOrigin.Begin);
                Stream output = context.HttpContext.Response.OutputStream;
                byte[] bytes = new byte[1024 * 10];
                int readSize = 0;
                while ((readSize = ms.Read(bytes, 0, bytes.Length)) > 0)
                {
                    output.Write(bytes, 0, readSize);
                    context.HttpContext.Response.Flush();
                }


            }


        }
        #endregion
    }
}