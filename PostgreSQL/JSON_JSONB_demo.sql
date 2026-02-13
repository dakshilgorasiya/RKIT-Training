CREATE TABLE PRODUCTS (
	ID SERIAL PRIMARY KEY,
	NAME VARCHAR(255) NOT NULL,
	PROPERTIES JSONB
);

INSERT INTO
	PRODUCTS (NAME, PROPERTIES)
VALUES
	(
		'Ink Fusion T-Shirt',
		'{"color": "white", "size": ["S","M","L","XL"]}'
	)
RETURNING
	*;

INSERT INTO
	PRODUCTS (NAME, PROPERTIES)
VALUES
	(
		'ThreadVerse T-Shirt',
		'{"color": "black", "size": ["S","M","L","XL"]}'
	),
	(
		'Design Dynamo T-Shirt',
		'{"color": "blue", "size": ["S","M","L","XL"]}'
	)
RETURNING
	*;

SELECT
	*
FROM
	PRODUCTS;

SELECT
	ID,
	NAME,
	PROPERTIES -> 'color'
FROM
	PRODUCTS;

SELECT
	ID,
	NAME,
	PROPERTIES ->> 'color'
FROM
	PRODUCTS
WHERE
	PROPERTIES ->> 'color' IN ('black', 'white');

CREATE TABLE CONTACTS (
	ID SERIAL PRIMARY KEY,
	NAME VARCHAR(255) NOT NULL,
	PHONES JSONB
);

INSERT INTO
	CONTACTS (NAME, PHONES)
VALUES
	('John Doe', '["408-111-2222", "408-111-2223"]'),
	('Jane Doe', '["212-111-2222", "212-111-2223"]')
RETURNING
	*;

-- If index out of bound null will come
SELECT
	NAME,
	PHONES ->> 1 "work phone"
FROM
	CONTACTS;