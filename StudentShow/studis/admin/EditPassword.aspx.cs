using System;
using System.Web.UI;
using System.Data;

public partial class admin_EditPassword : System.Web.UI.Page
{
    SDM.BLL.AdminInfo bll = new SDM.BLL.AdminInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (int.TryParse(Request.QueryString["AdminID"], out int adminId))
            {
                SDM.BLL.AdminInfo bll = new SDM.BLL.AdminInfo();
                DataSet ds = bll.GetAdminList();
                DataRow[] rows = ds.Tables[0].Select("AdminID = " + adminId);

                if (rows.Length > 0)
                {
                    txtUsername.Text = rows[0]["AdminName"].ToString(); // 默认显示原用户名
                }
            }
        }
    }

    protected void btnUpdatePassword_Click(object sender, EventArgs e)
    {
        int adminId = Convert.ToInt32(Request.QueryString["AdminID"]);
        string originalUsername = txtUsername.Text.Trim();
        string currentPassword = txtCurrentPassword.Text.Trim();
        string newPassword = txtNewPassword.Text.Trim();
        string confirmPassword = txtConfirmPassword.Text.Trim();

        if (newPassword != confirmPassword)
        {
            lblPasswordStatus.Text = "新密码和确认密码不一致！";
            return;
        }

        SDM.BLL.AdminInfo bll = new SDM.BLL.AdminInfo();
        if (!bll.ValidateOldPassword(adminId, currentPassword))
        {
            lblPasswordStatus.Text = "当前密码错误！";
            return;
        }

        // 获取原来的用户名
        string oldUsername = GetOldUsername(adminId);
        if (originalUsername != oldUsername)
        {
            // 修改用户名 + 密码
            if (bll.UpdateAdminInfo(adminId, originalUsername, newPassword))
            {
                Response.Redirect("AdminInfo.aspx");
            }
            else
            {
                lblPasswordStatus.Text = "修改失败，请重试！";
            }
        }
        else
        {
            // 只修改密码
            if (bll.UpdatePassword(adminId, newPassword))
            {
                Response.Redirect("AdminInfo.aspx");
            }
            else
            {
                lblPasswordStatus.Text = "密码修改失败！";
            }
        }
    }

    private string GetOldUsername(int adminId)
    {
        SDM.BLL.AdminInfo bll = new SDM.BLL.AdminInfo();
        DataSet ds = bll.GetAdminList();
        DataRow[] rows = ds.Tables[0].Select("AdminID = " + adminId);
        if (rows.Length > 0)
        {
            return rows[0]["AdminName"].ToString();
        }
        return "";
    }

}
