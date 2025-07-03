using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class admin_WorkPersonList : System.Web.UI.Page
{
    SDM.BLL.WorksInfo bll = new SDM.BLL.WorksInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindWorkList();
        }
    }

    private void BindWorkList()
    {
        DataSet ds = bll.GetAllPersonWorks();
        gvWorks.DataSource = ds;
        gvWorks.DataBind();
    }

    protected void gvWorks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int workId = Convert.ToInt32(gvWorks.DataKeys[e.RowIndex].Value);
        bool deleted = bll.Delete(workId);
        if (deleted)
        {
            BindWorkList(); // 刷新列表
        }
    }
}


