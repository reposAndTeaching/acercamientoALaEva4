/*create database acercamientoALaEva4*/

use acercamientoALaEva4;


create table usuarios(
	id int primary key identity,
	rut varchar(255),
	pass varchar(255),
	nombre varchar(255),
	apellido varchar(255),
	rol int
);


create table roles(
	id int primary key identity,
	nombre varchar(255),
	tienePermisosAdmin bit
);

create table requerimientos(
	id int primary key identity,
	descripcion varchar(max),
	responsable int,
	tipo varchar(31),
	prioridad varchar(10)
	);


select * from roles;
select * from usuarios;
select * from requerimientos;

insert into roles values('Admin', 1);
insert into roles values('User', 0);

insert into usuarios values('111', '123456','Administrador', 'Requerimientos', 1);
insert into usuarios values('222', '123456', 'Diego', 'Lucero', 2);

select * from usuarios where rut = '111' and pass = '123456';

drop table usuarios