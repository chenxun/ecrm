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
    //using Powerson.BusinessFacade;
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
		string _loadMsg = "";
		
		protected string valCode;

		protected DataCommon dataCommon;
        protected ecrmUserBinding userService;
        protected ecrmCustomerBinding customerService;
        //protected UserService userService;
        //protected CustomerService customerService;
        //protected RoleService roleService;
        //protected FlowService flowService;
        //protected OrderService orderService;

		protected override void OnInit(EventArgs e)
		{
			// Ȼ����������ļ������ݿ����ͣ���ʼ�����ݷ��ʶ��� [6/15/2008]
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
			// ��ʼ���û�������� [9/23/2008]
            userService = new ecrmUserBinding();
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
		protected override void OnError(EventArgs e)
		{
			string str_msg = Server.GetLastError().ToString();
            string str_errorCode = DateTime.Now.ToShortDateString() + DateTime.Now.ToLongTimeString();
            str_errorCode = str_errorCode.Replace(":", "").Replace("-", "");
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
			string strRet = Request.QueryString[name].ToString();
			return strRet;
		}

		protected void AddLoadMessage(string p_msg)
		{
			_loadMsg += p_msg;
		}
        /// <summary>
        /// ��һ��DataTable�����ݣ��󶨵�һ��List�ؼ������������˵�
        /// </summary>
        /// <param name="targetControl">List�ؼ���Items���Զ���</param>
        /// <param name="dataSource">����ԴDataTale</param>
        /// <param name="valueColumnName">List�ؼ�Value��Ӧ��DataTable����</param>
        /// <param name="textColumnName">List�ؼ�Text��Ӧ��DataTable����</param>
        /// <param name="topText">List�ؼ���һ����ʾ�����֣������null����û�е�һ��</param>
        protected void DataBind(ListItemCollection targetControl, DataTable dataSource, string valueColumnName, string textColumnName, string topText)
        {
            targetControl.Clear();
            if (null == dataSource)
                throw new NullReferenceException(string.Format("�޷��󶨿ؼ�{0}����Ϊ����Դ��null"));

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
        /// ���ݿؼ�Item��Value����λ����Ӧ��Item
        /// </summary>
        /// <param name="p_control">���ڶ�λItem�������˵�</param>
        /// <param name="p_value">��Ҫ��λ��Item��value</param>
        public static void FocusItemByValue(ListControl p_control, string p_value)
        {
            p_control.ClearSelection();
            ListItem item = p_control.Items.FindByValue(p_value);
            if (null != item)
                item.Selected = true;
        }
        /// <summary>
        /// ���ݿؼ�Item��Text����λ����Ӧ��Item
        /// </summary>
        /// <param name="p_control">���ڶ�λItem�������˵�</param>
        /// <param name="p_text">��Ҫ��λ��Item��Text</param>
        public static void FocusItemByText(ListControl p_control, string p_text)
        {
            p_control.ClearSelection();
            ListItem item = p_control.Items.FindByText(p_text);
            if (null != item)
                item.Selected = true;
        }

        //protected string GetTip(string tipText)
        //{
        //    return string.Format("this.T_TITLE='��ʾ';return escape('{0}');", tipText );
        //}
        //protected ComponentArt.Web.UI.Calendar FindPicker(UserControl p_ctrl)
        //{
        //    return (ComponentArt.Web.UI.Calendar)p_ctrl.FindControl("Picker1");
        //}
	} // class PageBase
    
} 
