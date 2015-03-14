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
using Powerson.DataAccess;
using Powerson.BusinessFacade;
using Powerson.Framework;
using Powerson.Web.RailsService;

namespace Powerson.Web.Controls
{
    public partial class DeptInfo : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BaseInfoBind();
        }
        private void BaseInfoBind()
        {
            if (IsFirstLoad)
            {
                PageDataBind();
                IsFirstLoad = false;
            }
        }
        private void PageDataBind()
        {
            // 取出所有部门信息，并绑定 [9/2/2006]
        }
        public void DeptDataBind(Department dept)
        {
            _TextBoxDepName.Text = dept.name;
            FocusItemByValue(_DropDownListDep, dept.manager_id.ToString());
        }
        public void CleanInput()
        {
            _TextBoxDepName.Text = "";
            //		PageDataBind();
        }

    }
}