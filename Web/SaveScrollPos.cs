using System;
using System.Data;

namespace Powerson.Web
{
	/// <summary>
	/// Summary description for ForumJump.
	/// </summary>
	public class SaveScrollPos : System.Web.UI.Control, System.Web.UI.IPostBackDataHandler
	{
		private int ScrollPos 
		{
			get 
			{
				return ViewState["ScrollPos"]!=null ? (int)ViewState["ScrollPos"] : 0;
			}
			set 
			{
				ViewState["ScrollPos"] = value;
			}
		}

		#region IPostBackDataHandler
		public virtual bool LoadPostData(string postDataKey,System.Collections.Specialized.NameValueCollection postCollection) 
		{
			ScrollPos = int.Parse(postCollection[postDataKey]);
			return false;
		}

		public virtual void RaisePostDataChangedEvent() 
		{
		}
		#endregion

		protected override void OnPreRender(EventArgs e)
		{
			if(!Page.ClientScript.IsStartupScriptRegistered("scrollToPos"))
                Page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "scrollToPos", String.Format("<script language='javascript'>scrollTo(0,{0});</script>", ScrollPos));

            if (!Page.ClientScript.IsClientScriptBlockRegistered("doScroll"))
                Page.ClientScript.RegisterClientScriptBlock(typeof(System.Web.UI.Page), "doScroll",
					"<script language='javascript'>\n"+
					"onscroll=function(){\n"+
					"	document.getElementById('" + this.UniqueID + "').value=document.body.scrollTop;\n"+
					"}\n"+
					"</script>");
			base.OnPreRender(e);
		}

		protected override void Render(System.Web.UI.HtmlTextWriter writer) 
		{
			writer.WriteLine(String.Format("<input type='hidden' name='{0}' id='{0}' value='{1}'/>",this.UniqueID,ScrollPos));
		}
	}
}
