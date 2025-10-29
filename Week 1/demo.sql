# Create database
CREATE DATABASE EMPLOYEE;

# Select database
USE EMPLOYEE;

# Drop tables before creating new one
DROP TABLE IF EXISTS T01;
DROP TABLE IF EXISTS T02;
DROP TABLE IF EXISTS T03;

# Create tables
# Departments
CREATE TABLE T01 
(
	T01F01 INT PRIMARY KEY, # Department ID
    T01F02 VARCHAR(50) NOT NULL UNIQUE, # Name of department
    T01F03 VARCHAR(50) # Location of department
);

desc t01;

alter table t01 modify column t01f02 varchar(40);

# Employees
CREATE TABLE T02
(
	T02F01 INT PRIMARY KEY, # Employee ID
    T02F02 VARCHAR(50) NOT NULL, # First name
    T02F03 VARCHAR(50) NOT NULL, # Last name
    T02F04 VARCHAR(100) NOT NULL UNIQUE, # Email
    T02F05 DATE NOT NULL, # Hiring date
    T02F06 VARCHAR(50) NOT NULL, # Role
    T02F07 DECIMAL(10, 2) NOT NULL, # Monthly salary
    T02F08 INT, # Foreign key to Departments
	FOREIGN KEY (T02F08) REFERENCES T01(T01F01)
);

# Ex_employees
CREATE TABLE T03
(
	T03F01 INT PRIMARY KEY, # Employee ID
    T03F02 VARCHAR(50) NOT NULL, # First name
    T03F03 VARCHAR(50) NOT NULL, # Last name
    T03F04 DATE NOT NULL # When employee left
);

select t01f03, group_concat(t01f02) from t01 where t01f02 like "h%s" group by t01f03;
select t01f03, group_concat(t01f02) from t01 group by t01f03 having t01f02 like "h%s";
select * from t01;

select t01f03 from t01 as t1 where t01f03 = (select t01f02 from t01 where t01f02 like "h&s" group by t1.t01f03);

select t02f02, t02f07 from t02 where t02f07 < all (select avg(t02f07) from t02 group by t02f08 having 2);

select avg(t02f07) from t02 group by t02f08 having 2;

insert into t01(t01f01, t01f02, t01f03) values (9, "Human resours", "Mumbai");

# Alter table

# Rename table
ALTER TABLE DEPARTMENTS RENAME T01;

# Add new column
ALTER TABLE T01 ADD T01F04 TIMESTAMP;

# Rename column
ALTER TABLE T01 RENAME COLUMN T01F04 TO TIMECREATED;

# Drop column
ALTER TABLE T01 DROP COLUMN TIMECREATED;

# Change data type
ALTER TABLE T01 MODIFY COLUMN T01F03 VARCHAR(100);

# Add primary key
ALTER TABLE T01 ADD CONSTRAINT PK_TO1 PRIMARY KEY(T01F01);

# Drop forign key
ALTER TABLE T02 DROP CONSTRAINT T02_IBFK_1;

# Add foreign key
ALTER TABLE T02 ADD CONSTRAINT FK_T02F08 FOREIGN KEY (T02F08) REFERENCES T01(T01F01);

# Drop unique constraint
ALTER TABLE T02 DROP CONSTRAINT T02F04;

# Add unique constraint
ALTER TABLE T02 ADD CONSTRAINT T02F04_UNIQUE UNIQUE(T02F04);

# Add check constraint
ALTER TABLE T02 ADD CONSTRAINT T02F07_CHECK CHECK(T02F07 > 0);

# Add not null constraint
ALTER TABLE T02 MODIFY COLUMN T02F02 VARCHAR(50) NOT NULL;

# Set default value
ALTER TABLE T02 ALTER COLUMN T02F05 SET DEFAULT (CURDATE());

# Drop default values
ALTER TABLE T02 ALTER COLUMN T02F05 DROP DEFAULT;

# INSERT DATA

# DEPARTMRNT DATA
INSERT INTO T01 (T01F01, T01F02, T01F03) VALUES 
(1, 'Engineering', 'Bengaluru'),
(2, 'Sales', 'Mumbai'),
(3, 'Human Resources', 'Rajkot'),
(4, 'Marketing', 'Delhi'),
(5, 'Finance', 'Mumbai');

