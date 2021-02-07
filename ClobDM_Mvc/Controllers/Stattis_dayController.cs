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
    public class Stattis_dayController : Controller
    {
        //
        // GET: /Stattis_day/
        public ActionResult Index()
        {
            return View();
        }
	}
}