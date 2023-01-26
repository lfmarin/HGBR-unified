USE hospital_boca;

INSERT INTO Pacientes (noExpediente, nombre, apPaterno, apMaterno, fechaNac, fkEstadoCivil, ivs, fkEscolaridad, fkOcupacion, fkReligion, fkLugarReferencia,
numHijosVivos, edadHijoMenor, nombreEsposa, aosRelac, calleCasa, numCasa, colCasa, telCasa, calleTrabajo, numTrabajo, colTrabajo, telTrabajo) VALUES
('1111111111', 'Alan de Jesús', 'Campos', 'Acevedo', '1953-01-26', 2, 17, 4, 1, 3, 4, 3, 3, 'Rosalva Luna Pérez', 18, 'Calle uno', 36, 'Colonia Uno', '1232223434', 'Calle Diez', 10, 'Colonia 10', '1234561111'),
('3492487548', 'Esteban', 'López', 'Castillo', '1975-09-24', 2, 14, 4, 1, 3, 4, 3, 3, 'María López Ortiz', 18, 'Calle dos', 36, 'Colonia dos', '1232223434', 'Calle Once', 10, 'Colonia 11', '1234561111'),
('1354395739', 'Carlos', 'Hernández', 'Sosa', '1976-06-28', 2, 22, 5, 1, 3, 3, 3, 3, 'Karla Jiménez Herrera', 18, 'Calle tres', 36, 'Colonia tres', '1232223434', 'Calle Doce', 10, 'Colonia 12', '1234561111'),
('9685840434', 'Saul', 'Herrera', 'Guzmán', '1972-04-27', 3, 23, 5, 1, 3, 2, 2, 3, 'Paula Soto Cano', 18, 'Calle cuatro', 36, 'Colonia cuatro', '1232223434', 'Calle Trece', 10, 'Colonia 13', '1234561111'),
('2945894183', 'Agustin', 'Sánchez', 'Cruz', '1960-06-15', 2, 16, 4, 1, 3, 3, 2, 3, 'Paulina Macías Luna', 18, 'Calle cinco', 36, 'Colonia cinco', '1232223434', 'Calle Catorce', 10, 'Colonia 14', '1234561111'),
('7943823893', 'Juan', 'Martínez', 'López', '1978-05-11', 3, 16, 5, 1, 3, 4, 3, 3, 'Rosa Hernández Sevilla', 18, 'Calle seis', 36, 'Colonia seis', '1232223434', 'Calle Quince', 10, 'Colonia 15', '1234561111'),
('8549332302', 'Gilberto', 'Pérez', 'Rodríguez', '1979-08-13', 4, 17, 7, 1, 3, 4, 2, 3, 'María del Carmen Juárez Ochoa', 18, 'Calle siete', 36, 'Colonia siete', '1232223434', 'Calle Dieciseis', 10, 'Colonia 16', '1234561111'),
('7283914990', 'Manuel', 'Jiménez', 'Barradas', '1971-03-07', 6, 16, 6, 1, 3, 4, 1, 3, 'Valeria Mijangos Musule', 18, 'Calle ocho', 36, 'Colonia ocho', '1232223434', 'Calle Diecisiete', 10, 'Colonia 17', '1234561111'),
('6854930392', 'Armando', 'Ortiz', 'Mejía', '1969-11-01', 6, 18, 2, 1, 3, 4, 3, 1, 'Katia Ortiz Mena', 18, 'Calle nueve', 36, 'Colonia nueve', '1232223434', 'Calle Dieciocho', 10, 'Colonia 19', '1234561111'),
('2139292203', 'Ernesto', 'Chávez', 'Barrios', '1965-10-05', 2, 18, 4, 1, 3, 4, 3, 3, 'Montserrat Nieves de la Cruz', 18, 'Calle diez', 36, 'Colonia diez', '1232223434', 'Calle Diecinueve', 10, 'Colonia 19', '1234561111');

