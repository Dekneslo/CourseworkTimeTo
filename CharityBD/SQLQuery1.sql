CREATE DATABASE CharityDB;
USE CharityDB;

--1
-- Таблица ролей
CREATE TABLE Roles (
    idRole INT PRIMARY KEY IDENTITY(1,1),
    nameRole NVARCHAR(50) NOT NULL
);

--2
-- Таблица пользователей
CREATE TABLE Users (
    idUser INT PRIMARY KEY IDENTITY(1,1),
    firstName NVARCHAR(50) NOT NULL,
    lastName NVARCHAR(50) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    password NVARCHAR(255) NOT NULL,
    role INT FOREIGN KEY REFERENCES Roles(idRole) NOT NULL
);

--3
-- Таблица профилей пользователей
CREATE TABLE Profiles (
    idProfile INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    city NVARCHAR(50),
    country NVARCHAR(50),
    phoneNumber NVARCHAR(20) NOT NULL,
    biography NVARCHAR(MAX)
);

--4
-- Таблица категорий курсов
CREATE TABLE Categories (
    idCategory INT PRIMARY KEY IDENTITY(1,1),
    nameCategory NVARCHAR(100) NOT NULL
);

--5
-- Таблица курсов (без прямой ссылки на пользователя)
CREATE TABLE Courses (
    idCourse INT PRIMARY KEY IDENTITY(1,1),
    nameCourse NVARCHAR(100) NOT NULL,
    description NVARCHAR(MAX),
    idCategory INT FOREIGN KEY REFERENCES Categories(idCategory) NOT NULL,
    dateCreated DATETIME DEFAULT GETDATE() NOT NULL
);

--6
-- Таблица для медиафайлов курсов
CREATE TABLE CourseMedia (
    idMedia INT PRIMARY KEY IDENTITY(1,1),
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse) NOT NULL,
    mediaType NVARCHAR(10) NOT NULL, -- 'photo', 'video'
    mediaPath NVARCHAR(255) NOT NULL
);

--7
-- Таблица для хранения связи пользователей и курсов (составной ключ)
CREATE TABLE UsersCourses (
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse) NOT NULL,
    PRIMARY KEY (idUser, idCourse)
);

--8
-- Таблица для хранения файлов
CREATE TABLE Files (
    idFile INT PRIMARY KEY IDENTITY(1,1),
    nameFile NVARCHAR(255) NOT NULL,
    fileType NVARCHAR(50) NOT NULL,
    fileSize BIGINT CHECK (fileSize > 0) NOT NULL,
    filePath NVARCHAR(255) NOT NULL,
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NULL
);

--9
-- Таблица для назначения прав доступа к файлам
CREATE TABLE FileAccess (
    idFile INT FOREIGN KEY REFERENCES Files(idFile) NOT NULL,
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL, 
    accessType NVARCHAR(50) NOT NULL, -- 'read', 'write', 'admin'
    PRIMARY KEY (idFile, idUser)
);

--10
-- Таблица сообщений
CREATE TABLE Messages (
    idMessage INT PRIMARY KEY IDENTITY(1,1),
    idSender INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    idRecipient INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    sendingDatetime DATETIME DEFAULT GETDATE() NOT NULL,
    messageText NVARCHAR(MAX) NOT NULL,
	CHECK (idSender <> idRecipient)
);

--11
-- Таблица комнат для чатов
CREATE TABLE ChatRooms (
    idChatRoom INT PRIMARY KEY IDENTITY(1,1),
    nameRoom NVARCHAR(100) NOT NULL
);

--12
-- Таблица связи пользователей и чат-комнат (составной ключ)
CREATE TABLE ChatRoomUsers (
    idChatRoom INT FOREIGN KEY REFERENCES ChatRooms(idChatRoom) NOT NULL,
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    PRIMARY KEY (idChatRoom, idUser)
);

--13
-- Таблица для комментариев к курсам
CREATE TABLE Comments (
    idComment INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse) NOT NULL,
    commentDescription NVARCHAR(MAX) NOT NULL,
    dateCommented DATETIME DEFAULT GETDATE() NOT NULL
);

--14
-- Таблица для медиафайлов в комментариях
CREATE TABLE CommentMedia (
    idMedia INT PRIMARY KEY IDENTITY(1,1),
    idComment INT FOREIGN KEY REFERENCES Comments(idComment) NOT NULL,
    mediaType NVARCHAR(10) NOT NULL, -- 'photo', 'video'
    mediaPath NVARCHAR(255) NOT NULL
);

