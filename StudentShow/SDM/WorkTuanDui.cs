using System;

namespace SDM.Model
{
    [Serializable]
    public class WorkTuanDui
    {
        public WorkTuanDui() { }

        public int WorkID { get; set; }
        public string Tdmc { get; set; }

        public string UserNumber_1 { get; set; }
        public string UserNumber_1_des { get; set; }

        public string UserNumber_2 { get; set; }
        public string UserNumber_2_des { get; set; }

        public string UserNumber_3 { get; set; }
        public string UserNumber_3_des { get; set; }


        public string WorkName { get; set; }
        public string WorkCate { get; set; }
        public string WorkDes { get; set; }
        public string WorkTime { get; set; }
        public string WorkUrl { get; set; }
        public string WorkPicUrl { get; set; }
        public string tdmc { get; set; }  // 团队名称
        public string WorkZipUrl { get; set; }  // 源码压缩包路径

    }
}
