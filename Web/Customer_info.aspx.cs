using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Powerson.Framework;
using Powerson.BusinessFacade;
using Powerson.DataAccess;
using Powerson.Web.RailsService;

namespace Powerson.Web
{
    public partial class Customer_info : AuthPageBase
    {
        Customer the_customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BuildCustomer();
                CustomerDataBind();
            }

        }
        /// <summary>
        /// 显示客户的基本数据
        /// </summary>
        void CustomerDataBind()
        {
            //this.form1.
            if (the_customer == null)
                return;
            CustomerInfo_edit.CustomerDataBind(the_customer);
            //CustomerInfo_edit.CustomerId = str_id;

            //this.thistitle.Text = CustomerInfo_edit.getCustomerInfo().CompanyName;
            
            // 检查按钮是否显示 [5/27/2009]
            CheckButton();

            VisitRecordDataBind(the_customer.id);
            //HistoryDataBind();
            //OrderDataBind();
            //NewProjectDataBind();

            // 显示上次的拜访计划 [5/24/2009]
            FindPicker(PickerAndCalendar_addVisitRecord_nextVisit).SelectedDate = DateTime.Now.AddDays(1);
            FindPicker(PickerAndCalendar_newproject).SelectedDate = DateTime.Now.AddDays(7);
            TextBox_addVisit_nextVisit.Text = "";
            // 这里要显示以前的拜访计划的 [3/5/2009]
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select * from _VisitPlan where CustomerId={0} and PlanType=1 and PlanStatus='{1}' order by Id desc", CustomerInfo_edit.CustomerId, CustomerService.PLANSTATUS_PENDING), ds, VisitPlanData._VISITPLAN_TABLE);
            //if (ds.Tables[VisitPlanData._VISITPLAN_TABLE].Rows.Count == 0)
            //{
            //    Label_visitPlan.Text = "暂时没有跟进计划";
            //}
            //else
            //{
            //    DataRow dr = ds.Tables[VisitPlanData._VISITPLAN_TABLE].Rows[0];
            //    Label_visitPlan.Text = string.Format("您计划在 {0} 跟进该客户，请注意以下信息：<br>{1}", Convert.ToDateTime(dr[VisitPlanData.VISITPLANDATE_FIELDS]).ToShortDateString(), dr[VisitPlanData.REMARK_FIELDS]);
            //}
        }

        private void BuildCustomer()
        {
            string str_id = GetQueryString("id");
            if (str_id == null)
            {
                return;
            }
            TdCustomerResult res = customerService.GetCustomerById(int.Parse(str_id));
            if (!res.result)
            {
                AddLoadMessage(res.msg);
                return;
            }
            the_customer = res.customers[0];
        }
        /// <summary>
        /// 根据客户状态，检查各个按钮
        /// </summary>
        void CheckButton()
        {
            Button_saveCustomer.Visible = false;
            Button_add_rec.Visible = false;
            Button_opensea.Visible = false;
            Button_saveRecord.Visible = false;
            Button_newproj.Visible = false;
            Button_apply.Visible = false;
            Button_newOrder.Visible = false;

            //UserDO me = LoginSession.GetCurrentUser(this);

            //if (BitUtil.BitAnd(me.RoleId, RoleService.ROLE_MANAGER))
            //    Button_shift.Visible = true;// 只有经理可以转移客户 [8/5/2009]

            //string c_id = GetQueryString("id");
            //CustomerDO cus = customerService.GetCustomerById(int.Parse(c_id));
            //if (cus.InOpenSea == 1)
            //    return;

            //if (cus.InOpenSea == 2)
            //{
            //    // 判断是不是自己扔的，如果是，不准捡 [5/28/2009]
            //    bool b_ismine = false;
            //    if (cus.UserId == me.PersonId)
            //        b_ismine = true;
            //    if (b_ismine)
            //        return;
            //    Button_apply.Visible = true;
            //    return;
            //}
            if (me.id == the_customer.user_id)
                Button_saveCustomer.Visible = true;
            //Button_add_rec.Visible = Button_saveCustomer.Visible;
            //Button_opensea.Visible = Button_saveCustomer.Visible;
            //Button_saveRecord.Visible = Button_saveCustomer.Visible;
            //Button_newproj.Visible = Button_saveCustomer.Visible;
            //// 如果是客服和经理，可以创建订单 [7/26/2009]
            //if (BitUtil.BitAnd(me.RoleId, RoleService.ROLE_SUPPORT) || BitUtil.BitAnd(me.RoleId, RoleService.ROLE_MANAGER))
            //{
            //    Button_newOrder.Visible = true;
            //}
            //else
            //{
            //    Button_newOrder.Visible = false;
            //}
            return;
        }
        /// <summary>
        /// 显示客户的拜访记录列表
        /// </summary>
        void VisitRecordDataBind(int customer_id)
        {
            VisitRecord[] res = customerService.GetVisitRecordsByCustomer(customer_id);

            Grid_visitRecord.DataSource = res;
            Grid_visitRecord.DataBind();
        }
        /// <summary>
        /// 显示客户的历史变更记录
        /// </summary>
        void HistoryDataBind()
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select * from _CustomerHistory where CustomerId={0} order by Id desc", CustomerInfo_edit.CustomerId), ds, CustomerHistoryData._CUSTOMERHISTORY_TABLE);
            //Grid_history.DataSource = ds.Tables[CustomerHistoryData._CUSTOMERHISTORY_TABLE];
            //Grid_history.DataBind();
        }
        /// <summary>
        /// 显示这个客户已经签的订单
        /// </summary>
        void OrderDataBind()
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select O.*,P.Name from _Orders O,_PersonalInfo P where O.UserId=P.Id and O.customerId={0}", CustomerInfo_edit.CustomerId), ds, OrderData._ORDERS_TABLE);
            //GridView_order.DataSource = ds.Tables[OrderData._ORDERS_TABLE];
            //GridView_order.DataBind();
        }
        /// <summary>
        /// 显示这个客户产生的新项目意向
        /// </summary>
        void NewProjectDataBind()
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select V.*,P.Name from _VisitPlan V,_PersonalInfo P where V.PersonId=P.Id and V.CustomerId={0} and V.PlanType=3", CustomerInfo_edit.CustomerId), ds, VisitPlanData._VISITPLAN_TABLE);
            //GridView_newproj.DataSource = ds.Tables[VisitPlanData._VISITPLAN_TABLE];
            //GridView_newproj.DataBind();
        }
        /// <summary>
        /// 保存客户的基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_saveCustomer_Click(object sender, System.EventArgs e)
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select * from _Customers where Id={0}", CustomerInfo_edit.CustomerId), ds, CustomersData._CUSTOMERS_TABLE);
            //if (ds.Tables[0].Rows.Count.Equals(0))
            //{
            //    AddLoadMessage("更新客户信息失败");
            //    return;
            //}
            DataRow dr = ds.Tables[0].Rows[0];
            //CustomerDO customerNew = CustomerInfo_edit.getCustomerInfo();
            ////dr[CustomersData.COMPANYNAME_FIELDS] = customerNew.CompanyName;
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
            //dr[CustomersData.KEYWORDS_FIELDS] = customerNew.Keywords;

            //dataCommon.UpdateData(ds);

            //customerService.AddChangeHistory(CustomerInfo_edit.ChangeHistory);
            //HistoryDataBind();
            AddLoadMessage("客户信息被成功保存");
        }
        /// <summary>
        /// 确认将客户扔进公海
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_confirm_opensea_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select * from _Customers where id={0}", CustomerInfo_edit.CustomerId), ds, CustomersData._CUSTOMERS_TABLE);
            //dataCommon.GetAllData("select top 1 * from _VisitRecord", ds, VisitRecordData._VISITRECORD_TABLE);

            //DataRow dr = ds.Tables[CustomersData._CUSTOMERS_TABLE].Rows[0];
            //dr[CustomersData.INOPENSEA_FIELDS] = 2;
            //dr[CustomersData.REMARK_FIELDS] = string.Format("----这是扔进公海的原因----\r\n{0}\r\n-----------end----------\r\n{1}", TextBox_opensea_reason.Text,  dr[CustomersData.REMARK_FIELDS]);
            //dataCommon.UpdateData(ds);
            //// 添加一条历史记录 [3/10/2009]
            //HistoryDO openseaHis = new HistoryDO();
            //openseaHis.ChangeDate = DateTime.Now;
            //openseaHis.ColumnName = "公海";
            //openseaHis.CustomerId = int.Parse(CustomerInfo_edit.CustomerId);
            //openseaHis.NewValue = "进入公海";
            //openseaHis.OldValue = "销售私有";
            //openseaHis.PersonName = LoginSession.GetCurrentUser(this.Page).RealName;
            //customerService.AddChangeHistory(new HistoryDO[1] { openseaHis });

            AddLoadMessage("您已经把该客户扔进公海");
            CustomerDataBind();
        }
        /// <summary>
        /// 新增一条拜访记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_addRecord_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData("select * from _Customers where id=" + CustomerInfo_edit.CustomerId, ds, CustomersData._CUSTOMERS_TABLE);
            //dataCommon.GetAllData("select top 1 * from _VisitRecord", ds, VisitRecordData._VISITRECORD_TABLE);
            //dataCommon.GetAllData(string.Format("select * from _VisitPlan where CustomerId={0} and PlanType=1 and PlanStatus='{1}'", CustomerInfo_edit.CustomerId, CustomerService.PLANSTATUS_PENDING), ds, VisitPlanData._VISITPLAN_TABLE);

            //// 修改客户的最近访问信息 [3/10/2009]
            //DataRow dr_customer = ds.Tables[CustomersData._CUSTOMERS_TABLE].Rows[0];
            //dr_customer[CustomersData.LASTVISITDATE_FIELDS] = DateTime.Now;
            //dr_customer[CustomersData.LASTVISITINFO_FIELDS] = VisitRecordInfo_addVisit.Remark;

            //DataRow dr = ds.Tables[VisitRecordData._VISITRECORD_TABLE].NewRow();
            //dr[VisitRecordData.CUSTOMERID_FIELDS] = CustomerInfo_edit.CustomerId;
            //dr[VisitRecordData.PERSONID_FIELDS] = LoginSession.GetCurrentUser(this).PersonId;
            //dr[VisitRecordData.REMARK_FIELDS] = VisitRecordInfo_addVisit.Remark;
            //dr[VisitRecordData.TITLE_FIELDS] = VisitRecordInfo_addVisit.RecordTitle;
            //dr[VisitRecordData.VISITDATE_FIELDS] = VisitRecordInfo_addVisit.VisitDate;
            //ds.Tables[VisitRecordData._VISITRECORD_TABLE].Rows.Add(dr);

            //foreach (DataRow dr_status in ds.Tables[VisitPlanData._VISITPLAN_TABLE].Rows)
            //{
            //    dr_status[VisitPlanData.PLANSTATUS_FIELDS] = CustomerService.PLANSTATUS_VISITED;
            //}
            //DataRow dr_plan = ds.Tables[VisitPlanData._VISITPLAN_TABLE].NewRow();
            //dr_plan[VisitPlanData.CUSTOMERID_FIELDS] = CustomerInfo_edit.CustomerId;
            //dr_plan[VisitPlanData.PERSONID_FIELDS] = LoginSession.GetCurrentUser(this).PersonId;
            //dr_plan[VisitPlanData.PLANSTATUS_FIELDS] = CustomerService.PLANSTATUS_PENDING;
            //dr_plan[VisitPlanData.PLANTYPE_FIELDS] = CustomerService.PLANTYPE_VISITPLAN;
            //dr_plan[VisitPlanData.REMARK_FIELDS] = TextBox_addVisit_nextVisit.Text;
            //dr_plan[VisitPlanData.VISITPLANDATE_FIELDS] = FindPicker(PickerAndCalendar_addVisitRecord_nextVisit).SelectedDate;
            //ds.Tables[VisitPlanData._VISITPLAN_TABLE].Rows.Add(dr_plan);

            //dataCommon.UpdateData(ds);
            //AddLoadMessage("您成功添加了拜访记录");

            VisitRecordInfo_addVisit.Cleanup();
            CustomerDataBind();
        }
        /// <summary>
        /// 点击保存拜访记录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_saveRecord_Click(object sender, EventArgs e)
        {
            string str_vid = Grid_visitRecord.SelectedItems[0].ToArray()[0].ToString();
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select * from _VisitRecord where Id={0}", str_vid), ds, VisitRecordData._VISITRECORD_TABLE);
            //DataRow dr = ds.Tables[VisitRecordData._VISITRECORD_TABLE].Rows[0];

            //dr[VisitRecordData.REMARK_FIELDS] = VisitRecordInfo_editVisitRecord.Remark;
            //dr[VisitRecordData.TITLE_FIELDS] = VisitRecordInfo_editVisitRecord.RecordTitle;
            //dr[VisitRecordData.VISITDATE_FIELDS] = VisitRecordInfo_editVisitRecord.VisitDate;

            dataCommon.UpdateData(ds);
            //VisitRecordDataBind();
            AddLoadMessage("您成功保存了拜访记录");

        }
        /// <summary>
        /// 当用户双击拜访记录时，异步显示数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Callback_visit_Callback(object sender, ComponentArt.Web.UI.CallBackEventArgs e)
        {
            //VisitRecordInfo_editVisitRecord.RecordId = e.Parameter;
            VisitRecordInfo_editVisitRecord.DataBind();
            VisitRecordInfo_editVisitRecord.RenderControl(e.Output);
        }
        /// <summary>
        /// 添加新的项目意向
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_addNewProject_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select top 1 * from _VisitPlan"), ds, VisitPlanData._VISITPLAN_TABLE);
            //DataRow dr = ds.Tables[VisitPlanData._VISITPLAN_TABLE].NewRow();
            //dr[VisitPlanData.CUSTOMERID_FIELDS] = CustomerInfo_edit.CustomerId;
            //dr[VisitPlanData.PERSONID_FIELDS] = LoginSession.GetCurrentUser(this).PersonId;
            //dr[VisitPlanData.PLANSTATUS_FIELDS] = CustomerService.PLANSTATUS_PENDING;
            //dr[VisitPlanData.PLANTYPE_FIELDS] = CustomerService.PLANTYPE_NEWPROJECT;
            //dr[VisitPlanData.REMARK_FIELDS] = TextBox_newproject.Text;
            //dr[VisitPlanData.VISITPLANDATE_FIELDS] = FindPicker(PickerAndCalendar_newproject).SelectedDate;
            //ds.Tables[VisitPlanData._VISITPLAN_TABLE].Rows.Add(dr);
            //dataCommon.UpdateData(ds);
            AddLoadMessage("成功的添加了新项目意向");
            NewProjectDataBind();
        }
        /// <summary>
        /// 销售人员自己从公海中认领客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_apply_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData("select * from _customers where id=" + CustomerInfo_edit.CustomerId, ds, CustomersData._CUSTOMERS_TABLE);
            //DataRow dr = ds.Tables[CustomersData._CUSTOMERS_TABLE].Rows[0];

            //dr[CustomersData.USERID_FIELDS] = LoginSession.GetCurrentUser(this).PersonId;
            //dr[CustomersData.INOPENSEA_FIELDS] = 0;

            //dataCommon.UpdateData(ds);

            //HistoryDO openseaHis = new HistoryDO();
            //openseaHis.ChangeDate = DateTime.Now;
            //openseaHis.ColumnName = "公海";
            //openseaHis.CustomerId = int.Parse(CustomerInfo_edit.CustomerId);
            //openseaHis.NewValue = "销售认领";
            //openseaHis.OldValue = "在公海中";
            //openseaHis.PersonName = LoginSession.GetCurrentUser(this.Page).RealName;
            //customerService.AddChangeHistory(new HistoryDO[1] { openseaHis });

            AddLoadMessage("您成功的认领了此客户");
            CustomerDataBind();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_createOrder_Click(object sender, EventArgs e)
        {
            //FlowStatusDO order_new = flowService.getInitStatus(FlowType.ORDER_APPROVE);
            //_Order order = OrderInfo_create.GetNewOrder();
            //order.OrderStatus = order_new.Id;
            //CustomerDO cus = customerService.GetCustomerById(int.Parse(CustomerInfo_edit.CustomerId));
            //order.CustomerId = cus.Id;
            //order.UserId = cus.UserId;
            //orderService.CreateOrder(order);
            AddLoadMessage("订单已成功创建");
            OrderDataBind();
        }
        protected void Callback_neworder_Callback(object sender, ComponentArt.Web.UI.CallBackEventArgs e)
        {
            //UserDO me = LoginSession.GetCurrentUser(this);
//             if (BitUtil.BitAnd(me.RoleId, RoleService.ROLE_MANAGER))
//             {
//                 OrderInfo_create.CtrlAction = CommandNameType.EDIT;
//             }
            //OrderInfo_create.CustomerId = CustomerInfo_edit.CustomerId;
            ////OrderInfo_create.DataBind();
            //OrderInfo_create.RenderControl(e.Output);
        }
        protected void Button_confirm_shift_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select * from _Customers where Id={0}", CustomerInfo_edit.CustomerId), ds, CustomersData._CUSTOMERS_TABLE);
            if (ds.Tables[0].Rows.Count.Equals(0))
            {
                AddLoadMessage("更新客户信息失败");
                return;
            }

            //CustomerDO cus = customerService.GetCustomerById(int.Parse(CustomerInfo_edit.CustomerId));
            //HistoryDO openseaHis = new HistoryDO();
            //openseaHis.ChangeDate = DateTime.Now;
            //openseaHis.ColumnName = "销售";
            //openseaHis.CustomerId = int.Parse(CustomerInfo_edit.CustomerId);
            //openseaHis.NewValue = SalesList_shift.SalesName;
            //openseaHis.OldValue = userService.GetPersonName( cus.UserId);
            //openseaHis.PersonName = LoginSession.GetCurrentUser(this.Page).RealName;
            //customerService.AddChangeHistory(new HistoryDO[] { openseaHis });

            //DataRow dr = ds.Tables[0].Rows[0];
            //dr[CustomersData.USERID_FIELDS] = SalesList_shift.SalesId;
            //dr[CustomersData.INOPENSEA_FIELDS] = 0;
            //dataCommon.UpdateData(ds);
            
            AddLoadMessage("客户已成功的转移");
            CustomerDataBind();
        }
    }
}