--15
-- Таблица для лайков
CREATE TABLE Likes (
    idLike INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    idFile INT FOREIGN KEY REFERENCES Files(idFile),
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse)
);

--16
-- Таблица для ежедневных обновлений
CREATE TABLE DailyUpdates (
    idUpdate INT PRIMARY KEY IDENTITY(1,1),
    description NVARCHAR(MAX) NOT NULL,
    dateOfPosted DATETIME DEFAULT GETDATE() NOT NULL,
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL
);

--17
-- Таблица для хранения языков пользователей (составной ключ)
CREATE TABLE UserLanguages (
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    language NVARCHAR(10) NOT NULL, -- 'EN', 'RU', 'DE', 'KZ'
    PRIMARY KEY (idUser, language)
);

--18
-- Таблица для постов
CREATE TABLE Posts (
    idPost INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    postTitle NVARCHAR(255) NOT NULL,
    postContent NVARCHAR(MAX) NOT NULL,
    datePosted DATETIME DEFAULT GETDATE() NOT NULL
);

--19
-- Таблица для медиафайлов в постах
CREATE TABLE PostMedia (
    idMedia INT PRIMARY KEY IDENTITY(1,1),
    idPost INT FOREIGN KEY REFERENCES Posts(idPost) NOT NULL,
    mediaType NVARCHAR(10) NOT NULL, -- 'photo', 'video'
    mediaPath NVARCHAR(255) NOT NULL
);

--20
-- Таблица для аудита действий пользователей
CREATE TABLE AuditLog (
    idLog INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    action NVARCHAR(100) NOT NULL,
    dateAction DATETIME DEFAULT GETDATE() NOT NULL,
    description NVARCHAR(MAX)
);

--------------------------------------------------

------------------------------------------

-- 1. Таблица ролей
INSERT INTO Roles (nameRole) VALUES 
('Admin'), 
('User'), 
('Manager'), 
('Moderator'), 
('Editor'), 
('Subscriber'), 
('Guest'), 
('VIP'), 
('Support');

-- 2. Таблица пользователей
INSERT INTO Users (firstName, lastName, email, password, role) 
VALUES 
('Admin', 'User', 'admin@example.com', 'adminpassword', 1),
('Jane', 'Smith', 'jane@example.com', 'hashed_password2', 2),
('Tom', 'Hanks', 'tom@example.com', 'hashed_password3', 3),
('Alice', 'Johnson', 'alice@example.com', 'hashed_password4', 4),
('Bob', 'Brown', 'bob@example.com', 'hashed_password5', 5),
('Charlie', 'Black', 'charlie@example.com', 'hashed_password6', 6),
('David', 'White', 'david@example.com', 'hashed_password7', 7),
('Eva', 'Green', 'eva@example.com', 'hashed_password8', 8),
('Frank', 'Blue', 'frank@example.com', 'hashed_password9', 9),
('Grace', 'Red', 'grace@example.com', 'hashed_password10', 2);

-- 3. Таблица профилей пользователей
INSERT INTO Profiles (idUser, city, country, phoneNumber, biography) 
VALUES 
(1, 'New York', 'USA', '555-1001', 'Administrator of the system.'),
(2, 'Berlin', 'Germany', '555-1002', 'A regular user with an interest in psychology.'),
(3, 'Almaty', 'Kazakhstan', '555-1003', 'Experienced manager working in the tech industry.'),
(4, 'London', 'UK', '555-1004', 'Moderator for the community.'),
(5, 'Paris', 'France', '555-1005', 'Editor with 5 years of experience in content writing.'),
(6, 'Rome', 'Italy', '555-1006', 'Contributor to many community projects.'),
(7, 'Tokyo', 'Japan', '555-1007', 'Avid reader and subscriber to the platform.'),
(8, 'Moscow', 'Russia', '555-1008', 'Guest user exploring the platform.'),
(9, 'Astana', 'Kazakhstan', '555-1009', 'VIP member with exclusive access to content.'),
(10, 'Dubai', 'UAE', '555-1010', 'Support staff helping users with issues.');

-- 4. Таблица категорий курсов
INSERT INTO Categories (nameCategory) 
VALUES 
('Psychology'), 
('Business'), 
('Technology'), 
('Health'), 
('Art'), 
('Music'), 
('Cooking'), 
('Photography'), 
('Literature'), 
('Science');

