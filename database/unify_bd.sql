USE hospital_boca;

-- CATALOGOS
CREATE TABLE sexo(
	id INTEGER AUTO_INCREMENT,
    nombre VARCHAR(1),
    PRIMARY KEY(id)
);

CREATE TABLE tipovialidad(
	id INTEGER AUTO_INCREMENT,
    nombre VARCHAR(25),
    PRIMARY KEY(id)
);

CREATE TABLE tipoasentamiento(
	id INTEGER AUTO_INCREMENT,
    nombre VARCHAR(25),
    PRIMARY KEY(id)
);

CREATE TABLE estados(
	id INTEGER AUTO_INCREMENT,
    nombre VARCHAR(60),
    PRIMARY KEY(id)
);

-- TABLAS

CREATE TABLE pacientesArch(
	noExpediente VARCHAR(13),
    nombre VARCHAR(80),
    apPaterno VARCHAR(50),
    apMaterno VARCHAR(50),
    curp VARCHAR(18),
    fechaNac DATE,
    horaNac TIME,
    entidadNac VARCHAR(30),
    edadYears INTEGER,
    edadMonths INTEGER,
    edadDays INTEGER,
    edadHours INTEGER,
    nacidoHospital BOOLEAN,
    fkSexo INTEGER, -- llave foranea
    peso FLOAT,
    talla INTEGER,
    fkEstadoCivil INTEGER, -- llave foranea
    insabi BOOLEAN,
    gratuitidad BOOLEAN,
    indigena BOOLEAN,
    lenguaIndigena BOOLEAN,
    cualLengua VARCHAR(30),
    fkTipoCalleCasa INTEGER, -- llave foranea
    calleCasa VARCHAR(30),
    numCasa VARCHAR(10),
    numCasaInt VARCHAR(10),
    fkTipoColCasa INTEGER, -- llave foranea
    colCasa VARCHAR(50),
    cp BIGINT,
    localidad VARCHAR(50),
    municipio VARCHAR(50),
    entidadFederativa VARCHAR(50),
    pais VARCHAR(50),
    telCasa BIGINT,
    PRIMARY KEY(noExpediente),
    FOREIGN KEY(fkSexo) REFERENCES sexo(id),
    FOREIGN KEY(fkEstadoCivil) REFERENCES estadocivil(idEstadoCivil),
    FOREIGN KEY(fkTipoCalleCasa) REFERENCES tipovialidad(id),
    FOREIGN KEY(fkTipoColCasa) REFERENCES tipoasentamiento(id)
);

-- LLENADO

INSERT INTO sexo(nombre)
VALUES
('M'),
('F');

INSERT INTO tipovialidad(nombre)
VALUES
('Aeropuerto'),
('Ampliacion'),
('Barrio'),
('Canton'),
('Ciudad'),
('Ciudad industrial'),
('Colonia'),
('Condominio'),
('Conjunto habitacional'),
('Corredor industrial'),
('Coto'),
('Cuartel'),
('Ejido'),
('Exhacienda'),
('Fraccion'),
('Fraccionamiento'),
('Granja'),
('Hacienda'),
('Ingenio'),
('Manzana'),
('Paraje'),
('Parque industrial'),
('Privada'),
('Prolongacion'),
('Pueblo'),
('Puerto'),
('Rancheria'),
('Rancho'),
('Region'),
('Residencial'),
('Rinconada'),
('Seccion'),
('Sector'),
('Supermanzana'),
('Unidad'),
('Unidad habitacional'),
('Villa'),
('Zona federal'),
('Zona industrial'),
('Zona militar'),
('Ninguno'),
('Zona naval');

INSERT INTO tipoasentamiento(nombre)
VALUES
('Ampliacion'),
('Andador'),
('Avenida'),
('Boulevard'),
('Calle'),
('Callejon'),
('Calzada'),
('Cerrada'),
('Circuito'),
('Circunvalacion'),
('Continuacion'),
('Corredor'),
('Diagonal'),
('Eje vial'),
('Pasaje'),
('Peatonal'),
('Periferico'),
('Privada'),
('Prolongacion'),
('Retorno'),
('Viaducto'),
('Ninguno'),
('Carretera'),
('Camino'),
('Terraceria'),
('Brecha'),
('Vereda');

INSERT INTO estados(nombre)
VALUES
('Aguascalientes'),
('Baja California'),
('Baja California Sur'),
('Campeche'),
('Chiapas'),
('Chihuahua'),
('Ciudad de México'),
('Coahuila'),
('Colima'),
('Durango'),
('Estado de México'),
('Guanajuato'),
('Guerrero'),
('Hidalgo'),
('Jalisco'),
('Michoacán'),
('Morelos'),
('Nayarit'),
('Nuevo León'),
('Oaxaca'),
('Puebla'),
('Querétaro'),
('Quintana Roo'),
('San Luis Potosí'),
('Sinaloa'),
('Sonora'),
('Tabasco'),
('Tamaulipas'),
('Tlaxcala'),
('Veracruz'),
('Yucatán'),
('Zacatecas');