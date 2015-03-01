//----------------------------------------------------------------

//----------------------------------------------------------------

namespace Powerson.Web
{
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;

    using Powerson.Framework;
    using Powerson.BusinessFacade;
	using Powerson.DataAccess;
    using RailsService;
    /// <summary>
    ///     The code-behind base class for all pages.
    ///     <remarks>
    ///         This class derives off of System.Web.UI.Page.
    ///     </remarks>
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        protected enum CommandNameType { NEW, EDIT, DELETE, NULL, LIMITEDIT };
        
        string _loadMsg = "";
		
		protected string valCode;

		protected DataCommon dataCommon;
        protected EcrmUserBinding userService;
        protected EcrmCustomerBinding customerService;
        protected User me;
        //protected UserService userService;
        //protected CustomerService customerService;
        //protected RoleService roleService;
        //protected FlowService flowService;
        //protected OrderService orderService;

		protected override void OnInit(EventArgs e)
		{
			// 然后根据配置文件的数据库类型，初始化数据访问对象 [6/15/2008]
			switch(Properties.Settings.Default.DBTYPE.ToLower())
			{
				case "ole":
                    //dataCommon = new OleDataCommon();
					break;
				case "sql":
					dataCommon = new SqlDataCommon(Powerson.Web.Properties.Settings.Default.CONNECTSTRING);
					break;
				default:
					break;
			}
			// 初始化用户服务对象 [9/23/2008]
            userService = new EcrmUserBinding();
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

        protected void GetCurrentUser()
        {
            if (null != me)
                return;
            int userid = CurrentUserId;
            if (0 == userid)
                return;
            TdUserResult res = userService.GetUserById(userid);
            if (!res.result)
                return;
            me = res.users[0];
        }
		protected override void OnError(EventArgs e)
		{
			string str_msg = Server.GetLastError().ToString();
            string str_errorCode = DateTime.Now.Day + DateTime.Now.ToLongTimeString().Replace(":", "");
            FlyLog.WriteLog(string.Format("{0}\r\n{1}", str_errorCode, str_msg));
            Response.Redirect(string.Format("Error.aspx?code={0}", str_errorCode));
		}

		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			string script = "";
			if(_loadMsg.Length > 0)
				script = String.Format("<script language=\"javascript\">\nonload=function(){1}\nalert(\"{0}\");\n{2}\n</script>\n",_loadMsg,'{','}');

			base.Render(writer);
            writer.WriteLine(script);
        }
		protected string GetQueryString(string name)
		{
			if (null == Request.QueryString[name])
			{
				return null;
			}
			return Request.QueryString[name].ToString();
		}

		protected void AddLoadMessage(string p_msg)
		{
			_loadMsg += p_msg;
		}
        /// <summary>
        /// 将一个DataTable的数据，绑定到一个List控件，比如下拉菜单
        /// </summary>
        /// <param name="targetControl">List控件的Items属性对象</param>
        /// <param name="dataSource">数据源DataTale</param>
        /// <param name="valueColumnName">List控件Value对应的DataTable列名</param>
        /// <param name="textColumnName">List控件Text对应的DataTable列名</param>
        /// <param name="topText">List控件第一行显示的文字，如果是null，则没有第一行</param>
        protected void DataBind(ListItemCollection targetControl, DataTable dataSource, string valueColumnName, string textColumnName, string topText)
        {
            targetControl.Clear();
            if (null == dataSource)
                throw new NullReferenceException(string.Format("无法绑定控件{0}，因为数据源是null"));

            if (null != topText)
            {
                targetControl.Add(new ListItem(topText, "0"));
            }

            foreach (DataRow dr in dataSource.Rows)
            {
                targetControl.Add(new ListItem(dr[textColumnName].ToString(), dr[valueColumnName].ToString()));
            }
        }
        /// <summary>
        /// 根据控件Item的Value，定位到相应的Item
        /// </summary>
        /// <param name="p_control">用于定位Item的下拉菜单</param>
        /// <param name="p_value">需要定位的Item的value</param>
        protected void FocusItemByValue(ListControl p_control, string p_value)
        {
            p_control.ClearSelection();
            ListItem item = p_control.Items.FindByValue(p_value);
            if (null != item)
                item.Selected = true;
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
        protected int CurrentUserId
        {
            get
            {
                if (Session["CurrentUser"] == null)
                    return 0;
                return Convert.ToInt32(Session["CurrentUser"]);
            }
            set
            {
                Session["CurrentUser"] = value;
            }
        }
        //protected string GetTip(string tipText)
        //{
        //    return string.Format("this.T_TITLE='提示';return escape('{0}');", tipText );
        //}
        //protected ComponentArt.Web.UI.Calendar FindPicker(UserControl p_ctrl)
        //{
        //    return (ComponentArt.Web.UI.Calendar)p_ctrl.FindControl("Picker1");
        //}
	} // class PageBase
    
} 