-- 5. Таблица курсов
INSERT INTO Courses (nameCourse, description, idCategory, dateCreated) 
VALUES 
('Intro to Psychology', 'Learn the basics of psychology.', 1, GETDATE()),
('Business Management 101', 'Introduction to business management.', 2, GETDATE()),
('Tech Innovations', 'Explore the latest in technology.', 3, GETDATE()),
('Healthy Living', 'Tips for a healthy lifestyle.', 4, GETDATE()),
('Art History', 'A deep dive into art history.', 5, GETDATE()),
('Music Theory', 'Learn the basics of music theory.', 6, GETDATE()),
('Cooking 101', 'Basic cooking skills for beginners.', 7, GETDATE()),
('Photography for Beginners', 'Learn how to take stunning photos.', 8, GETDATE()),
('Modern Literature', 'Explore modern works of literature.', 9, GETDATE()),
('Science in Everyday Life', 'Learn about science in daily life.', 10, GETDATE());

-- 6. Таблица для медиафайлов курсов
INSERT INTO CourseMedia (idCourse, mediaType, mediaPath) 
VALUES 
(1, 'photo', 'path/to/psychology1.jpg'),
(2, 'video', 'path/to/business1.mp4'),
(3, 'photo', 'path/to/tech1.jpg'),
(4, 'photo', 'path/to/health1.jpg'),
(5, 'video', 'path/to/art1.mp4'),
(6, 'photo', 'path/to/music1.jpg'),
(7, 'photo', 'path/to/cooking1.jpg'),
(8, 'video', 'path/to/photography1.mp4'),
(9, 'photo', 'path/to/literature1.jpg'),
(10, 'video', 'path/to/science1.mp4');

-- 7. Таблица для связи пользователей и курсов
INSERT INTO UsersCourses (idUser, idCourse) 
VALUES 
(1, 1), 
(2, 2), 
(3, 3), 
(4, 4), 
(5, 5), 
(6, 6), 
(7, 7), 
(8, 8), 
(9, 9), 
(10, 10);

-- 8. Таблица для файлов
INSERT INTO Files (nameFile, fileType, fileSize, filePath, idUser) 
VALUES 
('doc1.pdf', 'pdf', 102400, 'path/to/doc1.pdf', 1),
('doc2.docx', 'docx', 204800, 'path/to/doc2.docx', 2),
('image1.jpg', 'jpg', 512000, 'path/to/image1.jpg', 3),
('presentation1.pptx', 'pptx', 1024000, 'path/to/presentation1.pptx', 4),
('audio1.mp3', 'mp3', 3072000, 'path/to/audio1.mp3', 5),
('video1.mp4', 'mp4', 5120000, 'path/to/video1.mp4', 6),
('archive1.zip', 'zip', 10240000, 'path/to/archive1.zip', 7),
('spreadsheet1.xlsx', 'xlsx', 204800, 'path/to/spreadsheet1.xlsx', 8),
('ebook1.epub', 'epub', 102400, 'path/to/ebook1.epub', 9),
('presentation2.pptx', 'pptx', 1024000, 'path/to/presentation2.pptx', 10);

-- 9. Таблица для назначения прав доступа к файлам
INSERT INTO FileAccess (idFile, idUser, accessType) 
VALUES 
(1, 1, 'admin'),
(2, 2, 'write'),
(3, 3, 'read'),
(4, 4, 'read'),
(5, 5, 'write'),
(6, 6, 'admin'),
(7, 7, 'read'),
(8, 8, 'admin'),
(9, 9, 'write'),
(10, 10, 'admin');

-- 10. Таблица сообщений
INSERT INTO Messages (idSender, idRecipient, sendingDatetime, messageText) 
VALUES 
(1, 2, GETDATE(), 'Hello, how are you?'),
(2, 1, GETDATE(), 'I am good, thank you!'),
(3, 4, GETDATE(), 'Can we meet tomorrow?'),
(4, 3, GETDATE(), 'Sure, what time?'),
(5, 6, GETDATE(), 'Check this new document.'),
(6, 5, GETDATE(), 'Got it, thanks.'),
(7, 8, GETDATE(), 'Are you available for a call?'),
(8, 7, GETDATE(), 'Yes, let me know when.'),
(9, 10, GETDATE(), 'See you at the meeting.'),
(10, 9, GETDATE(), 'Looking forward to it.');

