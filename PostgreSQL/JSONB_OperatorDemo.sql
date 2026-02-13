CREATE TABLE PRODUCTS (ID SERIAL PRIMARY KEY, DATA JSONB);

INSERT INTO
	PRODUCTS (DATA)
VALUES
	(
		'{
        "name": "iPhone 15 Pro",
        "category": "Electronics",
        "description": "The latest iPhone with advanced features.",
        "brand": "Apple",
        "price": 999.99,
        "attributes": {
            "color": "Graphite",
            "storage": "256GB",
            "display": "6.1-inch Super Retina XDR display",
            "processor": "A15 Bionic chip"
        },
        "tags": ["smartphone", "iOS", "Apple"]
    }'
	),
	(
		'{
        "name": "Samsung Galaxy Watch 4",
        "category": "Electronics",
        "description": "A smartwatch with health tracking and stylish design.",
        "brand": "Samsung",
        "price": 349.99,
        "attributes": {
            "color": "Black",
            "size": "42mm",
            "display": "AMOLED display",
            "sensors": ["heart rate monitor", "ECG", "SpO2"]
        },
        "tags": ["smartwatch", "wearable", "Samsung"]
    }'
	),
	(
		'{
        "name": "Leather Case for iPhone 15 Pro",
        "category": "Accessories",
        "description": "Premium leather case for iPhone 15 Pro.",
        "brand": "Apple",
        "price": 69.99,
        "attributes": {
            "color": "Saddle Brown",
            "material": "Genuine leather",
            "compatible_devices": ["iPhone 15 Pro", "iPhone 15 Pro Max"]
        },
        "tags": ["phone case", "accessory", "Apple"]
    }'
	),
	(
		'{
        "name": "Wireless Charging Pad",
        "category": "Accessories",
        "description": "Fast wireless charger compatible with smartphones and smartwatches.",
        "brand": "Anker",
        "price": 29.99,
        "attributes": {
            "color": "White",
            "compatible_devices": ["iPhone", "Samsung Galaxy", "Apple Watch", "Samsung Galaxy Watch"]
        },
        "tags": ["accessory", "wireless charger"]
    }'
	)
RETURNING
	*;

SELECT
	*
FROM
	PRODUCTS;

-- ->
SELECT
	DATA -> 'name' AS PRODUCT_NAME
FROM
	PRODUCTS;

-- ->>
SELECT
	DATA ->> 'name' AS PRODUCT_NAME
FROM
	PRODUCTS;

-- #>
SELECT
	DATA #> '{attributes, color}' AS ATTRIBUTES
FROM
	PRODUCTS;

-- @>
SELECT
	ID,
	DATA ->> 'name' PRODUCT_NAME
FROM
	PRODUCTS
WHERE
	DATA @> '{"category": "Electronics"}'::JSONB;

-- <@
SELECT
	DATA ->> 'name' NAME,
	DATA ->> 'price' PRICE
FROM
	PRODUCTS
WHERE
	'{"price": 999.99}'::JSONB <@ DATA;

-- ||
SELECT
	'{"name": "iPad"}'::JSONB || '{"price": 799}'::JSONB AS PRODUCT;

-- ?
SELECT
	ID,
	DATA ->> 'name' PRODUCT_NAME,
	DATA ->> 'price' PRICE
FROM
	PRODUCTS
WHERE
	DATA ? 'price';

-- ?|
SELECT
	DATA ->> 'name' PRODUCT_NAME,
	DATA ->> 'attributes' ATTRIBUTES
FROM
	PRODUCTS
WHERE
	DATA -> 'attributes' ?| ARRAY['storage', 'size'];

-- ?&
SELECT
	DATA ->> 'name' PRODUCT_NAME,
	DATA ->> 'attributes' ATTRIBUTES
FROM
	PRODUCTS
WHERE
	DATA -> 'attributes' ?& ARRAY['color', 'storage'];

-- -
SELECT
	'{"name": "John Doe", "age": 22}'::JSONB - 'name' RESULT;

SELECT
	'{"name": "John Doe", "age": 22, "email": "john.doe@example.com"}'::JSONB - ARRAY['age', 'email'] RESULT;

SELECT
	'["PostgreSQL", "API", "Web Dev"]'::JSONB - ARRAY['API', 'Web Dev'] RESULT;

-- @?
SELECT
	DATA ->> 'name' PRODUCT_NAME,
	DATA ->> 'price' PRICE
FROM
	PRODUCTS
WHERE
	DATA @? '$.price ? (@ > 999)';

-- @@
SELECT
	DATA ->> 'name' PRODUCT_NAME,
	DATA ->> 'price' PRICE
FROM
	PRODUCTS
WHERE
	DATA @@ '$.price > 999';

CREATE INDEX IDX_GIN_JSON_DATA ON PRODUCTS USING GIN (DATA);

SET
	ENABLE_SEQSCAN = OFF;