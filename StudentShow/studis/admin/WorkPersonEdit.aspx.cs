using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class admin_WorkPersonEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadWorkInfo();
        }
    }

    private void LoadWorkInfo()
    {
        if (Request.QueryString["WorkID"] != null && int.TryParse(Request.QueryString["WorkID"], out int workId))
        {
            SDM.BLL.WorksInfo bll = new SDM.BLL.WorksInfo();
            DataSet ds = bll.GetWorkById(workId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txtWorkName.Text = row["WorkName"].ToString();
                txtWorkCate.Text = row["WorkCate"].ToString();
                txtWorkDes.Text = row["WorkDes"].ToString();
                ViewState["WorkUrl"] = row["WorkUrl"].ToString();
                ViewState["WorkPicUrl"] = row["WorkPicUrl"].ToString();
                ViewState["WorkZipUrl"] = row["WorkZipUrl"].ToString();
            }
        }
        else
        {
            lblMsg.Text = "无效的作品ID！";
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["WorkID"] == null || !int.TryParse(Request.QueryString["WorkID"], out int workId))
        {
            lblMsg.Text = "无效的作品ID！";
            return;
        }

        SDM.BLL.WorksInfo bll = new SDM.BLL.WorksInfo();
        SDM.Model.WorksInfo model = new SDM.Model.WorksInfo();

        model.WorkID = workId;
        model.WorkName = txtWorkName.Text.Trim();
        model.WorkCate = txtWorkCate.Text.Trim();
        model.WorkDes = txtWorkDes.Text.Trim();
        model.WorkTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  // 格式化为字符串


        // 视频上传
        if (fuVideo.HasFile)
        {
            string ext = System.IO.Path.GetExtension(fuVideo.FileName);
            string path = "~/Upload/" + Guid.NewGuid().ToString() + ext;
            fuVideo.SaveAs(Server.MapPath(path));
            model.WorkUrl = path;
        }
        else
        {
            model.WorkUrl = ViewState["WorkUrl"]?.ToString();
        }

        // 图片上传
        if (fuPic.HasFile)
        {
            string ext = System.IO.Path.GetExtension(fuPic.FileName);
            string path = "~/Upload/" + Guid.NewGuid().ToString() + ext;
            fuPic.SaveAs(Server.MapPath(path));
            model.WorkPicUrl = path;
        }
        else
        {
            model.WorkPicUrl = ViewState["WorkPicUrl"]?.ToString();
        }

        // 压缩包上传
        if (fuZip.HasFile)
        {
            string ext = System.IO.Path.GetExtension(fuZip.FileName);
            string path = "~/Upload/" + Guid.NewGuid().ToString() + ext;
            fuZip.SaveAs(Server.MapPath(path));
            model.WorkZipUrl = path;
        }
        else
        {
            model.WorkZipUrl = ViewState["WorkZipUrl"]?.ToString();
        }

        bool success = bll.Update(model);
        lblMsg.Text = success ? "修改成功！" : "修改失败，请重试";
    }
}
