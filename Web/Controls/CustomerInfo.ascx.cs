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
using Powerson.Web.RailsService;

namespace Powerson.Web.Controls
{
    public partial class CustomerInfo : UserControlBase
    {
        
        protected Customer customer;
        //HistoryDO[] changeHistory;

        protected void Page_Load(object sender, EventArgs e)
        {
            BaseDataBind();
        }
        private void BaseDataBind()
        {
            if (IsFirstLoad)
            {
            }
            if (null == ViewState["DataInit"])
            {
                ValidatorBuild();
                ViewState["DataInit"] = true;
            }
        }
        private void ValidatorBuild()
        {
            string str_valGroup = "";
            //switch (CtrlAction)
            //{
            //    case CommandNameType.NEW:
            //        str_valGroup = "new";
            //        break;
            //    case CommandNameType.EDIT:
            //        str_valGroup = "edit";
            //        TextBox_companyname.ReadOnly = true;
            //        break;
            //    case CommandNameType.LIMITEDIT:
            //        DropDownList_area.Enabled = false;
            //        DropDownList_buyIntent.Enabled = false;
            //        DropDownList_customerRank.Enabled = false;
            //        DropDownList_industryType.Enabled = false;
            //        DropDownList_village.Enabled = false;
            //        DropDownList_visitType.Enabled = false;
            //        break;
            //    default:
            //        break;
            //}
            RequiredFieldValidator_companyName.ValidationGroup = str_valGroup;
            RequiredFieldValidator_keyword.ValidationGroup = str_valGroup;
        }
        public void CustomerDataBind(Customer customer)
        {
            if (null == customer)
                return;

            BaseDataBind();

        //    CustomerDO customer = customerService.GetCustomerById(int.Parse(CustomerId) );

            TextBox_companyname.Text = customer.name;
            TextBox_www.Text = customer.web_site;
            TextBox_contactman.Text = customer.contact_man;
            TextBox_position.Text = customer.position;
            TextBox_tel.Text = customer.tel;
            TextBox_extend.Text = customer.ext;
            TextBox_moblie.Text = customer.mobile;
            TextBox_fax.Text = customer.fax;
            TextBox_email.Text = customer.email;
            TextBox_keyword.Text = customer.keywords;

            FocusItemByText(DropDownList_industryType, customer.industry_type);
            FocusItemByText(DropDownList_buyIntent, customer.buy_intent);
            FocusItemByValue(DropDownList_customerRank, customer.rank_id.ToString());
            FocusItemByText(DropDownList_area, customer.area);
            FocusItemByText(DropDownList_visitType, customer.source);
        //    VillageDataBind();
        //    ListControlUtil.FocusItemByText(DropDownList_village, customer.Village);

            TextBox_address.Text = customer.address;
            TextBox_remark.Text = customer.remark;

        //    ViewState[CustomersData.RANKID_FIELDS] = DropDownList_customerRank.SelectedItem.Text;
        }
        public string CustomerId
        {
            get
            {
                if (null == ViewState["CustomerId"])
                    return null;
                return ViewState["CustomerId"].ToString();
            }
            set
            {
                ViewState["CustomerId"] = value;
                //CustomerDataBind();
            }
        }
        public TdCustomerRequest getCustomerInfo()
        {
            TdCustomerRequest ret = new TdCustomerRequest();
            ret.name = TextBox_companyname.Text;
            ret.web_site = TextBox_www.Text;
            ret.contact_man = TextBox_contactman.Text;
            ret.tel = TextBox_tel.Text.Trim();
            ret.ext = TextBox_extend.Text;
            ret.position = TextBox_position.Text;
            ret.mobile = TextBox_moblie.Text.Trim();
            ret.fax = TextBox_fax.Text.Trim();
            ret.email = TextBox_email.Text.Trim();
            ret.industry_type = DropDownList_industryType.SelectedItem.Text;
            ret.buy_intent = DropDownList_buyIntent.SelectedItem.Text;
            ret.source = DropDownList_visitType.SelectedItem.Text;
            //if (DropDownList_visitType.SelectedIndex > 0)
            //{
            //    ret.VisitType = DropDownList_visitType.SelectedItem.Text;
            //}
            ret.rank_id = int.Parse(DropDownList_customerRank.SelectedValue);
            ret.area = DropDownList_area.SelectedItem.Text;
            //if (DropDownList_village.SelectedIndex > 0)
            //{
            //    ret.Village = DropDownList_village.SelectedItem.Text;
            //}
            ret.address = TextBox_address.Text;
            ret.remark = TextBox_remark.Text;
            ret.keywords = TextBox_keyword.Text;

            //if (CtrlAction == CommandNameType.EDIT)
            //{
            //    if (!ViewState[CustomersData.RANKID_FIELDS].ToString().Equals(DropDownList_customerRank.SelectedItem.Text))
            //    {
            //        HistoryDO rank = new HistoryDO();
            //        rank.ChangeDate = DateTime.Now;
            //        rank.ColumnName = "成熟度";
            //        rank.CustomerId = int.Parse(CustomerId);
            //        rank.NewValue = DropDownList_customerRank.SelectedItem.Text;
            //        rank.OldValue = ViewState[CustomersData.RANKID_FIELDS].ToString();
            //        rank.PersonName = LoginSession.GetCurrentUser(this.Page).RealName;
            //        ChangeHistory[0] = rank;
            //    }
            //}
            return ret;
        }
        public void cleanup()
        {
            TextBox_companyname.Text = "";
            TextBox_www.Text = "";
            TextBox_contactman.Text = "";
            TextBox_tel.Text = "";
            TextBox_extend.Text = "";
            TextBox_position.Text = "";
            TextBox_moblie.Text = "";
            TextBox_fax.Text = "";
            TextBox_email.Text = "";
            TextBox_address.Text = "";
            TextBox_remark.Text = "";
        }
        //private void VillageDataBind()
        //{
        //    DataSet ds = new DataSet();
        //    //dataCommon.GetAllData(string.Format("SELECT * FROM _Village WHERE areaid={0}", DropDownList_area.SelectedValue), ds, VillageData._VILLAGE_TABLE);
        //    //ListControlUtil.DataBind(DropDownList_village.Items, ds.Tables[VillageData._VILLAGE_TABLE], VillageData.ID_FIELDS, VillageData.VILLAGENAME_FIELDS, "<请选择...>");
        //}

        //protected void DropDownList_area_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    VillageDataBind();
        //}

    }
}