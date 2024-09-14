SELECT 
    fk.name AS FK_name,
    tp.name AS Parent_table,
    ref.name AS Referenced_table
FROM 
    sys.foreign_keys AS fk
    INNER JOIN sys.tables AS tp ON fk.parent_object_id = tp.object_id
    INNER JOIN sys.tables AS ref ON fk.referenced_object_id = ref.object_id
WHERE 
    tp.name = 'AuditLog';


	SELECT 
    fk.name AS FK_name,
    tp.name AS Parent_table,
    ref.name AS Referenced_table,
    c1.name AS Parent_column,
    c2.name AS Referenced_column,
    fk.delete_referential_action_desc AS Delete_Action
FROM 
    sys.foreign_keys AS fk
    INNER JOIN sys.tables AS tp ON fk.parent_object_id = tp.object_id
    INNER JOIN sys.tables AS ref ON fk.referenced_object_id = ref.object_id
    INNER JOIN sys.foreign_key_columns AS fkc ON fk.object_id = fkc.constraint_object_id
    INNER JOIN sys.columns AS c1 ON fkc.parent_object_id = c1.object_id AND fkc.parent_column_id = c1.column_id
    INNER JOIN sys.columns AS c2 ON fkc.referenced_object_id = c2.object_id AND fkc.referenced_column_id = c2.column_id
WHERE 
    tp.name = 'UsersCourses' OR ref.name = 'Courses';

	----------------------------------------------------------
	-- Удаление существующих внешних ключей
ALTER TABLE Users DROP CONSTRAINT FK__Users__role__276EDEB3;
ALTER TABLE Profiles DROP CONSTRAINT FK__Profiles__idUser__2A4B4B5E;
ALTER TABLE Courses DROP CONSTRAINT FK__Courses__idCateg__2F10007B;
ALTER TABLE Courses DROP CONSTRAINT FK__Courses__idUser__300424B4;
ALTER TABLE CourseMedia DROP CONSTRAINT FK__CourseMed__idCou__33D4B598;
ALTER TABLE UsersCourses DROP CONSTRAINT FK__UsersCour__idUse__36B12243;
ALTER TABLE UsersCourses DROP CONSTRAINT FK__UsersCour__idCou__37A5467C;
ALTER TABLE Files DROP CONSTRAINT FK__Files__idUser__3A81B327;
ALTER TABLE FileAccess DROP CONSTRAINT FK__FileAcces__idFil__3D5E1FD2;
ALTER TABLE FileAccess DROP CONSTRAINT FK__FileAcces__idUse__3E52440B;
ALTER TABLE FileAccess DROP CONSTRAINT FK__FileAcces__idRol__3F466844;
ALTER TABLE Messages DROP CONSTRAINT FK__Messages__idSend__4222D4EF;
ALTER TABLE Messages DROP CONSTRAINT FK__Messages__idReci__4316F928;
ALTER TABLE ChatRoomUsers DROP CONSTRAINT FK__ChatRoomU__idCha__48CFD27E;
ALTER TABLE ChatRoomUsers DROP CONSTRAINT FK__ChatRoomU__idUse__49C3F6B7;
ALTER TABLE Comments DROP CONSTRAINT FK__Comments__idUser__4CA06362;
ALTER TABLE Comments DROP CONSTRAINT FK__Comments__idCour__4D94879B;
ALTER TABLE CommentMedia DROP CONSTRAINT FK__CommentMe__idCom__5165187F;
ALTER TABLE Likes DROP CONSTRAINT FK__Likes__idUser__5441852A;
ALTER TABLE Likes DROP CONSTRAINT FK__Likes__idFile__5535A963;
ALTER TABLE Likes DROP CONSTRAINT FK__Likes__idCourse__5629CD9C;
ALTER TABLE DailyUpdates DROP CONSTRAINT FK__DailyUpda__idUse__59FA5E80;
ALTER TABLE UserLanguages DROP CONSTRAINT FK__UserLangu__idUse__5CD6CB2B;
ALTER TABLE Posts DROP CONSTRAINT FK__Posts__idUser__5FB337D6;
ALTER TABLE PostMedia DROP CONSTRAINT FK__PostMedia__idPos__6383C8BA;
ALTER TABLE AuditLog DROP CONSTRAINT FK__AuditLog__idUser__66603565;

-- Восстановление внешних ключей с каскадным удалением
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Roles
FOREIGN KEY (role) REFERENCES Roles(idRole) ON DELETE CASCADE;

ALTER TABLE Profiles
ADD CONSTRAINT FK_Profiles_Users
FOREIGN KEY (idUser) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE Courses
ADD CONSTRAINT FK_Courses_Categories
FOREIGN KEY (idCategory) REFERENCES Categories(idCategory) ON DELETE CASCADE;

