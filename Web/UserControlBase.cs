using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Powerson.Framework;
using Powerson.BusinessFacade;
using Powerson.DataAccess;
using Powerson.Web.RailsService;

namespace Powerson.Web
{
	/// <summary>
	/// UserControlBase 的摘要说明。
	/// </summary>
	public class UserControlBase : System.Web.UI.UserControl
	{
		protected DataCommon dataCommon;
        protected EcrmUserBinding userService;
        protected EcrmCustomerBinding customerService;
        protected User me;
        //protected RoleService roleService;
        //protected FlowService flowService;
        //protected OrderService orderService;
        //private CommandNameType ctrlAction = CommandNameType.NULL;
		protected override void OnInit(EventArgs e)
		{
			// 然后根据配置文件的数据库类型，初始化数据访问对象 [6/15/2008]
            switch (Properties.Settings.Default.DBTYPE.ToLower())
			{
				case "ole":
                    //dataCommon = new OleDataCommon();
					break;
				case "sql":
                    //dataCommon = new SqlDataCommon(Properties.Settings.Default.CONNECTSTRING);
					break;
				default:
					break;
			}
            userService = new EcrmUserBinding();
            customerService = new EcrmCustomerBinding();
            //GetMe();
            base.OnInit(e);
		}

        private void GetMe()
        {
            TdUserResult res = userService.GetUserById(CurrentUserId);
            if (!res.result)
                throw new Exception(res.msg);
            me = res.users[0];
        }
        //public CommandNameType CtrlAction
        //{
        //    set
        //    {
        //        ctrlAction = value;
        //    }
        //    get
        //    {
        //        return ctrlAction;
        //    }
        //}
        /// <summary>
        /// 从日期组合控件中提取日历控件，用于get set日期
        /// </summary>
        /// <param name="p_ctrl">组合控件的id</param>
        /// <returns></returns>
        protected ComponentArt.Web.UI.Calendar FindPicker(UserControl p_ctrl)
        {
            return (ComponentArt.Web.UI.Calendar)p_ctrl.FindControl("Picker1");
        }
        /// <summary>
        /// 根据控件Item的Text，定位到相应的Item
        /// </summary>
        /// <param name="p_control">用于定位Item的下拉菜单</param>
        /// <param name="p_text">需要定位的Item的Text</param>
        protected void FocusItemByText(ListControl p_control, string p_text)
        {
            p_control.ClearSelection();
            ListItem item = p_control.Items.FindByText(p_text);
            if (null != item)
                item.Selected = true;
        }
        /// <summary>
        /// 判断用户控件是不是第一次load
        /// </summary>
        protected bool IsFirstLoad
        {
            get
            {
                if (ViewState["DataInit"] == null)
                    return false;
                return Convert.ToBoolean(ViewState["DataInit"]);
            }
            set
            {
                ViewState["DataInit"] = value;
            }
        }
        protected int CurrentUserId
        {
            get
            {
                if (Session["CurrentUser"] == null)
                    return 0;
                return Convert.ToInt32(Session["CurrentUser"]);
            }
        }

	}
}
