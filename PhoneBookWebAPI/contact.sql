-- Table: public.contact

-- DROP TABLE IF EXISTS public.contact;

CREATE TABLE IF NOT EXISTS public.contact
(
    id integer,
    firstname character varying(30) COLLATE pg_catalog."default",
    lastname character varying(30) COLLATE pg_catalog."default",
    gender character varying(30) COLLATE pg_catalog."default",
    dob character varying(30) COLLATE pg_catalog."default",
    email character varying(30) COLLATE pg_catalog."default",
    phone character varying(30) COLLATE pg_catalog."default",
    city character varying(30) COLLATE pg_catalog."default",
    state character varying(30) COLLATE pg_catalog."default",
    country character varying(30) COLLATE pg_catalog."default",
    picture bytea
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.contact
    OWNER to postgres;