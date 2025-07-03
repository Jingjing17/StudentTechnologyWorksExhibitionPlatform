using System;
using System.IO;

public partial class admin_WorkTuanDuiEdit : System.Web.UI.Page
{
    SDM.BLL.WorkTuanDui bll = new SDM.BLL.WorkTuanDui();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id;
            if (Request.QueryString["WorkID"] != null && int.TryParse(Request.QueryString["WorkID"], out id))
            {
                var ds = bll.GetWorkById(id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var row = ds.Tables[0].Rows[0];
                    txtTdmc.Text = row["tdmc"].ToString();
                    txtWorkName.Text = row["WorkName"].ToString();
                    txtWorkCate.Text = row["WorkCate"].ToString();
                    txtWorkDes.Text = row["WorkDes"].ToString();

                    txtUser1.Text = row["UserNumber_1"].ToString();
                    txtUser1Des.Text = row["UserNumber_1_des"].ToString();
                    txtUser2.Text = row["UserNumber_2"].ToString();
                    txtUser2Des.Text = row["UserNumber_2_des"].ToString();
                    txtUser3.Text = row["UserNumber_3"].ToString();
                    txtUser3Des.Text = row["UserNumber_3_des"].ToString();
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(Request.QueryString["WorkID"], out int id))
        {
            lblMsg.Text = "参数错误";
            return;
        }

        SDM.Model.WorkTuanDui model = new SDM.Model.WorkTuanDui
        {
            WorkID = id,
            tdmc = txtTdmc.Text.Trim(),
            WorkName = txtWorkName.Text.Trim(),
            WorkCate = txtWorkCate.Text.Trim(),
            WorkDes = txtWorkDes.Text.Trim(),
            UserNumber_1 = txtUser1.Text.Trim(),
            UserNumber_1_des = txtUser1Des.Text.Trim(),
            UserNumber_2 = txtUser2.Text.Trim(),
            UserNumber_2_des = txtUser2Des.Text.Trim(),
            UserNumber_3 = txtUser3.Text.Trim(),
            UserNumber_3_des = txtUser3Des.Text.Trim(),
            WorkTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        // 文件上传
        string uploadPath = "~/Upload/";
        if (fuImage.HasFile)
        {
            string imgName = Guid.NewGuid().ToString() + Path.GetExtension(fuImage.FileName);
            fuImage.SaveAs(Server.MapPath(uploadPath + imgName));
            model.WorkPicUrl = uploadPath + imgName;
        }
        if (fuVideo.HasFile)
        {
            string videoName = Guid.NewGuid().ToString() + Path.GetExtension(fuVideo.FileName);
            fuVideo.SaveAs(Server.MapPath(uploadPath + videoName));
            model.WorkUrl = uploadPath + videoName;
        }
        if (fuZip.HasFile)
        {
            string zipName = Guid.NewGuid().ToString() + Path.GetExtension(fuZip.FileName);
            fuZip.SaveAs(Server.MapPath(uploadPath + zipName));
            model.WorkZipUrl = uploadPath + zipName;
        }

        if (bll.Update(model))
        {
            Response.Redirect("WorkTuanDuiList.aspx");
        }
        else
        {
            lblMsg.Text = "修改失败，请重试。";
        }
    }
}
