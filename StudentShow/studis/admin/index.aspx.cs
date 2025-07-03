using System;
using System.Web.UI.WebControls;


public partial class admin_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 如果管理员未登录，跳转到登录页面
        if (Session["AdminName"] == null || Session["AdminID"] == null)
        {
            Response.Redirect("login.aspx");
        }

        // 登录成功后显示管理员信息
        Label lblName = (Label)Master.FindControl("Label1");
        Label lblID = (Label)Master.FindControl("Label2");

        lblName.Text = Session["AdminName"].ToString();
        lblID.Text = Session["AdminID"].ToString();
    }

}

