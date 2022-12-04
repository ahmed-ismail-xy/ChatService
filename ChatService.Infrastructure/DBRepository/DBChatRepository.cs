using CloudChatService.Core.IDBServices;
using CloudChatService.Core.DTOs.Chat;
using CloudChatService.Core.DTOs.UserProfile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace CloudChatService.Infrastructure.DBRepository
{
    public class DBChatRepository : IDBChatService
    {
        private readonly IConfiguration _configuration;
        public DBChatRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public GetAllChatsDTO.Response GetAllChats(string phoneNumber)
        {

            DataTable dt = new DataTable();

            string stmt = $"USE [CloudChatServiceDB]  DECLARE	@return_value int EXEC	@return_value = [dbo].[p_DisplayChats] @PhoneNumber = N'{phoneNumber}', @Action = 4 SELECT	'Return Value' = @return_value";
            var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            SqlCommand cmd = new SqlCommand(stmt, con);
            using (var da = new SqlDataAdapter(cmd))
            {
                con.Open();
                var executeResult = cmd.ExecuteNonQuery();
                da.Fill(dt);
                con.Close();
            }

            GetAllChatsDTO.Response ListOfChats = new GetAllChatsDTO.Response();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOfChats.Chats.Add(new ChatDTO()
                {
                    UserPhone = dt.Rows[i]["UserPhone"].ToString(),
                    UserInfoId = int.Parse(dt.Rows[i]["UserInfoId"].ToString() ?? ""),
                    ChatId = int.Parse(dt.Rows[i]["ChatId"].ToString() ?? ""),
                    LastMessageTypeId = int.Parse(dt.Rows[i]["LastMessageTypeId"].ToString() ?? ""),
                    UnreadMessagesCount = int.Parse(dt.Rows[i]["UnreadMessagesCount"].ToString() ?? ""),
                    ChatImageName = dt.Rows[i]["ChatImage"].ToString(),
                    ChatName = dt.Rows[i]["ChatName"].ToString(),
                    ChatStateName = dt.Rows[i]["ChatStateName"].ToString(),
                    LastMessage = dt.Rows[i]["LastMessage"].ToString(),
                    MessageTypeName = dt.Rows[i]["MessageTypeName"].ToString(),
                    LastMessageTime = dt.Rows[i]["LastMessageTime"].ToString().Length >= 1 ? dt.Rows[i]["LastMessageTime"].ToString() : "1212-12-12/00:00 AM",
                });
            }

            return ListOfChats;
        }
        public GetAllUsersDTO.Response GetAllUsers(string phoneNumber)
        {
            DataTable dt = new DataTable();

            string stmt = $"USE [CloudChatServiceDB]  DECLARE	@return_value int EXEC	@return_value = [dbo].[p_UserInfo] @PhoneNumber = N'{phoneNumber}', @Action = 5 SELECT	'Return Value' = @return_value";
            var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            SqlCommand cmd = new SqlCommand(stmt, con);
            using (var da = new SqlDataAdapter(cmd))
            {
                con.Open();
                var executeResult = cmd.ExecuteNonQuery();
                da.Fill(dt);
                con.Close();
            }

            GetAllUsersDTO.Response ListOfUsers = new GetAllUsersDTO.Response();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOfUsers.Users.Add(new UserDTO()
                {
                    UserInfoId = int.Parse(dt.Rows[i]["UserInfoId"].ToString() ?? ""),
                    FirstName = dt.Rows[i]["FirstName"].ToString(),
                    LastName = dt.Rows[i]["LastName"].ToString(),
                    Bio = dt.Rows[i]["Bio"].ToString(),
                    PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString(),
                    UserImageName = dt.Rows[i]["UserImage"].ToString()
                });
            }

            return ListOfUsers;
        }
        public int CheckIsChatExistAndCreateIt(CheckIsChatExistAndCreateItDTO.Request request)
        {

            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            keyValuePairs.Add("@UserInfoId_1", request.SenderId);
            keyValuePairs.Add("@UserInfoId_2", request.ReceiverId);
            int returnValue = 0;

            SQLStoredProcedureCommand.InitConfiguration(_configuration);

            SQLStoredProcedureCommand.StoredProcedureCommand(
                tableName: "CloudChat.p_ChatMembers", commandParameters: keyValuePairs,
                actionNumber: 4, returnName: "ChatId", returnValue: ref returnValue);

            return returnValue;

        }
    }
}