ALTER TABLE Courses
ADD CONSTRAINT FK_Courses_Users
FOREIGN KEY (idUser) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE CourseMedia
ADD CONSTRAINT FK_CourseMedia_Courses
FOREIGN KEY (idCourse) REFERENCES Courses(idCourse) ON DELETE CASCADE;

ALTER TABLE UsersCourses
ADD CONSTRAINT FK_UsersCourses_Users
FOREIGN KEY (idUser) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE UsersCourses
ADD CONSTRAINT FK_UsersCourses_Courses
FOREIGN KEY (idCourse) REFERENCES Courses(idCourse) ON DELETE ACTION;

---- Удалите старое ограничение, если оно есть
--ALTER TABLE UsersCourses
--DROP CONSTRAINT FK_UsersCourses_Courses;

---- Добавьте новое ограничение без каскадного удаления
--ALTER TABLE UsersCourses
--ADD CONSTRAINT FK_UsersCourses_Courses
--FOREIGN KEY (idCourse) REFERENCES Courses(idCourse) ON DELETE NO ACTION;


ALTER TABLE Files
ADD CONSTRAINT FK_Files_Users
FOREIGN KEY (idUser) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE FileAccess
ADD CONSTRAINT FK_FileAccess_Files
FOREIGN KEY (idFile) REFERENCES Files(idFile) ON DELETE CASCADE;

ALTER TABLE FileAccess
ADD CONSTRAINT FK_FileAccess_Users
FOREIGN KEY (idUser) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE FileAccess
ADD CONSTRAINT FK_FileAccess_Roles
FOREIGN KEY (idRole) REFERENCES Roles(idRole) ON DELETE CASCADE;

ALTER TABLE Messages
ADD CONSTRAINT FK_Messages_Sender
FOREIGN KEY (idSender) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE Messages
ADD CONSTRAINT FK_Messages_Recipient
FOREIGN KEY (idRecipient) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE ChatRoomUsers
ADD CONSTRAINT FK_ChatRoomUsers_ChatRooms
FOREIGN KEY (idChatRoom) REFERENCES ChatRooms(idChatRoom) ON DELETE CASCADE;

ALTER TABLE ChatRoomUsers
ADD CONSTRAINT FK_ChatRoomUsers_Users
FOREIGN KEY (idUser) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE Comments
ADD CONSTRAINT FK_Comments_Users
FOREIGN KEY (idUser) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE Comments
ADD CONSTRAINT FK_Comments_Courses
FOREIGN KEY (idCourse) REFERENCES Courses(idCourse) ON DELETE CASCADE;

ALTER TABLE CommentMedia
ADD CONSTRAINT FK_CommentMedia_Comments
FOREIGN KEY (idComment) REFERENCES Comments(idComment) ON DELETE CASCADE;

ALTER TABLE Likes
ADD CONSTRAINT FK_Likes_Users
FOREIGN KEY (idUser) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE Likes
ADD CONSTRAINT FK_Likes_Files
FOREIGN KEY (idFile) REFERENCES Files(idFile) ON DELETE CASCADE;

ALTER TABLE Likes
ADD CONSTRAINT FK_Likes_Courses
FOREIGN KEY (idCourse) REFERENCES Courses(idCourse) ON DELETE CASCADE;

ALTER TABLE DailyUpdates
ADD CONSTRAINT FK_DailyUpdates_Users
FOREIGN KEY (idUser) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE UserLanguages
ADD CONSTRAINT FK_UserLanguages_Users
FOREIGN KEY (idUser) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE Posts
ADD CONSTRAINT FK_Posts_Users
FOREIGN KEY (idUser) REFERENCES Users(idUser) ON DELETE CASCADE;

ALTER TABLE PostMedia
ADD CONSTRAINT FK_PostMedia_Posts
FOREIGN KEY (idPost) REFERENCES Posts(idPost) ON DELETE CASCADE;

ALTER TABLE AuditLog
ADD CONSTRAINT FK_AuditLog_Users
FOREIGN KEY (idUser) REFERENCES Users(idUser) ON DELETE CASCADE;

--------------------------------
CREATE DATABASE CharityDB;

USE CharityDB;

