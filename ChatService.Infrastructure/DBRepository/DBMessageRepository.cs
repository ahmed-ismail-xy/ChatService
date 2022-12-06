using CloudChatService.Core.DTOs.Message;
using CloudChatService.Core.DTOs.UserProfile;
using CloudChatService.Core.IDBServices;
using CloudChatService.Infrastructure.Repository.UserRepository.Helper;
using CloudChatService.Infrastrucure.Data;
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

        private GetAllMessagesDTO.Response GetFilesList(GetAllMessagesDTO.Response ListOfMessages)
        {
            ListOfMessages.Messages.ForEach(mes =>
            {
                DataTable dt = new DataTable();
                if (mes.HasFiles)
                {
                    string stmt = $"USE [CloudChatServiceDB]  DECLARE	@return_value int EXEC	@return_value = [dbo].[p_FileList] @MessageId = N'{mes.MessageId}', @Action = 4 SELECT	'Return Value' = @return_value";
                    var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
                    SqlCommand cmd = new SqlCommand(stmt, con);
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        con.Open();
                        var executeResult = cmd.ExecuteNonQuery();
                        da.Fill(dt);
                        con.Close();
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        mes.filesList.IsRecord = Convert.ToBoolean(dt.Rows[i]["IsRecord"].ToString());
                        mes.filesList.RecordDuration = dt.Rows[i]["RecordDuration"].ToString();

                        mes.filesList.FileName.Add(dt.Rows[i]["FileName"].ToString());
                        mes.filesList.FileSize.Add(dt.Rows[i]["FileSize"].ToString());
                        
                        ImageData data = new ImageData();
                        data = SaveUserFile.getUserFile(dt.Rows[i]["FilePath"].ToString());

                       // MemoryStream ms = new MemoryStream(data.file);

                        mes.filesList.Files.Add(data.file);
                    }
                }
            });
            

            return ListOfMessages;
        }
        public GetAllMessagesDTO.Response GetAllMessagesByChatId(int chatId)
        {
            DataTable dt = new DataTable();

            string stmt = $"SELECT * FROM [dbo].[Message] WHERE ChatId = {chatId}";
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


            //string physicalPath = "wwwroot/pdf/mvc.pdf";
            //byte[] pdfBytes = System.IO.File.ReadAllBytes(physicalPath);
            //MemoryStream ms = new MemoryStream(pdfBytes);
            //return new FileStreamResult(ms, "application/pdf");


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOfMessages.Messages.Add(new MessageDTO<byte[]>()
                {
                    ChatId = int.Parse(dt.Rows[i]["ChatId"].ToString()),
                    MessageId = dt.Rows[i]["MessageId"].ToString(),
                    MessageStateId = int.Parse(dt.Rows[i]["MessageStateId"].ToString()),
                    MessageTxt = dt.Rows[i]["MessageTxt"].ToString(),
                    MessageTime = dt.Rows[i]["MessageTime"].ToString().Length >= 1 ? dt.Rows[i]["MessageTime"].ToString() : "1212-12-12",
                    SenderId = int.Parse(dt.Rows[i]["SenderId"].ToString()),
                    MessageTypeId = int.Parse(dt.Rows[i]["MessageTypeId"].ToString()),
                    StarredMessage = dt.Rows[i]["StarredMessage"].ToString().Equals("true") ? true : false,
                    HasFiles = Convert.ToBoolean(dt.Rows[i]["HasFiles"].ToString()),

                    filesList = new FilesListInMessage<byte[]>()
                    {
                        FileName = new List<string>() { },
                        FileSize = new List<string>() { },
                        IsRecord = false,
                        RecordDuration = String.Empty,
                        Files = new List<byte[]>(){ }
                    }
                }) ; 
            }

            GetFilesList(ListOfMessages);

            return ListOfMessages;
        }
        public bool SendMessage(MessageDTO<IFormFile> message, List<string> pathes = null)
        {
            string stmt = $"USE [CloudChatServiceDB] DECLARE	@return_value int EXEC	@return_value = [dbo].[p_Message] @MessageId = N'{message.MessageId}', @MessageTxt = N'{message.MessageTxt}', @MessageTime = N'{message.MessageTime}', @StarredMessage = {message.StarredMessage}, @SenderId = {message.SenderId}, @MessageTypeId = {message.MessageTypeId}, @ChatId = {message.ChatId}, @MessageStateId = {message.MessageStateId}, @HasFiles = {message.HasFiles}, @Action = 1 SELECT	'Return Value' = @return_value";
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
                    string stat = $"USE [CloudChatServiceDB]  DECLARE	@return_value int EXEC	@return_value = [dbo].[p_FileList] @FilePath = N'{path}', @MessageId = N'{message.MessageId}', @FileSize = N'{message.filesList.FileSize.FirstOrDefault()}', @FileName = N'{message.filesList.FileName.FirstOrDefault()}', @ChatId = N'{message.ChatId}', @IsRecord = N'{message.filesList.IsRecord}', @Action = 1 SELECT	'Return Value' = @return_value";
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
