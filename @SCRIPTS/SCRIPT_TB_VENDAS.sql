-- Table: public.tb_vendas

-- DROP TABLE IF EXISTS public.tb_vendas;

CREATE TABLE IF NOT EXISTS public.tb_vendas
(
    ven_id integer NOT NULL DEFAULT nextval('tb_vendas_ven_id_seq'::regclass),
    ven_data date DEFAULT CURRENT_TIMESTAMP,
    ven_fk_id_cliente integer NOT NULL,
    ven_valor_total numeric(10,2) NOT NULL,
    ven_fk_id_produto integer NOT NULL,
    ven_quantidade integer NOT NULL,
    ven_preco_unitario numeric(10,2) NOT NULL,
    CONSTRAINT tb_vendas_pkey PRIMARY KEY (ven_id),
    CONSTRAINT tb_vendas_ven_fk_id_cliente_fkey FOREIGN KEY (ven_fk_id_cliente)
        REFERENCES public.tb_clientes (cl_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT tb_vendas_ven_fk_id_produto_fkey FOREIGN KEY (ven_fk_id_produto)
        REFERENCES public.tb_produtos (prd_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.tb_vendas
    OWNER to postgres;