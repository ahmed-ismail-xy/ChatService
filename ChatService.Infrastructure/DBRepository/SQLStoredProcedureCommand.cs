using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CloudChatService.Infrastructure.DBRepository
{
    public class SQLStoredProcedureCommand
    {
        private static IConfiguration _configuration;
        public static IConfiguration configuration
        {
            get { return _configuration; }
        }
        public static void InitConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private static void StoredProcedureCommand<T>(string tableName, Dictionary<string, T> commandParameters, int actionNumber, ref int executeResult, ref DataTable dt)
        {
            using (var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            using (var cmd = new SqlCommand(tableName, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var commandParameter in commandParameters)
                {
                    cmd.Parameters.AddWithValue(commandParameter.Key, commandParameter.Value);
                }

                cmd.Parameters.AddWithValue("@Action", actionNumber);
                con.Open();
                executeResult = cmd.ExecuteNonQuery();
                da.Fill(dt);
                con.Close();
            }
        }

        //Return DataTable
        public static void StoredProcedureCommand<T>(string tableName, Dictionary<string, T> commandParameters, int actionNumber, ref DataTable dt)
        {
            int executeResult = 0;
            
            StoredProcedureCommand(tableName: tableName, commandParameters: commandParameters, actionNumber: actionNumber, executeResult: ref executeResult, dt: ref dt);
        }

        //Return int Value 
        public static void StoredProcedureCommand<T>(string tableName, Dictionary<string, T> commandParameters, int actionNumber, string returnName, ref int returnValue)
        {
            int executeResult = 0;
            DataTable dt = new DataTable();
            StoredProcedureCommand(tableName: tableName, commandParameters: commandParameters, actionNumber: actionNumber, executeResult: ref executeResult, dt: ref dt);
            bool result = executeResult == 0 ? false : true;

            if (result)
            {
                if (dt.Rows.Count > 0)
                {
                    returnValue = int.Parse(dt.Rows[0][returnName].ToString() ?? "");

                }
                // returnValue = double.IsNaN(returnValue) == false ? 0 : returnValue;
            }
        }

        //Return string Value
        public static void StoredProcedureCommand<T>(string tableName, Dictionary<string, T> commandParameters, int actionNumber, string returnName, ref string returnValue)
        {
            int executeResult = 0;
            DataTable dt = new DataTable();
            StoredProcedureCommand(tableName: tableName, commandParameters: commandParameters, actionNumber: actionNumber, executeResult: ref executeResult, dt: ref dt);
            bool result = executeResult == 0 ? false : true;

            if (result)
            {
                returnValue = dt.Rows[0][returnName].ToString();
            }
        }
        //Return Boolean
        public static void StoredProcedureCommand<T>(string tableName, Dictionary<string, T> commandParameters, int actionNumber, ref bool result)
        {
            int executeResult = 0;
            DataTable dt = new DataTable();
            StoredProcedureCommand(tableName: tableName, commandParameters: commandParameters, actionNumber: actionNumber, executeResult: ref executeResult, dt: ref dt);
            result = executeResult == 0 ? false : true;
        }

    }

}