--1 Таблица ролей
CREATE TABLE Roles (
    idRole INT PRIMARY KEY IDENTITY(1,1),
    nameRole NVARCHAR(50)
);
--2 Таблица пользователей
CREATE TABLE Users (
    idUser INT PRIMARY KEY IDENTITY(1,1),
    firstName NVARCHAR(50),
    lastName NVARCHAR(50),
    email NVARCHAR(100) UNIQUE,
    password NVARCHAR(255),
    role INT FOREIGN KEY REFERENCES Roles(idRole) ON DELETE CASCADE
);
--3 Таблица профилей пользователей
CREATE TABLE Profiles (
    idProfile INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE,
    city NVARCHAR(50),
    country NVARCHAR(50),
    phoneNumber NVARCHAR(20),
    biography NVARCHAR(MAX)
);
--4 Таблица категорий курсов
CREATE TABLE Categories (
    idCategory INT PRIMARY KEY IDENTITY(1,1),
    nameCategory NVARCHAR(100)
);
--5 Таблица курсов
CREATE TABLE Courses (
    idCourse INT PRIMARY KEY IDENTITY(1,1),
    nameCourse NVARCHAR(100),
    description NVARCHAR(MAX),
    idCategory INT FOREIGN KEY REFERENCES Categories(idCategory) ON DELETE CASCADE,
    idUser INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE,
    dateCreated DATETIME DEFAULT GETDATE()
);
--6 Таблица для медиафайлов курсов
CREATE TABLE CourseMedia (
    idMedia INT PRIMARY KEY IDENTITY(1,1),
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse) ON DELETE CASCADE,
    mediaType NVARCHAR(10), -- 'photo', 'video'
    mediaPath NVARCHAR(255)
);
--7 Таблица для связи пользователей и курсов
CREATE TABLE UsersCourses (
    idUser INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE,
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse) ON DELETE CASCADE,
    PRIMARY KEY (idUser, idCourse)
);
--8 Таблица для файлов
CREATE TABLE Files (
    idFile INT PRIMARY KEY IDENTITY(1,1),
    nameFile NVARCHAR(255),
    fileType NVARCHAR(50),
    fileSize BIGINT,
    filePath NVARCHAR(255),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE
);
--9 Таблица для назначения прав доступа к файлам
CREATE TABLE FileAccess (
    idFile INT FOREIGN KEY REFERENCES Files(idFile) ON DELETE CASCADE,
    idUser INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE,
    idRole INT FOREIGN KEY REFERENCES Roles(idRole) ON DELETE CASCADE,
    accessType NVARCHAR(50),
    PRIMARY KEY (idFile, idUser)
);
--10 Таблица сообщений
CREATE TABLE Messages (
    idMessage INT PRIMARY KEY IDENTITY(1,1),
    idSender INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE,
    idRecipient INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE,
    sendingDatetime DATETIME DEFAULT GETDATE(),
    messageText NVARCHAR(MAX)
);
--11 Таблица комнат для чатов
CREATE TABLE ChatRooms (
    idChatRoom INT PRIMARY KEY IDENTITY(1,1),
    nameRoom NVARCHAR(100)
);
--12 Таблица связи пользователей и чат-комнат
CREATE TABLE ChatRoomUsers (
    idChatRoom INT FOREIGN KEY REFERENCES ChatRooms(idChatRoom) ON DELETE CASCADE,
    idUser INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE,
    PRIMARY KEY (idChatRoom, idUser)
);
--13 Таблица для комментариев к курсам
CREATE TABLE Comments (
    idComment INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE,
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse) ON DELETE CASCADE,
    commentDescription NVARCHAR(MAX),
    dateCommented DATETIME DEFAULT GETDATE()
);
--14 Таблица для медиафайлов в комментариях
CREATE TABLE CommentMedia (
    idMedia INT PRIMARY KEY IDENTITY(1,1),
    idComment INT FOREIGN KEY REFERENCES Comments(idComment) ON DELETE CASCADE,
    mediaType NVARCHAR(10),
    mediaPath NVARCHAR(255)
);
--15 Таблица для лайков
CREATE TABLE Likes (
    idLike INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE,
    idFile INT FOREIGN KEY REFERENCES Files(idFile) ON DELETE CASCADE,
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse) ON DELETE CASCADE
);
--16 Таблица для ежедневных обновлений
CREATE TABLE DailyUpdates (
    idUpdate INT PRIMARY KEY IDENTITY(1,1),
    description NVARCHAR(MAX),
    dateOfPosted DATETIME DEFAULT GETDATE(),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE
);
--17 Таблица для хранения языков пользователей
CREATE TABLE UserLanguages (
    idUser INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE,
    language NVARCHAR(10), -- 'EN', 'RU', 'DE', 'KZ'
    PRIMARY KEY (idUser, language)
);
--18 Таблица для постов
CREATE TABLE Posts (
    idPost INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE,
    postTitle NVARCHAR(255),
    postContent NVARCHAR(MAX),
    datePosted DATETIME DEFAULT GETDATE()
);
--19 Таблица для медиафайлов в постах
CREATE TABLE PostMedia (
    idMedia INT PRIMARY KEY IDENTITY(1,1),
    idPost INT FOREIGN KEY REFERENCES Posts(idPost) ON DELETE CASCADE,
    mediaType NVARCHAR(10),
    mediaPath NVARCHAR(255)
);
--20 Таблица для аудита действий пользователей
CREATE TABLE AuditLog (
    idLog INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) ON DELETE CASCADE,
    action NVARCHAR(100),
    dateAction DATETIME DEFAULT GETDATE(),
    description NVARCHAR(MAX)
);
