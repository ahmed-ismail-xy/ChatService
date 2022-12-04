using CloudChatService.Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CloudChatService.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AccountState> AccountStates { get; set; }
        public DbSet<BlockedContact> BlockedContacts { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMember> ChatMembers { get; set; }
        public DbSet<ChatState> ChatState { get; set; }
        public DbSet<ChatType> ChatType { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<FileList> ImageList { get; set; }
        public DbSet<LastSeenPrivacy> LastSeenPrivacy { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MessageState> MessageState { get; set; }
        public DbSet<MessageType> MessageType { get; set; }
        public DbSet<ProfileImagePrivacy> ProfileImagesPrivacy { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserPrivacy> UserPrivacy { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

    }
}
