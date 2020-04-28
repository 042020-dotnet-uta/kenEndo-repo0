CREATE Table Department(
ID INT NOT NULL IDENTITY(1,1),
Name NVARCHAR(50) NOT NULL,
Location NVARCHAR(50) NOT NULL
PRIMARY KEY(ID)
);

CREATE Table Employee(
ID INT NOT NULL IDENTITY(1,1),
FirstName NVARCHAR(50) NOT NULL,
LastNAme NVARCHAR(50) NOT NULL,
SSN CHAR(9) NOT NULL,
DeptID INT NOT NULL
PRIMARY KEY(ID),
FOREIGN KEY(DeptID) REFERENCES Department(ID)
);

CREATE Table EmpDetails(
ID INT NOT NULL IDENTITY(1,1),
EmployeeID INT NOT NULL,
Salary INT NOT NULL,
Address1 NVARCHAR(50) NOT NULL,
Address2 NVARCHAR(50) NOT NULL,
City NVARCHAR(50) NOT NULL,
State NVARCHAR(50) NOT NULL,
Country NVARCHAR(50) NOT NULL
PRIMARY KEY(ID),
FOREIGN KEY(EmployeeID) REFERENCES Employee(ID)
);
--add at least 3 records into each table
INSERT INTO Department(Name,Location)
VALUES ('Finance','Dallas');

INSERT INTO Department(Name,Location)
VALUES ('HR','Austin');

INSERT INTO Department(Name,Location)
VALUES ('HQ','Houston');

INSERT INTO Employee(FirstName, LastName, SSN, DeptID)
VALUES ('David', 'Dunk', 123456789, 1);

INSERT INTO Employee(FirstName, LastName, SSN, DeptID)
VALUES ('Cindy', 'Pass', 123456789, 2);

INSERT INTO Employee(FirstName, LastName, SSN, DeptID)
VALUES ('Justin', 'Miss', 123456789, 3);

INSERT INTO Employee(FirstName, LastName, SSN, DeptID)
VALUES ('Matthew', 'anything', 123456789, 4);

INSERT INTO EmpDetails(EmployeeID, Salary, Address1, Address2, City, State, Country)
VALUES (4, 60000, '123 street', '456 street', 'Dallas', 'Texas', 'USA');

INSERT INTO EmpDetails(EmployeeID, Salary, Address1, Address2, City, State, Country)
VALUES (5, 70000, '321 street', '654 street', 'Austin', 'Texas', 'USA');

INSERT INTO EmpDetails(EmployeeID, Salary, Address1, Address2, City, State, Country)
VALUES (6, 80000, '789 street', '987 street', 'Houston', 'Texas', 'USA');

INSERT INTO EmpDetails(EmployeeID, Salary, Address1, Address2, City, State, Country)
VALUES (8, 60000, '789 street', '987 street', 'San Antonio', 'Texas', 'USA');


--add employee Tina Smith
INSERT INTO Employee(FirstName,LastName,SSN,DeptID)
VALUES('Tina','Smith',987654321,1);

INSERT INTO EmpDetails(EmployeeID, Salary, Address1, Address2, City, State, Country)
VALUES (7, 70000, '782 street', '947 street', 'San Antonio', 'Texas', 'USA');

UPDATE Employee
SET DeptID = 4
WHERE ID = 7;

--add department Marketing
INSERT INTO Department(Name, Location)
VALUES ('Marketing','San Antonio');

--list all employees in marketing
SELECT * FROM Employee
WHERE DeptID = 4;

--report total salary of Marketing
SELECT sum(Salary) from EmpDetails
WHERE ID
in(
select ID from employee where DeptID
in(
select ID from Department where name ='marketing'
)
);

--report total employees by department
SELECT dept.Name, Count(Employee.ID) AS NumEmployees FROM Employee
JOIN Department dept on dept.ID = Employee.DeptID
Group BY dept.Name;

--increase salary of Tina Smith to $90,000
UPDATE EmpDetails
SET Salary = 90000
WHERE EmployeeId in(
select ID from employee where FirstName='Tina');
