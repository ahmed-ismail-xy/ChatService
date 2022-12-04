using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudChatService.Infrastrucure.Data
{
    public class FileList
    {
        public int FileListId { get; set; }
        public string FilePath { get; set; }

        public int MessageId { get; set; }
    }
}
