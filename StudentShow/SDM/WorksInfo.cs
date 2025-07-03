using System;

namespace SDM.Model
{
    [Serializable]
    public class WorksInfo
    {
        public WorksInfo() { }

        public int WorkID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string WorkName { get; set; }
        public string WorkCate { get; set; }
        public string WorkDes { get; set; }
        public string WorkTime { get; set; }
        public string WorkUrl { get; set; }
        public string WorkPicUrl { get; set; }
        public string WorkZipUrl { get; set; }

    }
}

