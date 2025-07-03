using System;
using System.Data;
using SDM.BLL;

public partial class stu_WorkPersonList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindWorks();
        }
    }

    private void BindWorks()
    {
        int userId = int.Parse(Session["userId"].ToString());
        WorksInfo bll = new WorksInfo();
        DataSet ds = bll.GetListByUserID(userId);

        gvWorks.DataSource = ds;
        gvWorks.DataBind();
    }
}
