USE hospital_boca;

INSERT INTO EstadoCivil(nombreEstado) VALUES
('Soltero'),
('Casado'),
('Concubinato'),
('Divorciado'),
('Viudo'),
('Prefiero no responder');

INSERT INTO Escolaridad(nombreEscolaridad) VALUES
('Preescolar'),
('Primaria'),
('Secundaria'),
('Bachillerato'),
('Licenciatura'),
('Especialidad'),
('Maestría'),
('Doctorado'),
('Sin estudios'),
('Ninguno');

INSERT INTO Ocupacion(nombreOcupacion) VALUES
('Profesionista en el sector privado'),
('Profesionista en dependencia del gobierno'),
('Trabajador agrícola, ganadero, silvícola y de caza o pesca'),
('Vendedor ambulante'),
('Comerciante'),
('Artesano'),
('Trabajador en fábrica'),
('Servicio doméstico'),
('Miembro de las fuerzas armadas mexicanas'),
('Jubilado - Pensionado'),
('Otro');

INSERT INTO Religion(nombreReligion) VALUES
('Católico'),
('Evangélico'),
('Cristiano'),
('Protestante'),
('Judaísmo'),
('Islámico'),
('Budismo'),
('Hinduísmo'),
('Ateo'),
('Agnóstico'),
('Ninguno'),
('Otro'),
('Prefiero no responder');

INSERT INTO LugarReferencia(nombreLugar) VALUES
('Centro de salud'),
('Conocidos'),
('Familiares'),
('Medios digitales (sitios web, redes sociales)'),
('Medios de comunicación (televisión, radio)'),
('Por cuenta propia'),
('Ninguno');

INSERT INTO OpinionPareja(nombreOpinion) VALUES
('De acuerdo'),
('Es indiferente'),
('Desacuerdo');

INSERT INTO MetodoPlanificacion(nombreMetodo) VALUES
('Inyectables'),
('Píldoras anticonceptivas'),
('Implante subdérmico'),
('Condón masculino/femenino'),
('Dispositivo Intrauterino'),
('Parche'),
('Otro'),
('Ninguno');

INSERT INTO CalidadServicio(nombreCalidad) VALUES
('Excelente'),
('Bueno'),
('Regular'),
('Malo');

INSERT INTO CalidadRelacion(nombreCalidadRelacion) VALUES
('Igual'),
('Mejor'),
('Peor');