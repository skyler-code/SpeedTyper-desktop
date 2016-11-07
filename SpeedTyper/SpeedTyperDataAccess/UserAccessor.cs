using SpeedTyperDataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTyperDataAccess
{
    public class UserAccessor
    {
        public static int VerifyUsernameAndPassword(string username, string passwordHash)
        {
            var result = 0;

            // get a connection
            var conn = DBConnection.GetConnection();
            
            var cmdText = @"sp_authenticate_user";

            // create a command object
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar, 100);

            // set parameter values
            cmd.Parameters["@UserName"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            // try-catch-finally

            try
            {
                // open a connection
                conn.Open();

                // execute and capture the result
                result = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public static User RetrieveUserByUsername(string username)
        {
            User user = null;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_user_by_username";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar);
            cmd.Parameters["@Username"].Value = username;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    user = new User()
                    {
                        UserID = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        DisplayName = reader.GetString(2),
                        TitleID = reader.GetInt32(3),
                        Level = reader.GetInt32(4),
                        CurrentXP = reader.GetInt32(5),
                        XPToLevel = reader.GetInt32(6),
                    };
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return user;
        }

        public static int CreateUser(string username, string displayname, string passwordhash)
        {
            var result = 0;

            // get a connection
            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_create_user";

            // create a command object
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@DisplayName", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar, 100);

            // set parameter values
            cmd.Parameters["@UserName"].Value = username;
            cmd.Parameters["@DisplayName"].Value = displayname;
            cmd.Parameters["@PasswordHash"].Value = passwordhash;

            // try-catch-finally

            try
            {
                // open a connection
                conn.Open();

                // execute and capture the result
                result = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
 
}
