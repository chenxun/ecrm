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
using Powerson.BusinessFacade;
using Powerson.DataAccess;

namespace Powerson.Web
{
    public partial class Customer_manage : AuthPageBase
    {
        const int TAB_EDIT_CUSTOMER = 0;
        const int TAB_CUSTOMER_LIST = 1;
        const int TAB_VISIT_PLAN = 2;
        const int TAB_CONTINUE_PAY = 3;
        const int TAB_NEW_PROJECT = 4;
        /// <summary>
        /// 记录刚才的Tab序号是几号
        /// </summary>
        public int RecentTabIndex
        {
            set
            {
                ViewState["RecentTabIndex"] = value;
            }
            get
            {
                if (null == ViewState["RecentTabIndex"])
                    return TAB_CUSTOMER_LIST;
                return Convert.ToInt32(ViewState["RecentTabIndex"]);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BaseDataBind();
                VisitPlanGridBind();
                NewProjectTabDataBind();
            }
        }

        private void BaseDataBind()
        {
            FindPicker(PickerAndCalendar_nextVisit).SelectedDate = DateTime.Now.AddDays(1);
            //UserDO me = LoginSession.GetCurrentUser(this);
            //// 只有销售可以创建客户 [7/26/2009]
            //if (BitUtil.BitAnd(me.RoleId, RoleService.ROLE_MANAGER) || BitUtil.BitAnd(me.RoleId, RoleService.ROLE_SALES) || BitUtil.BitAnd(me.RoleId, RoleService.ROLE_LEADER))
            //{
            //    Button_addCustomer.Visible = true;
            //}
            //else
            //{
            //    Button_addCustomer.Visible = false;
            //}

        }

        #region 客户管理tab
        /// <summary>
        /// 当点击客户搜索按钮调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FindCustomer_manage_FindCustomerButtonClick(object sender, EventArgs e)
        {
            gridDataBind();
        }
        /// <summary>
        /// 根据搜索条件，绑定客户信息列表
        /// </summary>
        private void gridDataBind()
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData("FindCustomer", FindCustomer_manage.GetSqlPara(), ds, CustomersData._CUSTOMERS_TABLE);
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = FindCustomer_manage.GetRowFilter();
            Grid_customer.DataSource = dv;
            Grid_customer.DataBind();
        }
        #endregion
        #region 显示客户的所有信息
        private void CustomerInfoBind(string p_customerId)
        {
            

            TabStrip_customer.SelectedTab = TabStrip_customer.Tabs[TAB_EDIT_CUSTOMER];
            TabStrip_customer.Tabs[TAB_EDIT_CUSTOMER].Visible = true;
            MultiPage_customer.SelectedIndex = TAB_EDIT_CUSTOMER;

        }

        #endregion
        #region 编辑客户基本信息

        /// <summary>
        /// 将编辑客户信息的tab隐藏
        /// </summary>
        private void cancelEdit()
        {
            TabStrip_customer.SelectedTab = TabStrip_customer.Tabs[RecentTabIndex];
            TabStrip_customer.Tabs[TAB_EDIT_CUSTOMER].Visible = false;
            MultiPage_customer.SelectedIndex = RecentTabIndex;
        }




