using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Powerson.BusinessFacade;
using Powerson.Framework;
using Powerson.Web.RailsService;

namespace Powerson.Web
{
    public partial class Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void Button_login_Click(object sender, EventArgs e)
        {
            if (TextBox_code.Text.Equals(this.valCode))
            {
                TextBox_code.Text = "";
                AddLoadMessage( "—È÷§¬Î¥ÌŒÛ");
                return;
            }
            TdUserResult res = userService.GetUserByName(TextBox_name.Text.TrimEnd().ToLower());
            if (!res.result)
            {
                AddLoadMessage(res.msg);
                return;
            }
            if (!res.user.password.Equals(StringUtil.MD5Hash(TextBox_password.Text)))
            {
                AddLoadMessage("√‹¬Î¥ÌŒÛ°£");
                return;
            }
            //LoginSession.SetIsLogin(this, true);
            //LoginSession.SetCurrentUser(this, u);

            //DataTable dt_f = userService.getFrameByRole(u.RoleId);
            //if (null != dt_f)
            //{
            //    LoginSession.SetFrameRank(this, dt_f);
            //}

            //Response.Redirect("home.aspx");
            return;
        }
    }
}
