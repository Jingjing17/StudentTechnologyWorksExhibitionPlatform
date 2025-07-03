using System;
using System.IO;
using SDM.BLL;
using SDM.Model;

public partial class stu_WorkTuanDuiInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) { }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (!fuVideo.HasFile || !fuImage.HasFile || !fuZip.HasFile)
        {
            lblMsg.Text = "请上传所有文件（视频、图片、压缩包）";
            return;
        }

        // 检查文件扩展名
        string videoExt = Path.GetExtension(fuVideo.FileName).ToLower();
        string imgExt = Path.GetExtension(fuImage.FileName).ToLower();
        string zipExt = Path.GetExtension(fuZip.FileName).ToLower();

        if (videoExt != ".mp4" || !(imgExt == ".jpg" || imgExt == ".png") || !(zipExt == ".zip" || zipExt == ".rar"))
        {
            lblMsg.Text = "文件格式不合法";
            return;
        }

        // 生成保存路径
        string folder = Server.MapPath("~/Upload/");
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

        string videoPath = "~/Upload/" + Guid.NewGuid() + videoExt;
        string imgPath = "~/Upload/" + Guid.NewGuid() + imgExt;
        string zipPath = "~/Upload/" + Guid.NewGuid() + zipExt;

        fuVideo.SaveAs(Server.MapPath(videoPath));
        fuImage.SaveAs(Server.MapPath(imgPath));
        fuZip.SaveAs(Server.MapPath(zipPath)); // zip文件暂时不入库

        SDM.Model.WorkTuanDui model = new SDM.Model.WorkTuanDui
        {
            tdmc = txtTdmc.Text.Trim(),
            UserNumber_1 = txtUser1.Text.Trim(),
            UserNumber_1_des = txtUser1Des.Text.Trim(),
            UserNumber_2 = txtUser2.Text.Trim(),
            UserNumber_2_des = txtUser2Des.Text.Trim(),
            UserNumber_3 = txtUser3.Text.Trim(),
            UserNumber_3_des = txtUser3Des.Text.Trim(),
            WorkName = txtWorkName.Text.Trim(),
            WorkCate = txtWorkCate.Text.Trim(),
            WorkDes = txtWorkDes.Text.Trim(),
            WorkTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
            WorkUrl = videoPath,
            WorkPicUrl = imgPath,
            WorkZipUrl = zipPath  // 如果有源码
        };


        SDM.BLL.WorkTuanDui bll = new SDM.BLL.WorkTuanDui();
        bool result = bll.Add(model);


        if (result)
        {
            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = "上传成功！";
        }
        else
        {
            lblMsg.Text = "上传失败，请稍后再试";
        }
    }
}