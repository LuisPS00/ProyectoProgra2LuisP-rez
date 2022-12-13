create database Gimnasio

use Gimnasio

create table Usuarios
(
ID_Usuarios int identity primary key,
Email varchar(30) not null,
Clave varchar(30) not null,
Nombre varchar(50)not null,
Tipo varchar(50) not null
)

create table Clientes
(
ID_Cliente int identity primary key,
Nombre varchar(50),
Apellido varchar(50),
Telefono varchar(50),
)

create table Direcciones
(
ID_Direccion int identity primary key,
Codigo_Cliente int,
Codigo_Provincia int ,
Codigo_Canton int,
Codigo_Distrito int,
Comentarios varchar(500),
constraint FKD_Codigo_Cliente FOREIGN KEY (Codigo_Cliente) references Clientes(ID_Cliente),
constraint FKD_Codigo_Provincia FOREIGN KEY (Codigo_Provincia) references Provincia(ID_Provincia),
constraint FKD_Codigo_Canton FOREIGN KEY (Codigo_Canton) references Canton (ID_Canton),
constraint FKD_Codigo_Distrito FOREIGN KEY (Codigo_Distrito) references Distrito(ID_Distrito)
)

 create table Provincia
(
ID_Provincia int identity primary key,
Nombre varchar(50)
)

create table Canton
(
ID_Canton int identity primary key,
Nombre varchar(50),
Codigo_Provincia int
constraint FK_Codigo_Provincia FOREIGN KEY (Codigo_Provincia) references Provincia(ID_Provincia)
)

create table Distrito
(
Id_Distrito int identity primary key,
Nombre varchar(50),
Codigo_Canton int
constraint FK_Codigo_Canton FOREIGN KEY (Codigo_Canton) references Canton(ID_Canton)
)

create table Producto
(
ID_Producto int identity primary key,
Nombre varchar(50),
Precio float
)

create table MAE_Factura
(
NFactura int identity primary key ,
Fecha datetime constraint DF_fecha default GetDate(),
Codigo_Cliente int,
IVTotal float
constraint FK_Codigo_Cliente FOREIGN KEY (Codigo_Cliente) references Clientes(ID_Cliente)
)

create table Det_Factura
(
Codigo_Factura int identity primary key,
NFactura int,
Codigo_producto varchar(50),
Cantidad float,
Precio_Uniatario float
constraint FK_NFactura FOREIGN KEY (Nfactura) references Mae_Factura(Nfactura)
)

---PROCEDIMIENTO DE ALAMECENADO TABLA USUARIOS---
create procedure IngresarUsuarios
@Email varchar(30),
@Clave varchar(30),
@Nombre varchar(50),
@Tipo varchar(30)='Cliente'
as
begin
insert into Usuarios(Email,Clave,Nombre,Tipo) values(@Email, @Clave, @Nombre,@tipo) 
end
exec IngresarUsuarios  'hjghj', 'Luis Pérez',

create procedure BorrarUsuario
@ID_Usuarios int
 as
 begin
 delete Usuarios where ID_Usuarios =@ID_Usuarios 
 end
 exec BorrarUsuario 10

 create procedure ActualizarUsuarios
@ID_Usuarios int,
@Email varchar(30),
@Clave varchar(30),
@Nombre varchar(50),
@tipo varchar(30)
as
 begin
 update Usuarios set Email = @Email, Clave=@Clave, Nombre=@Nombre, Tipo=@tipo where ID_Usuarios  = @ID_Usuarios 
 end
 exec ActualizarUsuarios 1, 'Luis@uh.com','123', 'Luis', 'admin'


 create procedure llenartabla
 as
 begin
 Select *from Usuarios 
 end
create procedure ConsultaUsuario
@ID_Usuarios int
 as
 begin
 Select Email, Clave, Nombre, tipo from Usuarios where ID_Usuarios =@ID_Usuarios
 end
 exec ConsultaUsuario 5

 create procedure ValidarUsuarios
 @Email varchar(30),
 @Clave varchar(30)
 as
 begin
 select *from Usuarios where Email=@Email and Clave=@Clave
 end

 exec ValidarUsuarios 'Luis@uh.com', '124'

  ---PROCEDIMIENTO DE ALAMECENADO TABLA ClIENTES---
 create procedure IngresarClientes
@Nombre varchar(30)= '',
@Apellido varchar(30)='',
@Telefono varchar(50)=''
as
begin
insert into Clientes(Nombre,Apellido,Telefono) values(@Nombre, @Apellido, @Telefono) 
end
exec IngresarClientes 'Maricruz', 'Perez', '88477123'

create procedure BorrarCliente
@ID_Cliente int
 as
 begin
 delete Clientes where ID_Cliente = @ID_Cliente
 end
 exec BorrarUsuario 6

 create procedure ActualizarClientes
 @ID_Cliente int,
@Nombre varchar(50),
@Apellido varchar(30),
@Telefono varchar(50)
as
 begin
 update Clientes set Nombre=@Nombre, Apellido=@Apellido, Telefono=@telefono where ID_Cliente = @ID_Cliente
 end
 exec ActualizarClientes 1, 'Alejandro', 'Perez Sanchez', '86418798'

 create procedure Pu
 @ID_Cliente int
 as
 begin
 Select *from Clientes where   ID_Cliente=@ID_Cliente
 end
 exec ConsultarClientes
 create procedure llenartabla2
 as
 begin
 Select *from Clientes 
 end

  ---PROCEDIMIENTO DE ALAMECENADO TABLA DIRECCIONES---
 create procedure IngresarDireccion
