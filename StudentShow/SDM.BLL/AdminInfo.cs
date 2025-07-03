using System.Data;

namespace SDM.BLL
{
    public class AdminInfo
    {
        private readonly SDM.DAL.AdminInfo dal = new SDM.DAL.AdminInfo();

        public DataSet GetLogin(string strName, string strPass)
        {
            return dal.GetLogin(strName, strPass);
        }

        public DataSet GetAdminList()
        {
            return dal.GetAdminList();
        }

        public bool ValidateOldPassword(int adminID, string currentPassword)
        {
            return dal.ValidateOldPassword(adminID, currentPassword);
        }

        public bool UpdatePassword(int adminID, string newPassword)
        {
            return dal.UpdatePassword(adminID, newPassword);
        }

        public bool DeleteAdmin(int adminID)
        {
            return dal.DeleteAdmin(adminID);
        }

        public bool UpdateAdminInfo(int adminID, string adminName, string adminPass)
        {
            return dal.UpdateAdminInfo(adminID, adminName, adminPass);
        }

        public bool AddAdmin(string adminName, string adminPass)
        {
            return dal.AddAdmin(adminName, adminPass);
        }
    }
}



