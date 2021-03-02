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

CREATE VIEW IspisSvihRuta 
AS 
SELECT r.IDRute, m1.Naziv AS 'Polazište', m2.Naziv AS 'Odredište'
FROM Ruta r, Mjesto m1, mjesto m2 
WHERE r.Polazište = m1.PBR AND r.Odredište = m2.PBR;


CREATE VIEW IspisSvihVozača
AS
SELECT v.OIB, v.Ime, v.Prezime, v.BrMobitela, m.Naziv FROM Vozači v, Mjesto m WHERE v.PBR = m.PBR


CREATE PROCEDURE MjestaKrozKojaProlaziRuta(@RUTA CHAR(15))
AS
	SELECT IDRute, Naziv FROM Prolazi, Mjesto WHERE Prolazi.IDRute = @RUTA AND Prolazi.PBR = Mjesto.PBR
	

CREATE PROCEDURE VozačiZaZaduženoVozilo(@REGISTRACIJA CHAR(15))
AS
SELECT vozač.OIB, vozač.Ime, vozač.Prezime AS 'Vozač', 
vozilo.Registracija AS 'Zaduženo vozilo'
FROM Vozači vozač, Vozi vozilo WHERE vozilo.OIB = vozač.OIB AND vozilo.Registracija = @REGISTRACIJA


CREATE PROCEDURE VozilaZaduženaVozaču(@OIB CHAR(13))
AS
SELECT vozač.OIB, vozač.Ime, vozač.Prezime AS 'Vozač', 
autobus.Registracija, autobus.SerijskiBroj, autobus.Marka, autobus.Model, autobus.BrojSjedala AS 'Vozilo'
FROM Vozači vozač, Vozi vozilo, Autobusi autobus WHERE vozač.OIB = @OIB AND vozilo.OIB = @OIB AND vozilo.Registracija = autobus.Registracija


CREATE PROCEDURE AutobusiSaMougćihXSjedala(@BROJ_SJEDALA INT)
AS
	SELECT A.Registracija, A.SerijskiBroj, A.Marka, A.Model, A.BrojSjedala
	FROM Autobusi A
	WHERE A.BrojSjedala >= @BROJ_SJEDALA
	
	
CREATE PROCEDURE AutobusiKojiVozeNaRuti(@ID_RUTE CHAR(15))
AS
	SELECT v.IDRute, A.Registracija, A.Marka, A.Model FROM Autobusi A, VoziNA v WHERE v.IDRute = @ID_RUTE AND v.Registracija = A.Registracija
	
	
CREATE PROCEDURE ProvjeriKartu(@BROJ_KARTE CHAR(15))
AS
	DECLARE @DATUM_ISTEKA DATETIME
	SET @DATUM_ISTEKA = (SELECT Karta.IstekKarte FROM Karta WHERE Karta.BrojKarte = @BROJ_KARTE)
	IF (@DATUM_ISTEKA < GETDATE())
		PRINT 'Karta je istekla na datum: ' + convert(varchar, @DATUM_ISTEKA, 1)
	ELSE 
		PRINT 'Karta vrijedi do: ' + convert(varchar, getdate(), 1)
	
	
CREATE FUNCTION CijenaProdanihKarataZaDan(@DATUM_KUPNJE DATETIME)
RETURNS DECIMAL(5,2)
AS
	BEGIN
	DECLARE @SUM_CIJENA DECIMAL(5,2)
	SET @SUM_CIJENA = SELECT SUM(K.Cijena)
	FROM Karta K
	WHERE K.VrijemeKupnje = @DATUM_KUPNJE
	RETURN @SUM_CIJENA
END


CREATE FUNCTION DohvatiPutovanje(@ID_PUTOVANJA CHAR(15))
RETURNS VARCHAR(60)
AS
BEGIN
	DECLARE @TEMP VARCHAR(60)
	SET @TEMP = (SELECT m1.Naziv + m2.Naziv FROM Putovanje, NaRuti, Ruta, Mjesto m1, Mjesto m2
	WHERE Putovanje.IDPutovanja = @ID_PUTOVANJA AND NaRuti.IDPutovanja = @ID_PUTOVANJA AND NaRuti.IDRute = Ruta.IDRute
	AND Ruta.Polazište = m1.PBR AND Ruta.Odredište = m2.PBR)
	RETURN @TEMP
END