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