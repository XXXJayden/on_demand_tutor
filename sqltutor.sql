Create database OnDemandTutorDB

GO
USE OnDemandTutorDB

GO
-- Tạo bảng Tutor
CREATE TABLE Tutor (
    TutorID INT PRIMARY KEY IDENTITY(1,1),
    Fullname NVARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
	Description NVARCHAR(255),
    Major NVARCHAR(255) NOT NULL
);
GO

-- Tạo bảng Student
CREATE TABLE Student (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    Fullname NVARCHAR(255) NOT NULL,
	Password VARCHAR(50) NOT NULL,
    Phone VARCHAR(15) NOT NULL,
    Email VARCHAR(255) NOT NULL,
	Address NVARCHAR(255) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    Grade VARCHAR(50) NOT NULL
);
GO



-- Tạo bảng Service
CREATE TABLE Service (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Service NVARCHAR(255) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);
GO

-- Tạo bảng Achievement
CREATE TABLE Achievement (
    AchievementID INT PRIMARY KEY IDENTITY(1,1),
    TutorID INT NOT NULL,
    Certificate VARCHAR(255) NOT NULL,
    FOREIGN KEY (TutorID) REFERENCES Tutor(TutorID)
);

GO

-- Tạo bảng TutorService
CREATE TABLE TutorService (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ServiceID INT NOT NULL,
    TutorID INT NOT NULL,
    FOREIGN KEY (ServiceID) REFERENCES Service(ID),
    FOREIGN KEY (TutorID) REFERENCES Tutor(TutorID)
);
GO

-- Tạo bảng Booking
CREATE TABLE Booking (
    ID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL,
    TutorID INT NOT NULL,
    ServiceID INT NOT NULL,
    Status VARCHAR(25) NOT NULL,
	DateStart Date,
	DateEnd Date,

    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (TutorID) REFERENCES Tutor(TutorID),
    FOREIGN KEY (ServiceID) REFERENCES Service(ID)
);
GO

-- Tạo bảng Feedbacks
CREATE TABLE Feedbacks (
    FbID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT NOT NULL,
    StudentID INT NOT NULL,
    Rating INT NOT NULL,
    Detail TEXT NOT NULL,
    FOREIGN KEY (BookingID) REFERENCES Booking(ID)
);
GO

-- Tạo bảng Schedule
CREATE TABLE Schedule (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Date NVARCHAR(25) NOT NULL,
    Slot VARCHAR(50) NOT NULL
);
GO

-- Tạo bảng BookingSchedule
CREATE TABLE BookingSchedule (
    ID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT NOT NULL,
    ScID INT NOT NULL,
    FOREIGN KEY (BookingID) REFERENCES Booking(ID),
    FOREIGN KEY (ScID) REFERENCES Schedule(ID)
);
GO

-- Tạo bảng Moderator
CREATE TABLE Moderator (
    ModID INT PRIMARY KEY IDENTITY(1,1),
    Fullname NVARCHAR(255) NOT NULL,
	Password VARCHAR(50) NOT NULL,
    Email VARCHAR(255) NOT NULL
);
GO