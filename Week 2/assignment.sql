USE StudentDB;

-- Assignment 6
-- 1.	Find students who scored above the average score using a subquery.
SELECT DISTINCT
	T01F01,
	T01F02
FROM 
	T01
    INNER JOIN T03 ON T01F01 = T03F02
WHERE
	T03F04 > (SELECT AVG(T03F04) FROM T03);

    
-- 2.	Get students enrolled in the same course as “John” using a correlated subquery.
SELECT
	T01F01,
    T01F02
FROM
	T01
    INNER JOIN T03 ON T01F01 = T03F02
WHERE
	T03F03 = (SELECT T03F03 FROM T03 INNER JOIN T01 ON T03F02 = T01F01 WHERE T01F02 = 'Alice Johnson');
    

INSERT INTO T02 (T02F01, T02F02, T02F03) VALUES
(201, 'COA', 4),
(202, 'OS', 3),
(203, 'PYTHON', 1);
-- Assignment 7
-- 1.	Write a query to list all distinct course names from Courses and Marks tables (use UNION).
SELECT
	T02F02
FROM
	T02
UNION
SELECT 
	T03F03
FROM 	
	T03;
    
-- 2.	Write another query to include duplicates (use UNION ALL).
SELECT
	T02F02
FROM
	T02
UNION ALL
SELECT 
	T03F03
FROM 	
	T03;
   
-- Assignment 8
-- 1.	Add a PRIMARY KEY on student_id.
ALTER TABLE T01 DROP PRIMARY KEY;
ALTER TABLE T01 ADD CONSTRAINT PK_T01F01 PRIMARY KEY(T01F01);

-- 2.	Add an AUTO_INCREMENT to course_id.
ALTER TABLE T01 DROP CONSTRAINT T01F05_FK;
ALTER TABLE T02 MODIFY COLUMN T02F01 INT AUTO_INCREMENT;
ALTER TABLE T01 ADD CONSTRAINT T01F05_FK FOREIGN KEY (T01F05) REFERENCES T02(T02F01);

INSERT INTO T02 (T02F02, T02F03) VALUES
('Backend development', 4);


ALTER TABLE T01 DROP CONSTRAINT T01F06;
-- 3.	Create an INDEX on email for faster search.
CREATE UNIQUE INDEX INDEX_EMAIL ON T01(T01F06);


-- 4.	Prove query optimization difference using EXPLAIN with and without index.
EXPLAIN SELECT 
	T01F01,
    T01F02,
    T01F06
FROM 
	T01
WHERE
	T01F06 = 'EVE@GMAIL.COM';
    

-- Assignment 9
-- 1.	Write a Stored Procedure to return all students enrolled in a given course.
DROP PROCEDURE IF EXISTS GET_STUDENT_ENROLLED_IN_COURSE;

DELIMITER $$
CREATE PROCEDURE GET_STUDENT_ENROLLED_IN_COURSE(IN p_course_name VARCHAR(50))
BEGIN
	SELECT
		T01F01,
        T01F02
	FROM 
		T01
        INNER JOIN T02 ON T01F05 = T02F01
	WHERE
		T02F02 = p_course_name;
END$$
DELIMITER ;

CALL GET_STUDENT_ENROLLED_IN_COURSE("Business Administration");

-- 2.	Create a Function to calculate grade based on marks (e.g., A/B/C).
DELIMITER $$
CREATE FUNCTION CALCULATE_GRADE(p_marks DECIMAL(5,2))
RETURNS CHAR
DETERMINISTIC
BEGIN
	DECLARE v_grade CHAR(1);
    
	IF p_marks >= 80 THEN
		SET v_grade = 'A';
	ELSEIF p_marks >=  60 THEN
		SET v_grade = 'B';
	ELSEIF p_marks >= 40 THEN
		SET v_grade = 'C';
	ELSE
		SET v_grade = 'F';
	END IF;
    
    RETURN v_grade;
END$$
DELIMITER ;

SELECT
	CALCULATE_GRADE(70);
    

-- 3.	Create a Trigger to log deleted student records into a new table DeletedStudents.
# Delted student
DROP TABLE IF EXISTS T04;
CREATE TABLE T04
(
	T04F01 INT NOT NULL, # student id
    T04F02 VARCHAR(30) NOT NULL, # name
    T04F03 INT NOT NULL, # age
    T04F04 ENUM("MALE", "FEMALE", "OTHER") NOT NULL, # gender
    T04F05 VARCHAR(100) NOT NULL, # email
    T04F06 DATE DEFAULT (CURDATE()) # deletion date
);


DROP TRIGGER IF EXISTS AFTER_STUDENT_DELETE;
DELIMITER $$
CREATE TRIGGER AFTER_STUDENT_DELETE
AFTER DELETE ON T01
FOR EACH ROW
BEGIN
	INSERT INTO T04(T04F01, T04F02, T04F03, T04F04, T04F05) VALUES
    (OLD.T01F01, OLD.T01F02, OLD.T01F03, OLD.T01F04, OLD.T01F06);
END$$
DELIMITER ;

SELECT * FROM T01;
DELETE FROM T01 WHERE T01F01 = 2;
SELECT * FROM T04;



-- Assignment 10
-- 1.	Create a View StudentCourseView that shows student name + course name.
CREATE OR REPLACE VIEW STUDENTCOURSEVIEW AS
SELECT
	T01F01,
    T01F02,
    T02F02
FROM 
	T01
    INNER JOIN T02 ON T01F05 = T02F01;

-- 2.	Query from the view to find students enrolled in “Database Systems”.
SELECT
	T01F01,
    T01F02,
    T02F02
FROM 
	STUDENTCOURSEVIEW
WHERE
	T02F02 = "Computer Science";
    
    
CREATE DATABASE StudentDB_Copy;
USE StudentDB_Copy;
SELECT * FROM T01;



