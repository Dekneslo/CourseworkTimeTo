CREATE DATABASE CharityDB
USE CharityDB;

-- Таблица ролей
CREATE TABLE Roles (
    idRole INT PRIMARY KEY IDENTITY(1,1),
    nameRole NVARCHAR(50) NOT NULL
);

-- Таблица пользователей
CREATE TABLE Users (
    idUser INT PRIMARY KEY IDENTITY(1,1),
    firstName NVARCHAR(50) NOT NULL,
    lastName NVARCHAR(50) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    password NVARCHAR(255) NOT NULL,
    role INT FOREIGN KEY REFERENCES Roles(idRole) NOT NULL
);

-- Таблица профилей пользователей
CREATE TABLE Profiles (
    idProfile INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    city NVARCHAR(50),
    country NVARCHAR(50),
    phoneNumber NVARCHAR(20) NOT NULL,
    biography NVARCHAR(MAX)
);

-- Таблица категорий курсов
CREATE TABLE Categories (
    idCategory INT PRIMARY KEY IDENTITY(1,1),
    nameCategory NVARCHAR(100) NOT NULL
);

-- Таблица курсов
CREATE TABLE Courses (
    idCourse INT PRIMARY KEY IDENTITY(1,1),
    nameCourse NVARCHAR(100) NOT NULL,
    description NVARCHAR(MAX),
    idCategory INT FOREIGN KEY REFERENCES Categories(idCategory) NOT NULL,
    dateCreated DATETIME DEFAULT GETDATE() NOT NULL
);

-- Таблица для хранения файлов
CREATE TABLE Files (
    idFile INT PRIMARY KEY IDENTITY(1,1),
    nameFile NVARCHAR(255) NOT NULL,
    fileType NVARCHAR(50) NOT NULL,
    fileSize BIGINT CHECK (fileSize > 0) NOT NULL,
    filePath NVARCHAR(255) NOT NULL,
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NULL
);

-- Таблица для медиафайлов курсов
CREATE TABLE CourseMedia (
    idMedia INT PRIMARY KEY IDENTITY(1,1),
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse) NOT NULL,
    idFile INT FOREIGN KEY REFERENCES Files(idFile) NOT NULL -- Ссылка на таблицу Files
);

-- Таблица для хранения связи пользователей и курсов (составной ключ)
CREATE TABLE UsersCourses (
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse) NOT NULL,
    PRIMARY KEY (idUser, idCourse)
);

-- Таблица для назначения прав доступа к файлам
CREATE TABLE FileAccess (
    idFile INT FOREIGN KEY REFERENCES Files(idFile) NOT NULL,
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL, 
    accessType NVARCHAR(50) NOT NULL, -- 'read', 'write', 'admin'
    PRIMARY KEY (idFile, idUser)
);

-- Таблица сообщений
CREATE TABLE Messages (
    idMessage INT PRIMARY KEY IDENTITY(1,1),
    idSender INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    idRecipient INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    sendingDatetime DATETIME DEFAULT GETDATE() NOT NULL,
    messageText NVARCHAR(MAX) NOT NULL,
    CHECK (idSender <> idRecipient)
);

-- Таблица комнат для чатов
CREATE TABLE ChatRooms (
    idChatRoom INT PRIMARY KEY IDENTITY(1,1),
    nameRoom NVARCHAR(100) NOT NULL
);

-- Таблица связи пользователей и чат-комнат (составной ключ)
CREATE TABLE ChatRoomUsers (
    idChatRoom INT FOREIGN KEY REFERENCES ChatRooms(idChatRoom) NOT NULL,
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    PRIMARY KEY (idChatRoom, idUser)
);

-- Таблица для постов
CREATE TABLE Posts (
    idPost INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    postTitle NVARCHAR(255) NOT NULL,
    postContent NVARCHAR(MAX) NOT NULL,
    datePosted DATETIME DEFAULT GETDATE() NOT NULL
);

-- Таблица для комментариев к курсам и постам
CREATE TABLE Comments (
    idComment INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    idPost INT FOREIGN KEY REFERENCES Posts(idPost) NULL, -- Комментарии к постам
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse) NULL, -- Комментарии к курсам
    commentDescription NVARCHAR(MAX) NOT NULL,
    dateCommented DATETIME DEFAULT GETDATE() NOT NULL,
);

