using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class stu_Person : System.Web.UI.Page
{
    public SDM.BLL.StudentInfo bll = new SDM.BLL.StudentInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 获取 session 中保存的 userId（学生学号是 string 类型）
            string userId = Session["userId"]?.ToString();

            if (!string.IsNullOrEmpty(userId))
            {
                // 获取数据
                DataSet ds = bll.GetStudentInfo(userId);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    lblName.Text = row["UserName"].ToString();
                    lblSex.Text = row["UserSex"].ToString();
                    lblNumber.Text = row["UserNumber"].ToString();
                    lblXy.Text = row["UserXy"].ToString();
                    lblZy.Text = row["UserZy"].ToString();
                    lblBj.Text = row["UserBj"].ToString();
                }
            }
        }
    }


}