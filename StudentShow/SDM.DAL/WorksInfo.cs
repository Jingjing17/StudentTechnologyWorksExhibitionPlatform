using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SDM.Model;

namespace SDM.DAL
{
    public class WorksInfo
    {
        public bool Add(SDM.Model.WorksInfo model)
        {
            string sql = @"INSERT INTO WorksInfo (UserID, WorkName, WorkCate, WorkDes, WorkTime, WorkUrl, WorkPicUrl)
                   VALUES (@UserID, @WorkName, @WorkCate, @WorkDes, @WorkTime, @WorkUrl, @WorkPicUrl)";

            SqlParameter[] parameters = {
        new SqlParameter("@UserID", model.UserID),
        new SqlParameter("@WorkName", model.WorkName),
        new SqlParameter("@WorkCate", model.WorkCate),
        new SqlParameter("@WorkDes", model.WorkDes),
        new SqlParameter("@WorkTime", model.WorkTime),
        new SqlParameter("@WorkUrl", model.WorkUrl),
        new SqlParameter("@WorkPicUrl", model.WorkPicUrl)
    };

            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }


        public DataSet GetListByUserID(int userId)
        {
            string sql = "SELECT * FROM WorksInfo WHERE UserID=@UserID";
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userId)
            };
            return DbHelperSQL.Query(sql, parameters);
        }

        public DataSet GetWorkById(int workId)
        {
            string sql = "SELECT * FROM WorksInfo WHERE WorkID=@WorkID";
            SqlParameter[] parameters = {
                new SqlParameter("@WorkID", workId)
            };
            return DbHelperSQL.Query(sql, parameters);
        }

        public bool Delete(int workId)
        {
            string sql = "DELETE FROM WorksInfo WHERE WorkID=@WorkID";
            SqlParameter[] parameters = {
        new SqlParameter("@WorkID", workId)
    };
            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }

        public DataSet GetAllPersonWorks()
        {
            string sql = @"
        SELECT 
            w.WorkID,
            w.WorkName,
            w.WorkCate,
            w.WorkDes,
            w.WorkTime,
            w.WorkUrl,
            w.WorkPicUrl,
            w.WorkZipUrl,
            s.UserNumber,
            s.UserName
        FROM WorksInfo w
        JOIN StudentInfo s ON w.UserID = s.UserID
        ORDER BY w.WorkTime DESC";

            return DbHelperSQL.Query(sql);
        }
        public bool Update(SDM.Model.WorksInfo model)
        {
            string sql = @"UPDATE WorksInfo SET 
                    WorkName = @WorkName, 
                    WorkCate = @WorkCate, 
                    WorkDes = @WorkDes, 
                    WorkTime = @WorkTime, 
                    WorkUrl = @WorkUrl, 
                    WorkPicUrl = @WorkPicUrl, 
                    WorkZipUrl = @WorkZipUrl
                    WHERE WorkID = @WorkID";

            SqlParameter[] parameters = {
        new SqlParameter("@WorkName", model.WorkName),
        new SqlParameter("@WorkCate", model.WorkCate),
        new SqlParameter("@WorkDes", model.WorkDes),
        new SqlParameter("@WorkTime", model.WorkTime),
        new SqlParameter("@WorkUrl", model.WorkUrl),
        new SqlParameter("@WorkPicUrl", model.WorkPicUrl),
        new SqlParameter("@WorkZipUrl", model.WorkZipUrl),
        new SqlParameter("@WorkID", model.WorkID)
    };

            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }

    }
}

