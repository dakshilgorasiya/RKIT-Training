--
-- PostgreSQL database dump
--

\restrict B0inWiAhSEHh9YeFh1DiXUtrfGWeJTqP2hWypFPOheNFPoeWILdyUeuV9Qbn8Rb

-- Dumped from database version 18.1
-- Dumped by pg_dump version 18.1

-- Started on 2026-02-13 17:49:05

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
-- TOC entry 6 (class 2615 OID 16921)
-- Name: employee; Type: SCHEMA; Schema: -; Owner: trn
--

CREATE SCHEMA employee;


ALTER SCHEMA employee OWNER TO trn;

--
-- TOC entry 239 (class 1255 OID 17045)
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
-- TOC entry 241 (class 1255 OID 17070)
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
-- TOC entry 244 (class 1255 OID 17097)
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
-- TOC entry 240 (class 1255 OID 17056)
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
-- TOC entry 243 (class 1255 OID 17093)
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
-- TOC entry 242 (class 1255 OID 17072)
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
-- TOC entry 220 (class 1259 OID 16942)
-- Name: empt01; Type: TABLE; Schema: employee; Owner: trn
--

CREATE TABLE employee.empt01 (
    t01f01 integer NOT NULL,
    t01f02 character varying NOT NULL,
    t01f03 character varying(100)
);


ALTER TABLE employee.empt01 OWNER TO trn;

--
-- TOC entry 221 (class 1259 OID 16953)
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
-- TOC entry 222 (class 1259 OID 16974)
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
-- TOC entry 231 (class 1259 OID 17750)
-- Name: contacts; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.contacts (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    phones jsonb
);


ALTER TABLE public.contacts OWNER TO trn;

--
-- TOC entry 230 (class 1259 OID 17749)
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
-- TOC entry 5008 (class 0 OID 0)
-- Dependencies: 230
-- Name: contacts_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: trn
--

ALTER SEQUENCE public.contacts_id_seq OWNED BY public.contacts.id;


--
-- TOC entry 227 (class 1259 OID 17293)
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
-- TOC entry 237 (class 1259 OID 17858)
-- Name: dense_ranks; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.dense_ranks (
    c character varying(10)
);


ALTER TABLE public.dense_ranks OWNER TO trn;

--
-- TOC entry 226 (class 1259 OID 17215)
-- Name: departments; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.departments (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    manager character varying(255) NOT NULL
);


ALTER TABLE public.departments OWNER TO trn;

--
-- TOC entry 225 (class 1259 OID 17214)
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
-- TOC entry 5010 (class 0 OID 0)
-- Dependencies: 225
-- Name: departments_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: trn
--

ALTER SEQUENCE public.departments_id_seq OWNED BY public.departments.id;


--
-- TOC entry 223 (class 1259 OID 17001)
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
-- TOC entry 224 (class 1259 OID 17005)
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
-- TOC entry 229 (class 1259 OID 17726)
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
-- TOC entry 228 (class 1259 OID 17725)
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
-- TOC entry 5013 (class 0 OID 0)
-- Dependencies: 228
-- Name: posts_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: trn
--

ALTER SEQUENCE public.posts_id_seq OWNED BY public.posts.id;


--
-- TOC entry 233 (class 1259 OID 17818)
-- Name: product_groups; Type: TABLE; Schema: public; Owner: trn
--

CREATE TABLE public.product_groups (
    group_id integer NOT NULL,
    group_name character varying(255) NOT NULL
);


ALTER TABLE public.product_groups OWNER TO trn;

--
-- TOC entry 232 (class 1259 OID 17817)
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
-- TOC entry 5014 (class 0 OID 0)
-- Dependencies: 232
-- Name: product_groups_group_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: trn
--

ALTER SEQUENCE public.product_groups_group_id_seq OWNED BY public.product_groups.group_id;


--
-- TOC entry 235 (class 1259 OID 17827)
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
-- TOC entry 234 (class 1259 OID 17826)
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
-- TOC entry 5015 (class 0 OID 0)
-- Dependencies: 234
-- Name: products_product_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: trn
--

ALTER SEQUENCE public.products_product_id_seq OWNED BY public.products.product_id;


--
-- TOC entry 238 (class 1259 OID 17861)
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
-- TOC entry 236 (class 1259 OID 17849)
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
-- TOC entry 4812 (class 2604 OID 17753)
-- Name: contacts id; Type: DEFAULT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.contacts ALTER COLUMN id SET DEFAULT nextval('public.contacts_id_seq'::regclass);


--
-- TOC entry 4788 (class 2604 OID 17218)
-- Name: departments id; Type: DEFAULT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.departments ALTER COLUMN id SET DEFAULT nextval('public.departments_id_seq'::regclass);


--
-- TOC entry 4810 (class 2604 OID 17729)
-- Name: posts id; Type: DEFAULT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.posts ALTER COLUMN id SET DEFAULT nextval('public.posts_id_seq'::regclass);


--
-- TOC entry 4813 (class 2604 OID 17821)
-- Name: product_groups group_id; Type: DEFAULT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.product_groups ALTER COLUMN group_id SET DEFAULT nextval('public.product_groups_group_id_seq'::regclass);


--
-- TOC entry 4814 (class 2604 OID 17830)
-- Name: products product_id; Type: DEFAULT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.products ALTER COLUMN product_id SET DEFAULT nextval('public.products_product_id_seq'::regclass);


--
-- TOC entry 4820 (class 2606 OID 16950)
-- Name: empt01 empt01_pkey; Type: CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt01
    ADD CONSTRAINT empt01_pkey PRIMARY KEY (t01f01);