# EMPLOYEE DATA
INSERT INTO T02 (T02F01, T02F02, T02F03, T02F04, T02F05, T02F06, T02F07, T02F08) VALUES
(101, 'Rohan', 'Sharma', 'rohan.sharma@example.com', '2021-08-15', 'Software Engineer', 80000.00, 1),
(102, 'Priya', 'Patel', 'priya.patel@example.com', '2020-03-10', 'Senior Software Engineer', 120000.00, 1),
(103, 'Amit', 'Singh', 'amit.singh@example.com', '2022-01-20', 'Database Administrator', 95000.00, 1),
(104, 'Anjali', 'Mehta', 'anjali.mehta@example.com', '2019-11-05', 'Sales Manager', 110000.00, 2),
(105, 'Vikram', 'Rao', 'vikram.rao@example.com', '2023-07-12', 'Sales Representative', 75000.00, 2),
(106, 'Sunita', 'Jain', 'sunita.jain@example.com', '2021-05-25', 'HR Manager', 90000.00, 3),
(107, 'Deepak', 'Kumar', 'deepak.kumar@example.com', '2024-02-01', 'HR Assistant', 50000.00, 3),
(108, 'Neha', 'Gupta', 'neha.gupta@example.com', '2022-09-30', 'Marketing Specialist', 85000.00, 4),
(109, 'Sanjay', 'Verma', 'sanjay.verma@example.com', '2020-06-18', 'Accountant', 70000.00, 5),
(110, 'Pooja', 'Mishra', 'pooja.mishra@example.com', '2023-10-09', 'Sales Representative', 72000.00, 2),
(111, 'Rajesh', 'Nair', 'rajesh.nair@example.com', '2025-01-15', 'Junior Engineer', 60000.00, 1),
(112, 'Kavita', 'Iyer', 'kavita.iyer@example.com', '2024-08-01', 'Consultant', 150000.00, NULL);

# EX_EMPLOYEE DATA
INSERT INTO T03 (T03F01, T03F02, T03F03, T03F04) VALUES
(201, 'Arjun', 'Reddy', '2023-12-31'),
(202, 'Meera', 'Desai', '2024-06-30');


# UPDATE QUERY
# To change employee department from marketing to sales
UPDATE
	T02
SET 
	T02F08 = 5
WHERE
	T02F01 = 108;
    
# To give increment of 10% salary to employee working in Sales department
UPDATE 
	T02
SET
	T02F07 = T02F07 * 1.1
WHERE
	T02F08 = 2;
    
    
# DELETE QUERY
# To delete employee with ID 109
DELETE FROM 
	T02
WHERE 
	T02F01 = 109;
    
    
# SELECT QUERY
# Get all data of Department
SELECT 
	* 
FROM 
	T01;

# WHERE CLAUSE
# Get details of department having id 1
SELECT
	T01F01,
    T01F02,
    T01F03
FROM 
	T01
WHERE
	T01F01 = 1;
    
# ORDER BY CLAUSE
# List all employee in asending order
SELECT
	T02F01,
    T02F02,
    T02F03
FROM
	T02
ORDER BY
	T02F02,
    T02F03;
    
# GROUP BY CALUSE
# Count number of employee department wise
SELECT 
	T01F02,
	COUNT(T02F01) AS NUMBER_OF_EMPLOYEE
FROM 
	T02
    INNER JOIN T01 ON (T01F01 = T02F08)
GROUP BY
	T02F08;
    
# HAVING CLAUSE
# Get department having total salary greater than 100000
SELECT
	T01F02,
    SUM(T02F07)
FROM 
	T02
    INNER JOIN T01 ON (T01F01 = T02F08)
GROUP BY
	T02F08
HAVING
	SUM(T02F07) > 100000;
    
# LIMIT OFFSET
# To fetch employee with third highest salary
SELECT
	T02F02,
    T02F01,
    T02F07
FROM
	T02
ORDER BY
	T02F07
LIMIT 
	1
OFFSET
	2;
    
# SUM, COUNT, AVG, MIN, MAX

# SUM
# Get department having total salary greater than 100000
SELECT
	T01F02,
    SUM(T02F07)
FROM 
	T02
    INNER JOIN T01 ON (T01F01 = T02F08)
GROUP BY
	T02F08;
    
# COUNT
# Count number of employee department wise
SELECT 
	T01F02,
	COUNT(T02F01) AS NUMBER_OF_EMPLOYEE
FROM 
	T02
    INNER JOIN T01 ON (T01F01 = T02F08)
GROUP BY
	T02F08;
    
# AVG
# To calculate average salary of department
SELECT
	T01F02,
    AVG(T02F07)
FROM 
	T02
    INNER JOIN T01 ON (T01F01 = T02F08)
GROUP BY
	T02F08;
    
# MIN, MAX
# To find minimum and maximum salary of department
SELECT
	T01F02,
    MIN(T02F07),
    MAX(T02F07)
FROM 
	T02
    INNER JOIN T01 ON (T01F01 = T02F08)
GROUP BY
	T02F08;



# INNER JOIN
# To list employees with their department name
SELECT
	T02F02,
    T02F03,
    T01F02
FROM 
	T01
    INNER JOIN T02 ON T01F01 = T02F08;
    
# LEFT JOIN
# To list all employee (also who is not associated with any department)
SELECT 
	T02F02,
    T02F03,
    T01F02
FROM
	T02
    LEFT JOIN T01 ON T01F01 = T02F08;
    
# RIGHT JOIN
# To list department with no employee
SELECT 
    T01F02
FROM
	T02
    RIGHT OUTER JOIN T01 ON T01F01 = T02F08
WHERE 
	T02F01 IS NULL;


# CROSS JOIN
# To list employee with their department name
SELECT 
	T02F02,
    T02F03,
    T01F02
FROM 
	T01
    CROSS JOIN T02
WHERE 
	T01F01 = T02F08;
