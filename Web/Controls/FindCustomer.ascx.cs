using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Powerson.DataAccess;
using Powerson.Framework;
using Powerson.BusinessFacade;

namespace Powerson.Web.Controls
{
    public partial class FindCustomer : UserControlBase
    {
        public event EventHandler FindCustomerButtonClick;
        protected void Page_Load(object sender, EventArgs e)
        {
            BaseDataBind();
        }
        private void BaseDataBind()
        {
            if (null == ViewState["DataInit"])
            {
                FindPicker(PickerAndCalendar_begin).SelectedDate = DateTime.Now.AddDays(-3);
                FindPicker(PickerAndCalendar_end).SelectedDate = DateTime.Now;
                DropDownListBind();
                ViewState["DataInit"] = true;
            }

        }
        private void DropDownListBind()
        {
            DataSet ds = new DataSet();

            //dataCommon.GetAllData(string.Format("SELECT * FROM [_CustomerRank]"), ds, CustomerRankData._CUSTOMERRANK_TABLE);
            //ListControlUtil.DataBind(DropDownList_rank.Items, ds.Tables[CustomerRankData._CUSTOMERRANK_TABLE], CustomerRankData.ID_FIELDS, CustomerRankData.RANKNAME_FIELDS, "<请选择...>");

            //dataCommon.GetAllData(string.Format("SELECT * FROM [_BuyIntent]"), ds, BuyIntentData._BUYINTENT_TABLE);
            //ListControlUtil.DataBind(DropDownList_buyIntent.Items, ds.Tables[BuyIntentData._BUYINTENT_TABLE], BuyIntentData.ID_FIELDS, BuyIntentData.INTENTNAME_FIELDS, "<请选择...>");
            
            //dataCommon.GetAllData(string.Format("SELECT * FROM [_area]"), ds, AreaData._AREA_TABLE);
            //ListControlUtil.DataBind(DropDownList_area.Items, ds.Tables[AreaData._AREA_TABLE], AreaData.ID_FIELDS, AreaData.AREANAME_FIELDS, "<请选择...>");

            //DataTable dt_sales = roleService.GetSalesList(LoginSession.GetCurrentUser(this.Page));
            //ListControlUtil.DataBind(DropDownList_sales.Items, dt_sales, PersonalInfoData.ID_FIELDS, PersonalInfoData.NAME_FIELDS, "<请选择...>");
        }
        protected void Button_find_Click(object sender, EventArgs e)
        {
            if (null != FindCustomerButtonClick)
            {
                if (DropDownList_noVisit.SelectedIndex > 0)
                {
                    CheckBox_addtime_valid.Checked = false;
                }

                FindCustomerButtonClick(sender, e);
            }
        }
        public ArrayList GetSqlPara()
        {
            SqlParameter para_dateBegin;// 如果要查看一段时间没有跟进的客户，录入日期的条件就要失效 [3/14/2009]
            //if (CheckBox_addtime_valid.Checked)
            //{
            //    para_dateBegin = DBParamBuild.CreateParam("@AddDateBegin", SqlDbType.DateTime, 0, FindPicker(PickerAndCalendar_begin).SelectedDate);
            //}else
            //{
            //    para_dateBegin = DBParamBuild.CreateParam("@AddDateBegin", SqlDbType.DateTime, 0, DBNull.Value);
            //}
            //SqlParameter[] para_ret = {
            //    DBParamBuild.CreateParam("@CompanyName", SqlDbType.VarChar, 100, TextBox_companyName.Text.TrimEnd() ),
            //    DBParamBuild.CreateParam("@ContactMan", SqlDbType.VarChar, 100, TextBox_contactMan.Text.TrimEnd() ),
            //    DBParamBuild.CreateParam("@VisitType", SqlDbType.VarChar, 100, DropDownList_visitType.SelectedIndex>0 ? (object)DropDownList_visitType.SelectedItem.Text : DBNull.Value),
            //    DBParamBuild.CreateParam("@BuyIntent", SqlDbType.VarChar, 100, DropDownList_buyIntent.SelectedIndex>0 ? (object)DropDownList_buyIntent.SelectedItem.Text : DBNull.Value),
            //    DBParamBuild.CreateParam("@Area", SqlDbType.VarChar, 100, DropDownList_area.SelectedIndex>0 ? (object)DropDownList_area.SelectedItem.Text : DBNull.Value),
            //    DBParamBuild.CreateParam("@CustomerRank", SqlDbType.Int, 4, DropDownList_rank.SelectedIndex>0 ? (object)DropDownList_rank.SelectedValue : DBNull.Value),
            //    DBParamBuild.CreateParam("@LastVist", SqlDbType.DateTime, 0, DropDownList_noVisit.SelectedIndex>0 ? (object)DateTime.Now.AddDays(0 - Convert.ToInt32(DropDownList_noVisit.SelectedValue)) : DBNull.Value),
            //    DBParamBuild.CreateParam("@SalesId", SqlDbType.Int, 100, DropDownList_sales.SelectedIndex>0 ? (object)DropDownList_sales.SelectedValue : DBNull.Value ),
            //    para_dateBegin,
            //    DBParamBuild.CreateParam("@AddDateEnd", SqlDbType.DateTime, 0, FindPicker(PickerAndCalendar_end).SelectedDate.AddDays(1))
            //};
            //ArrayList ret = new ArrayList(para_ret);
            return null;
        }
        public string GetSalesIds()
        {
            string str_salesId = "";
            if (DropDownList_sales.SelectedIndex == 0)
            {
                for (int i = 0; i < DropDownList_sales.Items.Count; i ++ )
                {
                    str_salesId += DropDownList_sales.Items[i].Value + ",";
                }
                str_salesId = StringUtil.StrLeftBack(str_salesId, ",", true);
            }else
            {
                str_salesId = DropDownList_sales.SelectedValue;
            }
            return str_salesId;
        }
        public string GetRowFilter()
        {
            string str_filter = "";

            str_filter += string.Format(" UserId in ({0}) ", GetSalesIds());

            if (DropDownList_noVisit.SelectedIndex > 0 && DropDownList_rank.SelectedIndex == 0)
            {
                str_filter += " and rankid<>2 ";
            }
            return str_filter;
        }
    }
}