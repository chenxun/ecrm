using System;
using System.Web;
using System.Web.UI;
using System.Data;
using Powerson.Framework;
using Powerson.BusinessFacade;
using Powerson.DataAccess;

namespace Powerson.Web
{
	/// <summary>
	/// 
	/// </summary>
	public class AuthPageBase : PageBase
	{
		protected override void OnInit(EventArgs e)
		{

			// 首先判断是不是已经登录 [6/15/2008]
            //if(!LoginSession.IsLogin(this.Page) )
            //{
            //    Response.Redirect("Timeout.aspx");
            //}
            base.OnInit(e);
            // 下面的代码为了调试 [5/24/2009]
//             UserDO u = userService.getUserByName("xunchen");
//             LoginSession.SetIsLogin(this, true);
//             LoginSession.SetCurrentUser(this, u);
		}
	}
}
