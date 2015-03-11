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
    public partial class VisitRecordInfo : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BaseInfoBind();
        }
        private void BaseInfoBind()
        {
            if (IsFirstLoad)
            {
                FindPicker(PickerAndCalendar_visitDate).SelectedDate = DateTime.Now;
                IsFirstLoad = true;
            }
        }
        //public string RecordId
        //{
        //    set
        //    {
        //        ViewState["RecordId"] = value;
        //        VisitInfoBind();
        //    }
        //    get
        //    {
        //        if (null == ViewState["RecordId"])
        //            return null;
        //        return ViewState["RecordId"].ToString();
        //    }
        //}
        public void VisitInfoBind(VisitRecord record)
        {
            //if (null == RecordId)
            //    return;

            BaseInfoBind();

            //DataSet ds = new DataSet();
            //dataCommon.GetAllData(string.Format("select * from _VisitRecord where Id={0}", RecordId), ds, VisitRecordData._VISITRECORD_TABLE);

            //if (ds.Tables[VisitRecordData._VISITRECORD_TABLE].Rows.Count == 0)
            //    throw new Exception(string.Format("没有找到ID是{0}的拜访记录", RecordId));

            //DataRow dr = ds.Tables[VisitRecordData._VISITRECORD_TABLE].Rows[0];

            FocusItemByText(DropDownList_type, record.title);
            TextBox_remark.Text = record.remark;
            FindPicker(PickerAndCalendar_visitDate).SelectedDate = record.visit_date;
            //cal_visit = (ComponentArt.Web.UI.Calendar)PickerAndCalendar_visitDate.FindControl("Picker1");
            //cal_visit.SelectedDate = Convert.ToDateTime(dr[VisitRecordData.VISITDATE_FIELDS]);
            //PersonId = dr[VisitRecordData.PERSONID_FIELDS].ToString();
        }
        public void Cleanup()
        {
            TextBox_remark.Text = "";
            FindPicker(PickerAndCalendar_visitDate).SelectedDate = DateTime.Now;
            DropDownList_type.SelectedIndex = 0;
        }
        public VisitRecord GetRecord()
        {
            VisitRecord ret = new VisitRecord();
            ret.title = DropDownList_type.SelectedItem.Text;
            ret.visit_date = FindPicker(PickerAndCalendar_visitDate).SelectedDate;
            ret.remark = TextBox_remark.Text;
            return ret;
        }
    }
}