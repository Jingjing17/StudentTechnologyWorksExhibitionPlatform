using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace SDM.DAL
{
    public class AdminInfo
    {
        // 登录验证
        public DataSet GetLogin(string strName, string strPass)
        {
            string sql = "SELECT * FROM AdminInfo WHERE AdminName=@strname AND AdminPass=@strpass";
            SqlParameter[] parameters = {
                new SqlParameter("@strname", strName),
                new SqlParameter("@strpass", strPass)
            };
            return DbHelperSQL.Query(sql, parameters);
        }

        // 获取管理员列表
        public DataSet GetAdminList()
        {
            return DbHelperSQL.Query("SELECT * FROM AdminInfo");
        }

        // 验证旧密码
        public bool ValidateOldPassword(int adminID, string currentPassword)
        {
            string sql = "SELECT COUNT(1) FROM AdminInfo WHERE AdminID=@AdminID AND AdminPass=@CurrentPassword";
            SqlParameter[] parameters = {
                new SqlParameter("@AdminID", adminID),
                new SqlParameter("@CurrentPassword", currentPassword)
            };
            return DbHelperSQL.Exists(sql, parameters);
        }

        // 更新密码
        public bool UpdatePassword(int adminID, string newPassword)
        {
            string sql = "UPDATE AdminInfo SET AdminPass=@NewPassword WHERE AdminID=@AdminID";
            SqlParameter[] parameters = {
                new SqlParameter("@NewPassword", newPassword),
                new SqlParameter("@AdminID", adminID)
            };
            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }

        // 删除管理员
        public bool DeleteAdmin(int adminID)
        {
            string sql = "DELETE FROM AdminInfo WHERE AdminID=@AdminID";
            SqlParameter[] parameters = {
                new SqlParameter("@AdminID", adminID)
            };
            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }

        // 修改用户名和密码
        public bool UpdateAdminInfo(int adminID, string adminName, string adminPass)
        {
            string sql = "UPDATE AdminInfo SET AdminName=@AdminName, AdminPass=@AdminPass WHERE AdminID=@AdminID";
            SqlParameter[] parameters = {
                new SqlParameter("@AdminName", adminName),
                new SqlParameter("@AdminPass", adminPass),
                new SqlParameter("@AdminID", adminID)
            };
            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }

        // 添加新管理员
        public bool AddAdmin(string adminName, string adminPass)
        {
            string sql = "INSERT INTO AdminInfo (AdminName, AdminPass) VALUES (@AdminName, @AdminPass)";
            SqlParameter[] parameters = {
                new SqlParameter("@AdminName", adminName),
                new SqlParameter("@AdminPass", adminPass)
            };
            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}



