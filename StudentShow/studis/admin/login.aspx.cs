using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class admin_login : System.Web.UI.Page
{
    public SDM.BLL.AdminInfo bll = new SDM.BLL.AdminInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        // 如果已经登录，直接跳转到首页
        if (Session["AdminName"] != null && Session["AdminID"] != null)
        {
            Response.Redirect("index.aspx");
        }
    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string adminName = txtUserName.Text.Trim();
        string adminPass = txtUserPass.Text.Trim();

        SDM.BLL.AdminInfo bll = new SDM.BLL.AdminInfo();
        DataSet ds = bll.GetLogin(adminName, adminPass);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["AdminName"] = ds.Tables[0].Rows[0]["AdminName"].ToString();
            Session["AdminID"] = ds.Tables[0].Rows[0]["AdminID"].ToString();

            // ✅ 跳转管理员首页
            Response.Redirect("index.aspx");
        }
        else
        {
            lblMsg.Text = "账号或密码错误！";
        }
    }

}