DROP DATABASE IF EXISTS Сomputer_systems;
CREATE DATABASE Сomputer_systems;
USE Сomputer_systems;

-- Создание таблицы "Ошибка"
CREATE TABLE Errors (
    ID INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(50)
);

-- Создание таблицы "Заявки"
CREATE TABLE Requests (
    ID INT AUTO_INCREMENT PRIMARY KEY , 
    Equipment_Type VARCHAR(255), 
    Serial_Number VARCHAR(255), 
    Creation_Date DATE, 
    Problem_Description TEXT,
    Errors_ID INT, 
	FOREIGN KEY (Errors_ID) REFERENCES Errors (ID) ON DELETE CASCADE 
);

-- Создание таблицы "Роль"
CREATE TABLE Roles (
	ID INT AUTO_INCREMENT PRIMARY KEY , 
	Name VARCHAR(100) 
);


-- Создание таблицы "Администратор"
CREATE TABLE Admins (
    ID  INT AUTO_INCREMENT PRIMARY KEY,  
    FIO VARCHAR(255),   
    Phone VARCHAR(11),
	Password VARCHAR(100),
	Email VARCHAR(100),
    ID_Roles INT,
    FOREIGN KEY (ID_Roles) REFERENCES Roles (ID)
);
-- Создание таблицы "Исполнители"
CREATE TABLE Executors (
    ID  INT AUTO_INCREMENT PRIMARY KEY ,  
    FIO VARCHAR(255) ,   
    Position VARCHAR(255),  
    Department VARCHAR(255),  
    Phone VARCHAR(11),
	Password VARCHAR(100),
	Email VARCHAR(100),
    ID_Roles INT,
    FOREIGN KEY (ID_Roles) REFERENCES Roles (ID)
);

-- Создание таблицы "Клиент"
CREATE TABLE Clients (
	ID  INT AUTO_INCREMENT PRIMARY KEY , 
	FIO VARCHAR(255),  
	Passport VARCHAR(10),
    Address VARCHAR(255),  
    Phone VARCHAR(11),
	Password VARCHAR(100),
	Email VARCHAR(100),
    ID_Roles INT,
    FOREIGN KEY (ID_Roles) REFERENCES Roles (ID)
); 

-- Создание таблицы "Отчеты_по_ремонту"
CREATE TABLE Repair_Reports (
    ID INT AUTO_INCREMENT PRIMARY KEY, 
    Begin_Date Date,
    End_Date DATE ,
    Description_all_work TEXT, 
    Used_resources VARCHAR(255),
    Spare_parts_needed VARCHAR(255), 
	Total_cost DECIMAL(10, 2) ,
    Coordination_with_other_specialists VARCHAR(255),
    Request_ID INT, 
    FOREIGN KEY (Request_ID) REFERENCES Requests (ID) ON DELETE CASCADE , 
	Executor_ID INT ,
    FOREIGN KEY (Executor_ID) REFERENCES Executors (ID) ON DELETE CASCADE ,
    Clients_ID INT ,
    FOREIGN KEY (Clients_ID) REFERENCES Clients (ID) ON DELETE CASCADE 
);
CREATE TABLE Priority (
    ID INT AUTO_INCREMENT PRIMARY KEY ,
    Descriptions VARCHAR(255), 
    Name VARCHAR(255)
);

-- Создание таблицы "Мониторинг_заявок"
CREATE TABLE Request_Monitoring (
    ID INT AUTO_INCREMENT PRIMARY KEY ,
    Time_receipt TIME,
    Time_acceptance TIME,
    Processing_time INT, 
    Registered BOOLEAN, 
	Request_ID INT,
    FOREIGN KEY (Request_ID) REFERENCES Requests (ID) ON DELETE CASCADE ,
    Admin_ID INT,
    FOREIGN KEY (Admin_ID) REFERENCES Admins (ID) ON DELETE CASCADE ,
    Priority_ID INT,
    FOREIGN KEY (Priority_ID) REFERENCES Priority (ID)
);
-- Создание таблицы "Проделанные работы"
CREATE TABLE Work_done (
    ID INT AUTO_INCREMENT PRIMARY KEY ,
    Work_time INT, 
    Description_work VARCHAR(255),  
    Expenses DECIMAL(10, 2),
    Request_ID INT,
    FOREIGN KEY (Request_ID) REFERENCES Requests (ID) ON DELETE CASCADE ,
    Executor_ID INT,
    FOREIGN KEY (Executor_ID) REFERENCES Executors (ID) ON DELETE CASCADE 
);

