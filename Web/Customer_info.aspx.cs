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

namespace Powerson.Web
{
    public partial class Customer_info : AuthPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CustomerDataBind();
            }

        }
        /// <summary>
        /// ��ʾ�ͻ��Ļ�������
        /// </summary>
        void CustomerDataBind()
        {
            //this.form1.
            string str_id = GetQueryString("id");
            if (str_id == null)
            {
                AddLoadMessage("û���ҵ��ͻ���Ϣ");
                return;
            }
            CustomerInfo_edit.CustomerId = str_id;

            //this.thistitle.Text = CustomerInfo_edit.getCustomerInfo().CompanyName;
            
            // ��鰴ť�Ƿ���ʾ [5/27/2009]
            CheckButton();

            VisitRecordDataBind();
            HistoryDataBind();
            OrderDataBind();
            NewProjectDataBind();

            // ��ʾ�ϴεİݷüƻ� [5/24/2009]
            FindPicker(PickerAndCalendar_addVisitRecord_nextVisit).SelectedDate = DateTime.Now.AddDays(1);
            FindPicker(PickerAndCalendar_newproject).SelectedDate = DateTime.Now.AddDays(7);
            TextBox_addVisit_nextVisit.Text = "";
            // ����Ҫ��ʾ��ǰ�İݷüƻ��� [3/5/2009]
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select * from _VisitPlan where CustomerId={0} and PlanType=1 and PlanStatus='{1}' order by Id desc", CustomerInfo_edit.CustomerId, CustomerService.PLANSTATUS_PENDING), ds, VisitPlanData._VISITPLAN_TABLE);
            //if (ds.Tables[VisitPlanData._VISITPLAN_TABLE].Rows.Count == 0)
            //{
            //    Label_visitPlan.Text = "��ʱû�и����ƻ�";
            //}
            //else
            //{
            //    DataRow dr = ds.Tables[VisitPlanData._VISITPLAN_TABLE].Rows[0];
            //    Label_visitPlan.Text = string.Format("���ƻ��� {0} �����ÿͻ�����ע��������Ϣ��<br>{1}", Convert.ToDateTime(dr[VisitPlanData.VISITPLANDATE_FIELDS]).ToShortDateString(), dr[VisitPlanData.REMARK_FIELDS]);
            //}
        }
        /// <summary>
        /// ���ݿͻ�״̬����������ť
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
            //    Button_shift.Visible = true;// ֻ�о������ת�ƿͻ� [8/5/2009]

            //string c_id = GetQueryString("id");
            //CustomerDO cus = customerService.GetCustomerById(int.Parse(c_id));
            //if (cus.InOpenSea == 1)
            //    return;

            //if (cus.InOpenSea == 2)
            //{
            //    // �ж��ǲ����Լ��ӵģ�����ǣ���׼�� [5/28/2009]
            //    bool b_ismine = false;
            //    if (cus.UserId == me.PersonId)
            //        b_ismine = true;
            //    if (b_ismine)
            //        return;
            //    Button_apply.Visible = true;
            //    return;
            //}
            //Button_saveCustomer.Visible = customerService.CanEditCustomer(c_id, me);
            //Button_add_rec.Visible = Button_saveCustomer.Visible;
            //Button_opensea.Visible = Button_saveCustomer.Visible;
            //Button_saveRecord.Visible = Button_saveCustomer.Visible;
            //Button_newproj.Visible = Button_saveCustomer.Visible;
            //// ����ǿͷ��;������Դ������� [7/26/2009]
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
        /// ��ʾ�ͻ��İݷü�¼�б�
        /// </summary>
        void VisitRecordDataBind()
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select V.*,P.Name from _VisitRecord V,_PersonalInfo P where V.PersonId=P.Id and V.CustomerId={0} order by V.VisitDate desc", CustomerInfo_edit.CustomerId), ds, VisitRecordData._VISITRECORD_TABLE);

            //Grid_visitRecord.DataSource = ds.Tables[VisitRecordData._VISITRECORD_TABLE];
            //Grid_visitRecord.DataBind();
        }
        /// <summary>
        /// ��ʾ�ͻ�����ʷ�����¼
        /// </summary>
        void HistoryDataBind()
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select * from _CustomerHistory where CustomerId={0} order by Id desc", CustomerInfo_edit.CustomerId), ds, CustomerHistoryData._CUSTOMERHISTORY_TABLE);
            //Grid_history.DataSource = ds.Tables[CustomerHistoryData._CUSTOMERHISTORY_TABLE];
            //Grid_history.DataBind();
        }
        /// <summary>
        /// ��ʾ����ͻ��Ѿ�ǩ�Ķ���
        /// </summary>
        void OrderDataBind()
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select O.*,P.Name from _Orders O,_PersonalInfo P where O.UserId=P.Id and O.customerId={0}", CustomerInfo_edit.CustomerId), ds, OrderData._ORDERS_TABLE);
            //GridView_order.DataSource = ds.Tables[OrderData._ORDERS_TABLE];
            //GridView_order.DataBind();
        }
        /// <summary>
        /// ��ʾ����ͻ�����������Ŀ����
        /// </summary>
        void NewProjectDataBind()
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select V.*,P.Name from _VisitPlan V,_PersonalInfo P where V.PersonId=P.Id and V.CustomerId={0} and V.PlanType=3", CustomerInfo_edit.CustomerId), ds, VisitPlanData._VISITPLAN_TABLE);
            //GridView_newproj.DataSource = ds.Tables[VisitPlanData._VISITPLAN_TABLE];
            //GridView_newproj.DataBind();
        }
        /// <summary>
        /// ����ͻ��Ļ�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_saveCustomer_Click(object sender, System.EventArgs e)
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select * from _Customers where Id={0}", CustomerInfo_edit.CustomerId), ds, CustomersData._CUSTOMERS_TABLE);
            //if (ds.Tables[0].Rows.Count.Equals(0))
            //{
            //    AddLoadMessage("���¿ͻ���Ϣʧ��");
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
            AddLoadMessage("�ͻ���Ϣ���ɹ�����");
        }
        /// <summary>
        /// ȷ�Ͻ��ͻ��ӽ�����
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
            //dr[CustomersData.REMARK_FIELDS] = string.Format("----�����ӽ�������ԭ��----\r\n{0}\r\n-----------end----------\r\n{1}", TextBox_opensea_reason.Text,  dr[CustomersData.REMARK_FIELDS]);
            //dataCommon.UpdateData(ds);
            //// ���һ����ʷ��¼ [3/10/2009]
            //HistoryDO openseaHis = new HistoryDO();
            //openseaHis.ChangeDate = DateTime.Now;
            //openseaHis.ColumnName = "����";
            //openseaHis.CustomerId = int.Parse(CustomerInfo_edit.CustomerId);
            //openseaHis.NewValue = "���빫��";
            //openseaHis.OldValue = "����˽��";
            //openseaHis.PersonName = LoginSession.GetCurrentUser(this.Page).RealName;
            //customerService.AddChangeHistory(new HistoryDO[1] { openseaHis });

            AddLoadMessage("���Ѿ��Ѹÿͻ��ӽ�����");
            CustomerDataBind();
        }
        /// <summary>
        /// ����һ���ݷü�¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_addRecord_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData("select * from _Customers where id=" + CustomerInfo_edit.CustomerId, ds, CustomersData._CUSTOMERS_TABLE);
            //dataCommon.GetAllData("select top 1 * from _VisitRecord", ds, VisitRecordData._VISITRECORD_TABLE);
            //dataCommon.GetAllData(string.Format("select * from _VisitPlan where CustomerId={0} and PlanType=1 and PlanStatus='{1}'", CustomerInfo_edit.CustomerId, CustomerService.PLANSTATUS_PENDING), ds, VisitPlanData._VISITPLAN_TABLE);

            //// �޸Ŀͻ������������Ϣ [3/10/2009]
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
            //AddLoadMessage("���ɹ�����˰ݷü�¼");

            VisitRecordInfo_addVisit.Cleanup();
            CustomerDataBind();
        }
        /// <summary>
        /// �������ݷü�¼��ť
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
            VisitRecordDataBind();
            AddLoadMessage("���ɹ������˰ݷü�¼");

        }
        /// <summary>
        /// ���û�˫���ݷü�¼ʱ���첽��ʾ����
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
        /// ����µ���Ŀ����
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
            AddLoadMessage("�ɹ������������Ŀ����");
            NewProjectDataBind();
        }
        /// <summary>
        /// ������Ա�Լ��ӹ���������ͻ�
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
            //openseaHis.ColumnName = "����";
            //openseaHis.CustomerId = int.Parse(CustomerInfo_edit.CustomerId);
            //openseaHis.NewValue = "��������";
            //openseaHis.OldValue = "�ڹ�����";
            //openseaHis.PersonName = LoginSession.GetCurrentUser(this.Page).RealName;
            //customerService.AddChangeHistory(new HistoryDO[1] { openseaHis });

            AddLoadMessage("���ɹ��������˴˿ͻ�");
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
            AddLoadMessage("�����ѳɹ�����");
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
                AddLoadMessage("���¿ͻ���Ϣʧ��");
                return;
            }

            //CustomerDO cus = customerService.GetCustomerById(int.Parse(CustomerInfo_edit.CustomerId));
            //HistoryDO openseaHis = new HistoryDO();
            //openseaHis.ChangeDate = DateTime.Now;
            //openseaHis.ColumnName = "����";
            //openseaHis.CustomerId = int.Parse(CustomerInfo_edit.CustomerId);
            //openseaHis.NewValue = SalesList_shift.SalesName;
            //openseaHis.OldValue = userService.GetPersonName( cus.UserId);
            //openseaHis.PersonName = LoginSession.GetCurrentUser(this.Page).RealName;
            //customerService.AddChangeHistory(new HistoryDO[] { openseaHis });

            //DataRow dr = ds.Tables[0].Rows[0];
            //dr[CustomersData.USERID_FIELDS] = SalesList_shift.SalesId;
            //dr[CustomersData.INOPENSEA_FIELDS] = 0;
            //dataCommon.UpdateData(ds);
            
            AddLoadMessage("�ͻ��ѳɹ���ת��");
            CustomerDataBind();
        }
    }
}
