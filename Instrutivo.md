1. crear la tabla product con el siguiente script:
CREATE TABLE IF NOT EXISTS public.product
(
    idproduct integer NOT NULL DEFAULT nextval('product_idproduct_seq'::regclass),
    name character varying(255) COLLATE pg_catalog."default",
    cantidad integer,
    CONSTRAINT product_pkey PRIMARY KEY (idproduct)
)
2. cambiar la cadena de coneccion en el archivo PruebaCCL\Infrastructure\DependencyInjection
3. ejecutar el la solucion PruebaCCL\WebApplicationApiBackend\WebApplicationApiBackend.sln
4.Estando en la carpeta PruebaCCL\FrontCCL ejecutar el comando npm start
5.Para hacer el login nombre del usurio por defecto es "Danie"l clave "123"