INSERT INTO Hospitales(entidadFederativa, jurSanitaria, uMedica) VALUES 
('Veracruz', 'VIII', 'Hospital General de Boca del Río'),
('Veracruz', 'VIII', 'Hospital General de Veracruz'),
('Veracruz', 'VII', 'Centro de Salud de Boca del Río'),
('Veracruz', 'V', 'Hospital de Alta Especialidad'),
('Veracruz', 'VIII', 'Centro de Salud de Veracruz'),
('Veracruz', 'VII', 'Centro de Salud de Medellín');

INSERT INTO Doctores(nombre, apPaterno, apMaterno) VALUES
('Cristina', 'Cuellar', 'Méndez'),
('Mario', 'Valladares', 'Espinoza'),
('Antonio', 'Ochoa', 'Lara'),
('María de Jesús', 'Vargas', 'Flores'),
('Karla Ivette', 'Mariscal', 'Gómez'),
('José Eduardo', 'Aguirre', 'Hernández'),
('José Daniel', 'Pérez', 'Trujillo'),
('Elvira', 'Cortés', 'Palacios'),
('Darla Elizabeth', 'Castro', 'Castillejos');

INSERT INTO PersonalConsejeria(nombre, apPaterno, apMaterno) VALUES
('Trinidad', 'Cruz', 'Gómez'),
('Melissa', 'Antonio', 'Romero'),
('Inés', 'Roque', 'Cruz'),
('Alessandra', 'Aguilar', 'Gómez'),
('Gilberto', 'Solano', 'López'),
('Luis Antonio', 'Márquez', 'Vázquez'),
('Carlos', 'Zamudio', 'González'),
('David', 'Amador', 'Zamora');

INSERT INTO HistoriaClinica(fkPaciente, fkHospital, fechaElab) VALUES
('3492487548', 1,'2022-03-11'),
('1354395739', 1,'2022-03-11'),
('9685840434', 2,'2022-03-12'),
('2945894183', 1,'2022-03-12'),
('7943823893', 1,'2022-03-12'),
('8549332302', 1,'2022-03-12'),
('7283914990', 3,'2022-03-13'),
('6854930392', 1,'2022-03-14'),
('2139292203', 1,'2022-03-15'),
('3492487548', 2,'2022-03-15');

INSERT INTO MotivoSolicitud(fkHistoria, causaNoHijos, fkOpinion, fkMetodoPlanificacion) VALUES
(1, 'Familia completa', 1, 4),
(2, 'No desea tener hijos', 1, 4),
(3, 'Familia completa', 1, 4),
(4, 'No desea tener hijos', 1, 8),
(5, 'No desea tener hijos', 2, 8);

INSERT INTO HistoriaExploracion(fkHistoria, antFamiliares, antPersonalesNoPat, antPersonalesPat, ta, peso, talla, fc, fr, tem, expOrganos, tipoPaciente) VALUES
(1, 'Negados', 'Buena alimentacion', 'Alergicos negados', '', '80', '1.75', '', '', '36.5', 'Normal', 'Sano'),
(2, 'Negados', 'Buena higiene', 'Cirugia apendicitis', '', '90', '1.90', '', '', '36.5', 'Normal', 'Sano'),
(3, 'Negados', 'Actividad fisica regular', 'Alergicos negados', '', '80', '1.75', '', '', '36.5', 'Normal', 'Sano'),
(4, 'Negados', 'Buena alimentacion', 'Infección urinaria reciente', '', '90', '1.80', '', '', '36.5', 'Normal', 'Sano'),
(5, 'Negados', 'Actividad física regular', 'Alérgicos negados', '', '70', '1.70', '', '', '36.5', 'Normal', 'Sano');

INSERT INTO ProcQuirurgico(fkHistoria, fechaCirugia, fkDoctor, notaQuirurgica, patologia) VALUES
(1, '2022-04-21', 1, 'q', 'y'),
(2, '2022-04-21', 2, 'w', 'u'),
(3, '2022-04-22', 3, 'e', 'i'),
(4, '2022-04-23', 2, 'r', 'o'),
(5, '2022-04-24', 2, 't', 'p');

