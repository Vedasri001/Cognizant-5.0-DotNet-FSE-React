USE CognizantSQL;

DROP PROCEDURE IF EXISTS GetEmployeeById;

DELIMITER $$

CREATE PROCEDURE GetEmployeeById(IN empId INT)
BEGIN
    SELECT *
    FROM Employee
    WHERE EmployeeID = empId;
END $$

DELIMITER ;

CALL GetEmployeeById(104);