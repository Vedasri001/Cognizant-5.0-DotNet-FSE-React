USE CognizantSQL;

DROP FUNCTION IF EXISTS AnnualSalary;

DELIMITER $$

CREATE FUNCTION AnnualSalary(monthlySalary DECIMAL(10,2))
RETURNS DECIMAL(10,2)
DETERMINISTIC
BEGIN
    RETURN monthlySalary * 12;
END $$

DELIMITER ;

SELECT
    EmployeeName,
    Salary,
    AnnualSalary(Salary) AS AnnualSalary
FROM Employee;