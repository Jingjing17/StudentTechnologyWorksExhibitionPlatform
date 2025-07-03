using System.Data;

namespace SDM.BLL
{
    public class WorksInfo
    {
        private readonly SDM.DAL.WorksInfo dal = new SDM.DAL.WorksInfo();

        public bool Add(SDM.Model.WorksInfo model)
        {
            return dal.Add(model);
        }

        public DataSet GetListByUserID(int userId)
        {
            return dal.GetListByUserID(userId);
        }

        public DataSet GetWorkById(int workId)
        {
            return dal.GetWorkById(workId);
        }

        public bool Delete(int workId)
        {
            return dal.Delete(workId);
        }
        public DataSet GetAllPersonWorks()
        {
            return dal.GetAllPersonWorks();
        }
        public bool Update(SDM.Model.WorksInfo model)
        {
            return dal.Update(model);
        }

    }
}

