-- select just the first name and last name of every actor
SELECT
	FIRST_NAME,
	LAST_NAME
FROM 
	ACTOR;

-- select the title and description of all films where the rating is 'PG-13'
SELECT
	TITLE,
	DESCRIPTION
FROM 
	FILM
WHERE
	RATING='PG-13';


-- SELECT MOVIE IN DECENDING ORDER OF LONGEST
SELECT
	TITLE,
	LENGTH
FROM
	FILM
WHERE
	RATING = 'PG-13'
ORDER BY
	LENGTH DESC;


-- COUNT FILM FOR EACH RATING
SELECT
	RATING,
	COUNT(FILM_ID)
FROM
	FILM
GROUP BY
	RATING;

-- Print city name with country
SELECT
	CITY,
	COUNTRY
FROM
	CITY
	INNER JOIN COUNTRY ON CITY.COUNTRY_ID = COUNTRY.COUNTRY_ID;

-- retrieves the first_name, last_name, and city for every customer
SELECT
	FIRST_NAME,
	LAST_NAME,
	CITY
FROM 
	CUSTOMER
	INNER JOIN ADDRESS ON CUSTOMER.ADDRESS_ID = ADDRESS.ADDRESS_ID
	INNER JOIN CITY ON ADDRESS.CITY_ID = CITY.CITY_ID;


-- select the title and length of all films where the length is greater than the average length of all films
SELECT
	TITLE,
	LENGTH
FROM
	FILM
WHERE
	LENGTH > (SELECT AVG(LENGTH) FROM FILM)
ORDER BY
	LENGTH DESC;


-- RANK FILM BY THEIR CATEGORY LENGTH
SELECT
	TITLE,
	RATING,
	LENGTH,
	RANK() OVER (PARTITION BY RATING ORDER BY LENGTH DESC) AS RANK_IN_CATEGORY
FROM 
	FILM;

-- RANK FILM BY THEIR CATEGORY LENGTH LIMIT EACH CATEGORY TO 5
WITH RANKED_FILM AS (
	SELECT
		TITLE,
		RATING,
		LENGTH,
		RANK() OVER (PARTITION BY RATING ORDER BY LENGTH DESC) AS RANK_IN_CATEGORY
	FROM 
		FILM
) 
SELECT 
	* 
FROM 
	RANKED_FILM
WHERE
	RANK_IN_CATEGORY <= 5;


-- Which 3 film categories have generated the highest total revenue?
SELECT
	CATEGORY.NAME,
	SUM(AMOUNT) AS TOTAL_REVENUE
FROM
	CATEGORY
	INNER JOIN FILM_CATEGORY ON CATEGORY.CATEGORY_ID = FILM_CATEGORY.CATEGORY_ID
	INNER JOIN FILM ON FILM.FILM_ID = FILM_CATEGORY.FILM_ID
	INNER JOIN INVENTORY ON INVENTORY.FILM_ID = FILM.FILM_ID
	INNER JOIN RENTAL ON RENTAL.INVENTORY_ID = INVENTORY.INVENTORY_ID
	INNER JOIN PAYMENT ON PAYMENT.RENTAL_ID = RENTAL.RENTAL_ID
GROUP BY
	CATEGORY.NAME
ORDER BY
	TOTAL_REVENUE DESC
LIMIT 3;


-- "Employee of the Month" was for every month available in the data.
WITH monthly_sales AS (
    SELECT
        TO_CHAR(payment.payment_date, 'YYYY-MM') AS payment_month,
        staff.first_name,
        staff.last_name,
        SUM(payment.amount) AS total_revenue,
        RANK() OVER (
            PARTITION BY TO_CHAR(payment.payment_date, 'YYYY-MM') 
            ORDER BY SUM(payment.amount) DESC
        ) AS revenue_rank
    FROM
        payment
    JOIN
        staff ON payment.staff_id = staff.staff_id
    GROUP BY
        TO_CHAR(payment.payment_date, 'YYYY-MM'), 
        staff.staff_id,
        staff.first_name, 
        staff.last_name
)
SELECT
    payment_month,
    first_name,
    last_name,
    total_revenue
FROM
    monthly_sales
WHERE
    revenue_rank = 1
ORDER BY
    payment_month;



