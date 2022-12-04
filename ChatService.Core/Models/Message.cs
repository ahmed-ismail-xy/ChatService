using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class Message
    {
        Message()
        {
            this.ImageLists = new HashSet<FileList>();
        }
        public int MessageId { get; set; }
        public string MessageTxt { get; set; }
        public DateTime MessageTime { get; set; }
        public int ImagesCount { get; set; }
        public string RecordDuration { get; set; }
        public string FileSize { get; set; }
        public string FileName { get; set; }
        public bool HasImages { get; set; }
        public bool StarredMessage { get; set; }
        public int SenderId { get; set; }


        public Nullable<int> MessageTypeId { get; set; }
        public virtual MessageType MessageType { get; set; }
        public Nullable<int> ChatId { get; set; }
        public virtual Chat Chat { get; set; }
        public Nullable<int> MessageStateId { get; set; }
        public virtual MessageState MessageState { get; set; }

        public virtual ICollection<FileList> ImageLists { get; set; }
    }
}
