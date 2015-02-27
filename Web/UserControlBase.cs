using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Powerson.SystemFramework;
using Powerson.BusinessFacade;
using Powerson.DataAccess;

namespace Powerson.Web
{
	/// <summary>
	/// UserControlBase 的摘要说明。
	/// </summary>
	public class UserControlBase : System.Web.UI.UserControl
	{
		protected DataCommon dataCommon;
        //protected UserService userService;
        //protected CustomerService customerService;
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
					dataCommon = new SqlDataCommon(Properties.Settings.Default.CONNECTSTRING);
					break;
				default:
					break;
			}
            //this.userService = new UserService();
            //userService.ServiceDataCommon = this.dataCommon;
            //customerService = new CustomerService();
            //customerService.ServiceDataCommon = this.dataCommon;
            //roleService = new RoleService();
            //roleService.ServiceDataCommon = this.dataCommon;
            //flowService = new FlowService();
            //flowService.ServiceDataCommon = dataCommon;
            //orderService = new OrderService();
            //orderService.ServiceDataCommon = dataCommon;
            base.OnInit(e);
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
        protected ComponentArt.Web.UI.Calendar FindPicker(UserControl p_ctrl)
        {
            return (ComponentArt.Web.UI.Calendar)p_ctrl.FindControl("Picker1");
        }

	}
}