INSERT INTO Errors (Name) VALUES 
('Blue screen'),
('No internet connection'),
('Slow performance'),
('Software not working'),
('Hardware failure');

INSERT INTO Requests (Equipment_Type, Serial_Number, Creation_Date, Problem_Description, Errors_ID) VALUES 
('Desktop', '12345678', '2021-01-01', 'Computer crashes randomly', 1),
('Laptop', '98765432', '2021-02-15', 'Unable to connect to Wi-Fi', 2),
('Server', '54321678', '2021-03-10', 'Slow response time', 3),
('Printer', '87654321', '2021-04-20', 'Not printing properly', 4),
('Monitor', '23456789', '2021-05-05', 'Screen flickering', 5);

-- Добавление данных в таблицу Roles:
INSERT INTO Roles (Name) VALUES
('admin'),
('employee'),
('user');

INSERT INTO Admins (FIO, Phone, Password, Email, ID_Roles)
VALUES ('John Smith', '1234567890', 'password123', 'johnsmith@example.com', 1),
('Emily Johnson', '0987654321', 'password456', 'emilyjohnson@example.com', 1);

INSERT INTO Executors (FIO, Position, Department, Phone, Password, Email, ID_Roles) VALUES
('Michael Davis', 'IT Specialist', 'IT Department', '9876543210', 'password789', 'michaeldavis@example.com', 2),
('Emma Wilson', 'Technician', 'Service Department', '0123456789', 'password012', 'emmawilson@example.com', 2);

INSERT INTO Clients (FIO, Passport, Address, Phone, Password, Email, ID_Roles) VALUES 
('David Brown', '0123456789', '123 Main Street', '87654321093', 'password345', 'davidbrown@example.com', 3),
('Sophia Johnson', '0987654321', '456 Elm Street', '90123456785', 'password678', 'sophiajohnson@example.com', 3);

INSERT INTO Repair_Reports (Begin_Date, End_Date, Description_all_work, Used_resources, Spare_parts_needed, Total_cost, Coordination_with_other_specialists, Request_ID, Executor_ID, Clients_ID) VALUES
 ('2021-01-10', '2021-01-15', 'Replaced faulty motherboard', 'Screwdriver, thermal paste', 'Motherboard', 200, 'Consulted with network specialist', 1, 1, 1),
 ('2021-02-20', '2021-02-25', 'Reset network settings', 'Ethernet cable, network diagnostic tool', 'None', 50, 'No coordination required', 2, 2, 2),
 ('2021-03-15', '2021-03-20', 'Optimized server configuration', 'Server management software', 'None', 100, 'Coordinated with server specialist', 3, 2, 1),
 ('2021-04-25', '2021-04-30', 'Cleaned printhead', 'Cleaning solution, cotton swabs', 'Printhead', 30, 'No coordination required', 4, 1, 2),
 ('2021-05-15', '2021-05-25', 'A faulty cable has been replaced', 'Cable , monitor diagnostic tool', 'Cable', 50, 'No coordination required', 5, 1, 2);

INSERT INTO Priority (Descriptions, Name) VALUES 
('Очень высокий приоритет', 'High'),
('Средний приоритет', 'Medium'),
('Низкий приоритет', 'Low');

