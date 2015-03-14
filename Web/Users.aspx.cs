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
using Powerson.DataAccess;
using Powerson.Framework;
using Powerson.Web.RailsService;

namespace Powerson.Web
{
    public partial class Users : AuthPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                tUserInfo.Visible = false;
                tDepInfo.Visible = false;
                _ButtonDelDep.Attributes["onclick"] = "JavaScript:return confirm('ȷ��ɾ����');";
                TreeViewBind();
            }

        }
        #region ���Ϳؼ��Ĵ���
        private void TreeViewBind()
        {
            _TreeViewUser.Nodes.Clear();
            //TdUserResult res = userService.GetUsersAll();
            //if (!res.result)
            //{
            //    return;
            //}
            User root = new User();
            root.id = 0;
            root.name = "Root";
            ComponentArt.Web.UI.TreeViewNode root_node = CreateNode(root, false);
            _TreeViewUser.Nodes.Add(root_node);
            PopulateSubTree(root, root_node);
            

            //DataSet dsU = new DataSet();
            //dataCommon.GetAllData("SELECT * FROM [_Users] ORDER BY [RoleId], [RealName]", dsU, UsersData._USERS_TABLE);
            
            //dsU.Relations.Add("NodeRelation", dsU.Tables[0].Columns[UsersData.ID_FIELDS], dsU.Tables[0].Columns[UsersData.PARENTID_FIELDS]);
            //foreach (User user in res.users)
            //{
            //    if (user.manager_id.Equals(0))
            //    {
            //        ComponentArt.Web.UI.TreeViewNode newNode;
            //        newNode = CreateNode(user, false);
            //        //_TreeViewUser.Nodes.Add(newNode);
            //        //PopulateSubTree(drU, newNode);
            //    }
            //}
        }

        private ComponentArt.Web.UI.TreeViewNode CreateNode(User u, bool isuser)
        {
            ComponentArt.Web.UI.TreeViewNode node = new ComponentArt.Web.UI.TreeViewNode();
            node.Value = u.id.ToString();
            node.Text = u.name;
            if (isuser)
            {
                node.Expanded = false;
                node.ImageUrl = "contacts.gif";
                node.ToolTip = "�û�";
                node.DroppingEnabled = true;
                node.DraggingEnabled = true;
            }
            else
            {
                node.Expanded = true;
                node.ImageUrl = "mailbox.gif";
                node.DroppingEnabled = true;
                node.DraggingEnabled = false;
            }

            return node;
        }

        private void PopulateSubTree(User user, ComponentArt.Web.UI.TreeViewNode node)
        {

            ComponentArt.Web.UI.TreeViewNode childNode;
            TdUserResult res = userService.GetSoldiers(user.id);
            if (!res.result)
                return;
            foreach (User soldier in res.users)
            {
                childNode = CreateNode(soldier, true);
                node.Nodes.Add(childNode);
                this.PopulateSubTree(soldier, childNode);
            }
        }
        protected void TreeViewUser_NodeSelected(object sender, ComponentArt.Web.UI.TreeViewNodeEventArgs e)
        {
            //UserDO user = userService.getUserById(Convert.ToInt32(e.Node.Value));
            //if (user.RoleId.Equals(-1))
            //{
            //    tUserInfo.Visible = false;
            //    tDepInfo.Visible = true;
            //    _DeptInfo.DeptDataSource = user;
            //    if (userService.HasChild(e.Node.Value))
            //    {
            //        _ButtonDelDep.Enabled = false;
            //    }
            //    else
            //    {
            //        _ButtonDelDep.Enabled = true;
            //    }
            //}
            //else
            //{
            //    tUserInfo.Visible = true;
            //    tDepInfo.Visible = false;
            //    _UserInfo.UserDataSource = user;
            //}
        }

        protected void TreeViewUser_NodeMoved(object sender, ComponentArt.Web.UI.TreeViewNodeMovedEventArgs e)
        {
            DataSet dsU = new DataSet();
            //dataCommon.GetAllData("SELECT * FROM [_Users] WHERE Id=" + e.Node.Value, dsU, UsersData._USERS_TABLE);
            //dsU.Tables[0].Rows[0][UsersData.PARENTID_FIELDS] = e.Node.ParentNode.Value;
            //dataCommon.UpdateData(dsU);
        }

        #endregion
        #region ��ť�¼�
        protected void ButtonSaveUser_Click(object sender, System.EventArgs e)
        {
            //DataSet dsU = new DataSet();
            //dataCommon.GetAllData("SELECT * FROM [_Users] WHERE Id=" + _TreeViewUser.SelectedNode.Value, dsU, UsersData._USERS_TABLE);

            //DataRow drNew = dsU.Tables[0].Rows[0];
            //drNew[UsersData.REALNAME_FIELDS] = _UserInfo.RealName;
            //drNew[UsersData.ROLEID_FIELDS] = _UserInfo.RoleId;
            //drNew[UsersData.PERSONID_FIELDS] = _UserInfo.PersonId;
            //dataCommon.UpdateData(dsU);
            //TreeViewBind();
            //tUserInfo.Visible = false;
            AddLoadMessage("���Ѿ��ɹ��������û���Ϣ��");
        }
        protected void ButtonInitPass_Click(object sender, System.EventArgs e)
        {
            //string str_initPass = Properties.Settings.Default.INITIALPASSWORD;
            //userService.UpdatePassword(Convert.ToInt32(_TreeViewUser.SelectedNode.Value), str_initPass);
            //tUserInfo.Visible = false;
            //AddLoadMessage("�û��������ѱ�����Ϊ " + str_initPass);
            return;

        }
        protected void ButtonSaveDep_Click(object sender, System.EventArgs e)
        {
            //DataSet dsU = new DataSet();
            //dataCommon.GetAllData("SELECT * FROM [_Users] WHERE Id=" + _TreeViewUser.SelectedNode.Value, dsU, UsersData._USERS_TABLE);

            //DataRow drNew = dsU.Tables[0].Rows[0];
            //drNew[UsersData.REALNAME_FIELDS] = _DeptInfo.DeptName;
            //drNew[UsersData.USERNAME_FIELDS] = _DeptInfo.DeptName;
            //dataCommon.UpdateData(dsU);
            //TreeViewBind();
            //tDepInfo.Visible = false;
            AddLoadMessage("���Ѿ��ɹ������˲�����Ϣ��");

        }

        protected void ButtonDelDep_Click(object sender, System.EventArgs e)
        {
            DeleteUser(Convert.ToInt32(_TreeViewUser.SelectedNode.Value));
            tDepInfo.Visible = false;
        }

        private void DeleteUser(int userId)
        {
            dataCommon.ExecuteSql("DELETE FROM _Users WHERE Id=" + userId);
            TreeViewBind();
        }


        protected void Button_addDept_Click(object sender, EventArgs e)
        {
            //if (DeptInfo_add.ParentId != 0)
            //{
            //    if (userService.HasChild(DeptInfo_add.ParentId.ToString()))
            //    {
            //        AddLoadMessage("��������һ��ӵ��Ա���Ĳ������ٽ����š���ѡ����һ���ϼ����š�");
            //        return;
            //    }
            //}
            //DataSet dsD = new DataSet();
            //dataCommon.GetAllData("SELECT TOP 1 * FROM [_Users]", dsD, UsersData._USERS_TABLE);

            //DataRow drNew = dsD.Tables[0].NewRow();
            //if (DeptInfo_add.ParentId == 0)
            //{
            //    drNew[UsersData.PARENTID_FIELDS] = DBNull.Value;
            //}
            //else
            //{
            //    drNew[UsersData.PARENTID_FIELDS] = DeptInfo_add.ParentId;
            //}
            //drNew[UsersData.ROLEID_FIELDS] = -1;
            //drNew[UsersData.USERNAME_FIELDS] = DeptInfo_add.DeptName;
            //drNew[UsersData.PASSWORD_FIELDS] = "";
            //drNew[UsersData.INUSING_FIELDS] = true;
            //dsD.Tables[0].Rows.Add(drNew);
            //dataCommon.UpdateData(dsD);
            //AddLoadMessage("��ӳɹ��������Լ�����ӡ�");
            //DeptInfo_add.CleanInput();
            //TreeViewBind();
            return;
        }


        protected void Button_addUser_Click(object sender, EventArgs e)
        {
            DataSet dsU = new DataSet();
            //dataCommon.GetAllData("SELECT * FROM [_Users]", dsU, UsersData._USERS_TABLE);

            //foreach (DataRow drU in dsU.Tables[0].Rows)
            //{
            //    if (drU[UsersData.USERNAME_FIELDS].ToString().ToLower().Equals(UserInfo_add.UserName.ToLower()))
            //    {
            //        AddLoadMessage("ϵͳ���Ѿ�������ͬ�ĵ�¼����");
            //        return;
            //    }
            //}

            //DataRow drNew = dsU.Tables[0].NewRow();
            //if (UserInfo_add.DepId != 0)
            //{
            //    drNew[UsersData.PARENTID_FIELDS] = UserInfo_add.DepId;
            //}
            //drNew[UsersData.PASSWORD_FIELDS] = StringUtil.MD5Hash(Properties.Settings.Default.INITIALPASSWORD);
            //drNew[UsersData.REALNAME_FIELDS] = UserInfo_add.RealName;
            //drNew[UsersData.ROLEID_FIELDS] = UserInfo_add.RoleId;
            //drNew[UsersData.USERNAME_FIELDS] = UserInfo_add.UserName.ToLower();
            //drNew[UsersData.INUSING_FIELDS] = true;
            //drNew[UsersData.PERSONID_FIELDS] = UserInfo_add.PersonId;
            //dsU.Tables[0].Rows.Add(drNew);
            //dataCommon.UpdateData(dsU);
            //AddLoadMessage("�û��½��ɹ����������ӡ�");
            //UserInfo_add.CleanInput();
            TreeViewBind();
            return;
        }
        #endregion
    }
}
