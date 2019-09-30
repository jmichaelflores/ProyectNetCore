create database DBNetCore
go

use DBNetCore
go


create table Categories(
id_category int not null identity(1,1) primary key,
name varchar(50) null
);

create table Products(
id_product int not null identity(1,1) primary key,
name varchar(50) null,
category_id int,
constraint FK_Products_Categories foreign key (category_id) references Categories(id_category)
);

insert into Categories (name) values ('Comida');
insert into Categories (name) values ('Herramientas');
insert into Categories (name) values ('Muebles');

insert into Products (name, category_id) values ('Pan', 1);
insert into Products (name, category_id) values ('Pupusas', 1);
insert into Products (name, category_id) values ('Jamon', 1);
insert into Products (name, category_id) values ('Matillos', 2);
insert into Products (name, category_id) values ('Clavos', 2);
insert into Products (name, category_id) values ('Cerrucho', 2);
insert into Products (name, category_id) values ('Mesa', 3);
insert into Products (name, category_id) values ('Cama', 3);
insert into Products (name, category_id) values ('Sillon', 3);