INSERT INTO Request_Monitoring (Registered, Time_receipt, Time_acceptance, Processing_time, Request_ID, Admin_ID, Priority_ID) VALUES
(True, '08:00:00', '08:30:00', 30, 1, 1,2),
(True, '09:15:00', '10:00:00', 45, 2, 1,3),
(True, '10:30:00', '11:15:00', 45, 3, 2,1),
(True, '11:30:00', '12:00:00', 30, 4, 2,2),
(True, '12:45:00', '13:15:00', 30, 5, 1,1);

-- Inserting data into Work_done table
INSERT INTO Work_done (Work_time, Description_work, Expenses, Request_ID, Executor_ID) VALUES 
(30, 'Replaced faulty RAM module', 1500, 1, 2),
(20, 'Reinstalled operating system', 1000, 2, 1),
(40, 'Replaced hard drive', 2000, 3, 2),
(10, 'Cleaned printer internals', 800, 4, 1),
(20, 'Replaced monitor cable', 1600, 5, 2);



UPDATE `сomputer_systems`.`Clients` SET `Password` = '31457e06e2adb2178358e9fc6705e0b6f37e9b6ec9456e8890d28f292be9adc4' WHERE (`ID` = '1');
UPDATE `сomputer_systems`.`Clients` SET `Password` = '244091dbe590bba5ed965b2ef31191be8b79ea41a7106ebdf32f841182a7d2bb' WHERE (`ID` = '2');
UPDATE `сomputer_systems`.`Admins` SET `Password` = 'ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f' WHERE (`ID` = '1');
UPDATE `сomputer_systems`.`Admins` SET `Password` = 'c6ba91b90d922e159893f46c387e5dc1b3dc5c101a5a4522f03b987177a24a91' WHERE (`ID` = '2');
UPDATE `сomputer_systems`.`Executors` SET `Password` = '5efc2b017da4f7736d192a74dde5891369e0685d4d38f2a455b6fcdab282df9c' WHERE (`ID` = '1');
UPDATE `сomputer_systems`.`Executors` SET `Password` = 'cb28ca00e0fde85aeae3101ebbb701465181eb76241e75f77e3d54e60ed50c35' WHERE (`ID` = '2');


SELECT Requests.ID FROM Requests 
INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID 
WHERE Serial_Number = 12345678
AND Repair_Reports.Begin_Date = '2021-01-10';




SELECT Repair_Reports.Begin_Date, Request_Monitoring.Registered, Priority.Name, Equipment_Type, Serial_Number, Creation_Date, Problem_Description, Errors.Name
FROM Requests 
INNER JOIN Errors ON Requests.Errors_ID = Errors.ID 
INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID 
INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID 
INNER JOIN Request_Monitoring ON Requests.ID = Request_Monitoring.Request_ID 
INNER JOIN Work_done ON Requests.ID = Work_done.Request_ID 
INNER JOIN Priority ON Priority.ID = Request_Monitoring.Priority_ID 
WHERE Request_Monitoring.Registered = true
ORDER BY Repair_Reports.Begin_Date DESC;



SELECT Begin_Date, End_Date, Description_all_work, Used_resources, Spare_parts_needed, Total_cost, Coordination_with_other_specialists
FROM Repair_Reports
 INNER JOIN Requests ON Requests.ID = Repair_Reports.Request_ID
 Where Serial_Number = 12345678;



Select Work_done.Work_time, Work_done.Description_work, Work_done.Expenses, Repair_Reports.Begin_Date, Repair_Reports.End_Date, Repair_Reports.Description_all_work, Repair_Reports.Used_resources, Repair_Reports.Spare_parts_needed, Repair_Reports.Total_cost, Repair_Reports.Coordination_with_other_specialists
FROM Work_done INNER JOIN Executors ON Work_done.Request_ID = Executors.ID 
INNER JOIN Repair_Reports  ON Repair_Reports.Executor_ID = Executors.ID
INNER JOIN Requests ON Requests.ID = Work_done.Request_ID
Where Work_done.Request_ID = Repair_Reports.Request_ID;

