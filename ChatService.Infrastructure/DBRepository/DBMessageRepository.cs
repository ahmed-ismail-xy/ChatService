using CloudChatService.Core.DTOs.Message;
using CloudChatService.Core.DTOs.UserProfile;
using CloudChatService.Core.IDBServices;
using CloudChatService.Infrastructure.Repository.UserRepository.SheardMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace CloudChatService.Infrastructure.DBRepository
{
    public class DBMessageRepository : IDBMessageService
    {
        private readonly IConfiguration _configuration;
        public DBMessageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public GetAllMessagesDTO.Response GetAllMessagesByChatId(int chatId)
        {
            DataTable dt = new DataTable();

            string stmt = $"USE [CloudChatServiceDB]  DECLARE	@return_value int EXEC	@return_value = [dbo].[p_Message] @ChatId = {chatId}, @Action = 5 SELECT	'Return Value' = @return_value";
            var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            SqlCommand cmd = new SqlCommand(stmt, con);
            using (var da = new SqlDataAdapter(cmd))
            {
                con.Open();
                var executeResult = cmd.ExecuteNonQuery();
                da.Fill(dt);
                con.Close();
            }
            GetAllMessagesDTO.Response ListOfMessages = new GetAllMessagesDTO.Response();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOfMessages.Messages.Add(new MessageDTO<byte[]>()
                {
                    ChatId = int.Parse(dt.Rows[i]["ChatId"].ToString()),
                    MessageId = dt.Rows[i]["MessageId"].ToString(),
                    HasImages = Convert.ToBoolean(dt.Rows[i]["HasImages"].ToString()),
                    ImagesCount = int.Parse(dt.Rows[i]["ImagesCount"].ToString()),
                    MessageStateId = int.Parse(dt.Rows[i]["MessageStateId"].ToString()),
                    MessageTxt = dt.Rows[i]["MessageTxt"].ToString(),
                    MessageTime = dt.Rows[i]["MessageTime"].ToString().Length >= 1 ? dt.Rows[i]["MessageTime"].ToString() : "1212-12-12",
                    RecordDuration = dt.Rows[i]["RecordDuration"].ToString(),
                    SenderId = int.Parse(dt.Rows[i]["SenderId"].ToString()),
                    MessageTypeId = int.Parse(dt.Rows[i]["MessageTypeId"].ToString()),
                    StarredMessage = dt.Rows[i]["StarredMessage"].ToString().Equals("true") ? true : false,
                    FileSize = new List<String>(),
                    FileName = new List<String>(),
                    Files = new List<byte[]> { }
            }) ; ;
            }
            if(ListOfMessages.Messages.Count > 0)
            {

                ListOfMessages.Messages.ForEach(mes =>
                {
                    if (mes is null || !mes.HasImages)
                    {
                        return;
                    }
                    DataTable dtt = new DataTable();

                    string stat = $"USE [CloudChatServiceDB]  DECLARE	@return_value int EXEC	@return_value = [dbo].[p_FileList] @MessageId = N'{mes.MessageId}', @Action = 4 SELECT	'Return Value' = @return_value";
                    var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
                    SqlCommand cmd1 = new SqlCommand(stat, con);
                    using (var daa = new SqlDataAdapter(cmd1))
                    {
                        con.Open();
                        var executeResult = cmd1.ExecuteNonQuery();
                        daa.Fill(dtt);
                        con.Close();
                    }
                    mes.FileName = new List<string>();
                    mes.FileSize = new List<string>();
                    mes.Files = new List<byte[]> { };
                    for (int i = 0; i < dtt.Rows.Count; i++)
                    {
                        mes.FileName.Add(dtt.Rows[i]["FileName"].ToString());
                        mes.FileSize.Add(dtt.Rows[i]["FileSize"].ToString());
                        ImageData data = new ImageData();
                        data = SaveUserImage.getUserImage(dtt.Rows[i]["FilePath"].ToString());
                        mes.Files.Add(data.file);
                    }
                });
            }         

            return ListOfMessages;
        }
        public bool SendMessage(MessageDTO<IFormFile> message, List<string> pathes = null)
        {
            string stmt = $"USE [CloudChatServiceDB] DECLARE	@return_value int EXEC	@return_value = [dbo].[p_Message] @MessageId = N'{message.MessageId}', @MessageTxt = N'{message.MessageTxt}', @MessageTime = N'{message.MessageTime}', @ImagesCount = {message.ImagesCount}, @MessageTimeStamp = NULL, @RecordDuration = N'{message.RecordDuration}', @HasImages = {message.HasImages}, @StarredMessage = {message.StarredMessage}, @SenderId = {message.SenderId}, @MessageTypeId = {message.MessageTypeId}, @ChatId = {message.ChatId}, @MessageStateId = {message.MessageStateId}, @Action = 1 SELECT	'Return Value' = @return_value";
            var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            SqlCommand cmd3 = new SqlCommand(stmt, con);
            con.Open();
            var executeResult = cmd3.ExecuteNonQuery();
            con.Close();
            bool result = executeResult == 0 ? false : true;

            if (pathes.Count > 0 || pathes is not null)
            {
                foreach (string path in pathes)
                {
                    string stat = $"USE [CloudChatServiceDB]  DECLARE	@return_value int EXEC	@return_value = [dbo].[p_FileList] @FilePath = N'{path}', @MessageId = N'{message.MessageId}', @FileSize = N'{message.FileSize.FirstOrDefault()}', @FileName = N'{message.FileName.FirstOrDefault()}', @Action = 1 SELECT	'Return Value' = @return_value";
                    SqlCommand cmd = new SqlCommand(stat, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                   
                    return result;
                }
            }

            return result;
        }

        public bool CheckFolders(int chatId, string myPhoneNumber, string partnerPhoneNumber)
        {
            //string stmt = $"USE [CloudChatServiceDB] DECLARE	@return_value int EXEC	@return_value = [dbo].[p_Chat] @ChatId = {chatId}, @myPhoneNumber = N'{myPhoneNumber}', @partnerPhoneNumber = N'{partnerPhoneNumber}', @Action = 5 SELECT	'Return Value' = @return_value";
            //var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            //SqlCommand cmd = new SqlCommand(stmt, con);
            //con.Open();
            //var executeResult = cmd.ExecuteNonQuery();
            //con.Close();
            //int result = executeResult ;
            //return result;


            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            keyValuePairs.Add("@ChatId", chatId);
            keyValuePairs.Add("@myPhoneNumber", myPhoneNumber);
            keyValuePairs.Add("@partnerPhoneNumber", partnerPhoneNumber);

            bool result = false;

            SQLStoredProcedureCommand.InitConfiguration(_configuration);

            SQLStoredProcedureCommand.StoredProcedureCommand(
                tableName: "dbo.p_Chat", commandParameters: keyValuePairs,
                actionNumber: 5, result: ref result);

            return result;
        }
    }
}
