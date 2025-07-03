using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class stu_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null)
        {
            Response.Redirect("login.aspx");
            return;
        }

        int userId = Convert.ToInt32(Session["userId"]);
        SDM.BLL.StudentInfo bll = new SDM.BLL.StudentInfo();
        DataTable dt = bll.GetStudentById(userId);

        if (dt != null && dt.Rows.Count > 0)
        {
            Label1.Text = dt.Rows[0]["UserName"].ToString();
            Label2.Text = dt.Rows[0]["UserNumber"].ToString();  // 学号
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Clear(); // 清空学生登录状态
        Response.Redirect("login.aspx"); // 跳转到学生登录页
    }
}

