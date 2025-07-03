using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM.BLL
{
    public class StudentInfo
    {
        private readonly SDM.DAL.StudentInfo dal = new SDM.DAL.StudentInfo();
        public DataSet GetLogin(string strName, string strPass)
        {
            return dal.GetLogin(strName, strPass);
        }
        public DataSet GetStudentInfo(string userId)
        {
            return dal.GetStudentInfo(userId);
        }
        public DataSet GetList()
        {
            return dal.GetList();
        }

        public bool Delete(int userId)
        {
            return dal.Delete(userId);
        }

        public bool Add(SDM.Model.StudentInfo model)
        {
            return dal.Add(model);
        }

        public bool Update(SDM.Model.StudentInfo model)
        {
            return dal.Update(model);
        }

        public DataTable GetStudentById(int userId)
        {
            return dal.GetStudentById(userId);
        }
    }
}
