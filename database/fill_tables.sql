USE hgbr;

INSERT INTO sexo(nombre)
VALUES
('M'),
('F');

INSERT INTO estado_conyugal(nombre)
VALUES
('Soltero (a)'),
('Casado (a)'),
('Concubinato'),
('Divorciado (a)'),
('Viudo (a)'),
('Prefiero no responder');

INSERT INTO tipo_vialidad(nombre)
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

INSERT INTO tipo_asentamiento(nombre)
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


INSERT INTO pacientes(folio, nombre, primer_apellido, segundo_apellido, curp, fecha_nacimiento, entidad_nacimiento, edad, nacido_hospital, fk_sexo, peso, talla, fk_estado_conyugal, insabi, gratuitidad, indigena, lengua_indigena, cual_lengua, fk_tipo_vialidad, nombre_vialidad, num_ext, num_int, fk_tipo_asentamiento, nombre_asentamiento, cp, localidad, municipio_deleg, entidad_federativa, pais, telefono) VALUES
('ABCDEFGH', 'Josue', 'Tellez', 'Huerta', 'TEHJ000624HOCLRSA6', '2000-06-24', 'Oaxaca', 22, true, 1, 74, 174, 1, true, true, false, false, 'Ninguno', 1, 'Aeropuerto', 2, 133, 4, 'Boulevard', 94295, 'Boca del Rio', 'Boca del Rio', 'Veracruz', 'Mexico', '2741019045');