@Codigo_Cliente int,
@Codigo_Provincia int,
@Codigo_Canton int,
@Codigo_Distrito int,
@Comentarios varchar (500)
as
begin
insert into Direcciones(Codigo_Cliente,Codigo_Provincia,Codigo_Canton,Codigo_Distrito,Comentarios) values(@Codigo_Cliente,@Codigo_Provincia,@Codigo_Canton,@Codigo_Distrito,@Comentarios) 
end
exec IngresarDireccion 1,2,2,2,'prueba'

create procedure BorrarDireccion
 @ID_Direccion int 
 as
 begin
 delete Direcciones where ID_Direccion = @ID_Direccion
 end
 exec BorrBorrarDireccion

 create procedure ActualizarDireccion
  @ID_Direccion int,
  @Codigo_Cliente int,
@Codigo_Provincia int,
@Codigo_Canton int,
@Codigo_Distrito int,
@Comentarios varchar (500)
as
 begin
 update Direcciones set Codigo_Cliente=@Codigo_Cliente, Codigo_Provincia=@Codigo_Provincia, Codigo_Canton=@Codigo_Canton,Codigo_Distrito=@Codigo_Distrito,Comentarios=@Comentarios where ID_Direccion = @ID_Direccion
 end
 exec ActualizarDireccion 1,1,2,3,2,'jwefjwefkjwef'

 Create procedure ConsultarDireccion
  @ID_Direccion int 
 as
 begin
 Select *from Direcciones where     ID_Direccion=@ID_Direccion
 end
 exec ConsultarDireccion 1

 create procedure llenartabla3
 as
 begin
 Select *from Direcciones
 end
---PROCEDIMIENTO DE ALAMECENADO TABLA PROVINCIA---
 create procedure IngresarProvincia
@Nombre varchar (50)
as
begin
insert into Provincia(Nombre) values(@Nombre) 
end
exec IngresarProvincia 'Alajueñ'

create procedure BorrarProvincia
 @ID_Provincia int 
 as
 begin
 delete Provincia where ID_Provincia =@ID_Provincia
 end
 exec BorrarProvincia 2

 create procedure ActualizarProvincia
 @ID_Provincia int,
@Nombre varchar (50)
as
 begin
 update Provincia set Nombre=@Nombre where ID_Provincia =@ID_Provincia
 end
 exec ActualizarProvincia 2,'Alajuela'

 create procedure ConsultarProvincia
  @ID_Provincia int
 as
 begin
 Select *from Provincia where  ID_Provincia = int@ID_Provincia
 end
 exec ConsultarProvincia

  create procedure llenartabla4
 as
 begin
 Select *from Provincia
 end

 ---PROCEDIMIENTO DE ALAMECENADO TABLA CANTON---
 create procedure IngresarCanton
@Nombre varchar (50),
@Codigo_Provincia int
as
begin
insert into Canton(Nombre,Codigo_Provincia) values(@Nombre,@Codigo_Provincia) 
end
exec IngresarCanton 'santa ana', 2

create procedure BorrarCanton
 @ID_Canton int 
 as
 begin
 delete Canton where ID_Canton =@ID_Canton
 end
 exec BorrarCanton 4

 create procedure ActualizarCanton
@ID_Canton int, 
@Nombre varchar (50),
@ID_Provincia int
as
 begin
 update Canton set Nombre=@Nombre, Codigo_Provincia =Codigo_Provincia where ID_Canton  =@ID_Canton 
 end
 exec ActualizarCanton  2, 'Pavas', 1

 CREATE procedure ConsultarCanton
 @ID_Canton int
 as
 begin
 Select *from Canton where ID_Canton = @ID_Canton 
 end
 exec ConsultarCanton

  create procedure llenartabla5
 as
 begin
 Select *from Canton
 end

    ---PROCEDIMIENTO DE ALAMECENADO TABLA DISTRITO---
 create procedure IngresarDistrito
@Nombre varchar (50),
@Codigo_Canton int
as
begin
insert into Distrito(Nombre,Codigo_Canton) values(@Nombre,@Codigo_Canton) 
end
exec IngresarDistrito 'Claudia', 2

create procedure BorrarDistrito
 @ID_Distrito int 
 as
 begin
 delete Distrito where ID_Distrito =@ID_Distrito
 end
 exec BorrarDistrito 2

 create procedure ActualizarDistrito
@ID_Distrito int, 
@Nombre varchar (50),
@Codigo_Canton int
as
 begin
 update Distrito set Nombre=@Nombre, Codigo_Canton =@Codigo_Canton where ID_Distrito  =@ID_Distrito
 end
 exec ActualizarDistrito  4, 'San Cristobal', 6

 create procedure ConsultarDistrito
 @ID_Distrito int
 as
 begin
 Select *from Distrito where ID_Distrito  =@ID_Distrito
 end
 exec ConsultarDistrito

  create procedure llenartabla6
 as
 begin
 Select *from Distrito
 end


---PROCEDIMIENTO DE ALAMECENADO TABLA PRODUCTOS---
 create procedure IngresarProducto
@Nombre varchar (50),
@Precio float
as
begin
insert into Producto(Nombre, Precio) values(@Nombre, @Precio) 
end
exec IngresarProducto 'agua', 850

create procedure BorrarProducto
 @ID_Producto int 
 as
 begin
 delete Producto where ID_Producto =@ID_Producto
 end
 exec BorrarProducto 2

 create procedure ActualizarProducto
@ID_Producto int, 
@Nombre varchar (50),
@Precio float
as
 begin
 update Producto set Nombre=@Nombre, Precio=@Precio where ID_Producto =@ID_Producto
 end
 exec ActualizarProducto 1, 'Camiseta', 1500

 create procedure ConsultarProducto
 @ID_Producto int
 as
 begin
 Select *from Producto where ID_Producto =@ID_Producto
 end
 exec ConsultarProducto

  create procedure llenartabla7
 as
 begin
 Select *from Producto
 end
 