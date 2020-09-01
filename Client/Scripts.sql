CREATE TABLE viagem (
	id INT IDENTITY (1, 1) NOT NULL,
	descricao VARCHAR (50),
	data datetime,
	CONSTRAINT pk_viagem PRIMARY KEY (id)
);