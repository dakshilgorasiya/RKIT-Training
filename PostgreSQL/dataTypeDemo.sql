DROP TABLE IF EXISTS DEMO;

CREATE TABLE DEMO (
	-- Boolean
	COL_BOOLEAN BOOLEAN DEFAULT TRUE,
	-- Character types
	COL_CHAR CHAR(5) DEFAULT 'ABCDE',
	COL_VARCHAR VARCHAR(50) DEFAULT 'default text',
	COL_TEXT TEXT DEFAULT 'default long text',
	-- Numeric types
	COL_SMALLINT SMALLINT DEFAULT 1,
	COL_INTEGER INTEGER DEFAULT 10,
	COL_BIGINT BIGINT DEFAULT 1000,
	COL_NUMERIC NUMERIC(10, 2) DEFAULT 99.99,
	COL_REAL REAL DEFAULT 1.23,
	COL_DOUBLE DOUBLE PRECISION DEFAULT 123.456,
	-- Date & Time
	COL_DATE DATE DEFAULT CURRENT_DATE,
	COL_TIME TIME DEFAULT CURRENT_TIME,
	COL_TIMESTAMP TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	COL_TIMESTAMPTZ TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
	COL_INTERVAL INTERVAL DEFAULT INTERVAL '1 day',
	-- UUID
	COL_UUID UUID DEFAULT GEN_RANDOM_UUID(),
	-- JSON with default object
	COL_JSON JSON DEFAULT '{"status":"active","count":1,"tags":["demo","json"]}',
	-- JSONB with nested data
	COL_JSONB JSONB DEFAULT '{
           "user": {
             "id": 1,
             "name": "guest",
             "roles": ["reader"]
           },
           "settings": {
             "theme": "dark",
             "notifications": true
           }
        }',
	-- Array
	COL_INT_ARRAY INTEGER[] DEFAULT ARRAY[1, 2, 3],
	-- XML
	COL_XML XML DEFAULT '<root></root>',
	-- Binary data
	COL_BYTEA BYTEA DEFAULT '\xDEADBEEF'
);

INSERT INTO
	DEMO (COL_BOOLEAN)
VALUES
	(TRUE);

SELECT
	*
FROM
	DEMO;