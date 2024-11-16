-- Table: public.tb_produtos

-- DROP TABLE IF EXISTS public.tb_produtos;

CREATE TABLE IF NOT EXISTS public.tb_produtos
(
    prd_id integer NOT NULL DEFAULT nextval('tb_produtos_prd_id_seq'::regclass),
    prd_nome character varying(255) COLLATE pg_catalog."default" NOT NULL,
    prd_descricao text COLLATE pg_catalog."default",
    prd_preco_unitario numeric(10,2) NOT NULL,
    prd_quantidade_estoque integer NOT NULL,
    prd_codigo_barras text COLLATE pg_catalog."default",
    prd_data_cadastro date,
    CONSTRAINT tb_produtos_pkey PRIMARY KEY (prd_id),
    CONSTRAINT tb_produtos_prd_estoque_check CHECK (prd_quantidade_estoque >= 0)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.tb_produtos
    OWNER to postgres;
-- Index: idx_prd_nome

-- DROP INDEX IF EXISTS public.idx_prd_nome;

CREATE INDEX IF NOT EXISTS idx_prd_nome
    ON public.tb_produtos USING btree
    (prd_nome COLLATE pg_catalog."default" ASC NULLS LAST)
    TABLESPACE pg_default;