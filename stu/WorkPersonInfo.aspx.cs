using System;
using System.IO;
using SDM.BLL;
using SDM.Model;

public partial class stu_WorkPersonInfo : System.Web.UI.Page
{
    SDM.BLL.WorksInfo bll = new SDM.BLL.WorksInfo(); // ✅ 清楚地指定使用 BLL


    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (!fuVideo.HasFile || !fuImage.HasFile || !fuZip.HasFile)
        {
            lblMsg.Text = "请上传所有文件（视频、图片、压缩包）";
            return;
        }

        // 获取文件扩展名并验证
        string videoExt = Path.GetExtension(fuVideo.FileName).ToLower();
        string imgExt = Path.GetExtension(fuImage.FileName).ToLower();
        string zipExt = Path.GetExtension(fuZip.FileName).ToLower();

        if (videoExt != ".mp4" || !(imgExt == ".jpg" || imgExt == ".png") || !(zipExt == ".zip" || zipExt == ".rar"))
        {
            lblMsg.Text = "文件类型不合法";
            return;
        }

        // 生成保存路径
        string uploadDir = Server.MapPath("~/Upload/");
        if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

        string videoPath = "~/Upload/" + Guid.NewGuid() + videoExt;
        string imgPath = "~/Upload/" + Guid.NewGuid() + imgExt;
        string zipPath = "~/Upload/" + Guid.NewGuid() + zipExt;

        fuVideo.SaveAs(Server.MapPath(videoPath));
        fuImage.SaveAs(Server.MapPath(imgPath));
        fuZip.SaveAs(Server.MapPath(zipPath));

        // 构造模型
        SDM.Model.WorksInfo model = new SDM.Model.WorksInfo
        {
            UserID = int.Parse(Session["userId"].ToString()),
            WorkName = txtWorkName.Text.Trim(),
            WorkCate = txtWorkCate.Text.Trim(),
            WorkDes = txtWorkDes.Text.Trim(),
            WorkTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
            WorkUrl = videoPath,
            WorkPicUrl = imgPath // zip 存储暂不入库
        };

        if (bll.Add(model))
        {
            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = "上传成功！";
        }
        else
        {
            lblMsg.Text = "上传失败，请稍后重试。";
        }
    }
}
