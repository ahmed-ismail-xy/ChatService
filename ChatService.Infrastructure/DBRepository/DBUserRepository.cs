using CloudChatService.Core.DTOs.UserProfile;
using CloudChatService.Core.IDBServices;
using CloudChatService.Infrastrucure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace CloudChatService.Infrastructure.DBRepository
{
    public class DBUserRepository : IDBUserService
    {
        private readonly IConfiguration _configuration;
        public DBUserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UserDTO GetUserData(string phoneNumber)
        {

            DataTable dt = new DataTable();
            UserDTO user = new UserDTO();

            int executeResult;
            string stmt = $"USE [CloudChatServiceDB]  DECLARE	@return_value int EXEC	@return_value = [dbo].[p_UserInfo] @PhoneNumber = N'{phoneNumber}', @Action = 4 SELECT	'Return Value' = @return_value";
            var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            SqlCommand cmd = new SqlCommand(stmt, con);
            using (var da = new SqlDataAdapter(cmd))
            {
                con.Open();
                executeResult = cmd.ExecuteNonQuery();
                da.Fill(dt);
                con.Close();
            }

            bool result = executeResult == 0 ? false : true;

            if (result)
            {
                if (dt.Rows.Count > 0)
                {
                    user.UserInfoId = int.Parse(dt.Rows[0]["UserInfoId"].ToString() ?? "0");
                    user.FirstName = dt.Rows[0]["FirstName"].ToString();
                    user.LastName = dt.Rows[0]["LastName"].ToString();
                    user.Bio = dt.Rows[0]["Bio"].ToString();
                    user.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
                    user.UserImageName = dt.Rows[0]["UserImage"].ToString();
                    user.Password = dt.Rows[0]["Password"].ToString();
                    user.FireToken = dt.Rows[0]["FireToken"].ToString();
                    user.UserPrivacyId = int.Parse(dt.Rows[0]["UserPrivacyId"].ToString());
                    user.AccountStateId = int.Parse(dt.Rows[0]["AccountStateId"].ToString());

                }
            } 
            return user;
        }
       
        public bool UpdateUserInfo(string phoneNumber, string userBio = null,
           string userImage = null, string firstName = null,
           string lastName = null, string userPassword = null,
           string fireToken = null, string deleteAt = null,
            string createAt = null
           )
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            keyValuePairs.Add("@PhoneNumber", phoneNumber);
            keyValuePairs.Add("@Bio", userBio);
            keyValuePairs.Add("@UserImage", userImage);
            keyValuePairs.Add("@FirstName", firstName);
            keyValuePairs.Add("@LastName", lastName);
            keyValuePairs.Add("@Password", userPassword);
            keyValuePairs.Add("@FireToken", fireToken);
            keyValuePairs.Add("@DeleteAt", deleteAt);
            keyValuePairs.Add("@CreateAt", createAt);

            bool result = false;

            SQLStoredProcedureCommand.InitConfiguration(_configuration);

            SQLStoredProcedureCommand.StoredProcedureCommand(
                tableName: "dbo.p_UserInfo", commandParameters: keyValuePairs,
                actionNumber: 2, result: ref result);

            return result;
        }
        public bool DeleteUserImage(string phoneNumber)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            keyValuePairs.Add("@PhoneNumber", phoneNumber);
            bool result = false;

            SQLStoredProcedureCommand.InitConfiguration(_configuration);

            SQLStoredProcedureCommand.StoredProcedureCommand(
                tableName: "dbo.p_UserInfo", commandParameters: keyValuePairs,
                actionNumber: 6, result: ref result);

            return result;
        }
        public bool DeleteUser(string phoneNumber)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            keyValuePairs.Add("@PhoneNumber", phoneNumber);
            bool result = false;

            SQLStoredProcedureCommand.InitConfiguration(_configuration);

            SQLStoredProcedureCommand.StoredProcedureCommand(
                tableName: "dbo.p_UserInfo", commandParameters: keyValuePairs,
                actionNumber: 3, result: ref result);

            return result;
        }
        public bool CreateUser(UserInfo userInfo, string imagePath)
        {
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

                keyValuePairs.Add("@UserImage", imagePath);
                keyValuePairs.Add("@PhoneNumber", userInfo.PhoneNumber);
                keyValuePairs.Add("@FirstName", userInfo.FirstName);
                keyValuePairs.Add("@LastName", userInfo.LastName);
                keyValuePairs.Add("@Password", userInfo.Password);
                keyValuePairs.Add("@Bio", userInfo.Bio);
                keyValuePairs.Add("@FireToken", userInfo.FireToken);
                keyValuePairs.Add("@CreateAt", userInfo.CreateAt);
                keyValuePairs.Add("@UserPrivacyId", userInfo.UserPrivacyId);
                keyValuePairs.Add("@AccountStateId", userInfo.AccountStateId);


                bool result = false;

                SQLStoredProcedureCommand.InitConfiguration(_configuration);

                SQLStoredProcedureCommand.StoredProcedureCommand(
                    tableName: "dbo.p_UserInfo", commandParameters: keyValuePairs,
                    actionNumber: 1, result: ref result);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }

    }
}
