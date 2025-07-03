using System;
using System.Web.UI.WebControls;

public partial class stu_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 如果学生未登录，跳转到登录页面
        if (Session["userName"] == null || Session["userId"] == null)
        {
            Response.Redirect("login.aspx");
        }

        // 登录成功后显示学生信息
        Label lblName = (Label)Master.FindControl("Label1");
        Label lblID = (Label)Master.FindControl("Label2");

        lblName.Text = Session["userName"].ToString();
        lblID.Text = Session["userId"].ToString();
    }
}
