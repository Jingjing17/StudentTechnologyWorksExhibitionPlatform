using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 如果没有登录信息，跳转回登录页
        if (Session["AdminName"] == null || Session["AdminID"] == null)
        {
            Response.Redirect("login.aspx");
            return;
        }

        Label1.Text = Session["AdminName"].ToString();
        Label2.Text = Session["AdminID"].ToString();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Clear(); // 清除所有Session
        Response.Redirect("login.aspx"); // 跳转到管理员登录页
    }

}

