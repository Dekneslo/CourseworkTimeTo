using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    idCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__79D361B68C8E87A5", x => x.idCategory);
                });

            migrationBuilder.CreateTable(
                name: "ChatRooms",
                columns: table => new
                {
                    idChatRoom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameRoom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChatRoom__77CA433C661BA18F", x => x.idChatRoom);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    idRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__E5045C548C159758", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    idCourse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameCourse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCategory = table.Column<int>(type: "int", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__8982E309D74A2CF7", x => x.idCourse);
                    table.ForeignKey(
                        name: "FK__Courses__idCateg__4222D4EF",
                        column: x => x.idCategory,
                        principalTable: "Categories",
                        principalColumn: "idCategory");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3717C9829BB1CC78", x => x.idUser);
                    table.ForeignKey(
                        name: "FK__Users__role__3A81B327",
                        column: x => x.role,
                        principalTable: "Roles",
                        principalColumn: "idRole");
                });

            migrationBuilder.CreateTable(
                name: "ChatRoomUsers",
                columns: table => new
                {
                    IdChatRoom = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoomUsers", x => new { x.IdChatRoom, x.IdUser });
                    table.ForeignKey(
                        name: "FK_ChatRoomUsers_ChatRooms_IdChatRoom",
                        column: x => x.IdChatRoom,
                        principalTable: "ChatRooms",
                        principalColumn: "idChatRoom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatRoomUsers_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyUpdates",
                columns: table => new
                {
                    idUpdate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfPosted = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    idUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DailyUpd__746286B669900875", x => x.idUpdate);
                    table.ForeignKey(
                        name: "FK__DailyUpda__idUse__75A278F5",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    idFile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameFile = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    fileType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fileSize = table.Column<long>(type: "bigint", nullable: false),
                    filePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Files__775AFE727130F41E", x => x.idFile);
                    table.ForeignKey(
                        name: "FK__Files__idUser__46E78A0C",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "LikesToCourses",
                columns: table => new
                {
                    idLike = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idCourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LikesToC__1439B24683ABE907", x => x.idLike);
                    table.ForeignKey(
                        name: "FK__LikesToCo__idCou__6E01572D",
                        column: x => x.idCourse,
                        principalTable: "Courses",
                        principalColumn: "idCourse");
                    table.ForeignKey(
                        name: "FK__LikesToCo__idUse__6D0D32F4",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    idMessage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSender = table.Column<int>(type: "int", nullable: false),
                    idRecipient = table.Column<int>(type: "int", nullable: false),
                    sendingDatetime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    messageText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Messages__8D0E911DF9998DDF", x => x.idMessage);
                    table.ForeignKey(
                        name: "FK__Messages__idReci__5629CD9C",
                        column: x => x.idRecipient,
                        principalTable: "Users",
                        principalColumn: "idUser");
                    table.ForeignKey(
                        name: "FK__Messages__idSend__5535A963",
                        column: x => x.idSender,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    idPost = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    postTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    postContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datePosted = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Posts__BE0F4FD6F2CAA47A", x => x.idPost);
                    table.ForeignKey(
                        name: "FK__Posts__idUser__60A75C0F",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    idProfile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    biography = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Profiles__E5A723F8237547AA", x => x.idProfile);
                    table.ForeignKey(
                        name: "FK__Profiles__idUser__3D5E1FD2",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "UserLanguages",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    language = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserLang__A9ED13DFD73F19DD", x => new { x.idUser, x.language });
                    table.ForeignKey(
                        name: "FK__UserLangu__idUse__787EE5A0",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "UsersCourses",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCourses", x => new { x.IdUser, x.IdCourse });
                    table.ForeignKey(
                        name: "FK_UsersCourses_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "idCourse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersCourses_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseMedia",
                columns: table => new
                {
                    idMedia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCourse = table.Column<int>(type: "int", nullable: false),
                    idFile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseMe__28E7F5736E85D76B", x => x.idMedia);
                    table.ForeignKey(
                        name: "FK__CourseMed__idCou__49C3F6B7",
                        column: x => x.idCourse,
                        principalTable: "Courses",
                        principalColumn: "idCourse");
                    table.ForeignKey(
                        name: "FK__CourseMed__idFil__4AB81AF0",
                        column: x => x.idFile,
                        principalTable: "Files",
                        principalColumn: "idFile");
                });

            migrationBuilder.CreateTable(
                name: "FileAccess",
                columns: table => new
                {
                    idFile = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    accessType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FileAcce__442B82EAC0E96196", x => new { x.idFile, x.idUser });
                    table.ForeignKey(
                        name: "FK__FileAcces__idFil__5165187F",
                        column: x => x.idFile,
                        principalTable: "Files",
                        principalColumn: "idFile");
                    table.ForeignKey(
                        name: "FK__FileAcces__idUse__52593CB8",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    idComment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idPost = table.Column<int>(type: "int", nullable: true),
                    idCourse = table.Column<int>(type: "int", nullable: true),
                    commentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateCommented = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__0370297E0752E848", x => x.idComment);
                    table.ForeignKey(
                        name: "FK__Comments__idCour__66603565",
                        column: x => x.idCourse,
                        principalTable: "Courses",
                        principalColumn: "idCourse");
                    table.ForeignKey(
                        name: "FK__Comments__idPost__656C112C",
                        column: x => x.idPost,
                        principalTable: "Posts",
                        principalColumn: "idPost");
                    table.ForeignKey(
                        name: "FK__Comments__idUser__6477ECF3",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "LikesToPosts",
                columns: table => new
                {
                    idLike = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idPost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LikesToP__1439B24662FBE768", x => x.idLike);
                    table.ForeignKey(
                        name: "FK__LikesToPo__idPos__71D1E811",
                        column: x => x.idPost,
                        principalTable: "Posts",
                        principalColumn: "idPost");
                    table.ForeignKey(
                        name: "FK__LikesToPo__idUse__70DDC3D8",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "PostMedia",
                columns: table => new
                {
                    idMedia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPost = table.Column<int>(type: "int", nullable: false),
                    idFile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PostMedi__28E7F573B8658FAE", x => x.idMedia);
                    table.ForeignKey(
                        name: "FK__PostMedia__idFil__7C4F7684",
                        column: x => x.idFile,
                        principalTable: "Files",
                        principalColumn: "idFile");
                    table.ForeignKey(
                        name: "FK__PostMedia__idPos__7B5B524B",
                        column: x => x.idPost,
                        principalTable: "Posts",
                        principalColumn: "idPost");
                });

            migrationBuilder.CreateTable(
                name: "CommentMedia",
                columns: table => new
                {
                    idMedia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idComment = table.Column<int>(type: "int", nullable: false),
                    mediaType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    mediaPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CommentM__28E7F573BE92AB29", x => x.idMedia);
                    table.ForeignKey(
                        name: "FK__CommentMe__idCom__6A30C649",
                        column: x => x.idComment,
                        principalTable: "Comments",
                        principalColumn: "idComment");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomUsers_IdUser",
                table: "ChatRoomUsers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_CommentMedia_idComment",
                table: "CommentMedia",
                column: "idComment");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_idCourse",
                table: "Comments",
                column: "idCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_idPost",
                table: "Comments",
                column: "idPost");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_idUser",
                table: "Comments",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMedia_idCourse",
                table: "CourseMedia",
                column: "idCourse");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMedia_idFile",
                table: "CourseMedia",
                column: "idFile");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_idCategory",
                table: "Courses",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "IX_DailyUpdates_idUser",
                table: "DailyUpdates",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_FileAccess_idUser",
                table: "FileAccess",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Files_idUser",
                table: "Files",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_LikesToCourses_idCourse",
                table: "LikesToCourses",
                column: "idCourse");

            migrationBuilder.CreateIndex(
                name: "IX_LikesToCourses_idUser",
                table: "LikesToCourses",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_LikesToPosts_idPost",
                table: "LikesToPosts",
                column: "idPost");

            migrationBuilder.CreateIndex(
                name: "IX_LikesToPosts_idUser",
                table: "LikesToPosts",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_idRecipient",
                table: "Messages",
                column: "idRecipient");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_idSender",
                table: "Messages",
                column: "idSender");

            migrationBuilder.CreateIndex(
                name: "IX_PostMedia_idFile",
                table: "PostMedia",
                column: "idFile");

            migrationBuilder.CreateIndex(
                name: "IX_PostMedia_idPost",
                table: "PostMedia",
                column: "idPost");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_idUser",
                table: "Posts",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_idUser",
                table: "Profiles",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_role",
                table: "Users",
                column: "role");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E61648AC7037C",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersCourses_IdCourse",
                table: "UsersCourses",
                column: "IdCourse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatRoomUsers");

            migrationBuilder.DropTable(
                name: "CommentMedia");

            migrationBuilder.DropTable(
                name: "CourseMedia");

            migrationBuilder.DropTable(
                name: "DailyUpdates");

            migrationBuilder.DropTable(
                name: "FileAccess");

            migrationBuilder.DropTable(
                name: "LikesToCourses");

            migrationBuilder.DropTable(
                name: "LikesToPosts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PostMedia");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "UserLanguages");

            migrationBuilder.DropTable(
                name: "UsersCourses");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
