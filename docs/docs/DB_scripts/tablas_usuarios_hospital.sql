CREATE DATABASE IF NOT EXISTS hospital_boca_usuarios;
USE hospital_boca_usuarios;

CREATE TABLE Usuarios(
	idUser int not null auto_increment,
	userName varchar(30),
	strpass varchar(64),
	roleId int not null,
	idDoc int,
	primary key (idUser)
);

CREATE TABLE TokensCerrados(
	idToken int not null auto_increment,
	strToken text not null,
	primary key (idToken)
);

CREATE TABLE roles(
	id int not null,
	descripcion TEXT not null,
	namerole varchar(20) not null,
	primary key(id)
);

INSERT INTO Usuarios(userName, strpass, roleId, idDoc) VALUES
('josevarela', 'sdlkhjF', 0, 1);

INSERT INTO roles(id, descripcion, namerole) VALUES
(0, "Acceso total", "Admin"),
(1, "Permite control sobre administración de doctores. No permite acciones activas", "Secretario"),
(2, "Acceso total", "Admin");