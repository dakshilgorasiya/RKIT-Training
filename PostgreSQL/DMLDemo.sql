-- INSERT DATA
-- DEPARTMRNT DATA
INSERT INTO
	EMPLOYEE.EMPT01 (T01F01, T01F02, T01F03)
VALUES
	(1, 'Engineering', 'Bengaluru'),
	(2, 'Sales', 'Mumbai'),
	(3, 'Human Resources', 'Rajkot'),
	(4, 'Marketing', 'Delhi'),
	(5, 'Finance', 'Mumbai')
RETURNING
	*;

-- EMPLOYEE DATA
INSERT INTO
	EMPLOYEE.EMPT02 (
		T02F01,
		T02F02,
		T02F03,
		T02F04,
		T02F05,
		T02F06,
		T02F07,
		T02F08
	)
VALUES
	(
		101,
		'Rohan',
		'Sharma',
		'rohan.sharma@example.com',
		'2021-08-15',
		'Software Engineer',
		80000.00,
		1
	),
	(
		102,
		'Priya',
		'Patel',
		'priya.patel@example.com',
		'2020-03-10',
		'Senior Software Engineer',
		120000.00,
		1
	),
	(
		103,
		'Amit',
		'Singh',
		'amit.singh@example.com',
		'2022-01-20',
		'Database Administrator',
		95000.00,
		1
	),
	(
		104,
		'Anjali',
		'Mehta',
		'anjali.mehta@example.com',
		'2019-11-05',
		'Sales Manager',
		110000.00,
		2
	),
	(
		105,
		'Vikram',
		'Rao',
		'vikram.rao@example.com',
		'2023-07-12',
		'Sales Representative',
		75000.00,
		2
	),
	(
		106,
		'Sunita',
		'Jain',
		'sunita.jain@example.com',
		'2021-05-25',
		'HR Manager',
		90000.00,
		3
	),
	(
		107,
		'Deepak',
		'Kumar',
		'deepak.kumar@example.com',
		'2024-02-01',
		'HR Assistant',
		50000.00,
		3
	),
	(
		108,
		'Neha',
		'Gupta',
		'neha.gupta@example.com',
		'2022-09-30',
		'Marketing Specialist',
		85000.00,
		4
	),
	(
		109,
		'Sanjay',
		'Verma',
		'sanjay.verma@example.com',
		'2020-06-18',
		'Accountant',
		70000.00,
		5
	),
	(
		110,
		'Pooja',
		'Mishra',
		'pooja.mishra@example.com',
		'2023-10-09',
		'Sales Representative',
		72000.00,
		2
	),
	(
		111,
		'Rajesh',
		'Nair',
		'rajesh.nair@example.com',
		'2025-01-15',
		'Junior Engineer',
		60000.00,
		1
	),
	(
		112,
		'Kavita',
		'Iyer',
		'kavita.iyer@example.com',
		'2024-08-01',
		'Consultant',
		150000.00,
		NULL
	)
RETURNING
	*;

-- EX_EMPLOYEE DATA
INSERT INTO
	EMPLOYEE.EMPT03 (T03F01, T03F02, T03F03, T03F04)
VALUES
	(201, 'Arjun', 'Reddy', '2023-12-31'),
	(202, 'Meera', 'Desai', '2024-06-30')
RETURNING
	*;

-- UPDATE QUERY
-- To change employee department from marketing to sales
UPDATE EMPLOYEE.EMPT02
SET
	T02F08 = 5
WHERE
	T02F01 = 108;

-- To give increment of 10% salary to employee working in Sales department
UPDATE EMPLOYEE.EMPT02
SET
	T02F07 = T02F07 * 1.1
WHERE
	T02F08 = 2;

-- DELETE QUERY
-- To delete employee with ID 109
DELETE FROM EMPLOYEE.EMPT02
WHERE
	T02F01 = 109;
