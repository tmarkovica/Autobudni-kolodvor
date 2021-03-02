<Query Kind="SQL">
  <Connection>
    <ID>7ef1addc-135f-4454-a349-450f7020ad49</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>tempdb</Database>
  </Connection>
</Query>

CREATE TABLE Karta (
	BrojKarte CHAR(15),
	VrijemeKupnje DATETIME,
	IstekKarte DATETIME,
	Cijena DECIMAL(5,2),
	IDPutovanja CHAR(15),
	CONSTRAINT pk_BrojKarte PRIMARY KEY (BrojKarte)
);

CREATE TABLE Putovanje (
	IDPutovanja CHAR(15),
	StanicaPolazišta CHAR(30),
	StanicaOdredišta CHAR(30),
	IDRute CHAR(15),
	CONSTRAINT pk_IDPutovanja PRIMARY KEY(IDPutovanja)
);

CREATE TABLE Ruta (
	IDRute CHAR(15),
	Polazište CHAR(30),
	Odredište CHAR(30),
	CONSTRAINT pk_IDRute PRIMARY KEY (IDRute)
);

CREATE TABLE NaRuti (
	IDPutovanja CHAR(15),
	IDRute CHAR(15),
	CONSTRAINT pk_NaRuti PRIMARY KEY(IDPutovanja,IDRute),
	CONSTRAINT fk_Ruta_IDPutovanja FOREIGN KEY (IDPutovanja) REFERENCES Putovanje(IDPutovanja),
	CONSTRAINT fk_Ruta_IDRute FOREIGN KEY (IDRute) REFERENCES Ruta(IDRute),
);

CREATE TABLE Autobusi (
	Registracija CHAR(15),
	SerijskiBroj CHAR(15),
	Marka CHAR(30),
	Model CHAR(30),
	BrojSjedala INT,
	CONSTRAINT pk_Registracija PRIMARY KEY (Registracija)
);

CREATE TABLE Vozači (
	OIB CHAR(13),
	Ime CHAR(30),
	Prezime CHAR(30),
	BrMobitela CHAR(15),
	PBR CHAR(6),
	CONSTRAINT pk_OIB PRIMARY KEY (OIB)
);

CREATE TABLE Mjesto (
	PBR CHAR(6),
	Naziv CHAR(30),
	CONSTRAINT pk_PBR PRIMARY KEY (PBR)
);

CREATE TABLE Prolazi (
	IDRute CHAR(15),
	PBR CHAR(6),
	CONSTRAINT pk_Prolazi PRIMARY KEY (IDRute,PBR),
	CONSTRAINT fk_Prolazi_IDRute FOREIGN KEY (IDRute) REFERENCES Ruta(IDRute),
	CONSTRAINT fk_PBR FOREIGN KEY (PBR) REFERENCES Mjesto(PBR)
);

CREATE TABLE VoziNa (
	IDRute CHAR(15),
	Registracija CHAR(15),
	CONSTRAINT pk_VoziNa PRIMARY KEY (IDRute,Registracija),
	CONSTRAINT fk_VoziNa_IDRute FOREIGN KEY (IDRute) REFERENCES Ruta(IDRute),
	CONSTRAINT fk_VoziNa_Registracija FOREIGN KEY (Registracija) REFERENCES Autobusi(Registracija)
);

CREATE TABLE Vozi (
	OIB CHAR(13),
	Registracija CHAR(15),
	CONSTRAINT pk_Vozi PRIMARY KEY (OIB,Registracija),
	CONSTRAINT fk_OIB FOREIGN KEY (OIB) REFERENCES Vozači(OIB),
	CONSTRAINT fk_Vozi_Registracija FOREIGN KEY (Registracija) REFERENCES Autobusi(Registracija)
);

Drop table Mjesto
Drop table Karta
Drop table Autobusi
Drop table Putovanje
Drop table Ruta
Drop table Vozači
Drop table NaRuti
Drop table Prolazi
Drop table VoziNa
Drop table Vozi