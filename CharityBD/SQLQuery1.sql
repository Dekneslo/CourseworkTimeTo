CREATE DATABASE CharityDB;


USE CharityDB;
--1
-- Таблица ролей
CREATE TABLE Roles (
    idRole INT PRIMARY KEY IDENTITY(1,1),
    nameRole NVARCHAR(50)
);
--2
-- Таблица пользователей
CREATE TABLE Users (
    idUser INT PRIMARY KEY IDENTITY(1,1),
    firstName NVARCHAR(50),
    lastName NVARCHAR(50),
    email NVARCHAR(100) UNIQUE,
    password NVARCHAR(255),
    role INT FOREIGN KEY REFERENCES Roles(idRole)
);
--3
-- Таблица профилей пользователей
CREATE TABLE Profiles (
    idProfile INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser),
    city NVARCHAR(50),
    country NVARCHAR(50),
    phoneNumber NVARCHAR(20),
    biography NVARCHAR(MAX)
);
--4
-- Таблица категорий курсов
CREATE TABLE Categories (
    idCategory INT PRIMARY KEY IDENTITY(1,1),
    nameCategory NVARCHAR(100)
);
--5
-- Таблица курсов
CREATE TABLE Courses (
    idCourse INT PRIMARY KEY IDENTITY(1,1),
    nameCourse NVARCHAR(100),
    description NVARCHAR(MAX),
    idCategory INT FOREIGN KEY REFERENCES Categories(idCategory),
    idUser INT FOREIGN KEY REFERENCES Users(idUser),
    dateCreated DATETIME DEFAULT GETDATE()
);
--6
-- Таблица для медиафайлов курсов
CREATE TABLE CourseMedia (
    idMedia INT PRIMARY KEY IDENTITY(1,1),
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse),
    mediaType NVARCHAR(10), -- 'photo', 'video'
    mediaPath NVARCHAR(255)
);
--7
-- Таблица для хранения связи пользователей и курсов
CREATE TABLE UsersCourses (
    idUser INT FOREIGN KEY REFERENCES Users(idUser),
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse),
    PRIMARY KEY (idUser, idCourse)
);
--8
-- Таблица для хранения файлов
CREATE TABLE Files (
    idFile INT PRIMARY KEY IDENTITY(1,1),
    nameFile NVARCHAR(255),
    fileType NVARCHAR(50),
    fileSize BIGINT,
    filePath NVARCHAR(255),
    idUser INT FOREIGN KEY REFERENCES Users(idUser)
);
--9
-- Таблица для назначения прав доступа к файлам
CREATE TABLE FileAccess (
    idFile INT FOREIGN KEY REFERENCES Files(idFile),
    idUser INT FOREIGN KEY REFERENCES Users(idUser),
    idRole INT FOREIGN KEY REFERENCES Roles(idRole),
    accessType NVARCHAR(50), -- 'read', 'write', 'admin'
    PRIMARY KEY (idFile, idUser)
);
--10
-- Таблица сообщений
CREATE TABLE Messages (
    idMessage INT PRIMARY KEY IDENTITY(1,1),
    idSender INT FOREIGN KEY REFERENCES Users(idUser),
    idRecipient INT FOREIGN KEY REFERENCES Users(idUser),
    sendingDatetime DATETIME DEFAULT GETDATE(),
    messageText NVARCHAR(MAX)
);
--11
-- Таблица комнат для чатов
CREATE TABLE ChatRooms (
    idChatRoom INT PRIMARY KEY IDENTITY(1,1),
    nameRoom NVARCHAR(100)
);
--12
-- Таблица связи пользователей и чат-комнат
CREATE TABLE ChatRoomUsers (
    idChatRoom INT FOREIGN KEY REFERENCES ChatRooms(idChatRoom),
    idUser INT FOREIGN KEY REFERENCES Users(idUser),
    PRIMARY KEY (idChatRoom, idUser)
);
--13
-- Таблица для комментариев к курсам
CREATE TABLE Comments (
    idComment INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser),
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse),
    commentDescription NVARCHAR(MAX),
    dateCommented DATETIME DEFAULT GETDATE()
);
--14
-- Таблица для медиафайлов в комментариях
CREATE TABLE CommentMedia (
    idMedia INT PRIMARY KEY IDENTITY(1,1),
    idComment INT FOREIGN KEY REFERENCES Comments(idComment),
    mediaType NVARCHAR(10), -- 'photo', 'video'
    mediaPath NVARCHAR(255)
);
--15
-- Таблица для лайков
CREATE TABLE Likes (
    idLike INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser),
    idFile INT FOREIGN KEY REFERENCES Files(idFile),
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse)
);
--16
-- Таблица для ежедневных обновлений
CREATE TABLE DailyUpdates (
    idUpdate INT PRIMARY KEY IDENTITY(1,1),
    description NVARCHAR(MAX),
    dateOfPosted DATETIME DEFAULT GETDATE(),
    idUser INT FOREIGN KEY REFERENCES Users(idUser)
);
--17
-- Таблица для хранения языков пользователей
CREATE TABLE UserLanguages (
    idUser INT FOREIGN KEY REFERENCES Users(idUser),
    language NVARCHAR(10), -- 'EN', 'RU', 'DE', 'KZ'
    PRIMARY KEY (idUser, language)
);
--18
-- Таблица для постов
CREATE TABLE Posts (
    idPost INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser),
    postTitle NVARCHAR(255),
    postContent NVARCHAR(MAX),
    datePosted DATETIME DEFAULT GETDATE()
);
--19
-- Таблица для медиафайлов в постах
CREATE TABLE PostMedia (
    idMedia INT PRIMARY KEY IDENTITY(1,1),
    idPost INT FOREIGN KEY REFERENCES Posts(idPost),
    mediaType NVARCHAR(10), -- 'photo', 'video'
    mediaPath NVARCHAR(255)
);
--20
-- Таблица для аудита действий пользователей
CREATE TABLE AuditLog (
    idLog INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser),
    action NVARCHAR(100),
    dateAction DATETIME DEFAULT GETDATE(),
    description NVARCHAR(MAX)
);