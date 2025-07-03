using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class admin_WorkTuanDuiList : System.Web.UI.Page
{
    private SDM.BLL.WorkTuanDui bll = new SDM.BLL.WorkTuanDui();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTeamWorks();
        }
    }

    private void BindTeamWorks()
    {
        SDM.BLL.WorkTuanDui bll = new SDM.BLL.WorkTuanDui();
        DataSet ds = bll.GetAllWithNames(); // ✅ 使用联表查询
        gvTeamWorks.DataSource = ds;
        gvTeamWorks.DataBind();
    }


    private void LoadTeamWorks()
    {
        DataSet ds = bll.GetAll();
        gvTeamWorks.DataSource = ds;
        gvTeamWorks.DataBind();
    }

    protected void gvTeamWorks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int workId = Convert.ToInt32(gvTeamWorks.DataKeys[e.RowIndex].Value);
        if (bll.Delete(workId))
        {
            LoadTeamWorks(); // 刷新列表
        }
    }
}
