using System.Data;

namespace SDM.BLL
{
    public class WorkTuanDui
    {
        private readonly SDM.DAL.WorkTuanDui dal = new SDM.DAL.WorkTuanDui();

        public bool Add(SDM.Model.WorkTuanDui model)
        {
            return dal.Add(model);
        }

        public DataSet GetList()
        {
            return dal.GetList();
        }

        public DataSet GetWorkById(int workId)
        {
            return dal.GetWorkById(workId);
        }

        public bool Delete(int workId)
        {
            return dal.Delete(workId);
        }
        public DataSet GetAll()
        {
            return dal.GetAll();  // 调用 DAL 获取数据
        }
        public bool Update(SDM.Model.WorkTuanDui model)
        {
            return dal.Update(model);
        }
        public DataSet GetByUserNumber(string userNumber)
        {
            return dal.GetByUserNumber(userNumber);
        }

        public DataSet GetAllWithNames()
        {
            return dal.GetAllWithNames();
        }

    }
}

