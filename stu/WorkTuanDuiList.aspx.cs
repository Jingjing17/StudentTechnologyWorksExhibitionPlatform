using System;
using SDM.BLL;
using System.Data;

public partial class stu_WorkTuanDuiList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTeamWorks();
        }
    }

    private void BindTeamWorks()
    {
        string userNumber = Session["UserNumber"]?.ToString();
        if (!string.IsNullOrEmpty(userNumber))
        {
            SDM.BLL.WorkTuanDui bll = new SDM.BLL.WorkTuanDui();
            DataSet ds = bll.GetByUserNumber(userNumber); // ✅ 使用联表查询方法
            gvTeamWorks.DataSource = ds;
            gvTeamWorks.DataBind();
        }
    }



}
