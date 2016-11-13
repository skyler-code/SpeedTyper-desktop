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
    public class TestAccessor
    {
        public static TestData RetrieveRandomTest()
        {
            TestData testData = null;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_random_test";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    testData = new TestData()
                    {
                        TestID = reader.GetInt32(0),
                        TestDataText = reader.GetString(1),
                        DataSource = reader.GetString(2)
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

            return testData;
        }


    }
}
