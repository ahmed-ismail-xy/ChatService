
namespace CloudChatService.Core.DTOs.Message
{
    public class MessageDTO<T>
    {
        public string MessageId { get; set; }
        public string MessageTxt { get; set; }
        public string MessageTime { get; set; }
        public int ImagesCount { get; set; }
        public string RecordDuration { get; set; }
        public List<string>? FileSize { get; set; }
        public List<string>? FileName { get; set; }
        public bool HasImages { get; set; }
        public bool StarredMessage { get; set; }
        public int SenderId { get; set; }
        public int ChatId { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public int MessageStateId { get; set; }
        public int MessageTypeId { get; set; }
        public List<T>? Files { get; set; }
    }

}