-- 11. Таблица комнат для чатов
INSERT INTO ChatRooms (nameRoom) 
VALUES 
('General Chat'), 
('Project Team'), 
('Support Room'), 
('VIP Lounge'), 
('Study Group'), 
('Music Lovers'), 
('Tech Enthusiasts'), 
('Writers Club'), 
('Photography Hub'), 
('Cooking Tips');

-- 12. Таблица связи пользователей и чат-комнат
INSERT INTO ChatRoomUsers (idChatRoom, idUser) 
VALUES 
(1, 1), 
(2, 2), 
(3, 3), 
(4, 4), 
(5, 5), 
(6, 6), 
(7, 7), 
(8, 8), 
(9, 9), 
(10, 10);

-- 13. Таблица для комментариев к курсам
INSERT INTO Comments (idUser, idCourse, commentDescription, dateCommented) 
VALUES 
(1, 1, 'Great course!', GETDATE()),
(2, 2, 'Very informative.', GETDATE()),
(3, 3, 'I learned a lot.', GETDATE()),
(4, 4, 'Highly recommend this course.', GETDATE()),
(5, 5, 'Fantastic content.', GETDATE()),
(6, 6, 'Well structured.', GETDATE()),
(7, 7, 'Could use more examples.', GETDATE()),
(8, 8, 'Loved the hands-on approach.', GETDATE()),
(9, 9, 'Very detailed.', GETDATE()),
(10, 10, 'Clear and concise.', GETDATE());

-- 14. Таблица для медиафайлов в комментариях
INSERT INTO CommentMedia (idComment, mediaType, mediaPath) 
VALUES 
(1, 'photo', 'path/to/comment1.jpg'),
(2, 'video', 'path/to/comment2.mp4'),
(3, 'photo', 'path/to/comment3.jpg'),
(4, 'photo', 'path/to/comment4.jpg'),
(5, 'video', 'path/to/comment5.mp4'),
(6, 'photo', 'path/to/comment6.jpg'),
(7, 'photo', 'path/to/comment7.jpg'),
(8, 'video', 'path/to/comment8.mp4'),
(9, 'photo', 'path/to/comment9.jpg'),
(10, 'video', 'path/to/comment10.mp4');

-- 15. Таблица для лайков
INSERT INTO Likes (idUser, idFile, idCourse) 
VALUES 
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5),
(6, 6, 6),
(7, 7, 7),
(8, 8, 8),
(9, 9, 9),
(10, 10, 10);

-- 16. Таблица для ежедневных обновлений
INSERT INTO DailyUpdates (description, dateOfPosted, idUser) 
VALUES 
('System maintenance completed.', GETDATE(), 1),
('New course added: Business Management 101.', GETDATE(), 2),
('Weekly report uploaded.', GETDATE(), 3),
('Security update applied.', GETDATE(), 4),
('New chat room created.', GETDATE(), 5),
('Music Theory course updated.', GETDATE(), 6),
('New member joined: VIP.', GETDATE(), 7),
('Bug fixes in course modules.', GETDATE(), 8),
('Daily tips posted.', GETDATE(), 9),
('Science course released.', GETDATE(), 10);

-- 17. Таблица для хранения языков пользователей
INSERT INTO UserLanguages (idUser, language) 
VALUES 
(1, 'EN'),
(2, 'DE'),
(3, 'RU'),
(4, 'KZ');

-- 18. Таблица для постов
INSERT INTO Posts (idUser, postTitle, postContent, datePosted) 
VALUES 
(1, 'Welcome to the Platform', 'Hello everyone, welcome to our new platform!', GETDATE()),
(2, 'Business Management 101', 'Our new course on business management is live now.', GETDATE()),
(3, 'Tech Trends', 'Check out the latest trends in technology.', GETDATE()),
(4, 'Health Tips', 'Stay healthy with our daily tips.', GETDATE()),
(5, 'Art Gallery', 'Explore the history of art.', GETDATE()),
(6, 'Music Theory Basics', 'Learn the basics of music theory.', GETDATE()),
(7, 'Cooking for Beginners', 'Join our cooking course today!', GETDATE()),
(8, 'Photography Tips', 'How to take better photos.', GETDATE()),
(9, 'Literature Analysis', 'Deep dive into modern literature.', GETDATE()),
(10, 'Science Facts', 'Science made easy for everyone.', GETDATE());