-- Таблица для медиафайлов в комментариях (только для постов)
CREATE TABLE CommentMedia (
    idMedia INT PRIMARY KEY IDENTITY(1,1),
    idComment INT FOREIGN KEY REFERENCES Comments(idComment) NOT NULL,
    mediaType NVARCHAR(10) NOT NULL, -- 'photo', 'video'
    mediaPath NVARCHAR(255) NOT NULL
);

-- Таблица для лайков курсов
CREATE TABLE LikesToCourses (
    idLike INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    idCourse INT FOREIGN KEY REFERENCES Courses(idCourse) NOT NULL
);

-- Таблица для лайков постов
CREATE TABLE LikesToPosts (
    idLike INT PRIMARY KEY IDENTITY(1,1),
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    idPost INT FOREIGN KEY REFERENCES Posts(idPost) NOT NULL
);

-- Таблица для ежедневных обновлений
CREATE TABLE DailyUpdates (
    idUpdate INT PRIMARY KEY IDENTITY(1,1),
    description NVARCHAR(MAX) NOT NULL,
    dateOfPosted DATETIME DEFAULT GETDATE() NOT NULL,
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL
);

-- Таблица для хранения языков пользователей (составной ключ)
CREATE TABLE UserLanguages (
    idUser INT FOREIGN KEY REFERENCES Users(idUser) NOT NULL,
    language NVARCHAR(10) NOT NULL, -- 'EN', 'RU', 'DE', 'KZ'
    PRIMARY KEY (idUser, language)
);

-- Таблица для медиафайлов в постах
CREATE TABLE PostMedia (
    idMedia INT PRIMARY KEY IDENTITY(1,1),
    idPost INT FOREIGN KEY REFERENCES Posts(idPost) NOT NULL,
    idFile INT FOREIGN KEY REFERENCES Files(idFile) NOT NULL -- Ссылка на таблицу Files
);

USE CharityDB;

-- 1. Таблица ролей
INSERT INTO Roles (nameRole) VALUES 
('Admin'), 
('User'), 
('Manager'), 
('Guest'), 
('VIP');

-- 2. Таблица пользователей
INSERT INTO Users (firstName, lastName, email, password, role) 
VALUES 
('Admin', 'User', 'admin@example.com', 'adminpassword', 1),
('Jane', 'Smith', 'jane@example.com', 'hashed_password2', 2),
('Tom', 'Hanks', 'tom@example.com', 'hashed_password3', 3),
('Alice', 'Johnson', 'alice@example.com', 'hashed_password4', 4),
('Bob', 'Brown', 'bob@example.com', 'hashed_password5', 5),
('Charlie', 'Black', 'charlie@example.com', 'hashed_password6', 3),
('David', 'White', 'david@example.com', 'hashed_password7', 2),
('Eva', 'Green', 'eva@example.com', 'hashed_password8', 2),
('Frank', 'Blue', 'frank@example.com', 'hashed_password9', 2),
('Grace', 'Red', 'grace@example.com', 'hashed_password10', 3);

-- 3. Таблица профилей пользователей
INSERT INTO Profiles (idUser, city, country, phoneNumber, biography) 
VALUES 
(7, 'New York', 'USA', '555-1001', 'Administrator of the system.'),
(8, 'Berlin', 'Germany', '555-1002', 'A regular user with an interest in psychology.'),
(9, 'Almaty', 'Kazakhstan', '555-1003', 'Experienced manager working in the tech industry.'),
(10, 'London', 'UK', '555-1004', 'Moderator for the community.'),
(11, 'Paris', 'France', '555-1005', 'Editor with 5 years of experience in content writing.'),
(12, 'Rome', 'Italy', '555-1006', 'Contributor to many community projects.'),
(13, 'Tokyo', 'Japan', '555-1007', 'Avid reader and subscriber to the platform.'),
(14, 'Moscow', 'Russia', '555-1008', 'Guest user exploring the platform.'),
(15, 'Astana', 'Kazakhstan', '555-1009', 'VIP member with exclusive access to content.'),
(16, 'Dubai', 'UAE', '555-1010', 'Support staff helping users with issues.');

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

-- 6. Таблица для связи пользователей и курсов
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

