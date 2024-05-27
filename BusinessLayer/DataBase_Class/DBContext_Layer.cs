using BusinessLayer.Validate_Form;
using Data;
using ModelLayer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DataBase_Class
{
    public class DBContext_Layer
    {
        DataUtility utility = new DataUtility();
        public int AddUserData(DetailForm_Model userdata)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@name",userdata.name),
                new SqlParameter("@email",userdata.email),
                new SqlParameter("@mobile",userdata.mobile),
                new SqlParameter("@city",userdata.city)
            };
            int result = utility.ExecuteSql("sp_add_user_data",para);
            return result;
        }
        public DataTable DisplayAllData()
        {
            DataTable datatable = utility.GetDataTable("sp_select_all_data");
            return datatable;
        }
        public int DeleteUserData(int? id)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            int result = utility.ExecuteSql("sp_delete_user_data",para);
            return result;
        }
        public DataTable SelectOneData(int? id)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };

            DataTable datatable = utility.GetDataTable("sp_select_one_data",para);
            return datatable;
        }
        public int UpdateUserData(DetailForm_Model userdata)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@id",userdata.id),
                new SqlParameter("@name",userdata.name),
                new SqlParameter("@email",userdata.email),
                new SqlParameter("@mobile",userdata.mobile),
                new SqlParameter("@city",userdata.city)
            };
            int result = utility.ExecuteSql("sp_update_user_data", para);
            return result;
        }
    }
}