-- 19. Таблица для медиафайлов в постах
INSERT INTO PostMedia (idPost, mediaType, mediaPath) 
VALUES 
(1, 'photo', 'path/to/post1.jpg'),
(2, 'video', 'path/to/post2.mp4'),
(3, 'photo', 'path/to/post3.jpg'),
(4, 'photo', 'path/to/post4.jpg'),
(5, 'video', 'path/to/post5.mp4'),
(6, 'photo', 'path/to/post6.jpg'),
(7, 'photo', 'path/to/post7.jpg'),
(8, 'video', 'path/to/post8.mp4'),
(9, 'photo', 'path/to/post9.jpg'),
(10, 'video', 'path/to/post10.mp4');

-- 20. Таблица для аудита действий пользователей
INSERT INTO AuditLog (idUser, action, dateAction, description) 
VALUES 
(1, 'Login', GETDATE(), 'User logged in.'),
(2, 'Upload', GETDATE(), 'User uploaded a file.'),
(3, 'Comment', GETDATE(), 'User commented on a course.'),
(4, 'Create Course', GETDATE(), 'User created a new course.'),
(5, 'Edit Profile', GETDATE(), 'User updated their profile information.'),
(6, 'Send Message', GETDATE(), 'User sent a message.'),
(7, 'Join Chat Room', GETDATE(), 'User joined a chat room.'),
(8, 'Like Post', GETDATE(), 'User liked a post.'),
(9, 'Download File', GETDATE(), 'User downloaded a file.'),
(10, 'Logout', GETDATE(), 'User logged out.');

---------------------------------------

----9
---- Таблица для назначения прав доступа к файлам
--CREATE TABLE FileAccess (
--    idFile INT FOREIGN KEY REFERENCES Files(idFile) NOT NULL,
--    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
--    idRole INT FOREIGN KEY REFERENCES Roles(idRole) NOT NULL,
--    accessType NVARCHAR(50) NOT NULL, -- 'read', 'write', 'admin'
--    PRIMARY KEY (idFile, idUser)
--);