-- 7. Таблица для файлов
INSERT INTO Files (nameFile, fileType, fileSize, filePath, idUser) 
VALUES 
('course_intro.pdf', 'pdf', 102400, 'path/to/course_intro.pdf', 1),
('business_course.mp4', 'mp4', 2048000, 'path/to/business_course.mp4', 2),
('tech_innovations.jpg', 'jpg', 512000, 'path/to/tech_innovations.jpg', 3),
('health_tips.pdf', 'pdf', 102400, 'path/to/health_tips.pdf', 4),
('art_gallery.mp4', 'mp4', 2048000, 'path/to/art_gallery.mp4', 5),
('music_notes.jpg', 'jpg', 512000, 'path/to/music_notes.jpg', 6),
('cooking_tutorial.pdf', 'pdf', 102400, 'path/to/cooking_tutorial.pdf', 7),
('photography_tips.mp4', 'mp4', 2048000, 'path/to/photography_tips.mp4', 8),
('literature_essay.pdf', 'pdf', 102400, 'path/to/literature_essay.pdf', 9),
('science_diagrams.jpg', 'jpg', 512000, 'path/to/science_diagrams.jpg', 10);

-- 8. Таблица для назначения прав доступа к файлам
INSERT INTO FileAccess (idFile, idUser, accessType) 
VALUES 
(1, 1, 'read'),
(2, 2, 'write'),
(3, 3, 'read'),
(4, 4, 'read'),
(5, 5, 'read'),
(6, 6, 'write'),
(7, 7, 'admin'),
(8, 8, 'read'),
(9, 9, 'write'),
(10, 10, 'read');

-- 9. Таблица сообщений
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

-- 10. Таблица комнат для чатов
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

-- 11. Таблица связи пользователей и чат-комнат
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

-- 12. Таблица для постов
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

-- 13. Таблица для медиафайлов в постах
INSERT INTO PostMedia (idPost, idFile) 
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

-- 14. Таблица для лайков постов
INSERT INTO LikesToPosts (idUser, idPost) 
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

-- 15. Таблица для комментариев к курсам и постам
INSERT INTO Comments (idUser, idCourse, commentDescription, dateCommented) 
VALUES 
(2, 1, 'Great course!', GETDATE()),
(7, 2, 'Very informative.', GETDATE()),
(3, 3, 'I learned a lot.', GETDATE()),
(8, 4, 'Highly recommend this course.', GETDATE()),
(9, 5, 'Fantastic content.', GETDATE());

-- 16. Таблица для медиафайлов в комментариях
INSERT INTO CommentMedia (idComment, mediaType, mediaPath) 
VALUES 
(1, 'photo', 'path/to/comment1.jpg'),
(2, 'video', 'path/to/comment2.mp4'),
(3, 'photo', 'path/to/comment3.jpg');

-- 17. Таблица для лайков курсов
INSERT INTO LikesToCourses (idUser, idCourse) 
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

-- 18. Таблица для ежедневных обновлений
INSERT INTO DailyUpdates (description, dateOfPosted, idUser) 
VALUES 
('System maintenance completed.', GETDATE(), 3),
('New course added: Business Management 101.', GETDATE(), 10),
('Weekly report uploaded.', GETDATE(), 1),
('Security update applied.', GETDATE(), 6),
('New chat room created.', GETDATE(), 3);

-- 19. Таблица для хранения языков пользователей
INSERT INTO UserLanguages (idUser, language) 
VALUES 
(1, 'EN'),
(2, 'DE'),
(3, 'RU'),
(4, 'KZ');

-- 20. Таблица для медиафайлов курсов
INSERT INTO CourseMedia (idCourse, idFile)
VALUES 
(1, 1),  -- Медиафайл для курса 1 (например, изображение для "Intro to Psychology")
(2, 2),  -- Медиафайл для курса 2 (например, видео для "Business Management 101")
(3, 3),  -- Медиафайл для курса 3 (например, изображение для "Tech Innovations")
(4, 4),  -- Медиафайл для курса 4 (например, PDF для "Healthy Living")
(5, 5),  -- Медиафайл для курса 5 (например, видео для "Art History")
(6, 6),  -- Медиафайл для курса 6 (например, изображение для "Music Theory")
(7, 7),  -- Медиафайл для курса 7 (например, PDF для "Cooking 101")
(8, 8),  -- Медиафайл для курса 8 (например, видео для "Photography for Beginners")
(9, 9),  -- Медиафайл для курса 9 (например, PDF для "Modern Literature")
(10, 10); -- Медиафайл для курса 10 (например, изображение для "Science in Everyday Life")
