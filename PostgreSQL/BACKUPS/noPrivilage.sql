--
-- PostgreSQL database dump
--

\restrict YTJbbbMBXJXbg0n5NexAdmz0lILweRQRsf38zf6eBvG9913SDfhhlboi8bRCG7E

-- Dumped from database version 18.1
-- Dumped by pg_dump version 18.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: employee; Type: SCHEMA; Schema: -; Owner: trn
--

CREATE SCHEMA employee;


ALTER SCHEMA employee OWNER TO trn;

--
-- Name: calculate_age(date); Type: FUNCTION; Schema: employee; Owner: trn
--

CREATE FUNCTION employee.calculate_age(p_birth_date date) RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
	v_age INT;
BEGIN
    v_age = EXTRACT(YEAR FROM AGE(CURRENT_DATE, p_birth_date));
    RETURN v_age;
END;
$$;


ALTER FUNCTION employee.calculate_age(p_birth_date date) OWNER TO trn;

--
-- Name: count_employee(character varying); Type: PROCEDURE; Schema: employee; Owner: trn
--

CREATE PROCEDURE employee.count_employee(IN p_dept_name character varying, OUT p_count integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
	SELECT
		COUNT(T02F08)
	INTO
		P_COUNT
	FROM 
		EMPLOYEE.EMPT02
        INNER JOIN EMPLOYEE.EMPT01 ON T02F08 = T01F01
	WHERE
		T01F02 = p_dept_name;
END$$;


ALTER PROCEDURE employee.count_employee(IN p_dept_name character varying, OUT p_count integer) OWNER TO trn;

--
-- Name: fetch_employee(); Type: PROCEDURE; Schema: employee; Owner: trn
--

CREATE PROCEDURE employee.fetch_employee(OUT p_employee text)
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_name TEXT;
    cur_employee CURSOR FOR
        SELECT T02F02 || T02F03
        FROM employee.empt02;
BEGIN
    p_employee := '';

    OPEN cur_employee;

    LOOP
        FETCH cur_employee INTO v_name;
        EXIT WHEN NOT FOUND;

        IF p_employee = '' THEN
            p_employee := v_name;
        ELSE
            p_employee := p_employee || ', ' || v_name;
        END IF;
    END LOOP;

    CLOSE cur_employee;
END;
$$;


ALTER PROCEDURE employee.fetch_employee(OUT p_employee text) OWNER TO trn;

--
-- Name: get_employee_by_department(character varying); Type: FUNCTION; Schema: employee; Owner: trn
--

CREATE FUNCTION employee.get_employee_by_department(p_dept_name character varying) RETURNS TABLE(t02f01 integer, t02f02 character varying, t02f03 character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        e.T02F01,
        e.T02F02,
        e.T02F03
    FROM employee.empt02 e
    JOIN employee.empt01 d ON e.T02F08 = d.T01F01
    WHERE d.T01F02 = p_dept_name;
END;
$$;


ALTER FUNCTION employee.get_employee_by_department(p_dept_name character varying) OWNER TO trn;

--
-- Name: log_delete_employee_function(); Type: FUNCTION; Schema: employee; Owner: trn
--

CREATE FUNCTION employee.log_delete_employee_function() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
	INSERT INTO EMPLOYEE.EMPT03 (T03F01, T03F02, T03F03, T03F04) VALUES
    (OLD.T02F01, OLD.T02F02, OLD.T02F03, CURRENT_DATE);

	RETURN OLD;
END
$$;


ALTER FUNCTION employee.log_delete_employee_function() OWNER TO trn;

--
-- Name: double_number(integer); Type: PROCEDURE; Schema: public; Owner: trn
--

CREATE PROCEDURE public.double_number(INOUT p_num integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    p_num = p_num * 2;
END$$;


ALTER PROCEDURE public.double_number(INOUT p_num integer) OWNER TO trn;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: empt01; Type: TABLE; Schema: employee; Owner: trn
--

CREATE TABLE employee.empt01 (
    t01f01 integer NOT NULL,
    t01f02 character varying NOT NULL,
    t01f03 character varying(100)
);


ALTER TABLE employee.empt01 OWNER TO trn;

--
-- Name: empt02; Type: TABLE; Schema: employee; Owner: trn
--

CREATE TABLE employee.empt02 (
    t02f01 integer NOT NULL,
    t02f02 character varying NOT NULL,
    t02f03 character varying NOT NULL,
    t02f04 character varying NOT NULL,
    t02f05 date NOT NULL,
    t02f06 character varying NOT NULL,
    t02f07 numeric(10,2) NOT NULL,
    t02f08 integer,
    CONSTRAINT t02f07_check CHECK ((t02f07 > (0)::numeric))
);


ALTER TABLE employee.empt02 OWNER TO trn;

--
-- Name: empt03; Type: TABLE; Schema: employee; Owner: trn
--

CREATE TABLE employee.empt03 (
    t03f01 integer NOT NULL,
    t03f02 character varying NOT NULL,
    t03f03 character varying NOT NULL,
    t03f04 date NOT NULL
);


ALTER TABLE employee.empt03 OWNER TO trn;

--
-- Name: contacts; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.contacts (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    phones jsonb
);


ALTER TABLE public.contacts OWNER TO trn;

--
-- Name: contacts_id_seq; Type: SEQUENCE; Schema: public; Owner: trn
--

CREATE SEQUENCE public.contacts_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.contacts_id_seq OWNER TO trn;

--
-- Name: contacts_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: trn
--

ALTER SEQUENCE public.contacts_id_seq OWNED BY public.contacts.id;


--
-- Name: demo; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.demo (
    col_boolean boolean DEFAULT true,
    col_char character(5) DEFAULT 'ABCDE'::bpchar,
    col_varchar character varying(50) DEFAULT 'default text'::character varying,
    col_text text DEFAULT 'default long text'::text,
    col_smallint smallint DEFAULT 1,
    col_integer integer DEFAULT 10,
    col_bigint bigint DEFAULT 1000,
    col_numeric numeric(10,2) DEFAULT 99.99,
    col_real real DEFAULT 1.23,
    col_double double precision DEFAULT 123.456,
    col_date date DEFAULT CURRENT_DATE,
    col_time time without time zone DEFAULT CURRENT_TIME,
    col_timestamp timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    col_timestamptz timestamp with time zone DEFAULT CURRENT_TIMESTAMP,
    col_interval interval DEFAULT '1 day'::interval,
    col_uuid uuid DEFAULT gen_random_uuid(),
    col_json json DEFAULT '{"status":"active","count":1,"tags":["demo","json"]}'::json,
    col_jsonb jsonb DEFAULT '{"user": {"id": 1, "name": "guest", "roles": ["reader"]}, "settings": {"theme": "dark", "notifications": true}}'::jsonb,
    col_int_array integer[] DEFAULT ARRAY[1, 2, 3],
    col_xml xml DEFAULT '<root></root>'::xml,
    col_bytea bytea DEFAULT '\xdeadbeef'::bytea
);


ALTER TABLE public.demo OWNER TO trn;

--
-- Name: dense_ranks; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.dense_ranks (
    c character varying(10)
);


ALTER TABLE public.dense_ranks OWNER TO trn;

--
-- Name: departments; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.departments (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    manager character varying(255) NOT NULL
);


ALTER TABLE public.departments OWNER TO trn;

--
-- Name: departments_id_seq; Type: SEQUENCE; Schema: public; Owner: trn
--

CREATE SEQUENCE public.departments_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.departments_id_seq OWNER TO trn;

--
-- Name: departments_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: trn
--

ALTER SEQUENCE public.departments_id_seq OWNED BY public.departments.id;


--
-- Name: emp_dept; Type: VIEW; Schema: public; Owner: trn
--

CREATE VIEW public.emp_dept AS
 SELECT empt02.t02f01,
    empt02.t02f02,
    empt02.t02f03,
    empt01.t01f02
   FROM (employee.empt01
     JOIN employee.empt02 ON ((empt01.t01f01 = empt02.t02f08)));


ALTER VIEW public.emp_dept OWNER TO trn;

--
-- Name: emp_name; Type: VIEW; Schema: public; Owner: trn
--

CREATE VIEW public.emp_name AS
 SELECT t02f01,
    t02f02,
    t02f03
   FROM employee.empt02
  WITH CASCADED CHECK OPTION;


ALTER VIEW public.emp_name OWNER TO trn;

--
-- Name: posts; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.posts (
    id integer NOT NULL,
    title text NOT NULL,
    body text,
    body_search tsvector GENERATED ALWAYS AS (to_tsvector('english'::regconfig, body)) STORED
);


ALTER TABLE public.posts OWNER TO trn;

--
-- Name: posts_id_seq; Type: SEQUENCE; Schema: public; Owner: trn
--

CREATE SEQUENCE public.posts_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.posts_id_seq OWNER TO trn;

--
-- Name: posts_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: trn
--

ALTER SEQUENCE public.posts_id_seq OWNED BY public.posts.id;


--
-- Name: product_groups; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.product_groups (
    group_id integer NOT NULL,
    group_name character varying(255) NOT NULL
);


ALTER TABLE public.product_groups OWNER TO trn;

--
-- Name: product_groups_group_id_seq; Type: SEQUENCE; Schema: public; Owner: trn
--

CREATE SEQUENCE public.product_groups_group_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.product_groups_group_id_seq OWNER TO trn;

--
-- Name: product_groups_group_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: trn
--

ALTER SEQUENCE public.product_groups_group_id_seq OWNED BY public.product_groups.group_id;


--
-- Name: products; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.products (
    product_id integer NOT NULL,
    product_name character varying(255) NOT NULL,
    price numeric(11,2),
    group_id integer NOT NULL
);


ALTER TABLE public.products OWNER TO trn;

--
-- Name: products_product_id_seq; Type: SEQUENCE; Schema: public; Owner: trn
--

CREATE SEQUENCE public.products_product_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.products_product_id_seq OWNER TO trn;

--
-- Name: products_product_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: trn
--

ALTER SEQUENCE public.products_product_id_seq OWNED BY public.products.product_id;


--
-- Name: sales; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.sales (
    year smallint NOT NULL,
    group_id integer NOT NULL,
    amount numeric(10,2) NOT NULL,
    CONSTRAINT sales_year_check CHECK ((year > 0))
);


ALTER TABLE public.sales OWNER TO trn;

--
-- Name: sales_stats; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.sales_stats (
    name character varying(100) NOT NULL,
    year smallint NOT NULL,
    amount numeric(10,2),
    CONSTRAINT sales_stats_amount_check CHECK ((amount >= (0)::numeric)),
    CONSTRAINT sales_stats_year_check CHECK ((year > 0))
);


ALTER TABLE public.sales_stats OWNER TO trn;

--
-- Name: contacts id; Type: DEFAULT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.contacts ALTER COLUMN id SET DEFAULT nextval('public.contacts_id_seq'::regclass);


--
-- Name: departments id; Type: DEFAULT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.departments ALTER COLUMN id SET DEFAULT nextval('public.departments_id_seq'::regclass);


--
-- Name: posts id; Type: DEFAULT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.posts ALTER COLUMN id SET DEFAULT nextval('public.posts_id_seq'::regclass);


--
-- Name: product_groups group_id; Type: DEFAULT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.product_groups ALTER COLUMN group_id SET DEFAULT nextval('public.product_groups_group_id_seq'::regclass);


--
-- Name: products product_id; Type: DEFAULT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.products ALTER COLUMN product_id SET DEFAULT nextval('public.products_product_id_seq'::regclass);


--
-- Data for Name: empt01; Type: TABLE DATA; Schema: employee; Owner: trn
--

COPY employee.empt01 (t01f01, t01f02, t01f03) FROM stdin;
2	Sales	Mumbai
3	Human Resources	Rajkot
4	Marketing	Delhi
5	Finance	Mumbai
1	IT	Anand
\.


--
-- Data for Name: empt02; Type: TABLE DATA; Schema: employee; Owner: trn
--

COPY employee.empt02 (t02f01, t02f02, t02f03, t02f04, t02f05, t02f06, t02f07, t02f08) FROM stdin;
101	Rohan	Sharma	rohan.sharma@example.com	2021-08-15	Software Engineer	80000.00	1
102	Priya	Patel	priya.patel@example.com	2020-03-10	Senior Software Engineer	120000.00	1
103	Amit	Singh	amit.singh@example.com	2022-01-20	Database Administrator	95000.00	1
106	Sunita	Jain	sunita.jain@example.com	2021-05-25	HR Manager	90000.00	3
107	Deepak	Kumar	deepak.kumar@example.com	2024-02-01	HR Assistant	50000.00	3
111	Rajesh	Nair	rajesh.nair@example.com	2025-01-15	Junior Engineer	60000.00	1
112	Kavita	Iyer	kavita.iyer@example.com	2024-08-01	Consultant	150000.00	\N
104	Anjali	Mehta	anjali.mehta@example.com	2019-11-05	Sales Manager	121000.00	2
105	Vikram	Rao	vikram.rao@example.com	2023-07-12	Sales Representative	82500.00	2
110	Pooja	Mishra	pooja.mishra@example.com	2023-10-09	Sales Representative	79200.00	2
108	Neha	Gupta	neha.gupta@example.com	2022-09-30	Marketing Specialist	85000.00	5
\.


--
-- Data for Name: empt03; Type: TABLE DATA; Schema: employee; Owner: trn
--

COPY employee.empt03 (t03f01, t03f02, t03f03, t03f04) FROM stdin;
201	Arjun	Reddy	2023-12-31
202	Meera	Desai	2024-06-30
\.


--
-- Data for Name: contacts; Type: TABLE DATA; Schema: public; Owner: trn
--

COPY public.contacts (id, name, phones) FROM stdin;
1	John Doe	["408-111-2222", "408-111-2223"]
2	Jane Doe	["212-111-2222", "212-111-2223"]
\.


--
-- Data for Name: demo; Type: TABLE DATA; Schema: public; Owner: trn
--

COPY public.demo (col_boolean, col_char, col_varchar, col_text, col_smallint, col_integer, col_bigint, col_numeric, col_real, col_double, col_date, col_time, col_timestamp, col_timestamptz, col_interval, col_uuid, col_json, col_jsonb, col_int_array, col_xml, col_bytea) FROM stdin;
t	ABCDE	default text	default long text	1	10	1000	99.99	1.23	123.456	2026-02-09	18:21:57.365372	2026-02-09 18:21:57.365372	2026-02-09 18:21:57.365372+05:30	1 day	34622281-0341-42b1-a110-420820b3096e	{"status":"active","count":1,"tags":["demo","json"]}	{"user": {"id": 1, "name": "guest", "roles": ["reader"]}, "settings": {"theme": "dark", "notifications": true}}	{1,2,3}	<root></root>	\\xdeadbeef
\.


--
-- Data for Name: dense_ranks; Type: TABLE DATA; Schema: public; Owner: trn
--

COPY public.dense_ranks (c) FROM stdin;
A
A
B
C
C
D
E
\.


--
-- Data for Name: departments; Type: TABLE DATA; Schema: public; Owner: trn
--

COPY public.departments (id, name, manager) FROM stdin;
4	Sales	a
5	Marketing	b
6	IT	c
\.


--
-- Data for Name: posts; Type: TABLE DATA; Schema: public; Owner: trn
--

COPY public.posts (id, title, body) FROM stdin;
1	Introduction to PostgreSQL	This is an introductory post about PostgreSQL. It covers basic concepts and features.
2	Advanced PostgresSQL Techniques	In this post, we delve into advanced PostgreSQL techniques for efficient querying and data manipulation.
3	PostgreSQL Optimization Strategies	This post explores various strategies for optimizing PostgreSQL database performance and efficiency.
\.


--
-- Data for Name: product_groups; Type: TABLE DATA; Schema: public; Owner: trn
--

COPY public.product_groups (group_id, group_name) FROM stdin;
1	Smartphone
2	Laptop
3	Tablet
\.


--
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: trn
--

COPY public.products (product_id, product_name, price, group_id) FROM stdin;
1	Microsoft Lumia	200.00	1
2	HTC One	400.00	1
3	Nexus	500.00	1
4	iPhone	900.00	1
5	HP Elite	1200.00	2
6	Lenovo Thinkpad	700.00	2
7	Sony VAIO	700.00	2
8	Dell Vostro	800.00	2
9	iPad	700.00	3
10	Kindle Fire	150.00	3
11	Samsung Galaxy Tab	200.00	3
\.


--
-- Data for Name: sales; Type: TABLE DATA; Schema: public; Owner: trn
--

COPY public.sales (year, group_id, amount) FROM stdin;
2018	1	1474.00
2018	2	1787.00
2018	3	1760.00
2019	1	1915.00
2019	2	1911.00
2019	3	1118.00
2020	1	1646.00
2020	2	1975.00
2020	3	1516.00
\.


--
-- Data for Name: sales_stats; Type: TABLE DATA; Schema: public; Owner: trn
--

COPY public.sales_stats (name, year, amount) FROM stdin;
John Doe	2018	120000.00
Jane Doe	2018	110000.00
Jack Daniel	2018	150000.00
Yin Yang	2018	30000.00
Stephane Heady	2018	200000.00
John Doe	2019	150000.00
Jane Doe	2019	130000.00
Jack Daniel	2019	180000.00
Yin Yang	2019	25000.00
Stephane Heady	2019	270000.00
\.


--
-- Name: contacts_id_seq; Type: SEQUENCE SET; Schema: public; Owner: trn
--

SELECT pg_catalog.setval('public.contacts_id_seq', 2, true);


--
-- Name: departments_id_seq; Type: SEQUENCE SET; Schema: public; Owner: trn
--

SELECT pg_catalog.setval('public.departments_id_seq', 6, true);


--
-- Name: posts_id_seq; Type: SEQUENCE SET; Schema: public; Owner: trn
--

SELECT pg_catalog.setval('public.posts_id_seq', 3, true);


--
-- Name: product_groups_group_id_seq; Type: SEQUENCE SET; Schema: public; Owner: trn
--

SELECT pg_catalog.setval('public.product_groups_group_id_seq', 3, true);


--
-- Name: products_product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: trn
--

SELECT pg_catalog.setval('public.products_product_id_seq', 11, true);


--
-- Name: empt01 empt01_pkey; Type: CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt01
    ADD CONSTRAINT empt01_pkey PRIMARY KEY (t01f01);


--
-- Name: empt01 empt01_t01f02_key; Type: CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt01
    ADD CONSTRAINT empt01_t01f02_key UNIQUE (t01f02);


--
-- Name: empt02 empt02_pkey; Type: CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt02
    ADD CONSTRAINT empt02_pkey PRIMARY KEY (t02f01);


--
-- Name: empt02 empt02_t02f04_key; Type: CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt02
    ADD CONSTRAINT empt02_t02f04_key UNIQUE (t02f04);


--
-- Name: empt02 t02f04_unique; Type: CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt02
    ADD CONSTRAINT t02f04_unique UNIQUE (t02f04);


--
-- Name: empt03 t03f01_pk; Type: CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt03
    ADD CONSTRAINT t03f01_pk PRIMARY KEY (t03f01, t03f04);


--
-- Name: contacts contacts_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.contacts
    ADD CONSTRAINT contacts_pkey PRIMARY KEY (id);


--
-- Name: departments departments_name_key; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.departments
    ADD CONSTRAINT departments_name_key UNIQUE (name);


--
-- Name: departments departments_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.departments
    ADD CONSTRAINT departments_pkey PRIMARY KEY (id);


--
-- Name: posts posts_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.posts
    ADD CONSTRAINT posts_pkey PRIMARY KEY (id);


--
-- Name: product_groups product_groups_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.product_groups
    ADD CONSTRAINT product_groups_pkey PRIMARY KEY (group_id);


--
-- Name: products products_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (product_id);


--
-- Name: sales sales_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.sales
    ADD CONSTRAINT sales_pkey PRIMARY KEY (year, group_id);


--
-- Name: sales_stats sales_stats_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.sales_stats
    ADD CONSTRAINT sales_stats_pkey PRIMARY KEY (name, year);


--
-- Name: body_search_fts; Type: INDEX; Schema: public; Owner: trn
--

CREATE INDEX body_search_fts ON public.posts USING gin (body_search);


--
-- Name: empt02 log_delete_employee; Type: TRIGGER; Schema: employee; Owner: trn
--

CREATE TRIGGER log_delete_employee BEFORE DELETE ON employee.empt02 FOR EACH ROW EXECUTE FUNCTION employee.log_delete_employee_function();


--
-- Name: empt02 empt02_t02f08_fkey; Type: FK CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt02
    ADD CONSTRAINT empt02_t02f08_fkey FOREIGN KEY (t02f08) REFERENCES employee.empt01(t01f01);


--
-- Name: empt02 fk_t02f08; Type: FK CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt02
    ADD CONSTRAINT fk_t02f08 FOREIGN KEY (t02f08) REFERENCES employee.empt01(t01f01);


--
-- Name: products products_group_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_group_id_fkey FOREIGN KEY (group_id) REFERENCES public.product_groups(group_id);


--
-- Name: departments department_managers; Type: POLICY; Schema: public; Owner: trn
--

CREATE POLICY department_managers ON public.departments TO managers USING (((manager)::text = CURRENT_USER));


--
-- Name: departments; Type: ROW SECURITY; Schema: public; Owner: trn
--

ALTER TABLE public.departments ENABLE ROW LEVEL SECURITY;

--
-- PostgreSQL database dump complete
--

\unrestrict YTJbbbMBXJXbg0n5NexAdmz0lILweRQRsf38zf6eBvG9913SDfhhlboi8bRCG7E

