using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM.DAL
{
    public class StudentInfo
    {
        public DataSet GetLogin(string strName, string strPass)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from StudentInfo");
            strsql.Append(" where");
            strsql.Append(" UserName=@strname and UserPass=@strpass");
            SqlParameter[] parameter = {new SqlParameter("@strname", strName),
              new SqlParameter("@strpass", strPass)};
            return DbHelperSQL.Query(strsql.ToString(), parameter);
        }
        public DataSet GetStudentInfo(string userId)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from StudentInfo");
            strsql.Append(" where");
            strsql.Append(" UserId=@strid");
            SqlParameter[] parameter = {new SqlParameter("@strid", userId)};
            return DbHelperSQL.Query(strsql.ToString(), parameter);
        }
        public DataSet GetList()
        {
            return DbHelperSQL.Query("SELECT * FROM StudentInfo ORDER BY UserID DESC");
        }

        public bool Delete(int userId)
        {
            string sql = "DELETE FROM StudentInfo WHERE UserID = @UserID";
            SqlParameter[] parameters = {
            new SqlParameter("@UserID", userId)
        };
            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }
        public bool Add(SDM.Model.StudentInfo model)
        {
            string sql = @"INSERT INTO StudentInfo (UserName, UserSex, UserNumber, UserPass, UserXy, UserZy, UserBj, UserAddTime)
                   VALUES (@UserName, @UserSex, @UserNumber, @UserPass, @UserXy, @UserZy, @UserBj, @UserAddTime)";

            SqlParameter[] parameters = {
        new SqlParameter("@UserName", model.UserName),
        new SqlParameter("@UserSex", model.UserSex),
        new SqlParameter("@UserNumber", model.UserNumber),
        new SqlParameter("@UserPass", model.UserPass),
        new SqlParameter("@UserXy", model.UserXy),
        new SqlParameter("@UserZy", model.UserZy),
        new SqlParameter("@UserBj", model.UserBj),
        new SqlParameter("@UserAddTime", model.UserAddTime)
    };

            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Update(SDM.Model.StudentInfo model)
        {
            string sql = @"UPDATE StudentInfo SET
                   UserName = @UserName,
                   UserSex = @UserSex,
                   UserNumber = @UserNumber,
                   UserPass = @UserPass,
                   UserXy = @UserXy,
                   UserZy = @UserZy,
                   UserBj = @UserBj,
                   UserAddTime = @UserAddTime
                   WHERE UserID = @UserID";

            SqlParameter[] parameters = {
        new SqlParameter("@UserName", model.UserName),
        new SqlParameter("@UserSex", model.UserSex),
        new SqlParameter("@UserNumber", model.UserNumber),
        new SqlParameter("@UserPass", model.UserPass),
        new SqlParameter("@UserXy", model.UserXy),
        new SqlParameter("@UserZy", model.UserZy),
        new SqlParameter("@UserBj", model.UserBj),
        new SqlParameter("@UserAddTime", model.UserAddTime),
        new SqlParameter("@UserID", model.UserID)
    };

            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }
        public DataTable GetStudentById(int userId)
        {
            string sql = "SELECT * FROM StudentInfo WHERE UserID = @UserID";
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userId)
            };
            return DbHelperSQL.Query(sql, parameters).Tables[0];
        }

    }
}
