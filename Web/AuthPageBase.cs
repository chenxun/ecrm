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
            base.OnInit(e);
			// 首先判断是不是已经登录 [6/15/2008]
            if (CurrentUserId == 0)
                Response.Redirect("Timeout.aspx");
            GetCurrentUser();
            if (null == me)
                Response.Redirect("Timeout.aspx");
		}
	}
}