INSERT INTO EstudioAnatomo(fkHistoria, fechaEnvio, clave, resultado) VALUES
(1, '2022-04-20', 'i', 'Sin resultados'),
(2, '2022-04-20', 'k', 'Sin resultados'),
(3, '2022-04-21', 'm', 'Sin resultados'),
(4, '2022-04-22', 'm', 'Sin resultados'),
(5, '2022-04-23', 'i', 'Sin resultados');

INSERT INTO Evolucion(fkHistoria, complicaciones, espermaconteo) VALUES
(1, 'Ninguna', 0),
(2, 'Ninguna', 0),
(3, 'Ninguna', 0),
(4, 'Ninguna', 0),
(5, 'Ninguna', 0);

INSERT INTO FichaIdentificacion(fkPaciente, servicio, diagnostico) VALUES
('3492487548', 'x','y'),
('1354395739', 'x','y'),
('9685840434', 'x','y'),
('2945894183', 'x','y'),
('7943823893', 'x','y');

INSERT INTO NotaMedica(fkFicha, fechaHora, signosVitales, diagnosticoPre, cirugiaProgramada, fechaCirugia, tipoAnestesia,preparacion, fkDoctor, diagnosticoPost, complicaciones, descripcion) VALUES
(1, '2022-04-24 10:36:52', 'x', 'Usuario sano con paternidad satisfecha', 'Vasectomía sin bisturí', '2022-04-26', 'Local', 'Sin ayuno', 1, 'Usuario vasectomizado', 'Ninguna', 'Previa asepsia y antisepsia de la región escrotal y colocacion de campos estériles, se procede a realizar un botón dérmico con lidocaína simple...');

INSERT INTO CartaConsentimiento(fkFicha, fkHospital, fechaHora, fkConsejeria, testigo1, testigo2, fkDoctor) VALUES
(1, 1, '2022-04-24 10:36:52', 1, 'Karla López Ortiz', 'José Manuel Palacios Gómez', 2),
(2, 1, '2022-04-24 11:48:52', 1, 'Testigo 2', 'Testigo 3', 3),
(3, 1, '2022-04-24 12:00:30', 1, 'Testigo 4', 'Testigo 5', 2);

INSERT INTO InstruccionesPost(fkFicha, fkDoctor, fkHospital) VALUES
(1, 2, 1),
(2, 3, 1),
(3, 3, 2),
(4, 2, 1);

INSERT INTO EncuestaSeguimiento(fkPaciente, fkHospital, fechaEncuesta, fechaVasectomia,
origenInfo, fkConsejeria, referido, fkHospitalReferencia, fkCalidad, satisfaccion,
motivoSatisfaccion, complicacion, motivoComplicacion, fkCalidadRelacion, motivoCalidad,
fechaNegativo, LugarEspermaconteo, recomendacion, motivoRecomendacion, LugarVasectomia,
motivoLugar, recomendacionHospital, cualRecomendacion) VALUES
('3492487548', 1, '2022-04-24', '2022-03-21', 'Centro de salud', 1, 1, 1, 3, 1, "Gran servicio", 0, '', 2, "Gran servicio", '2022-05-26', "Centro de salud", 0, '', 1, "Proceso más rápido", 1, ''),
('1354395739', 1, '2022-04-26', '2022-03-22', 'Hospital', 1, 0, 1, 3, 1, "Buena calidad", 0, '', 2, "Buena calidad", '2022-05-27', "Centro de salud", 0, '', 1, "Proceso indoloro", 1, '');

INSERT INTO  SolicitudExamenes(fkFicha, fechaHora, tipoSolicitud, fkDoctor, estudios) VALUES
(1, '2022-04-24 10:36:52', 1, 2, 'Solicitud de exámenes de laboratorio para procedimiento de vasectomía'),
(2, '2022-04-25 11:47:03', 0, 1, 'Otra solicitud de exámenes de laboratorio para procedimiento de vasectomía');

