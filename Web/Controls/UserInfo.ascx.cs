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
    public partial class UserInfo : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BaseDataBind();
        }
        private void BaseDataBind()
        {
            if (null == ViewState["DataInit"])
            {
                PageDataBind();
                ViewState["DataInit"] = true;
            }
        }
        private void PageDataBind()
        {
            Role[] roles = userService.GetRolesAll();
            _CheckBoxListRole.DataSource = roles;
            //dataCommon.GetAllData("SELECT * FROM _Roles ORDER BY RoleName", ds, RolesData._ROLES_TABLE);
            //ListControlUtil.DataBind(_CheckBoxListRole.Items, ds.Tables[RolesData._ROLES_TABLE], RolesData.ROLEKEY_FIELDS, RolesData.ROLENAME_FIELDS, null);

            //dataCommon.GetAllData("SELECT * FROM [_Users] WHERE RoleId=-1 ORDER BY RealName", ds, UsersData._USERS_TABLE);
            //ListControlUtil.DataBind(_DropDownListDep.Items, ds.Tables[UsersData._USERS_TABLE], UsersData.ID_FIELDS, UsersData.USERNAME_FIELDS, "<请选择部门...>");

            //dataCommon.GetAllData("select [id],[name] from [_PersonalInfo] order by [name]", ds, PersonalInfoData._PERSONALINFO_TABLE);
            //ListControlUtil.DataBind(DropDownList_person.Items, ds.Tables[PersonalInfoData._PERSONALINFO_TABLE], "id", PersonalInfoData.NAME_FIELDS, null);
        }
        public void UserDataBind(User user)
        {
            //BaseDataBind();
            _TextBoxUserName.ReadOnly = true;

            _TextBoxUserName.Text = user.name;
            //_TextBoxRealName.Text = dataSource.RealName;
            FocusItemByValue(DropDownList_person, user.person_id.ToString());
            // 绑定角色信息 [6/14/2008]
            Role[] myroles = userService.GetRolesByUserId(user.id);
            foreach (ListItem item in _CheckBoxListRole.Items)
            {
                foreach (Role role in myroles)
                {
                    if (item.Value.Equals(role.role_key))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }

        public string UserName
        {
            get
            {
                return _TextBoxUserName.Text.TrimEnd();
            }
        }

        public string RealName
        {
            get
            {
                return _TextBoxRealName.Text.TrimEnd();
            }
        }
        public int RoleId
        {
            get
            {
                int i_role = 0;
                foreach (ListItem item in _CheckBoxListRole.Items)
                {
                    if (item.Selected)
                    {
                        i_role = BitUtil.BitOr(i_role, Convert.ToInt32(item.Value));
                    }
                }
                return i_role;
            }
        }

        public int DepId
        {
            get
            {
                return 0;
            }
        }
        public int PersonId
        {
            get
            {
                return Convert.ToInt32(DropDownList_person.SelectedValue);
            }
        }
        public void CleanInput()
        {
            _TextBoxUserName.Text = "";
            _CheckBoxListRole.ClearSelection();
        }

    }
}