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
using Powerson.Framework;
using Powerson.DataAccess;
using Powerson.BusinessFacade;
using Powerson.Web.RailsService;

namespace Powerson.Web
{
    public partial class Content : AuthPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageDataBind();
            //TodayPlanBind();
            //AddJavaScript(string.Format("NewUrl('Notice_index.aspx','main');"));
        }
        private void PageDataBind()
        {
            ComponentArt.Web.UI.NavBarItem newItem;

            Frame[] frames = userService.GetFramesByUserId(CurrentUserId);
            //DataTable dtFrameRank = LoginSession.GetFrameRank(this);
            foreach (Frame frame in frames)
            {
                if (frame.parent_id != 0)
                    continue;//如果不是一级菜单就skip
                newItem = CreateItem(frame.name, null, frame.image_file);
                _NavBarContent.Items.Add(newItem);

                foreach (Frame child in frames)
                {
                    if (child.parent_id != frame.id)
                        continue;
                    ComponentArt.Web.UI.NavBarItem childItem = CreateItem(child.name, child.navigate_url, child.image_file);
                    newItem.Items.Add(childItem);
                }
                newItem.Expanded = true;
            }
        }

        private ComponentArt.Web.UI.NavBarItem CreateItem(string frameName, string navigateUrl, string imageUrl)
        {
            ComponentArt.Web.UI.NavBarItem itemRet = new ComponentArt.Web.UI.NavBarItem();
            itemRet.Text = frameName;
            if (null == navigateUrl)// 如果链接是null,说明是一级菜单 [6/16/2008]
            {
                itemRet.DefaultSubItemLookId = "Level2ItemLook";
                itemRet.SubGroupCssClass = "Level2Group";
            }
            else
            {
                itemRet.Look.LeftIconUrl = imageUrl;
                itemRet.ClientSideCommand = "NewUrl('" + navigateUrl + "','main');";
            }
            return itemRet;
        }


        void TodayPlanBind()
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select C.Id,C.CompanyName from [_Customers] C,[_VisitPlan] V where C.Inopensea=0 and V.CustomerId=C.Id and V.PersonId={0} and V.VisitPlanDate<'{1}' and V.PlanType=1	and V.PlanStatus='等待处理'", LoginSession.GetCurrentUser(this).PersonId, DateTime.Now), ds, CustomersData._CUSTOMERS_TABLE);
            Label_today.Text = "";
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Label_today.Text += string.Format("<a href='customerinfo' onclick='OpenWindowInCenter(\"customer_info.aspx?id={0}\",\"{0}\");return false;'>{1}</a><br/>", dr["id"], dr["CompanyName"]);
            }
        }

    }
}
