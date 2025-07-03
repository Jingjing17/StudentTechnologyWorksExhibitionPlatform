using System;
using System.Data;
using System.Web.UI;

public partial class stu_login : System.Web.UI.Page
{
    public SDM.BLL.StudentInfo bll = new SDM.BLL.StudentInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        // 如果已经登录，直接跳转到学生首页
        if (Session["userName"] != null && Session["userId"] != null)
        {
            Response.Redirect("index.aspx");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string studentName = txtUserName.Text.Trim();
        string studentPass = txtUserPass.Text.Trim();

        // 通过学号和密码查询学生信息
        DataSet ds = bll.GetLogin(studentName, studentPass);

        if (ds.Tables[0].Rows.Count > 0)
        {
            // 设置 Session
            Session["userName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
            Session["userId"] = ds.Tables[0].Rows[0]["UserID"].ToString();
            Session["UserNumber"] = ds.Tables[0].Rows[0]["UserNumber"].ToString();

            // 登录成功后跳转到学生首页
            Response.Redirect("index.aspx");
        }
        else
        {
            lblMsg.Text = "账号或密码错误！";
        }
    }
}
