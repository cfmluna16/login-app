using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Sql;
using System.Data.SqlClient;
using Dapper;
using LoginApp.DataModels;
using System.Data;

namespace LoginApp
{
    public class DataAccess
    {
        private readonly string _connectionString;
        public DataAccess()
        {
            _connectionString = AppSettings.ConnectionString;
        }

        public void CreateUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = "pr_create_user";

                connection.Execute(sql
                    , new {
                        userName = user.UserName,
                        userPassword = user.UserPassword
                    },
                    commandType: CommandType.StoredProcedure);

                connection.Close();
            }
        }

        public User GetUser(string userName)
        {
            User user = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = "pr_get_user_byusername";

                user = connection.Query<User>(sql
                    , new
                    {
                        userName = userName                        
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                connection.Close();
            }

            return user;
        }
    }
}