SELECT COUNT(*) FROM Requests INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID  
WHERE Repair_Reports.End_Date <> Repair_Reports.Begin_Date AND Executors.Email = 'michaeldavis@example.com';

SELECT AVG(Work_time) FROM Work_done INNER JOIN Executors ON Executors.ID = Work_done.Executor_ID  WHERE Executors.Email = 'michaeldavis@example.com'; 
SELECT Name FROM Requests INNER JOIN Errors ON Requests.Errors_ID = Errors.ID INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID WHERE Executors.Email = 'michaeldavis@example.com';



SELECT Repair_Reports.Begin_Date, Repair_Reports.End_Date, Priority.Name, Equipment_Type, Serial_Number, Creation_Date, Problem_Description, Errors.Name 
FROM Requests
 INNER JOIN Errors ON Requests.Errors_ID = Errors.ID
 INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID
 INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID
 INNER JOIN Request_Monitoring ON Requests.ID = Request_Monitoring.Request_ID
 INNER JOIN Work_done ON Requests.ID = Work_done.Request_ID
 INNER JOIN Priority ON Priority.ID = Request_Monitoring.Priority_ID
 WHERE Begin_Date <> End_Date AND Errors.Name = 'Blue screen';


SELECT * FROM Requests WHERE Serial_Number = '12345678';

SELECT Repair_Reports.Begin_Date, Request_Monitoring.Registered, Priority.Name, Equipment_Type, Serial_Number, Creation_Date, Problem_Description, Errors.Name 
FROM Requests
 INNER JOIN Errors ON Requests.Errors_ID = Errors.ID
 INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID
 INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID
 INNER JOIN Request_Monitoring ON Requests.ID = Request_Monitoring.Request_ID
 INNER JOIN Work_done ON Requests.ID = Work_done.Request_ID
 INNER JOIN Priority ON Priority.ID = Request_Monitoring.Priority_ID
 
 ORDER BY Repair_Reports.Begin_Date DESC;

UPDATE Request_Monitoring
SET
    Processing_time = TIMESTAMPDIFF(MINUTE, Time_receipt, Time_acceptance)
WHERE Request_Monitoring.ID = 6;
    
select Processing_time = TIMESTAMPDIFF(MINUTE, Time_receipt, Time_acceptance) FROM Request_Monitoring;

SELECT * FROM Executors;
SELECT * FROM Clients;
SELECT * FROM Requests;
SELECT * FROM Work_done;
SELECT * FROM Request_Monitoring;
SELECT * FROM Repair_Reports;
DELETE FROM Requests
 WHERE Requests.Serial_Number = 9;

UPDATE Requests
 INNER JOIN Errors ON Requests.Errors_ID = Errors.ID
 INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID
 INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID
 INNER JOIN Request_Monitoring ON Requests.ID = Request_Monitoring.Request_ID
 INNER JOIN Work_done ON Requests.ID = Work_done.Request_ID
 SET Requests.Equipment_Type = 'МАМА9',
 Requests.Serial_Number = 9,
 Requests.Creation_Date = '2021-01-01',
 Errors.Name = 'МАМА9',
 Repair_Reports.Executor_ID = 2,
 Requests.Problem_Description = 'МАМА9',
 Work_done.Executor_ID = 2,
 Request_Monitoring.Priority_ID = 3
 WHERE Requests.Serial_Number = 9 AND 
 Repair_Reports.Begin_Date = '2024-02-08';



UPDATE Requests 
INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID 
INNER JOIN Errors ON Requests.Errors_ID = Errors.ID 
SET Requests.Equipment_Type = "МАМА",
Requests.Creation_Date = "2000-01-01", 
Requests.Problem_Description = "МАМА",
Errors.Name ="МАМА", 
Requests.Serial_Number = 999
WHERE Requests.Serial_Number = 12345678 AND 
Repair_Reports.Begin_Date ='2021-01-10';




