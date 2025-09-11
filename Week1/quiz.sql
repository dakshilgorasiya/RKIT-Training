CREATE DATABASE LibraryDB;

USE LibraryDB;

-- Authors
CREATE TABLE T01 
(
    T01F01 INT PRIMARY KEY AUTO_INCREMENT, -- author_id
    T01F02 VARCHAR(50) NOT NULL, -- first_name
    T01F03 VARCHAR(50) NOT NULL -- last_name
);

-- Books
CREATE TABLE T02 
(
    T02F01 INT PRIMARY KEY AUTO_INCREMENT, -- book_id
    T02F02 VARCHAR(100) NOT NULL, -- title
    T02F03 INT, -- author_id
    T02F04 VARCHAR(50) NOT NULL, -- genre
    T02F05 INT NOT NULL, -- publication_year
    T02F06 VARCHAR(13) UNIQUE, -- isbn
    FOREIGN KEY (T02F03) REFERENCES T01(T01F01)
);

-- Borrowers
CREATE TABLE T03 
(
    T03F01 INT PRIMARY KEY AUTO_INCREMENT, -- borrower_id
    T03F02 VARCHAR(50) NOT NULL, -- first_name
    T03F03 VARCHAR(50) NOT NULL, -- last_name
    T03F04 VARCHAR(100) UNIQUE NOT NULL, -- email
    T03F05 DATE -- registration_date
);

-- Borrowing_Records
CREATE TABLE T04 
(
    T04F01 INT PRIMARY KEY AUTO_INCREMENT, -- record_id
    T04F02 INT, -- 	book_id
    T04F03 INT, -- borrower_id
    T04F04 DATE NOT NULL, -- borrow_date
    T04F05 DATE NOT NULL, -- due_date
    T04F06 DATE, -- return date
    FOREIGN KEY (T04F02) REFERENCES T02(T02F01),
    FOREIGN KEY (T04F03) REFERENCES T03(T03F01)
);

INSERT INTO T01 (T01F02, T01F03) VALUES
('George', 'Orwell'),
('J.K.', 'Rowling'),
('Haruki', 'Murakami'),
('Gabriel', 'Garcia Marque'),
('Isaac', 'Asimov');

INSERT INTO T03 (T03F02, T03F03, T03F04, T03F05) VALUES
('John', 'Smith', 'john.smith@email.com', '2023-01-15'),
('Jane', 'Doe', 'jane.doe@email.com', '2023-03-22'),
('Peter', 'Jones', 'peter.jones@email.com', '2024-05-30'),
('Mary', 'Williams', 'mary.w@email.com', '2024-08-01');

INSERT INTO T02 (T02F02, T02F03, T02F04, T02F05, T02F06) VALUES
('1984', 1, 'Dystopian', 1949, '9780451524935'),
('Animal Farm', 1, 'Political Satire', 1945, '9780451526342'),
('Harry Potter and the Sorcerer''s Stone', 2, 'Fantasy', 1997, '9780590353427'),
('Norwegian Wood', 3, 'Fiction', 1987, '9780375704024'),
('Kafka on the Shore', 3, 'Magical Realism', 2002, '9781400079278'),
('One Hundred Years of Solitude', 4, 'Magical Realism', 1967, '9780060883287'),
('I, Robot', 5, 'Science Fiction', 1950, '9780553382563');

INSERT INTO T04 (T04F02, T04F03, T04F04, T04F05, T04F06) VALUES
(1, 1, '2025-07-01', '2025-07-15', '2025-07-14'),
(4, 2, '2025-08-15', '2025-08-29', '2025-08-28'),
(3, 1, '2025-08-10', '2025-08-24', NULL),
(7, 3, '2025-08-20', '2025-09-03', NULL),
(1, 2, '2025-08-25', '2025-09-08', NULL),
(6, 4, '2025-09-01', '2025-09-15', NULL);

-- Test truncate and transaction
START TRANSACTION;
TRUNCATE TABLE T04;
ROLLBACK;
SELECT * FROM T04;

-- List books which are currently borrowed and who has it and when its due date
SELECT
	T02F01,
    T02F02,
    T03F02,
    T03F03
FROM 
	T02
    INNER JOIN T04 ON T02F01 = T04F02 AND T04F06 IS NULL
    INNER JOIN T03 ON T04F03 = T03F01;
    
-- List author with more than one book in library
SELECT
	T01F01,
    T01F02,
    T01F03,
    COUNT(T02F03)
