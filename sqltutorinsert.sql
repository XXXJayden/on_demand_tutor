USE OnDemandTutorDB;
GO

-- Thêm dữ liệu vào bảng Tutor
INSERT INTO Tutor (Fullname, Password, Email, Status, Description, Major, Grade, Avatar)
VALUES
('John Doe', 'password123', 'john.doe@example.com', 'Active', 'Experienced in Mathematics', 'Mathematics','10','https://th.bing.com/th/id/OIP.-uzWRbEtN9bBg01j9owZqgHaHa?w=186&h=186&c=7&r=0&o=5&pid=1.7'),
('Jane Smith', 'password456', 'jane.smith@example.com', 'Active', 'Experienced in Physics', 'Physics','11','https://th.bing.com/th/id/OIP.qYkvb_vtTjNludvSV0IJZAHaLH?rs=1&pid=ImgDetMain'),
('Emily Johnson', 'password789', 'emily.johnson@example.com', 'InActive', 'Experienced in Chemistry', 'Chemistry','12','https://th.bing.com/th/id/OIP.Oz-hottA-PJhC5zWkc_o4gD6D6?rs=1&pid=ImgDetMain');
GO

-- Thêm dữ liệu vào bảng Student
INSERT INTO Student (Fullname, Password, Phone, Email, Address, Status, Grade)
VALUES
('Alice Brown', 'password123', '1234567890', 'alice.brown@example.com', '123 Main St', 'Active', '10'),
('Bob White', 'password456', '2345678901', 'bob.white@example.com', '456 Elm St', 'Active', '11'),
('Charlie Green', 'password789', '3456789012', 'charlie.green@example.com', '789 Oak St', 'InActive', '12');
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
(1, 'https://th.bing.com/th/id/R.4322e541b4b232fa586991e3c228174f?rik=XU3eXWirJiQ3Fw&pid=ImgRaw&r=0'),
(2, 'https://th.bing.com/th/id/OIP.DZgRZmGTZjAFM_sPCdJglAAAAA?w=360&h=254&rs=1&pid=ImgDetMain'),
(3, 'https://th.bing.com/th/id/OIP.aFwJgyLKcwTHjz5jUacHIwAAAA?w=368&h=280&rs=1&pid=ImgDetMain');
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


-- Thêm dữ liệu vào bảng Moderator
INSERT INTO Moderator (Fullname, Password, Email, Status)
VALUES
('Admin One', 'admin123', 'admin.one@example.com', 'Active'),
('Admin Two', 'admin456', 'admin.two@example.com', 'Active'),
('Admin Three', 'admin789', 'admin.three@example.com', 'Active');
GO