--
-- TOC entry 4822 (class 2606 OID 16952)
-- Name: empt01 empt01_t01f02_key; Type: CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt01
    ADD CONSTRAINT empt01_t01f02_key UNIQUE (t01f02);


--
-- TOC entry 4824 (class 2606 OID 16966)
-- Name: empt02 empt02_pkey; Type: CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt02
    ADD CONSTRAINT empt02_pkey PRIMARY KEY (t02f01);


--
-- TOC entry 4826 (class 2606 OID 16968)
-- Name: empt02 empt02_t02f04_key; Type: CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt02
    ADD CONSTRAINT empt02_t02f04_key UNIQUE (t02f04);


--
-- TOC entry 4828 (class 2606 OID 16998)
-- Name: empt02 t02f04_unique; Type: CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt02
    ADD CONSTRAINT t02f04_unique UNIQUE (t02f04);


--
-- TOC entry 4830 (class 2606 OID 17096)
-- Name: empt03 t03f01_pk; Type: CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt03
    ADD CONSTRAINT t03f01_pk PRIMARY KEY (t03f01, t03f04);


--
-- TOC entry 4839 (class 2606 OID 17759)
-- Name: contacts contacts_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.contacts
    ADD CONSTRAINT contacts_pkey PRIMARY KEY (id);


--
-- TOC entry 4832 (class 2606 OID 17227)
-- Name: departments departments_name_key; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.departments
    ADD CONSTRAINT departments_name_key UNIQUE (name);


--
-- TOC entry 4834 (class 2606 OID 17225)
-- Name: departments departments_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.departments
    ADD CONSTRAINT departments_pkey PRIMARY KEY (id);


--
-- TOC entry 4837 (class 2606 OID 17736)
-- Name: posts posts_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.posts
    ADD CONSTRAINT posts_pkey PRIMARY KEY (id);


--
-- TOC entry 4841 (class 2606 OID 17825)
-- Name: product_groups product_groups_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.product_groups
    ADD CONSTRAINT product_groups_pkey PRIMARY KEY (group_id);


--
-- TOC entry 4843 (class 2606 OID 17835)
-- Name: products products_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (product_id);


--
-- TOC entry 4847 (class 2606 OID 17869)
-- Name: sales sales_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.sales
    ADD CONSTRAINT sales_pkey PRIMARY KEY (year, group_id);


--
-- TOC entry 4845 (class 2606 OID 17857)
-- Name: sales_stats sales_stats_pkey; Type: CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.sales_stats
    ADD CONSTRAINT sales_stats_pkey PRIMARY KEY (name, year);


--
-- TOC entry 4835 (class 1259 OID 17737)
-- Name: body_search_fts; Type: INDEX; Schema: public; Owner: trn
--

CREATE INDEX body_search_fts ON public.posts USING gin (body_search);


--
-- TOC entry 4851 (class 2620 OID 17094)
-- Name: empt02 log_delete_employee; Type: TRIGGER; Schema: employee; Owner: trn
--

CREATE TRIGGER log_delete_employee BEFORE DELETE ON employee.empt02 FOR EACH ROW EXECUTE FUNCTION employee.log_delete_employee_function();


--
-- TOC entry 4848 (class 2606 OID 16969)
-- Name: empt02 empt02_t02f08_fkey; Type: FK CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt02
    ADD CONSTRAINT empt02_t02f08_fkey FOREIGN KEY (t02f08) REFERENCES employee.empt01(t01f01);


--
-- TOC entry 4849 (class 2606 OID 16992)
-- Name: empt02 fk_t02f08; Type: FK CONSTRAINT; Schema: employee; Owner: trn
--

ALTER TABLE ONLY employee.empt02
    ADD CONSTRAINT fk_t02f08 FOREIGN KEY (t02f08) REFERENCES employee.empt01(t01f01);


--
-- TOC entry 4850 (class 2606 OID 17836)
-- Name: products products_group_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: trn
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_group_id_fkey FOREIGN KEY (group_id) REFERENCES public.product_groups(group_id);


--
-- TOC entry 5002 (class 3256 OID 17239)
-- Name: departments department_managers; Type: POLICY; Schema: public; Owner: trn
--

CREATE POLICY department_managers ON public.departments TO managers USING (((manager)::text = CURRENT_USER));


--
-- TOC entry 5001 (class 0 OID 17215)
-- Dependencies: 226
-- Name: departments; Type: ROW SECURITY; Schema: public; Owner: trn
--

ALTER TABLE public.departments ENABLE ROW LEVEL SECURITY;

--
-- TOC entry 5009 (class 0 OID 0)
-- Dependencies: 226
-- Name: TABLE departments; Type: ACL; Schema: public; Owner: trn
--

GRANT SELECT ON TABLE public.departments TO managers;


--
-- TOC entry 5011 (class 0 OID 0)
-- Dependencies: 223
-- Name: TABLE emp_dept; Type: ACL; Schema: public; Owner: trn
--

GRANT SELECT ON TABLE public.emp_dept TO managers;


--
-- TOC entry 5012 (class 0 OID 0)
-- Dependencies: 224
-- Name: TABLE emp_name; Type: ACL; Schema: public; Owner: trn
--

GRANT SELECT ON TABLE public.emp_name TO managers;


-- Completed on 2026-02-13 17:49:10

--
-- PostgreSQL database dump complete
--

\unrestrict B0inWiAhSEHh9YeFh1DiXUtrfGWeJTqP2hWypFPOheNFPoeWILdyUeuV9Qbn8Rb

