using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SDM.Model;

namespace SDM.DAL
{
    public class WorkTuanDui
    {
        public bool Add(SDM.Model.WorkTuanDui model)
        {
            string sql = @"INSERT INTO WorkTuanDui
(tdmc, UserNumber_1, UserNumber_1_des, UserNumber_2, UserNumber_2_des, UserNumber_3, UserNumber_3_des,
 WorkName, WorkCate, WorkDes, WorkTime, WorkUrl, WorkPicUrl, WorkZipUrl)
VALUES
(@tdmc, @UserNumber_1, @UserNumber_1_des, @UserNumber_2, @UserNumber_2_des, @UserNumber_3, @UserNumber_3_des,
 @WorkName, @WorkCate, @WorkDes, @WorkTime, @WorkUrl, @WorkPicUrl, @WorkZipUrl)";

            SqlParameter[] parameters = {
                new SqlParameter("@tdmc", model.tdmc),
                new SqlParameter("@UserNumber_1", model.UserNumber_1),
                new SqlParameter("@UserNumber_1_des", model.UserNumber_1_des),
                new SqlParameter("@UserNumber_2", model.UserNumber_2),
                new SqlParameter("@UserNumber_2_des", model.UserNumber_2_des),
                new SqlParameter("@UserNumber_3", model.UserNumber_3),
                new SqlParameter("@UserNumber_3_des", model.UserNumber_3_des),
                new SqlParameter("@WorkName", model.WorkName),
                new SqlParameter("@WorkCate", model.WorkCate),
                new SqlParameter("@WorkDes", model.WorkDes),
                new SqlParameter("@WorkTime", model.WorkTime),
                new SqlParameter("@WorkUrl", model.WorkUrl),
                new SqlParameter("@WorkPicUrl", model.WorkPicUrl),
                new SqlParameter("@WorkZipUrl", model.WorkZipUrl)
            };

            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }

        public DataSet GetList()
        {
            return DbHelperSQL.Query("SELECT * FROM WorkTuanDui");
        }

        public DataSet GetAll()
        {
            return DbHelperSQL.Query("SELECT * FROM WorkTuanDui");
        }

        public DataSet GetWorkById(int workId)
        {
            string sql = "SELECT * FROM WorkTuanDui WHERE WorkID=@WorkID";
            SqlParameter[] parameters = {
                new SqlParameter("@WorkID", workId)
            };
            return DbHelperSQL.Query(sql, parameters);
        }

        public bool Delete(int workId)
        {
            string sql = "DELETE FROM WorkTuanDui WHERE WorkID=@WorkID";
            SqlParameter[] parameters = {
                new SqlParameter("@WorkID", workId)
            };
            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Update(SDM.Model.WorkTuanDui model)
        {
            string sql = @"UPDATE WorkTuanDui SET 
                tdmc = @tdmc,
                WorkName = @WorkName,
                WorkCate = @WorkCate,
                WorkDes = @WorkDes,
                WorkTime = @WorkTime,
                WorkUrl = @WorkUrl,
                WorkPicUrl = @WorkPicUrl,
                WorkZipUrl = @WorkZipUrl,
                UserNumber_1 = @UserNumber_1,
                UserNumber_1_des = @UserNumber_1_des,
                UserNumber_2 = @UserNumber_2,
                UserNumber_2_des = @UserNumber_2_des,
                UserNumber_3 = @UserNumber_3,
                UserNumber_3_des = @UserNumber_3_des
            WHERE WorkID = @WorkID";

            SqlParameter[] parameters = {
                new SqlParameter("@tdmc", model.tdmc),
                new SqlParameter("@WorkName", model.WorkName),
                new SqlParameter("@WorkCate", model.WorkCate),
                new SqlParameter("@WorkDes", model.WorkDes),
                new SqlParameter("@WorkTime", model.WorkTime),
                new SqlParameter("@WorkUrl", model.WorkUrl),
                new SqlParameter("@WorkPicUrl", model.WorkPicUrl),
                new SqlParameter("@WorkZipUrl", model.WorkZipUrl),
                new SqlParameter("@UserNumber_1", model.UserNumber_1),
                new SqlParameter("@UserNumber_1_des", model.UserNumber_1_des),
                new SqlParameter("@UserNumber_2", model.UserNumber_2),
                new SqlParameter("@UserNumber_2_des", model.UserNumber_2_des),
                new SqlParameter("@UserNumber_3", model.UserNumber_3),
                new SqlParameter("@UserNumber_3_des", model.UserNumber_3_des),
                new SqlParameter("@WorkID", model.WorkID)
            };

            return DbHelperSQL.ExecuteNonQuery(sql, parameters) > 0;
        }
        public DataSet GetByUserNumber(string userNumber)
        {
            string sql = @"
        SELECT 
            W.*, 
            S1.UserName AS UserName_1,
            S2.UserName AS UserName_2,
            S3.UserName AS UserName_3
        FROM WorkTuanDui W
        LEFT JOIN StudentInfo S1 ON W.UserNumber_1 = S1.UserNumber
        LEFT JOIN StudentInfo S2 ON W.UserNumber_2 = S2.UserNumber
        LEFT JOIN StudentInfo S3 ON W.UserNumber_3 = S3.UserNumber
        WHERE 
            W.UserNumber_1 = @UserNumber OR
            W.UserNumber_2 = @UserNumber OR
            W.UserNumber_3 = @UserNumber";

            SqlParameter[] parameters = {
        new SqlParameter("@UserNumber", userNumber)
    };

            return DbHelperSQL.Query(sql, parameters);
        }

        public DataSet GetAllWithNames()
        {
            string sql = @"
        SELECT w.*, 
               s1.UserName AS UserName_1, 
               s2.UserName AS UserName_2, 
               s3.UserName AS UserName_3
        FROM WorkTuanDui w
        LEFT JOIN StudentInfo s1 ON w.UserNumber_1 = s1.UserNumber
        LEFT JOIN StudentInfo s2 ON w.UserNumber_2 = s2.UserNumber
        LEFT JOIN StudentInfo s3 ON w.UserNumber_3 = s3.UserNumber";

            return DbHelperSQL.Query(sql);
        }

    }
}

