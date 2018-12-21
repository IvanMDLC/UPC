CREATE TABLE SOLICITUD(
COD_UNICO NUMBER(15) PRIMARY KEY,
COD_LINEA_NEGOCIO CHAR(1),
COD_MODAL_EST CHAR(2),
COD_PERIODO CHAR(6),
COD_TRAMITE NUMBER(5),
ESTADO VARCHAR2(2),
COD_ALUMNO CHAR(9)
);

CREATE TABLE DETALLE_SOLICITUD(
COD_DETALLE NUMBER(15),
COD_UNICO NUMBER(15),
COD_CURSO VARCHAR2(6),
COD_TIPO_PRUEBA CHAR(2),
NUM_PRUEBA NUMBER(5),
SECCION VARCHAR2(4),
GRUPO CHAR(2),
ESTADO_CURSO VARCHAR2(2),
CONSTRAINT FK_COD_UNICO FOREIGN KEY (COD_UNICO) REFERENCES SOLICITUD(COD_UNICO)
