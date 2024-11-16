-- Table: public.tb_clientes

-- DROP TABLE IF EXISTS public.tb_clientes;

CREATE TABLE IF NOT EXISTS public.tb_clientes
(
    cl_id integer NOT NULL DEFAULT nextval('tb_clientes_cl_id_seq'::regclass),
    cl_nome character varying(255) COLLATE pg_catalog."default" NOT NULL,
    cl_rua character varying(255) COLLATE pg_catalog."default",
    cl_telefone character varying(20) COLLATE pg_catalog."default",
    cl_email character varying(255) COLLATE pg_catalog."default" NOT NULL,
    cl_data_cadastro date,
    cl_cep character varying COLLATE pg_catalog."default",
    cl_bairro character varying COLLATE pg_catalog."default",
    cl_cidade character varying COLLATE pg_catalog."default",
    cl_numero character varying COLLATE pg_catalog."default",
    cl_estado character varying COLLATE pg_catalog."default",
    CONSTRAINT tb_clientes_pkey PRIMARY KEY (cl_id),
    CONSTRAINT tb_clientes_cl_email_key UNIQUE (cl_email)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.tb_clientes
    OWNER to postgres;
-- Index: idx_cl_email

-- DROP INDEX IF EXISTS public.idx_cl_email;

CREATE INDEX IF NOT EXISTS idx_cl_email
    ON public.tb_clientes USING btree
    (cl_email COLLATE pg_catalog."default" ASC NULLS LAST)
    TABLESPACE pg_default;