﻿// <auto-generated />
using System;
using CloudChatService.Infrastructure.Data;
using CloudChatService.Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CloudChatService.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220916042703_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.AccountState", b =>
                {
                    b.Property<int>("AccountStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountStateId"), 1L, 1);

                    b.Property<string>("AccountStateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountStateId");

                    b.ToTable("AccountStates");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.BlockedContact", b =>
                {
                    b.Property<int>("BlockedContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlockedContactId"), 1L, 1);

                    b.Property<DateTime>("BlockedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("BlockedId")
                        .HasColumnType("int");

                    b.Property<int?>("UserInfoId")
                        .HasColumnType("int");

                    b.HasKey("BlockedContactId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("BlockedContacts");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatId"), 1L, 1);

                    b.Property<string>("ChatImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ChatStateId")
                        .HasColumnType("int");

                    b.Property<int?>("ChatTypeId")
                        .HasColumnType("int");

                    b.Property<string>("LastMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LastMessageSenderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastMessageTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MessageTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UnreadMessageCount")
                        .HasColumnType("int");

                    b.HasKey("ChatId");

                    b.HasIndex("ChatStateId");

                    b.HasIndex("ChatTypeId");

                    b.HasIndex("MessageTypeId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.ChatMember", b =>
                {
                    b.Property<int>("ChatMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatMemberId"), 1L, 1);

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<int?>("UserInfoId")
                        .HasColumnType("int");

                    b.HasKey("ChatMemberId");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("ChatMembers");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.ChatState", b =>
                {
                    b.Property<int>("ChatStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatStateId"), 1L, 1);

                    b.Property<int>("ChatStateName")
                        .HasColumnType("int");

                    b.HasKey("ChatStateId");

                    b.ToTable("ChatState");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.ChatType", b =>
                {
                    b.Property<int>("ChatTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatTypeId"), 1L, 1);

                    b.Property<string>("ChatTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChatTypeId");

                    b.ToTable("ChatTypes");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"), 1L, 1);

                    b.Property<string>("GroupBio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.GroupMember", b =>
                {
                    b.Property<int>("GroupMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupMemberId"), 1L, 1);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("UserInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("GroupMemberId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserInfoId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.ImageList", b =>
                {
                    b.Property<int>("ImageListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageListId"), 1L, 1);

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MessageId")
                        .HasColumnType("int");

                    b.HasKey("ImageListId");

                    b.HasIndex("MessageId");

                    b.ToTable("ImageLists");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.LastSeenPrivacy", b =>
                {
                    b.Property<int>("LastSeenPrivacyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LastSeenPrivacyId"), 1L, 1);

                    b.Property<string>("LastSeenPrivacyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LastSeenPrivacyId");

                    b.ToTable("LastSeenPrivacy");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasImages")
                        .HasColumnType("bit");

                    b.Property<int>("ImagesCount")
                        .HasColumnType("int");

                    b.Property<int?>("MessageStateId")
                        .HasColumnType("int");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MessageTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MessageTypeId")
                        .HasColumnType("int");

                    b.Property<string>("RecordDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<bool>("StarredMessage")
                        .HasColumnType("bit");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatId");

                    b.HasIndex("MessageStateId");

                    b.HasIndex("MessageTypeId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.MessageState", b =>
                {
                    b.Property<int>("MessageStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageStateId"), 1L, 1);

                    b.Property<string>("MessageStateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageStateId");

                    b.ToTable("MessageStates");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.MessageType", b =>
                {
                    b.Property<int>("MessageTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageTypeId"), 1L, 1);

                    b.Property<string>("MessageTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageTypeId");

                    b.ToTable("MessageTypes");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.ProfileImagePrivacy", b =>
                {
                    b.Property<int>("ProfileImagePrivacyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfileImagePrivacyId"), 1L, 1);

                    b.Property<string>("ImagePrivacy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfileImagePrivacyId");

                    b.ToTable("ProfileImagesPrivacy");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.UserInfo", b =>
                {
                    b.Property<int>("UserInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserInfoId"), 1L, 1);

                    b.Property<int?>("AccountStateId")
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FireToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmail1Verfied")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmail2Verfied")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserPrivacyId")
                        .HasColumnType("int");

                    b.HasKey("UserInfoId");

                    b.HasIndex("AccountStateId");

                    b.HasIndex("UserPrivacyId");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.UserPrivacy", b =>
                {
                    b.Property<int>("UserPrivacyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserPrivacyId"), 1L, 1);

                    b.Property<int?>("LastSeenPrivacyId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfileImagePrivacyId")
                        .HasColumnType("int");

                    b.HasKey("UserPrivacyId");

                    b.HasIndex("LastSeenPrivacyId");

                    b.HasIndex("ProfileImagePrivacyId");

                    b.ToTable("UserPrivacies");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleId"), 1L, 1);

                    b.Property<string>("UserRoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.BlockedContact", b =>
                {
                    b.HasOne("CloudChatService.Infrastrucure.Data.UserInfo", "UserInfo")
                        .WithMany("BlockedContacts")
                        .HasForeignKey("UserInfoId");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.Chat", b =>
                {
                    b.HasOne("CloudChatService.Infrastrucure.Data.ChatState", "ChatState")
                        .WithMany("Chats")
                        .HasForeignKey("ChatStateId");

                    b.HasOne("CloudChatService.Infrastrucure.Data.ChatType", "ChatType")
                        .WithMany("Chats")
                        .HasForeignKey("ChatTypeId");

                    b.HasOne("CloudChatService.Infrastrucure.Data.MessageType", "MessageType")
                        .WithMany("Chats")
                        .HasForeignKey("MessageTypeId");

                    b.Navigation("ChatState");

                    b.Navigation("ChatType");

                    b.Navigation("MessageType");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.ChatMember", b =>
                {
                    b.HasOne("CloudChatService.Infrastrucure.Data.Chat", "Chat")
                        .WithMany("ChatMembers")
                        .HasForeignKey("ChatId");

                    b.HasOne("CloudChatService.Infrastrucure.Data.UserInfo", "UserInfo")
                        .WithMany("ChatMembers")
                        .HasForeignKey("UserInfoId");

                    b.Navigation("Chat");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.GroupMember", b =>
                {
                    b.HasOne("CloudChatService.Infrastrucure.Data.Group", "Group")
                        .WithMany("GroupMembers")
                        .HasForeignKey("GroupId");

                    b.HasOne("CloudChatService.Infrastrucure.Data.UserInfo", "UserInfo")
                        .WithMany("GroupMembers")
                        .HasForeignKey("UserInfoId");

                    b.HasOne("CloudChatService.Infrastrucure.Data.UserRole", "UserRole")
                        .WithMany("GroupMembers")
                        .HasForeignKey("UserRoleId");

                    b.Navigation("Group");

                    b.Navigation("UserInfo");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.ImageList", b =>
                {
                    b.HasOne("CloudChatService.Infrastrucure.Data.Message", "Message")
                        .WithMany("ImageLists")
                        .HasForeignKey("MessageId");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.Message", b =>
                {
                    b.HasOne("CloudChatService.Infrastrucure.Data.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId");

                    b.HasOne("CloudChatService.Infrastrucure.Data.MessageState", "MessageState")
                        .WithMany("Messages")
                        .HasForeignKey("MessageStateId");

                    b.HasOne("CloudChatService.Infrastrucure.Data.MessageType", "MessageType")
                        .WithMany("Messages")
                        .HasForeignKey("MessageTypeId");

                    b.Navigation("Chat");

                    b.Navigation("MessageState");

                    b.Navigation("MessageType");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.UserInfo", b =>
                {
                    b.HasOne("CloudChatService.Infrastrucure.Data.AccountState", "AccountState")
                        .WithMany("UserInfos")
                        .HasForeignKey("AccountStateId");

                    b.HasOne("CloudChatService.Infrastrucure.Data.UserPrivacy", "UserPrivacy")
                        .WithMany("UserInfos")
                        .HasForeignKey("UserPrivacyId");

                    b.Navigation("AccountState");

                    b.Navigation("UserPrivacy");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.UserPrivacy", b =>
                {
                    b.HasOne("CloudChatService.Infrastrucure.Data.LastSeenPrivacy", "LastSeenPrivacy")
                        .WithMany("UserPrivacies")
                        .HasForeignKey("LastSeenPrivacyId");

                    b.HasOne("CloudChatService.Infrastrucure.Data.ProfileImagePrivacy", "ProfileImagePrivacy")
                        .WithMany("UserPrivacies")
                        .HasForeignKey("ProfileImagePrivacyId");

                    b.Navigation("LastSeenPrivacy");

                    b.Navigation("ProfileImagePrivacy");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.AccountState", b =>
                {
                    b.Navigation("UserInfos");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.Chat", b =>
                {
                    b.Navigation("ChatMembers");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.ChatState", b =>
                {
                    b.Navigation("Chats");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.ChatType", b =>
                {
                    b.Navigation("Chats");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.Group", b =>
                {
                    b.Navigation("GroupMembers");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.LastSeenPrivacy", b =>
                {
                    b.Navigation("UserPrivacies");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.Message", b =>
                {
                    b.Navigation("ImageLists");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.MessageState", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.MessageType", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.ProfileImagePrivacy", b =>
                {
                    b.Navigation("UserPrivacies");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.UserInfo", b =>
                {
                    b.Navigation("BlockedContacts");

                    b.Navigation("ChatMembers");

                    b.Navigation("GroupMembers");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.UserPrivacy", b =>
                {
                    b.Navigation("UserInfos");
                });

            modelBuilder.Entity("CloudChatService.Infrastrucure.Data.UserRole", b =>
                {
                    b.Navigation("GroupMembers");
                });
#pragma warning restore 612, 618
        }
    }
}