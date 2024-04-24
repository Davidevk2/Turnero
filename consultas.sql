create table turnos ( Id int not null PRIMARY key AUTO_INCREMENT, Categoria varchar(50)not null, TipoDocumento varchar(10) not null, identificacion varchar(25) not null, Ficho varchar(25) not null, FechaEntrada Date, FechaAntendido Date, FechaSalida Date, Estado varchar(25) not null ); 


Insert into Categorias (Siglas, Nombre, Contador, Estado) values("SC", "Solicitar Citas", 00, "Activa" ), ("PF", "Pago Facturas", 00, "Activa"), ("AM", "Autorizacion medicamentos", 00, "Activa"), ("IG", "Informacion General", 00, "Activa"); 