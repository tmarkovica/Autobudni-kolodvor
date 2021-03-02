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

INSERT INTO Mjesto VALUES
('5000', 'RI'),
('10000', 'ZG'),
('20000', 'NA'),
('30000', 'OS');

SELECT * FROM Mjesto;

INSERT INTO Ruta VALUES
('1', '10000', '5000'),
('2', '10000', '30000'),
('3', '5000', '30000'),
('4', '20000', '30000');

SELECT * FROM Ruta;

INSERT INTO Prolazi VALUES
('1','5000'),
('1', '10000'),
('2', '10000'),
('2', '20000'),
('2', '30000'),
('3', '5000'),
('3', '10000'),
('3', '20000'),
('3', '30000'),
('4', '20000'),
('4', '30000');

SELECT * FROM Prolazi;

INSERT INTO Vozači VALUES
('111', 'Vozac1', 'Prezime1', '091', '30000'),
('222', 'Vozac2', 'Prezime2', '092', '10000'),
('333', 'Vozac3', 'Prezime3', '093', '5000');

DELETE FROM Vozači
SELECT * FROM Vozači;

INSERT INTO Autobusi VALUES
('ZG1', '10001', 'MAN', 'R54', 45),
('ZG2', '10002', 'MAN', 'R55', 42),
('ZG3', '10003', 'MAN', 'R56', 40);
DELETE FROM Autobusi
SELECT * FROM Autobusi;


INSERT INTO Vozi VALUES
('111', 'ZG1'),
('222', 'ZG2'),
('333', 'ZG2');
DELETE FROM Vozi
SELECT * FROM Vozi;

/* gore is good*/


INSERT INTO Karta VALUES
('00001', '2020/01/20', '2020/01/21', 15, '1'),
('00002', '2020/01/20', '2020/01/21', 5, '2'),
('00003', '2020/01/20', '2020/01/21', 10, '3'),
('00004', '2020/01/21', '2020/01/22', 20, '4');

SELECT *FROM Karta

INSERT INTO VoziNa VALUES
('1', 'ZG1'),
('2', 'ZG1'),
('3', 'ZG2'),
('4', 'ZG3'),
('1', 'ZG3'),
('2', 'ZG3'),
('3', 'ZG1');

DELETE FROM VoziNa

SELECT * FROM VoziNa