--USE CharityDB;
----1
---- Таблица ролей
--CREATE TABLE Roles (
--    idRole INT PRIMARY KEY IDENTITY(1,1),
--    nameRole NVARCHAR(50)
--);
----2
---- Таблица пользователей
--CREATE TABLE Users (
--    idUser INT PRIMARY KEY IDENTITY(1,1),
--    firstName NVARCHAR(50),
--    lastName NVARCHAR(50),
--    email NVARCHAR(100) UNIQUE,
--    password NVARCHAR(255),
--    role INT FOREIGN KEY REFERENCES Roles(idRole)
--);
----3
---- Таблица профилей пользователей
--CREATE TABLE Profiles (
--    idProfile INT PRIMARY KEY IDENTITY(1,1),
--    idUser INT FOREIGN KEY REFERENCES Users(idUser),
--    city NVARCHAR(50),
--    country NVARCHAR(50),
--    phoneNumber NVARCHAR(20),
--    biography NVARCHAR(MAX)
--);
----4
---- Таблица категорий курсов
--CREATE TABLE Categories (
--    idCategory INT PRIMARY KEY IDENTITY(1,1),
--    nameCategory NVARCHAR(100)
--);
----5
---- Таблица курсов
--CREATE TABLE Courses (
--    idCourse INT PRIMARY KEY IDENTITY(1,1),
--    nameCourse NVARCHAR(100),
--    description NVARCHAR(MAX),
--    idCategory INT FOREIGN KEY REFERENCES Categories(idCategory),
--    idUser INT FOREIGN KEY REFERENCES Users(idUser),
--    dateCreated DATETIME DEFAULT GETDATE()
--);
----6
---- Таблица для медиафайлов курсов
--CREATE TABLE CourseMedia (
--    idMedia INT PRIMARY KEY IDENTITY(1,1),
--    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse),
--    mediaType NVARCHAR(10), -- 'photo', 'video'
--    mediaPath NVARCHAR(255)
--);
----7
---- Таблица для хранения связи пользователей и курсов
--CREATE TABLE UsersCourses (
--    idUser INT FOREIGN KEY REFERENCES Users(idUser),
--    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse),
--    PRIMARY KEY (idUser, idCourse)
--);
----8
---- Таблица для хранения файлов
--CREATE TABLE Files (
--    idFile INT PRIMARY KEY IDENTITY(1,1),
--    nameFile NVARCHAR(255),
--    fileType NVARCHAR(50),
--    fileSize BIGINT,
--    filePath NVARCHAR(255),
--    idUser INT FOREIGN KEY REFERENCES Users(idUser)
--);
----9
---- Таблица для назначения прав доступа к файлам
--CREATE TABLE FileAccess (
--    idFile INT FOREIGN KEY REFERENCES Files(idFile),
--    idUser INT FOREIGN KEY REFERENCES Users(idUser),
--    idRole INT FOREIGN KEY REFERENCES Roles(idRole),
--    accessType NVARCHAR(50), -- 'read', 'write', 'admin'
--    PRIMARY KEY (idFile, idUser)
--);
----10
---- Таблица сообщений
--CREATE TABLE Messages (
--    idMessage INT PRIMARY KEY IDENTITY(1,1),
--    idSender INT FOREIGN KEY REFERENCES Users(idUser),
--    idRecipient INT FOREIGN KEY REFERENCES Users(idUser),
--    sendingDatetime DATETIME DEFAULT GETDATE(),
--    messageText NVARCHAR(MAX)
--);
----11
---- Таблица комнат для чатов
--CREATE TABLE ChatRooms (
--    idChatRoom INT PRIMARY KEY IDENTITY(1,1),
--    nameRoom NVARCHAR(100)
--);
----12
---- Таблица связи пользователей и чат-комнат
--CREATE TABLE ChatRoomUsers (
--    idChatRoom INT FOREIGN KEY REFERENCES ChatRooms(idChatRoom),
--    idUser INT FOREIGN KEY REFERENCES Users(idUser),
--    PRIMARY KEY (idChatRoom, idUser)
--);
----13
---- Таблица для комментариев к курсам
--CREATE TABLE Comments (
--    idComment INT PRIMARY KEY IDENTITY(1,1),
--    idUser INT FOREIGN KEY REFERENCES Users(idUser),
--    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse),
--    commentDescription NVARCHAR(MAX),
--    dateCommented DATETIME DEFAULT GETDATE()
--);
----14
---- Таблица для медиафайлов в комментариях
--CREATE TABLE CommentMedia (
--    idMedia INT PRIMARY KEY IDENTITY(1,1),
--    idComment INT FOREIGN KEY REFERENCES Comments(idComment),
--    mediaType NVARCHAR(10), -- 'photo', 'video'
--    mediaPath NVARCHAR(255)
--);
----15
---- Таблица для лайков
--CREATE TABLE Likes (
--    idLike INT PRIMARY KEY IDENTITY(1,1),
--    idUser INT FOREIGN KEY REFERENCES Users(idUser),
--    idFile INT FOREIGN KEY REFERENCES Files(idFile),
--    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse)
--);
----16
---- Таблица для ежедневных обновлений
--CREATE TABLE DailyUpdates (
--    idUpdate INT PRIMARY KEY IDENTITY(1,1),
--    description NVARCHAR(MAX),
--    dateOfPosted DATETIME DEFAULT GETDATE(),
--    idUser INT FOREIGN KEY REFERENCES Users(idUser)
--);
----17
---- Таблица для хранения языков пользователей
--CREATE TABLE UserLanguages (
--    idUser INT FOREIGN KEY REFERENCES Users(idUser),
--    language NVARCHAR(10), -- 'EN', 'RU', 'DE', 'KZ'
--    PRIMARY KEY (idUser, language)
--);
----18
---- Таблица для постов
--CREATE TABLE Posts (
--    idPost INT PRIMARY KEY IDENTITY(1,1),
--    idUser INT FOREIGN KEY REFERENCES Users(idUser),
--    postTitle NVARCHAR(255),
--    postContent NVARCHAR(MAX),
--    datePosted DATETIME DEFAULT GETDATE()
--);
----19
---- Таблица для медиафайлов в постах
--CREATE TABLE PostMedia (
--    idMedia INT PRIMARY KEY IDENTITY(1,1),
--    idPost INT FOREIGN KEY REFERENCES Posts(idPost),
--    mediaType NVARCHAR(10), -- 'photo', 'video'
--    mediaPath NVARCHAR(255)
--);
----20
---- Таблица для аудита действий пользователей
--CREATE TABLE AuditLog (
--    idLog INT PRIMARY KEY IDENTITY(1,1),
--    idUser INT FOREIGN KEY REFERENCES Users(idUser),
--    action NVARCHAR(100),
--    dateAction DATETIME DEFAULT GETDATE(),
--    description NVARCHAR(MAX)
--);
