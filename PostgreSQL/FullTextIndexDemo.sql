SELECT
	TO_TSVECTOR('watches'),
	TO_TSVECTOR('watched'),
	TO_TSVECTOR('watching');

SELECT
	TO_TSVECTOR('The quick brown fox jumps over the lazy dog.');

SELECT
	TO_TSQUERY('jumping | quickly');

SELECT
	TO_TSVECTOR('The quick brown fox jumps over the lazy dog.') @@ TO_TSQUERY('jumping');

CREATE TABLE POSTS (
	ID SERIAL PRIMARY KEY,
	TITLE TEXT NOT NULL,
	BODY TEXT,
	BODY_SEARCH TSVECTOR GENERATED ALWAYS AS (TO_TSVECTOR('english', BODY)) STORED
);

CREATE INDEX BODY_SEARCH_FTS ON POSTS USING GIN (BODY_SEARCH);

INSERT INTO
	POSTS (TITLE, BODY)
VALUES
	(
		'Introduction to PostgreSQL',
		'This is an introductory post about PostgreSQL. It covers basic concepts and features.'
	),
	(
		'Advanced PostgresSQL Techniques',
		'In this post, we delve into advanced PostgreSQL techniques for efficient querying and data manipulation.'
	),
	(
		'PostgreSQL Optimization Strategies',
		'This post explores various strategies for optimizing PostgreSQL database performance and efficiency.'
	);

SET
	ENABLE_SEQSCAN = ON;

SELECT
	*
FROM
	POSTS;

-- Post containing postgresql
SELECT
	ID,
	BODY
FROM
	POSTS
WHERE
	BODY_SEARCH @@ TO_TSQUERY('PostgreSQL');

-- Post containing postgresql and techniques
SELECT
	ID,
	BODY
FROM
	POSTS
WHERE
	BODY_SEARCH @@ TO_TSQUERY('PostgreSQL & techniques');

-- Post containing efficient or optimization
SELECT
	ID,
	BODY
FROM
	POSTS
WHERE
	BODY_SEARCH @@ TO_TSQUERY('efficient | optimization');

-- Post containing phrase 'PostgreSQL technique'
SELECT
	ID,
	BODY
FROM
	POSTS
WHERE
	BODY_SEARCH @@ TO_TSQUERY('''PostgreSQL technique''');