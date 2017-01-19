/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: rapport
------------------------------------------------------------*/
CREATE TABLE rapport(
	id       INT IDENTITY (1,1) NOT NULL ,
	dateTime DATETIME  ,
	CONSTRAINT prk_constraint_rapport PRIMARY KEY NONCLUSTERED (id)
);


/*------------------------------------------------------------
-- Table: data
------------------------------------------------------------*/
CREATE TABLE data(
	id            INT IDENTITY (1,1) NOT NULL ,
	offset        INT   ,
	pressure      INT   ,
	layout        INT   ,
	result        bit   ,
	lot           INT   ,
	timecode      INT   ,
	id_rapport    INT   ,
	id_couleur    INT   ,
	id_etat       INT   ,
	id_composant INT   ,
	id_etat_1     INT   ,
	CONSTRAINT prk_constraint_data PRIMARY KEY NONCLUSTERED (id)
);


/*------------------------------------------------------------
-- Table: couleur
------------------------------------------------------------*/
CREATE TABLE couleur(
	id      INT IDENTITY (1,1) NOT NULL ,
	libelle VARCHAR (50)  ,
	CONSTRAINT prk_constraint_couleur PRIMARY KEY NONCLUSTERED (id)
);


/*------------------------------------------------------------
-- Table: etat
------------------------------------------------------------*/
CREATE TABLE etat(
	id      INT IDENTITY (1,1) NOT NULL ,
	libelle VARCHAR (50)  ,
	CONSTRAINT prk_constraint_etat PRIMARY KEY NONCLUSTERED (id)
);


/*------------------------------------------------------------
-- Table: composant
------------------------------------------------------------*/
CREATE TABLE composant(
	id      INT IDENTITY (1,1) NOT NULL ,
	libelle VARCHAR (50)  ,
	CONSTRAINT prk_constraint_coomposant PRIMARY KEY NONCLUSTERED (id)
);



ALTER TABLE data ADD CONSTRAINT FK_data_id_rapport FOREIGN KEY (id_rapport) REFERENCES rapport(id);
ALTER TABLE data ADD CONSTRAINT FK_data_id_couleur FOREIGN KEY (id_couleur) REFERENCES couleur(id);
ALTER TABLE data ADD CONSTRAINT FK_data_id_etat FOREIGN KEY (id_etat) REFERENCES etat(id);
ALTER TABLE data ADD CONSTRAINT FK_data_id_composant FOREIGN KEY (id_composant) REFERENCES composant(id);
ALTER TABLE data ADD CONSTRAINT FK_data_id_etat_1 FOREIGN KEY (id_etat_1) REFERENCES etat(id);
