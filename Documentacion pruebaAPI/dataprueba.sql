--Creacion de la tabla de prueba
CREATE TABLE Brujas_Magos(
	identificacion bigint primary key NOT NULL,
	nombre varchar(20) NOT NULL,
	apellido varchar(20) NOT NULL,
	edad smallint NOT NULL,
	casa varchar(10) NOT NULL,
);

--Insert data de prueba
insert into Brujas_Magos
(identificacion, nombre, apellido, edad, casa)
values
(18933483, 'Alexis', 'Colon', 11, 'Gryffindor'),
(203458765, 'Alex', 'Martinez', 13, 'Hufflepuff'),
(19726387, 'Wade', 'Watts', 10, 'Ravenclaw'),
(22949767, 'Juan', 'Rea', 12, 'Slytherin');

--Consulta
select * from Brujas_Magos;

