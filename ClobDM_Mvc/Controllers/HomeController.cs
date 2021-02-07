using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClobDM_Model;
using System.Linq.Expressions;
namespace ClobDM_Mvc.Controllers
{
    public class HomeController : Controller
    {
        ClobDBContext db = new ClobDBContext();
        //权限的设计2,https://www.cnblogs.com/xiaoqi/archive/2011/01/24/1942880.html#
        //权限的设计1,https://www.cnblogs.com/insus/p/6211362.html
        //权限的设计3,https://blog.csdn.net/weixin_30549175/article/details/99080946
        //权限设计4,https://www.cnblogs.com/zhangxiaoyong/p/6906288.html
        //https://blog.csdn.net/weixin_30455023/article/details/99505390
        //lambda表达式Expression<Func<Person, bool>> 、Func<Person, bool>区别
        //结论
        //Func<TObject, bool>是委托(delegate)
        //Expression<Func<TObject, bool>>是表达式
        //Expression编译后就会变成delegate，才能运行。比如
        //Expression<Func<int, bool>> ex = x=>x < 100;
        //Func<int, bool> func = ex.Compile(); 
        //然后你就可以调用func：
        //func(5) //-返回 true
        //func(200) //- 返回 false
        //而表达式是不能直接调用的。
        //关于如何将多个expression合并为一个可以写多个where：
        //.where(expression1).where(expression2)...
        //运行时EF会自动合并优化的
        //https://www.cnblogs.com/dudu/archive/2012/04/01/enitity_framework_func.html
        //Entity Framework - Func引起的数据库全表查询
        //使用 Entity Framework 最要小心的性能杀手就是 —— 不正确的查询代码造成的数据库全表查询。
        //http://www.albahari.com/nutshell/predicatebuilder.aspx


        //C# 在EF模型中直接执行SQL语句,https://blog.csdn.net/qq_37779412/article/details/106906068
        //BootStrap-table 在asp.net中的应用,https://blog.csdn.net/qq237183141/article/details/78337512

        //ASP.NET MVC中使用 Bootstrap table插件,https://www.cnblogs.com/fuqiang88/p/4734081.html
        //EntityFrameworkCore教程：控制台程序生成数据库表,https://www.cnblogs.com/dotnet261010/p/12354844.html
        public ActionResult Index()
        {

            //C# MVC 页面上按钮的权限怎么控制
            //基本的思路是 封装一个 自己的htmlhelper方法 在执行htmlhelper前 加一次权限验证
            var DataList = db.sys_userinfo.Where(u => u.ID == 1).FirstOrDefault() ;
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    

    }
}