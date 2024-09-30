using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class MigratonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    idCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__79D361B63F4B6974", x => x.idCategory);
                });

            migrationBuilder.CreateTable(
                name: "ChatRooms",
                columns: table => new
                {
                    idChatRoom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameRoom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChatRoom__77CA433CF4E3AEFC", x => x.idChatRoom);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    idRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__E5045C5430EA4D7B", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    role = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3717C982F8104F53", x => x.idUser);
                    table.ForeignKey(
                        name: "FK__Users__role__3A81B327",
                        column: x => x.role,
                        principalTable: "Roles",
                        principalColumn: "idRole");
                });

            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    idLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: true),
                    action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    dateAction = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AuditLog__3C7153CAD404EE03", x => x.idLog);
                    table.ForeignKey(
                        name: "FK__AuditLog__idUser__797309D9",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "ChatRoomUsers",
                columns: table => new
                {
                    idChatRoom = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChatRoom__44BB3FA42387E54A", x => new { x.idChatRoom, x.idUser });
                    table.ForeignKey(
                        name: "FK__ChatRoomU__idCha__5BE2A6F2",
                        column: x => x.idChatRoom,
                        principalTable: "ChatRooms",
                        principalColumn: "idChatRoom");
                    table.ForeignKey(
                        name: "FK__ChatRoomU__idUse__5CD6CB2B",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    idCourse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameCourse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCategory = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    dateCreated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__8982E309D2B71B88", x => x.idCourse);
                    table.ForeignKey(
                        name: "FK__Courses__idCateg__4222D4EF",
                        column: x => x.idCategory,
                        principalTable: "Categories",
                        principalColumn: "idCategory");
                    table.ForeignKey(
                        name: "FK__Courses__idUser__4316F928",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "DailyUpdates",
                columns: table => new
                {
                    idUpdate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfPosted = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    idUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DailyUpd__746286B67E0071DA", x => x.idUpdate);
                    table.ForeignKey(
                        name: "FK__DailyUpda__idUse__6D0D32F4",
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
                    nameFile = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fileType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fileSize = table.Column<long>(type: "bigint", nullable: true),
                    filePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Files__775AFE7204FA4F12", x => x.idFile);
                    table.ForeignKey(
                        name: "FK__Files__idUser__4D94879B",
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
                    idSender = table.Column<int>(type: "int", nullable: true),
                    idRecipient = table.Column<int>(type: "int", nullable: true),
                    sendingDatetime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    messageText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Messages__8D0E911D9B5F3D7A", x => x.idMessage);
                    table.ForeignKey(
                        name: "FK__Messages__idReci__5535A963",
                        column: x => x.idRecipient,
                        principalTable: "Users",
                        principalColumn: "idUser");
                    table.ForeignKey(
                        name: "FK__Messages__idSend__5441852A",
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
                    idUser = table.Column<int>(type: "int", nullable: true),
                    postTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datePosted = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Posts__BE0F4FD65CDE2D42", x => x.idPost);
                    table.ForeignKey(
                        name: "FK__Posts__idUser__72C60C4A",
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
                    idUser = table.Column<int>(type: "int", nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    biography = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Profiles__E5A723F87824DFFA", x => x.idProfile);
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
                    table.PrimaryKey("PK__UserLang__A9ED13DF6C03C2DC", x => new { x.idUser, x.language });
                    table.ForeignKey(
                        name: "FK__UserLangu__idUse__6FE99F9F",
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
                    idUser = table.Column<int>(type: "int", nullable: true),
                    idCourse = table.Column<int>(type: "int", nullable: true),
                    commentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateCommented = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__0370297ED3E13A79", x => x.idComment);
                    table.ForeignKey(
                        name: "FK__Comments__idCour__60A75C0F",
                        column: x => x.idCourse,
                        principalTable: "Courses",
                        principalColumn: "idCourse");
                    table.ForeignKey(
                        name: "FK__Comments__idUser__5FB337D6",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "CourseMedia",
                columns: table => new
                {
                    idMedia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCourse = table.Column<int>(type: "int", nullable: true),
                    mediaType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    mediaPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseMe__28E7F5731CD3FFC7", x => x.idMedia);
                    table.ForeignKey(
                        name: "FK__CourseMed__idCou__45F365D3",
                        column: x => x.idCourse,
                        principalTable: "Courses",
                        principalColumn: "idCourse");
                });

            migrationBuilder.CreateTable(
                name: "UsersCourses",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idCourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UsersCou__BF8FE7B2D114015B", x => new { x.idUser, x.idCourse });
                    table.ForeignKey(
                        name: "FK__UsersCour__idCou__49C3F6B7",
                        column: x => x.idCourse,
                        principalTable: "Courses",
                        principalColumn: "idCourse");
                    table.ForeignKey(
                        name: "FK__UsersCour__idUse__48CFD27E",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "FileAccess",
                columns: table => new
                {
                    idFile = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: true),
                    accessType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdRoleNavigationIdRole = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FileAcce__442B82EAA6A02880", x => new { x.idFile, x.idUser });
                    table.ForeignKey(
                        name: "FK__FileAcces__idFil__5070F446",
                        column: x => x.idFile,
                        principalTable: "Files",
                        principalColumn: "idFile");
                    table.ForeignKey(
                        name: "FK__FileAcces__idUse__5165187F",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                    table.ForeignKey(
                        name: "FK_FileAccess_Roles_IdRoleNavigationIdRole",
                        column: x => x.IdRoleNavigationIdRole,
                        principalTable: "Roles",
                        principalColumn: "idRole");
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    idLike = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: true),
                    idFile = table.Column<int>(type: "int", nullable: true),
                    idCourse = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Likes__1439B2464CFB2529", x => x.idLike);
                    table.ForeignKey(
                        name: "FK__Likes__idCourse__693CA210",
                        column: x => x.idCourse,
                        principalTable: "Courses",
                        principalColumn: "idCourse");
                    table.ForeignKey(
                        name: "FK__Likes__idFile__68487DD7",
                        column: x => x.idFile,
                        principalTable: "Files",
                        principalColumn: "idFile");
                    table.ForeignKey(
                        name: "FK__Likes__idUser__6754599E",
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
                    idPost = table.Column<int>(type: "int", nullable: true),
                    mediaType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    mediaPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PostMedi__28E7F57349FDB128", x => x.idMedia);
                    table.ForeignKey(
                        name: "FK__PostMedia__idPos__76969D2E",
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
                    idComment = table.Column<int>(type: "int", nullable: true),
                    mediaType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    mediaPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CommentM__28E7F5734F3FDE32", x => x.idMedia);
                    table.ForeignKey(
                        name: "FK__CommentMe__idCom__6477ECF3",
                        column: x => x.idComment,
                        principalTable: "Comments",
                        principalColumn: "idComment");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLog_idUser",
                table: "AuditLog",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomUsers_idUser",
                table: "ChatRoomUsers",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_CommentMedia_idComment",
                table: "CommentMedia",
                column: "idComment");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_idCourse",
                table: "Comments",
                column: "idCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_idUser",
                table: "Comments",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMedia_idCourse",
                table: "CourseMedia",
                column: "idCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_idCategory",
                table: "Courses",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IdUser",
                table: "Courses",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_DailyUpdates_idUser",
                table: "DailyUpdates",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_FileAccess_IdRoleNavigationIdRole",
                table: "FileAccess",
                column: "IdRoleNavigationIdRole");

            migrationBuilder.CreateIndex(
                name: "IX_FileAccess_idUser",
                table: "FileAccess",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Files_idUser",
                table: "Files",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_idCourse",
                table: "Likes",
                column: "idCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_idFile",
                table: "Likes",
                column: "idFile");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_idUser",
                table: "Likes",
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
                name: "UQ__Users__AB6E6164B0C59288",
                table: "Users",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCourses_idCourse",
                table: "UsersCourses",
                column: "idCourse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLog");

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
                name: "Likes");

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
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