SELECT * FROM Requests
 INNER JOIN Errors ON Requests.Errors_ID = Errors.ID
 INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID
 INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID
 INNER JOIN Request_Monitoring ON Requests.ID = Request_Monitoring.Request_ID
 WHERE Requests.Serial_Number = 9 AND 
 Repair_Reports.Begin_Date = '2024-02-08';

SELECT * FROM Profile INNER JOIN Executors on Executors.ID = Profile.ID_Executors;
SELECT * FROM Сomputer_systems.roles;
SELECT name from Roles, profile where  Profile.ID_Roles = roles.ID;

SELECT * FROM Clients;
SELECT * FROM Admins;
SELECT * FROM Executors;

SELECT Serial_Number FROM Requests
INNER JOIN Errors ON Errors.ID = Requests.Errors_ID 
INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID 
INNER JOIN Clients ON Repair_Reports.Clients_ID = Clients.ID 
WHERE Clients.ID = 1;



SELECT Serial_Number, Creation_Date, Equipment_Type, Problem_Description, Errors.Name, Executors.FIO
FROM Requests INNER JOIN Errors ON Errors.ID = Requests.Errors_ID  
INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID 
INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID
WHERE Requests.Serial_Number = '12345678' AND Repair_Reports.Begin_Date = '2021-01-10';

SELECT Serial_Number, Creation_Date, Equipment_Type, Problem_Description, Errors.Name, Executors.FIO 
FROM Requests INNER JOIN Errors ON Requests.Errors_ID = Errors.ID 
INNER JOIN Repair_Reports ON Requests.ID = Repair_Reports.Request_ID 
INNER JOIN Executors ON Executors.ID = Repair_Reports.Executor_ID 
WHERE Requests.Serial_Number = '12345678'
AND Repair_Reports.Begin_Date = '2021-01-10';

SELECT Name FROM Roles
INNER JOIN Profile 
on Roles.ID = Profile.ID_Roles
INNER JOIN Executors 
on Executors.ID = Profile.ID_Executors;   


SELECT * FROM Requests
INNER JOIN Errors 
on Requests.Errors_ID = Errors.ID;  

SELECT * FROM Requests WHERE Serial_Number = 'A12345';
UPDATE Requests,Errors 
SET Requests.Equipment_Type = '1', Requests.Creation_Date = '2000-01-01', Requests.Problem_Description = '1' , Errors.Name = '1'
WHERE Serial_Number = 'A12345' AND Requests.Errors_ID = Errors.ID;
SET SQL_SAFE_UPDATES = 0;



SELECT Email, Serial_Number FROM Requests
INNER JOIN Repair_Reports on Repair_Reports.Request_ID = Requests.ID
INNER JOIN Executors on Repair_Reports.Executor_ID = Executors.ID
INNER JOIN Profile on Executors.ID = Profile.ID_Executors
WHERE Email = 'user@example.com';


SELECT Serial_Number, Date  FROM Requests
INNER JOIN Repair_Reports on Repair_Reports.Request_ID = Requests.ID
INNER JOIN Clients on Repair_Reports.Clients_ID = Clients.ID
WHERE Email = 'client1@example.com'; 
'{LoginForm.loginActive}';

INSERT INTO Clients (FIO, Passport, Address, Phone, Password, Email, ID_Roles) VALUES ('VFVF','', 'VFVF', 'VFVF', 'VFVF', 'VFVF', 3);
Select * FROM Clients;
DELETE FROM `сomputer_systems`.`Clients` WHERE (`ID` = '4');

SELECT* FROM Requests;
DELETE FROM `сomputer_systems`.`Requests` WHERE (`ID` = '4');

SELECT* FROM Repair_Reports;

UPDATE Requests,Errors 
SET Requests.Equipment_Type = @Equipment_Type, Requests.Creation_Date = @Creation_Date, 
Requests.Problem_Description = @Problem_Description , Errors.Name = @Name, NEW.Serial_Number
WHERE OLD.Serial_Number = @Serial_Number AND Creation_Date = @Creation_Date AND Requests.Errors_ID = Errors.ID;