create procedure InsertarCliente
@nombre varchar(50),
@apePaterno varchar(50),
@apeMaterno varchar (50),
@telefono varchar (50)
as
insert into Clientes (nombreCli, apellidoPaternoCli, apellidoMaternoCli, telefonoCli) values (@nombre, @apePaterno, @apeMaterno, @telefono)
go

InsertarCliente 'Hector','Nunez','Rivas','7732345678';

create procedure ActualizarCliente
@codigo int,
@nombre varchar(50),
@apePaterno varchar(50),
@apeMaterno varchar (50),
@telefono varchar (50)
as
update Clientes set nombreCli=@nombre, apellidoPaternoCli=@apePaterno, apellidoMaternoCli=@apeMaterno, telefonoCli=@telefono
where idCli=@codigo
go

ActualizarCliente @nombre='Oscar',@apePaterno='Rios',@apeMaterno='Nunez',@telefono='7739876543', @codigo='1';


create procedure EliminarCliente
@codigo int
as
delete from Clientes where idCli=@codigo
go

EliminarCliente @codigo='1';


create procedure BuscarCliente
@nombre varchar(50)
as
select *from Clientes where nombreCli like '%' + @nombre + '%'
go

BuscarCliente @nombre='hec'


create procedure ListarCliente
as
select *from Clientes 
go

ListarCliente;