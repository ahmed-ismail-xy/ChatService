
using CloudChatService.Infrastrucure.Data;

namespace CloudChatService.Core.DTOs.Message
{
    public class MessageDTO 
    {
        public  string MessageId { get; set; }
        public string MessageTxt { get; set; }
        public string MessageTime { get; set; }
        public bool HasFiles { get; set; }
        public bool StarredMessage { get; set; }
        public int SenderId { get; set; }
        public int ChatId { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public int MessageStateId { get; set; }
        public int MessageTypeId { get; set; }
    }
    public class FilesListInMessage<T>
    {
        public List<T> Files { get; set; } = new List<T>();
        public string RecordDuration { get; set; } = string.Empty;
        public bool IsRecord { get; set; } = false;
        public List<string> FileSize { get; set; } = new List<string>();
        public List<string> FileName { get; set; } = new List<string>();
    }
    public class MessageDTO<T> : MessageDTO
    {
        public FilesListInMessage<T> filesList { get; set; }

    }


}
