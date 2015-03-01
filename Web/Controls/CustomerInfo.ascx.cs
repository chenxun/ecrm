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
        
        protected Customer dataSource;
        //HistoryDO[] changeHistory;

        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList_area.DataBind();
            BaseDataBind();
        }
        private void BaseDataBind()
        {

            if (null == ViewState["DataInit"])
            {
                DropDownListBind();
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
        private void DropDownListBind()
        {
            //DropDownList_area.DataBind();
            //DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("SELECT * FROM [_IndustryType]"), ds, IndustryTypeData._INDUSTRYTYPE_TABLE);
            //ListControlUtil.DataBind(DropDownList_industryType.Items, ds.Tables[IndustryTypeData._INDUSTRYTYPE_TABLE], IndustryTypeData.ID_FIELDS, IndustryTypeData.TYPENAME_FIELDS, null);

            //dataCommon.GetAllData(string.Format("SELECT * FROM [_BuyIntent]"), ds, BuyIntentData._BUYINTENT_TABLE);
            //ListControlUtil.DataBind(DropDownList_buyIntent.Items, ds.Tables[BuyIntentData._BUYINTENT_TABLE], BuyIntentData.ID_FIELDS, BuyIntentData.INTENTNAME_FIELDS, null);

            ////ds = dataCommon.GetAllData("SELECT [VT_id], [VT_type] FROM [VisitType]");
            ////ListControlUtil.DataBind(_DropDownListVisitType.Items, ds.Tables[0], "VT_id", "VT_type", "<请选择...>");

            //dataCommon.GetAllData(string.Format("SELECT * FROM [_CustomerRank]"), ds, CustomerRankData._CUSTOMERRANK_TABLE);
            //ListControlUtil.DataBind(DropDownList_customerRank.Items, ds.Tables[CustomerRankData._CUSTOMERRANK_TABLE], CustomerRankData.ID_FIELDS, CustomerRankData.RANKNAME_FIELDS, null);

            //dataCommon.GetAllData(string.Format("SELECT * FROM [_area]"), ds, AreaData._AREA_TABLE);
            //ListControlUtil.DataBind(DropDownList_area.Items, ds.Tables[AreaData._AREA_TABLE], AreaData.ID_FIELDS, AreaData.AREANAME_FIELDS, null);
            //VillageDataBind();

        }
        private void CustomerDataBind()
        {
            if (null == CustomerId)
                return;

            BaseDataBind();

        //    CustomerDO customer = customerService.GetCustomerById(int.Parse(CustomerId) );

        //    TextBox_companyname.Text = customer.CompanyName;
        //    TextBox_www.Text = customer.Website;
        //    TextBox_contactman.Text = customer.ContactMan;
        //    TextBox_position.Text = customer.Position;
        //    TextBox_tel.Text = customer.Tel;
        //    TextBox_extend.Text = customer.Extension;
        //    TextBox_moblie.Text = customer.Mobile;
        //    TextBox_fax.Text = customer.Fax;
        //    TextBox_email.Text = customer.Email;
        //    TextBox_keyword.Text = customer.Keywords;

        //    ListControlUtil.FocusItemByText(DropDownList_industryType, customer.IndustryType);

        //    ListControlUtil.FocusItemByText( DropDownList_buyIntent, customer.BuyIntent);
        //    ListControlUtil.FocusItemByValue( DropDownList_customerRank, customer.RankId.ToString());
        //    ListControlUtil.FocusItemByText( DropDownList_area, customer.Area);
        //    ListControlUtil.FocusItemByText(DropDownList_visitType, customer.VisitType);
        //    VillageDataBind();
        //    ListControlUtil.FocusItemByText(DropDownList_village, customer.Village);

        //    TextBox_address.Text = customer.Address;
        //    TextBox_remark.Text = customer.Remark;

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
                CustomerDataBind();
            }
        }
        public Customer getCustomerInfo()
        {
            Customer ret = new Customer();
            //ret.CompanyName = TextBox_companyname.Text;
            //ret.Website = TextBox_www.Text;
            //ret.ContactMan = TextBox_contactman.Text;
            //ret.Tel = TextBox_tel.Text;
            //ret.Extension = TextBox_extend.Text;
            //ret.Position = TextBox_position.Text;
            //ret.Mobile = TextBox_moblie.Text;
            //ret.Fax = TextBox_fax.Text;
            //ret.Email = TextBox_email.Text;
            //ret.IndustryType = DropDownList_industryType.SelectedItem.Text;
            //ret.BuyIntent = DropDownList_buyIntent.SelectedItem.Text;
            //if (DropDownList_visitType.SelectedIndex > 0)
            //{
            //    ret.VisitType = DropDownList_visitType.SelectedItem.Text;
            //}
            //ret.RankId = int.Parse(DropDownList_customerRank.SelectedValue);
            //ret.Area = DropDownList_area.SelectedItem.Text;
            //if (DropDownList_village.SelectedIndex > 0)
            //{
            //    ret.Village = DropDownList_village.SelectedItem.Text;
            //}
            //ret.Address = TextBox_address.Text;
            //ret.Remark = TextBox_remark.Text;
            //ret.Keywords = TextBox_keyword.Text;

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
        private void VillageDataBind()
        {
            DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("SELECT * FROM _Village WHERE areaid={0}", DropDownList_area.SelectedValue), ds, VillageData._VILLAGE_TABLE);
            //ListControlUtil.DataBind(DropDownList_village.Items, ds.Tables[VillageData._VILLAGE_TABLE], VillageData.ID_FIELDS, VillageData.VILLAGENAME_FIELDS, "<请选择...>");
        }

        protected void DropDownList_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            VillageDataBind();
        }

    }
}