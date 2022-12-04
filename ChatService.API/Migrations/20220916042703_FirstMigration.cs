using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudChatService.API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountStates",
                columns: table => new
                {
                    AccountStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountStateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStates", x => x.AccountStateId);
                });

            migrationBuilder.CreateTable(
                name: "ChatState",
                columns: table => new
                {
                    ChatStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatStateName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatState", x => x.ChatStateId);
                });

            migrationBuilder.CreateTable(
                name: "ChatTypes",
                columns: table => new
                {
                    ChatTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatTypes", x => x.ChatTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupBio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "LastSeenPrivacy",
                columns: table => new
                {
                    LastSeenPrivacyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastSeenPrivacyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastSeenPrivacy", x => x.LastSeenPrivacyId);
                });

            migrationBuilder.CreateTable(
                name: "MessageStates",
                columns: table => new
                {
                    MessageStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageStateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageStates", x => x.MessageStateId);
                });

            migrationBuilder.CreateTable(
                name: "MessageTypes",
                columns: table => new
                {
                    MessageTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTypes", x => x.MessageTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProfileImagesPrivacy",
                columns: table => new
                {
                    ProfileImagePrivacyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePrivacy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileImagesPrivacy", x => x.ProfileImagePrivacyId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnreadMessageCount = table.Column<int>(type: "int", nullable: false),
                    LastMessageTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastMessageSenderId = table.Column<int>(type: "int", nullable: false),
                    MessageTypeId = table.Column<int>(type: "int", nullable: true),
                    ChatTypeId = table.Column<int>(type: "int", nullable: true),
                    ChatStateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chats_ChatState_ChatStateId",
                        column: x => x.ChatStateId,
                        principalTable: "ChatState",
                        principalColumn: "ChatStateId");
                    table.ForeignKey(
                        name: "FK_Chats_ChatTypes_ChatTypeId",
                        column: x => x.ChatTypeId,
                        principalTable: "ChatTypes",
                        principalColumn: "ChatTypeId");
                    table.ForeignKey(
                        name: "FK_Chats_MessageTypes_MessageTypeId",
                        column: x => x.MessageTypeId,
                        principalTable: "MessageTypes",
                        principalColumn: "MessageTypeId");
                });

            migrationBuilder.CreateTable(
                name: "UserPrivacies",
                columns: table => new
                {
                    UserPrivacyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileImagePrivacyId = table.Column<int>(type: "int", nullable: true),
                    LastSeenPrivacyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivacies", x => x.UserPrivacyId);
                    table.ForeignKey(
                        name: "FK_UserPrivacies_LastSeenPrivacy_LastSeenPrivacyId",
                        column: x => x.LastSeenPrivacyId,
                        principalTable: "LastSeenPrivacy",
                        principalColumn: "LastSeenPrivacyId");
                    table.ForeignKey(
                        name: "FK_UserPrivacies_ProfileImagesPrivacy_ProfileImagePrivacyId",
                        column: x => x.ProfileImagePrivacyId,
                        principalTable: "ProfileImagesPrivacy",
                        principalColumn: "ProfileImagePrivacyId");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagesCount = table.Column<int>(type: "int", nullable: false),
                    RecordDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasImages = table.Column<bool>(type: "bit", nullable: false),
                    StarredMessage = table.Column<bool>(type: "bit", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    MessageTypeId = table.Column<int>(type: "int", nullable: true),
                    ChatId = table.Column<int>(type: "int", nullable: true),
                    MessageStateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId");
                    table.ForeignKey(
                        name: "FK_Messages_MessageStates_MessageStateId",
                        column: x => x.MessageStateId,
                        principalTable: "MessageStates",
                        principalColumn: "MessageStateId");
                    table.ForeignKey(
                        name: "FK_Messages_MessageTypes_MessageTypeId",
                        column: x => x.MessageTypeId,
                        principalTable: "MessageTypes",
                        principalColumn: "MessageTypeId");
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FireToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmail1Verfied = table.Column<bool>(type: "bit", nullable: false),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmail2Verfied = table.Column<bool>(type: "bit", nullable: false),
                    UserPrivacyId = table.Column<int>(type: "int", nullable: true),
                    AccountStateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.UserInfoId);
                    table.ForeignKey(
                        name: "FK_UserInfos_AccountStates_AccountStateId",
                        column: x => x.AccountStateId,
                        principalTable: "AccountStates",
                        principalColumn: "AccountStateId");
                    table.ForeignKey(
                        name: "FK_UserInfos_UserPrivacies_UserPrivacyId",
                        column: x => x.UserPrivacyId,
                        principalTable: "UserPrivacies",
                        principalColumn: "UserPrivacyId");
                });

            migrationBuilder.CreateTable(
                name: "ImageLists",
                columns: table => new
                {
                    ImageListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageLists", x => x.ImageListId);
                    table.ForeignKey(
                        name: "FK_ImageLists_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId");
                });

            migrationBuilder.CreateTable(
                name: "BlockedContacts",
                columns: table => new
                {
                    BlockedContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlockedId = table.Column<int>(type: "int", nullable: false),
                    UserInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedContacts", x => x.BlockedContactId);
                    table.ForeignKey(
                        name: "FK_BlockedContacts_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "UserInfoId");
                });

            migrationBuilder.CreateTable(
                name: "ChatMembers",
                columns: table => new
                {
                    ChatMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<int>(type: "int", nullable: true),
                    UserInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMembers", x => x.ChatMemberId);
                    table.ForeignKey(
                        name: "FK_ChatMembers_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId");
                    table.ForeignKey(
                        name: "FK_ChatMembers_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "UserInfoId");
                });

            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    GroupMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    UserInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => x.GroupMemberId);
                    table.ForeignKey(
                        name: "FK_GroupMembers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_GroupMembers_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "UserInfoId");
                    table.ForeignKey(
                        name: "FK_GroupMembers_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlockedContacts_UserInfoId",
                table: "BlockedContacts",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMembers_ChatId",
                table: "ChatMembers",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMembers_UserInfoId",
                table: "ChatMembers",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ChatStateId",
                table: "Chats",
                column: "ChatStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ChatTypeId",
                table: "Chats",
                column: "ChatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_MessageTypeId",
                table: "Chats",
                column: "MessageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_GroupId",
                table: "GroupMembers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_UserInfoId",
                table: "GroupMembers",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_UserRoleId",
                table: "GroupMembers",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageLists_MessageId",
                table: "ImageLists",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageStateId",
                table: "Messages",
                column: "MessageStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageTypeId",
                table: "Messages",
                column: "MessageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_AccountStateId",
                table: "UserInfos",
                column: "AccountStateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_UserPrivacyId",
                table: "UserInfos",
                column: "UserPrivacyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivacies_LastSeenPrivacyId",
                table: "UserPrivacies",
                column: "LastSeenPrivacyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivacies_ProfileImagePrivacyId",
                table: "UserPrivacies",
                column: "ProfileImagePrivacyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockedContacts");

            migrationBuilder.DropTable(
                name: "ChatMembers");

            migrationBuilder.DropTable(
                name: "GroupMembers");

            migrationBuilder.DropTable(
                name: "ImageLists");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "AccountStates");

            migrationBuilder.DropTable(
                name: "UserPrivacies");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "MessageStates");

            migrationBuilder.DropTable(
                name: "LastSeenPrivacy");

            migrationBuilder.DropTable(
                name: "ProfileImagesPrivacy");

            migrationBuilder.DropTable(
                name: "ChatState");

            migrationBuilder.DropTable(
                name: "ChatTypes");

            migrationBuilder.DropTable(
                name: "MessageTypes");
        }
    }
}
