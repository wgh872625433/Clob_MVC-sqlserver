using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common
{
    public class CommonMsg
    {
        #region 提示信息
        /// <summary>
        ///  提示信息
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="navTabId"></param>
        /// <param name="rel"></param>
        /// <param name="callbackType"></param>
        /// <param name="forwardUrl"></param>
        /// <param name="strOther"></param>
        /// <returns></returns>
        public static string SuccessAlert(int statusCode, string message, string navTabId = "", string rel = "", string callbackType = "", string forwardUrl = "", string strOther = "")
        {
            return string.Format("{7}\"statusCode\":\"{0}\", \"message\":\"{1}\",\"navTabId\":\"{2}\",\"rel\":\"{3}\",\"callbackType\":\"{4}\",\"forwardUrl\":\"{5}\"{6}{8}", statusCode, message, navTabId, rel, callbackType, forwardUrl, strOther, "{", "}");
        }
        public static string ErrorAlert(int statusCode, string message)
        {
            return string.Format("{2}\"statusCode\":\"{0}\", \"message\":\"{1}\"{3}", statusCode, message, "{", "}");
        }
        #endregion 
    }
}