        #endregion
        #region 录入客户信息
        /// <summary>
        /// 点击添加客户按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_addCustomer_Click(object sender, EventArgs e)
        {
            //CustomerDO customerNew = CustomerInfo_add.getCustomerInfo();
            //if(customerService.CustomerIsExsit(customerNew.CompanyName) )
            //{
            //    AddLoadMessage("该客户已存在，无法重复添加");
            //    return;
            //}

            //DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select top 1 * from [_Customers]"), ds, CustomersData._CUSTOMERS_TABLE);
            //dataCommon.GetAllData("select top 1 * from [_VisitRecord]", ds, VisitRecordData._VISITRECORD_TABLE);
            //dataCommon.GetAllData("select top 1 * from [_VisitPlan]", ds, VisitPlanData._VISITPLAN_TABLE);

            //DataRow dr = ds.Tables[CustomersData._CUSTOMERS_TABLE].NewRow();
            
            //dr[CustomersData.COMPANYNAME_FIELDS] = customerNew.CompanyName;
            //dr[CustomersData.WEBSITE_FIELDS] = customerNew.Website;
            //dr[CustomersData.CONTACTMAN_FIELDS] = customerNew.ContactMan;
            //dr[CustomersData.TEL_FIELDS] = customerNew.Tel;
            //dr[CustomersData.EXTENSION_FIELDS] = customerNew.Extension;
            //dr[CustomersData.POSITION_FIELDS] = customerNew.Position;
            //dr[CustomersData.MOBILE_FIELDS] = customerNew.Mobile;
            //dr[CustomersData.FAX_FIELDS] = customerNew.Fax;
            //dr[CustomersData.EMAIL_FIELDS] = customerNew.Email;
            //dr[CustomersData.INDUSTRYTYPE_FIELDS] = customerNew.IndustryType;
            //dr[CustomersData.BUYINTENT_FIELDS] = customerNew.BuyIntent;
            //dr[CustomersData.VISITTYPE_FIELDS] = customerNew.VisitType;
            //dr[CustomersData.RANKID_FIELDS] = customerNew.RankId;
            //dr[CustomersData.AREA_FIELDS] = customerNew.Area;
            //dr[CustomersData.VILLAGE_FIELDS] = customerNew.Village;
            //dr[CustomersData.ADDRESS_FIELDS] = customerNew.Address;
            //dr[CustomersData.REMARK_FIELDS] = customerNew.Remark;
            //dr[CustomersData.ADDTIME_FIELDS] = DateTime.Now;
            //dr[CustomersData.USERID_FIELDS] = LoginSession.GetCurrentUser(this).PersonId;
            //dr[CustomersData.LASTVISITDATE_FIELDS] = DateTime.Now;
            //dr[CustomersData.LASTVISITINFO_FIELDS] = VisitRecordInfo_firstVisit.Remark;
            //dr[CustomersData.INOPENSEA_FIELDS] = 0;
            //dr[CustomersData.KEYWORDS_FIELDS] = customerNew.Keywords;

            //ds.Tables[CustomersData._CUSTOMERS_TABLE].Rows.Add(dr);
            //int i_customerId = dataCommon.InsertData(ds, CustomersData._CUSTOMERS_TABLE);

            //if (VisitRecordInfo_firstVisit.Remark.Length > 0)
            //{
            //    DataRow dr_record = ds.Tables[VisitRecordData._VISITRECORD_TABLE].NewRow();
            //    dr_record[VisitRecordData.CUSTOMERID_FIELDS] = i_customerId;
            //    dr_record[VisitRecordData.PERSONID_FIELDS] = LoginSession.GetCurrentUser(this).PersonId;
            //    dr_record[VisitRecordData.REMARK_FIELDS] = VisitRecordInfo_firstVisit.Remark;
            //    dr_record[VisitRecordData.TITLE_FIELDS] = VisitRecordInfo_firstVisit.RecordTitle;
            //    dr_record[VisitRecordData.VISITDATE_FIELDS] = VisitRecordInfo_firstVisit.VisitDate;
            //    ds.Tables[VisitRecordData._VISITRECORD_TABLE].Rows.Add(dr_record);
            //}

            //DataRow dr_plan = ds.Tables[VisitPlanData._VISITPLAN_TABLE].NewRow();
            //dr_plan[VisitPlanData.CUSTOMERID_FIELDS] = i_customerId;
            //dr_plan[VisitPlanData.PERSONID_FIELDS] = LoginSession.GetCurrentUser(this).PersonId;
            //dr_plan[VisitPlanData.PLANSTATUS_FIELDS] = CustomerService.PLANSTATUS_PENDING;
            //dr_plan[VisitPlanData.PLANTYPE_FIELDS] = CustomerService.PLANTYPE_VISITPLAN;
            //dr_plan[VisitPlanData.VISITPLANDATE_FIELDS] = FindPicker(PickerAndCalendar_nextVisit).SelectedDate;
            //dr_plan[VisitPlanData.REMARK_FIELDS] = TextBox_addCustomer_nextVisit.Text;
            //ds.Tables[VisitPlanData._VISITPLAN_TABLE].Rows.Add(dr_plan);

            //dataCommon.UpdateData(ds);

            AddLoadMessage("添加客户成功");
            CustomerInfo_add.cleanup();
            VisitRecordInfo_firstVisit.Cleanup();
            TextBox_addCustomer_nextVisit.Text = "";

            gridDataBind();
        }
        #endregion
        #region 客户拜访计划tab
        /// <summary>
        /// 将当前客户的拜访记录绑定到列表
        /// </summary>
        private void VisitPlanGridBind()
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData("FindVisitPlan", FindPlan_visit.GetSqlPara(), ds, CustomersData._CUSTOMERS_TABLE);
            //DataView dv = ds.Tables[0].DefaultView;
            //dv.RowFilter = FindPlan_visit.GetRowFilter();
            //Grid_visitPlan.DataSource = dv;
            //Grid_visitPlan.DataBind();
        }
        protected void FindCustomer_visitPlan_FindCustomerButtonClick(object sender, EventArgs e)
        {
            VisitPlanGridBind();
        }
        #endregion
        #region 新项目意向tab
        private void NewProjectTabDataBind()
        {
            string str_sql = string.Format("SELECT	C.Id,C.CompanyName,C.LastVisitDate,C.AddTime,R.RankName,P.Name as PersonName,V.Remark from [_Customers] C,[_CustomerRank] R,[_PersonalInfo] P,[_VisitPlan] V where C.RankId=R.Id and V.PersonId=P.Id and V.CustomerId=C.Id and V.PlanType=3 and V.PlanStatus='等待处理'");
            //if (!BitUtil.BitAnd(LoginSession.GetCurrentUser(this).RoleId, RoleService.ROLE_MANAGER))
            //    str_sql += " and V.PersonId=" + LoginSession.GetCurrentUser(this).PersonId;
            //DataSet ds = new DataSet();
            //dataCommon.GetAllData(str_sql, ds, CustomersData._CUSTOMERS_TABLE);
            //Grid_newproject.DataSource = ds.Tables[CustomersData._CUSTOMERS_TABLE];
            //Grid_newproject.DataBind();
        }
        #endregion
    }
}
