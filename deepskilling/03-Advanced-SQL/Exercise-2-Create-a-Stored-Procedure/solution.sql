USE CognizantSQL;

DROP PROCEDURE IF EXISTS GetAllEmployees;
DELIMITER $$

CREATE PROCEDURE GetAllEmployees()
BEGIN
    SELECT * FROM Employee;
END $$

DELIMITER ;

CALL GetAllEmployees();

DROP PROCEDURE IF EXISTS GetEmployeesByDepartment;
DELIMITER $$

CREATE PROCEDURE GetEmployeesByDepartment(IN dept VARCHAR(50))
BEGIN
    SELECT *
    FROM Employee
    WHERE Department = dept;
END $$

DELIMITER ;

CALL GetEmployeesByDepartment('IT');