FROM 
	T01
    INNER JOIN T02 ON T01F01 = T02F03
GROUP BY
	T02F03
HAVING 
	COUNT(T02F03) > 1;
    
-- Identify Overdue Books and Borrower Contact Info 
SELECT
	T03F01,
    T03F02,
    T03F03,
    T03F04,
    T04F05
FROM 
	T03
    INNER JOIN T04 ON T03F01 = T04F03
WHERE	
	T04F06 IS NULL AND
	T04F05 < (CURRENT_DATE());
    
-- Find the Most Actively Borrowed Book
SELECT
	T02F01,
    T02F02,
    T02F06,
    COUNT(T02F04)
FROM 
	T02
    INNER JOIN T04 ON T02F01 = T04F02
GROUP BY
	T02F01,
    T02F02,
    T02F06,
	T02F04
ORDER BY
	COUNT(T02F04) DESC
LIMIT 1;

-- List All Books That Have Never Been Borrowed 
SELECT
	T02F01,
    T02F02
FROM 
	T02
    LEFT JOIN T04 ON T02F01 = T04F02
WHERE
	T04F02 IS NULL;
    
EXPLAIN SELECT
	T02F01,
    T02F02
FROM 
	T02
    LEFT JOIN T04 ON T02F01 = T04F02
WHERE
	T04F02 IS NULL;

-- Find Borrowers Who Read Across Multiple Genres
WITH BORROWERGENERECOUNT AS 
(
	SELECT
		T03F01,
        T03F02,
        T03F03,
        COUNT(DISTINCT T02F04) AS DISTINCT_GENERE
	FROM
		T03
        INNER JOIN T04 ON T03F01 = T04F03
        INNER JOIN T02 ON T02F01 = T04F02
	GROUP BY
		T03F01,
        T03F02,
        T03F03
)
SELECT
	T03F01,
    T03F02,
    T03F03,
    DISTINCT_GENERE
FROM 
	BORROWERGENERECOUNT
WHERE
	DISTINCT_GENERE > 1;


-- Transactions
START TRANSACTION;
DELETE FROM T04;
SELECT * FROM T04;
ROLLBACK;
SELECT * FROM T04;

-- Savepoints
START TRANSACTION;
DELETE FROM T04 WHERE T04F01 = 1;
SELECT * FROM T04;
SAVEPOINT 1_DELETED;
DELETE FROM T04;
SELECT * FROM T04;
ROLLBACK TO SAVEPOINT 1_DELETED;
COMMIT;
SELECT * FROM T04;

-- User creation
CREATE USER 'TEST'@'LOCALHOST' IDENTIFIED BY 'PASSWORD';
CREATE USER 'TEST1'@'LOCALHOST' IDENTIFIED BY 'PASSWORD';

-- User deletion
DROP USER 'TEST'@'LOCALHOST';
DROP USER 'TEST1'@'LOCALHOST';

-- View grants
SHOW GRANTS FOR 'TEST'@'LOCALHOST';
SHOW GRANTS FOR 'TEST1'@'LOCALHOST';

-- Grant and Revoke
GRANT SELECT ON LibraryDB.* TO 'TEST'@'LOCALHOST';
REVOKE SELECT ON LIBRARYDB.* FROM 'TEST'@'LOCALHOST';

GRANT ALL PRIVILEGES ON *.* TO 'TEST1'@'LOCALHOST' WITH GRANT OPTION;
GRANT SELECT ON LIBRARYDB.* TO 'TEST1'@'LOCALHOST' WITH GRANT OPTION;
REVOKE ALL PRIVILEGES, GRANT OPTION FROM 'TEST1'@'LOCALHOST';
FLUSH PRIVILEGES;

-- Enable and diable logs and view log file locations

-- error log
SHOW VARIABLES LIKE 'datadir';
SHOW VARIABLES LIKE 'log_error';

-- general log
SET GLOBAL general_log = 'ON';
SHOW VARIABLES LIKE 'general_log_file';

-- slow query log
SET GLOBAL slow_query_log = 'ON';
SET GLOBAL log_queries_not_using_indexes = 'ON';
SHOW VARIABLES LIKE 'slow_query_log_file';

-- binary log
SHOW VARIABLES LIKE 'log_bin';

-- Table locks
LOCK TABLE T01 WRITE;
LOCK TABLE T01 READ;
UNLOCK TABLE;





