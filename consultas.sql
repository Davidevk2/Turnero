create table turnos ( Id int not null PRIMARY key AUTO_INCREMENT, Categoria varchar(50)not null, TipoDocumento varchar(10) not null, identificacion varchar(25) not null, Ficho varchar(25) not null, FechaEntrada Date, FechaAntendido Date, FechaSalida Date, Estado varchar(25) not null ); 

CREATE TABLE Usuarios ( Id int not null PRIMARY KEY AUTO_INCREMENT, Nombre Varchar(50) not null, Correo Varchar(150) not null, Password Varchar(250) not null, FechaRegistro Date ); 

Insert into Categorias (Siglas, Nombre, Contador, Estado) values("SC", "Solicitar Citas", 00, "Activa" ), ("PF", "Pago Facturas", 00, "Activa"), ("AM", "Autorizacion medicamentos", 00, "Activa"), ("IG", "Informacion General", 00, "Activa"); 

Create table Modulos( Id int not null PRIMARY key AUTO_INCREMENT, Nombre varchar(50) not null, Estado varchar(50) not null, Usuario int not null );