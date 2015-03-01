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
using Powerson.DataAccess;

namespace Powerson.Web
{
    public partial class Head : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //findFirstFrame();
            //ViewBoard();
        }
        private void findFirstFrame()
        {
            string ret = null;
            DataTable dt_f = null;// LoginSession.GetFrameRank(this);
            if (null == dt_f || dt_f.Rows.Count == 0)
                return;

            DataRow[] drs = dt_f.Select("FrameLevel=1");
            if (drs.Length.Equals(0))
            {
                return;
            }
            //string str_level1Frame = drs[0][FramesData.ID_FIELDS].ToString();
            //DataRow[] level2Frames = dt_f.Select("ParentId=" + str_level1Frame);
            //if (level2Frames.Length.Equals(0))
            //{
            //    return;
            //}
            //ret = level2Frames[0][FramesData.NAVIGATEURL_FIELDS].ToString();
            //AddJavaScript(string.Format("NewUrl('{0}','main');", ret));
        }
        void ViewBoard()
        {
            DataSet ds = new DataSet();
            dataCommon.GetAllData(string.Format("SELECT C.Id, C.CompanyName FROM _CustomerHistory AS H INNER JOIN  _Customers AS C ON H.CustomerId = C.Id WHERE (H.NewValue = '进入公海') AND (C.Inopensea=2) and (H.ChangeDate > '{0}')", DateTime.Now.AddDays(-7).ToShortDateString()), ds, "OpenSea");
            ds.Tables[0].Columns.Add("NavUrl", typeof(String));
            ds.Tables[0].Columns.Add("Text", typeof(String));

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                dr["NavUrl"] = string.Format("Customer_info.aspx?id={0}", dr["id"]);
                dr["Text"] = string.Format("客户 {0} 已进入公海", dr["CompanyName"]);
            }
            HeadlinesRotator.DataSource = ds;
            DataBind();
        }

    }
}
