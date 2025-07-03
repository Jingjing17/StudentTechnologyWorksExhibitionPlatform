using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class admin_AdminInfo : System.Web.UI.Page
{
    SDM.BLL.AdminInfo bll = new SDM.BLL.AdminInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAdminList();
        }
    }

    // 绑定管理员列表
    private void BindAdminList()
    {
        gvAdminList.DataSource = bll.GetAdminList();
        gvAdminList.DataBind();
    }

    // GridView操作：跳转修改密码、删除
    protected void gvAdminList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int adminID = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "ChangePwd")
        {
            // 跳转到修改密码页面，并传递 AdminID 参数
            Response.Redirect("EditPassword.aspx?AdminID=" + adminID);
        }
        else if (e.CommandName == "Delete")
        {
            bool result = bll.DeleteAdmin(adminID);
            if (result)
            {
                BindAdminList();
            }
            else
            {
                lblMsg.Text = "删除失败！";
            }
        }
    }

    // 新增管理员
    protected void btnAddAdmin_Click(object sender, EventArgs e)
    {
        string name = txtNewAdminName.Text.Trim();
        string pass = txtNewAdminPass.Text.Trim();

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
        {
            lblMsg.Text = "用户名或密码不能为空！";
            return;
        }

        DataSet ds = bll.GetAdminList();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            if (row["AdminName"].ToString() == name)
            {
                lblMsg.Text = "用户名已存在，新增失败！";
                return;
            }
        }

        // 执行插入操作（需你在 DAL/BLL 中添加 AddAdmin 方法）
        bool added = bll.AddAdmin(name, pass);
        if (added)
        {
            lblMsg.Text = "新增成功！";
            txtNewAdminName.Text = "";
            txtNewAdminPass.Text = "";
            BindAdminList();
        }
        else
        {
            lblMsg.Text = "新增失败，请重试！";
        }
    }
}



