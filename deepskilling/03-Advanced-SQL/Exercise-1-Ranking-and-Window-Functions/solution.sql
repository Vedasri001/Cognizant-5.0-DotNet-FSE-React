CREATE DATABASE IF NOT EXISTS CognizantSQL;
USE CognizantSQL;
CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(50),
    Department VARCHAR(50),
    Salary DECIMAL(10,2)
);
INSERT INTO Employee VALUES
(101,'Rahul','HR',45000),
(102,'Anjali','HR',55000),
(103,'Amit','IT',75000),
(104,'Priya','IT',90000),
(105,'Kiran','Finance',65000),
(106,'Sneha','Finance',65000),
(107,'Arjun','IT',80000),
(108,'Meena','HR',60000);
SELECT * FROM Employee;
SELECT
    EmployeeID,
    EmployeeName,
    Department,
    Salary,
    ROW_NUMBER() OVER (PARTITION BY Department ORDER BY Salary DESC) AS RowNum
FROM Employee;

SELECT VERSION();

SELECT
    EmployeeID,
    EmployeeName,
    Department,
    Salary,
    RANK() OVER(
        PARTITION BY Department
        ORDER BY Salary DESC
    ) AS Employee_Rank
FROM Employee;

SELECT
    EmployeeID,
    EmployeeName,
    Department,
    Salary,
    DENSE_RANK() OVER(
        PARTITION BY Department
        ORDER BY Salary DESC
    ) AS DenseRank
FROM Employee;

SELECT
    EmployeeName,
    Department,
    Salary,
    SUM(Salary) OVER(
        PARTITION BY Department
        ORDER BY Salary
    ) AS Running_Total
FROM Employee;

SELECT
    EmployeeName,
    Department,
    Salary,
    AVG(Salary) OVER(
        PARTITION BY Department
    ) AS Department_Average
FROM Employee;
