using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace LogUtil
{
    public class WiteLog
    {
        /// <summary>
        /// 日志保存
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="type">保存类型</param>
        /// <param name="content">写入内容</param>
        public static void WriteLogs( string content,string Logname)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (!string.IsNullOrEmpty(path))
            {
                path = AppDomain.CurrentDomain.BaseDirectory +"log";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\" + Logname;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (!File.Exists(path))
                {
                    FileStream fs = File.Create(path);
                    fs.Close();
                }
                if (File.Exists(path))
                {
                    StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") +  "\r\n" + content);
                    sw.WriteLine("----------------------------------------");
                    sw.Close();
                }
            }
        }
    }
}