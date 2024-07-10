USE OnDemandTutorDB;
GO

-- Thêm dữ liệu vào bảng Tutor
INSERT INTO Tutor (Fullname, Password, Email, Status, Description, Major, Grade, Avatar)
VALUES
('John Doe', 'password123', 'john.doe@example.com', 'Active', 'Experienced in Mathematics', 'Mathematics','10',''),
('Jane Smith', 'password456', 'jane.smith@example.com', 'Active', 'Experienced in Physics', 'Physics','11',''),
('Emily Johnson', 'password789', 'emily.johnson@example.com', 'Inactive', 'Experienced in Chemistry', 'Chemistry','12','');
GO

-- Thêm dữ liệu vào bảng Student
INSERT INTO Student (Fullname, Password, Phone, Email, Address, Status, Grade)
VALUES
('Alice Brown', 'password123', '1234567890', 'alice.brown@example.com', '123 Main St', 'Active', '10th'),
('Bob White', 'password456', '2345678901', 'bob.white@example.com', '456 Elm St', 'Active', '11th'),
('Charlie Green', 'password789', '3456789012', 'charlie.green@example.com', '789 Oak St', 'Inactive', '12th');
GO

-- Thêm dữ liệu vào bảng Service
INSERT INTO Service (Service)
VALUES
(N'Ôn kiến thức cơ bản'),
(N'Ôn thi, giải đề'),
(N'Làm báo bài'),
(N'Kiến thức học vượt')
GO



-- Thêm dữ liệu vào bảng Achievement
INSERT INTO Achievement (TutorID, Certificate)
VALUES
(1, 'Certified Mathematics Tutor'),
(2, 'Certified Physics Tutor'),
(3, 'Certified Chemistry Tutor');
GO

-- Thêm dữ liệu vào bảng TutorService
INSERT INTO TutorService (ServiceID, TutorID, Price)
VALUES
(1, 1, 100000),
(2, 1, 200000),
(3, 1, 300000),
(1, 2, 100000),
(2, 2, 200000),
(3, 2, 300000),
(1, 3, 100000),
(2, 3, 200000),
(3, 3, 300000);
GO

-- Thêm dữ liệu vào bảng Booking
INSERT INTO Booking (StudentID, TutorID, ServiceID, Status, DateStart, DateEnd, PaymentMethods)
VALUES
(1, 1, 1, 'Completed', '2024-01-01', '2024-01-31','Online'),
(2, 2, 2, 'Pending', '2024-02-01', '2024-02-28','Offline'),
(3, 3, 3, 'Cancelled', '2024-03-01', '2024-03-31','Online'),
(3, 2, 1, 'Approved', '2024-03-01', '2024-03-31','Offline');
GO

-- Thêm dữ liệu vào bảng Feedbacks
INSERT INTO Feedbacks (BookingID, StudentID, Rating, Detail)
VALUES
(1, 1, 5, 'Great tutoring session!'),
(2, 2, 4, 'Very helpful, but could improve communication.'),
(3, 3, 2, 'Not satisfied with the tutoring.');
GO

-- Thêm dữ liệu vào bảng Schedule
INSERT INTO Schedule ( Slot)
VALUES
( 'Slot 1'),
( 'Slot 2'),
( 'Slot 3'),
( 'Slot 4'),
( 'Slot 5'),
( 'Slot 6');
GO

-- Thêm dữ liệu vào bảng BookingSchedule
INSERT INTO BookingSchedule (BookingID, ScID, Date)
VALUES
(1, 1, '2024-01-02'),
(2, 2, '2024-04-10'),
(3, 3, '2024-06-17');
GO

-- Thêm dữ liệu vào bảng Moderator
INSERT INTO Moderator (Fullname, Password, Email, Status)
VALUES
('Admin One', 'admin123', 'admin.one@example.com', 'Active'),
('Admin Two', 'admin456', 'admin.two@example.com', 'Active'),
('Admin Three', 'admin789', 'admin.three@example.com', 'Active');
GO


INSERT INTO Report(Detail, Date, Status, Image ,StudentID, TutorID, ServiceID)
VALUES 
('Teacher Stupid', '2024-10-24', 'Pending', 'https://i.pinimg.com/564x/f5/7f/99/f57f99bc24a80a25994bead22c65950b.jpg',1 , 1, 1)
