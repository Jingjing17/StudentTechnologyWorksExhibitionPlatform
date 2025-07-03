using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class admin_StudentList : System.Web.UI.Page
{
    SDM.BLL.StudentInfo bll = new SDM.BLL.StudentInfo(); // 业务层对象

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        gvStudent.DataSource = bll.GetList();
        gvStudent.DataBind();
    }

    protected void gvStudent_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvStudent.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void gvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvStudent.EditIndex = -1;
        BindGrid();
    }

    protected void gvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int userId = Convert.ToInt32(gvStudent.DataKeys[e.RowIndex].Value);
        GridViewRow row = gvStudent.Rows[e.RowIndex];

        SDM.Model.StudentInfo model = new SDM.Model.StudentInfo
        {
            UserID = userId,
            UserName = ((TextBox)row.Cells[1].Controls[0]).Text.Trim(),
            UserSex = ((TextBox)row.Cells[2].Controls[0]).Text.Trim(),
            UserNumber = ((TextBox)row.Cells[3].Controls[0]).Text.Trim(),
            UserPass = ((TextBox)row.Cells[4].Controls[0]).Text.Trim(),
            UserXy = ((TextBox)row.Cells[5].Controls[0]).Text.Trim(),
            UserZy = ((TextBox)row.Cells[6].Controls[0]).Text.Trim(),
            UserBj = ((TextBox)row.Cells[7].Controls[0]).Text.Trim(),
            UserAddTime = ((TextBox)row.Cells[8].Controls[0]).Text.Trim()
        };

        bll.Update(model);
        gvStudent.EditIndex = -1;
        BindGrid();
    }

    protected void gvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int userId = Convert.ToInt32(gvStudent.DataKeys[e.RowIndex].Value);
        bll.Delete(userId);
        BindGrid();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string stuNumber = txtNumber.Text.Trim();
        DataSet ds = bll.GetList(); // 可优化为按学号查（若你有 GetByNumber）

        bool exists = false;
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            if (row["UserNumber"].ToString() == stuNumber)
            {
                exists = true;
                break;
            }
        }

        if (exists)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('该学号学生已存在，新增失败！');", true);
            return;
        }

        SDM.Model.StudentInfo model = new SDM.Model.StudentInfo
        {
            UserName = txtName.Text.Trim(),
            UserSex = txtSex.Text.Trim(),
            UserNumber = stuNumber,
            UserPass = txtPass.Text.Trim(),
            UserXy = txtXy.Text.Trim(),
            UserZy = txtZy.Text.Trim(),
            UserBj = txtBj.Text.Trim(),
            UserAddTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
        };

        bll.Add(model);
        BindGrid();

        txtName.Text = txtSex.Text = txtNumber.Text = txtPass.Text = txtXy.Text = txtZy.Text = txtBj.Text = "";
    }

}
