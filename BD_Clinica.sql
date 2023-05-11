create database BD_Clinica
go

use BD_Clinica
go

create table Cargos
(
	Id int primary key identity(1,1),
	Cargo varchar(50),
)
go

create table Usuarios 
(
	Id int primary key identity(1,1),
	Nombre	varchar(50),
	Correo	varchar(50),
	Telefono varchar(50),
	Contrasena varchar(50),
	Cargo int
	foreign key(Cargo) references Cargos(Id)
)

create table Pacientes
(
	Id int primary key identity(1,1),
	FechaIngreso date,
	Nombre varchar(50),
	Telefono varchar(50),
	Direccion varchar(50),
 )
go

create table Categorias
(
	Id int primary key identity(1,1),
	Nombre varchar(50)
);

create table Proveedores
(
	Id int primary key identity(1,1),
	Nombre varchar(50),
	Telefono varchar(15),
	Direccion varchar(50)
);

create table Productos
(
	Codigo varchar(8) primary key,
	Nombre varchar(50),
	Categoria int,
	Existencias int default 0,
	Descripcion text,
	PrecioCompra decimal(10,2) default 0,
	PrecioVenta decimal(10,2)default 0
	foreign key(Categoria) references Categorias(Id),
)
go

create table TipoDocumentos
(
	Id int primary key identity(1,1),
	Nombre varchar(50)
)
go

create table Compras
(
	Id int primary key identity(1,1),
	Fecha date,
	Documento int,
	Usuario int,
	Proveedor int,
	Total decimal(10,2),
	SubTotal decimal(10,2)
	foreign key(Documento) references TipoDocumentos(Id),
	foreign key(Usuario) references Usuarios(Id),
	foreign key(Proveedor) references Proveedores(Id)
);


create table DetalleCompra
(
	Id int primary key identity(1,1),
	IdCompra int,
	CodProducto varchar(8),
	PrecioCompra decimal(10,2),
	PrecioVenta decimal(10,2),
	Unidades int,
	Descuento decimal(10,2),
	SubTotal decimal(10,2),
	Total decimal(10,2)
	foreign key(IdCompra) references Compras(Id),
	foreign key(CodProducto) references Productos(Codigo)
);



create table Ventas
(
	Id int primary key identity(1,1),
	Fecha date,
	TipoDocumento int,
	IdUsuario int,
	IdPaciente int,
	SubTotal decimal(10,2),
	Total decimal(10,2)
	foreign key(TipoDocumento) references TipoDocumentos(Id),
	foreign key(IdUsuario) references Usuarios(Id),
	foreign key(IdPaciente) references Pacientes(Id)
);

 create table DetalleVentas
(
	Id int primary key identity(1,1),
	IdVenta int,
	IdProducto varchar(8),
	Precio decimal(10,2),
	Descuento decimal(10,2),
	Unidades int,
	SubTotal decimal(10,2),
	Total decimal(10,2)
	foreign key(IdProducto) references Productos(Codigo),
	foreign key(IdVenta) references Ventas(Id)
);
 
create table Citas
(
	Id int primary key identity(1,1),
	IdPaciente int,
	Fecha date,
	Hora varchar(50)
	foreign key(IdPaciente) references Pacientes(Id)
);

create table Especialidades
(
	Id int primary key identity(1,1),
	Nombre varchar(50)
)
go

create table Personal
(
	Id int primary key identity(1,1),
	Nombre varchar(50),
	Telefono varchar(50),
	Direccion varchar(50),
	Cedula varchar(50),
	Especialidad int
	foreign key(Especialidad) references Especialidades(Id)
)
go

create table Servicios
(
	Id int primary key identity(1,1),
	Nombre varchar(50),
	Costo decimal(10,2)
)
go
 
create table Facturas
(
	Id int primary key identity(1,1),
	Fecha date,
	Paciente int,
	Usuario int,
	Personal int,
	Descuento decimal(10,2),
	SubTotal decimal(10,2),
	Total decimal(10,2)
	foreign key(Paciente) references Pacientes(Id),
	foreign key(Usuario) references Usuarios(Id),
	foreign key(Personal) references Personal(Id)
)
go

create table Detalle_Factura
(
	Id int primary key identity(1,1),
	Factura int,
	Servicio int,
	Cantidad int,
	Precio decimal(10,2),
	Descuento decimal(10,2),
	SubTotal decimal(10,2),
	Total decimal(10,2)
	foreign key(Factura) references Facturas(Id),
	foreign key(Servicio) references Servicios(Id)
)
go
 

/*###################### INSERCIONES NECESARIAS ######################*/

insert into Cargos values ('Administrador');
insert into Cargos values ('Empleado');
go

insert into Especialidades values ('Dentista General')
insert into Especialidades values ('Cirujano Oral')
insert into Especialidades values ('Ortodoncista')
go

insert into Usuarios values ('Bismarck Arroliga', 'bismarck21@gmail.com', '82496723', '212865', 1)
insert into Usuarios values ('Camy Hernandez', 'camy198@gmail.com', '57406024', '212820', 2)
go

insert into Pacientes values(convert(date, getdate(),103), 'Carlos Medrano', '89307934', 'Leon')
insert into Pacientes values(convert(date, getdate(),103), 'Alexander Arroliga', '89307934', 'Managua')
insert into Pacientes values(convert(date, getdate(),103), 'Walter Montoya', '89307934', 'Nagarote')
go

insert into Personal values ('Franklin Peralta', '89609988', 'Granada', '2812309991004B', 1)
insert into Personal values ('Justo Lopez', '81609900','Managua', '4812309991008B', 3)
insert into Personal values ('Jose Ramon', '80609122', 'Leon', '2812305893001B', 2)
go
 
insert into Citas values (1,CONVERT(date, GETDATE(), 103), '02:30 PM');
insert into Citas values (2,CONVERT(date, GETDATE(), 103), '09:30 AM');
go

insert into Servicios values('Extraccion de Diente', 350.00)
insert into Servicios values('Blanqueamiento Dental', 500.00)
insert into Servicios values('Cirugia Dental', 4000.00)
go

insert into TipoDocumentos values ('Factura');
insert into TipoDocumentos values ('Boleta');
go

insert into Categorias values ('Anagelsicos');
insert into Categorias values ('Antiinflamatorio');
insert into Categorias values ('Antibioticos');
go

insert into Proveedores values ('Labotorio Ramos','89509933','Managua');
go

insert into Productos(Codigo,Nombre,Categoria,Descripcion) values('ACE001', 'Acetamenofen 500mg', 1, 'Dolor');
insert into Productos(Codigo,Nombre,Categoria,Descripcion)  values('ASP002', 'Aspirina 500mg', 1, 'Dolor');
go

/*###################### PROCEDIMIENTOS ALMACENADOS ######################*/

-------------------------------------PROCEDIMIENTO PARA USUARIOS
create proc sp_usuarios
	@op char(1) = null,
	@id	int = null,
	@nombre	varchar(50) = null,
	@correo	varchar(50) = null,
	@telefono varchar(50) = null,
	@contrasena varchar(50) = null,
	@cargo int = null
as
	begin
	if(@op = 'L')
		begin
			select u.Id, u.Nombre, u.Correo, c.Cargo, c.Id
			from Usuarios as u 
			inner join Cargos as c on c.Id = u.Cargo
			where u.Nombre = @nombre and u.Contrasena = @contrasena
		end
	if(@op = 'R')
		begin
			select u.Id, u.Nombre, u.Correo, u.Telefono, u.Contrasena, c.Cargo, c.Id as IdCargo
			from Usuarios as u
			inner join Cargos as c on c.Id = u.Cargo
		end
	if(@op = 'I')
		begin 
			insert into Usuarios values(@nombre, @correo, @telefono, @contrasena, @cargo)
		end
	if(@op = 'U')
		begin 
			update Usuarios set Nombre=@nombre,Correo=@correo,Telefono=@telefono,Contrasena=@contrasena,Cargo=@cargo
			where Id = @id 
		end
	if(@op = 'C')	
		begin
			select * from Cargos
		end
	end
go

-------------------------------------PROCEDIMIENTO PARA PACIENTES
create proc sp_pacientes
	@op char(1) = null,
	@id int = null,
	@fechaIngreso date = null,
	@nombre varchar(50) = null,
	@telefono varchar(50) = null,
	@direccion varchar(50) = null
as
	begin
	if(@op = 'L')
		begin
			select * from Pacientes
		end
	if(@op = 'I')
		begin
			insert into Pacientes values(convert(date, getdate(), 103), @nombre, @telefono, @direccion)
		end
	if(@op = 'U')
		begin
			update Pacientes set Nombre=@nombre, Telefono=@telefono, Direccion=@direccion
			where Id=@id 
		end
	end
go

-------------------------------------PROCEDIMIENTO PARA CITAS
create proc sp_citas
	@op char(1) = null,
	@id int = null,
	@idPaciente int = null,
	@fecha date = null,
	@hora varchar(50) = null
as
	begin
	if(@op = 'L')
		begin
			select c.Id, p.Nombre as [Paciente], c.Fecha, c.Hora, p.Id as IdPaciente 
			from Citas as c
			inner join Pacientes as p on p.Id = c.IdPaciente 
		end
	if(@op = 'I')
		begin
			insert into Citas values(@idPaciente, @fecha, @hora)
		end
	if(@op = 'U')
		begin
			update Citas set IdPaciente = @idPaciente, Fecha = @fecha, Hora = @hora
			where Id=@id 
		end
	end
go

-------------------------------------PROCEDIMIENTO PARA ESPECIALIDADES
create proc sp_especialidades
	@op char(1) = null,
	@id int = null,
	@nombre varchar(50) = null
as
	begin
	if(@op = 'L')
		begin
			select * from Especialidades
		end
	if(@op = 'I')
		begin
			insert into Especialidades values(@nombre)
		end
	if(@op = 'U')
		begin
			update Especialidades set Nombre=@nombre
			where Id=@id 
		end
	end
go

-------------------------------------PROCEDIMIENTO PARA PERSONAL
create proc sp_personal
	@op char(1) = null,
	@id int = null,
	@nombre varchar(50) = null,
	@telefono varchar(50) = null,
	@direccion varchar(50) = null,
	@cedula varchar(50) = null,
	@especialidad int = null
as
	begin
	if(@op = 'L')
		begin
			select p.Id, p.Nombre, p.Telefono, p.Direccion, p.Cedula, e.Nombre as [Especialidad], e.Id as IdEspecialidad
			from Personal as p
			inner join Especialidades as e on e.Id = p.Especialidad 
		end
	if(@op = 'I')
		begin
			insert into Personal values(@nombre,@telefono,@direccion,@cedula,@especialidad)
		end
	if(@op = 'U')
		begin
			update Personal set Nombre=@nombre, Telefono=@telefono, Direccion=@direccion, Cedula=@cedula, Especialidad=@especialidad
			where Id = @id
		end
	if(@op = 'E')
		begin
			select * from Especialidades 
		end
	end
go

-------------------------------------PROCEDIMIENTO PARA SERVICIOS
create proc sp_servicios
	@op char(1) = null,
	@id int = null,
	@nombre varchar(50) = null,
	@costo decimal(10,2) = null
as
	begin
	if(@op = 'L')
		begin
			select * from Servicios
		end
	if(@op = 'I')
		begin
			insert into Servicios values (@nombre, @costo)
		end
	if(@op = 'U')
		begin
			update Servicios set Nombre = @nombre, Costo = @costo
			where Id = @id
		end
	end
go


create type dbo.[Detalle_Factura] as table 
(
	[Servicio] int null,
	[Cantidad] int null,
	[Precio] decimal(10,2) null,
	[Descuento] decimal(10,2) null,
	[SubTotal] decimal(10,2) null,
	[Total] decimal(10,2) null
)
go
-------------------------------------PROCEDIMIENTO PARA FACTURA
create proc sp_factura
	@op char(1) = null,
	@fecha date = null,
	@paciente int = null,
	@usuario int = null,
	@personal int = null,
	@descuento decimal(10,2) = null,
	@subTotal decimal(10,2) = null,
	@total decimal(10,2) = null,
	@detalleFactura [Detalle_Factura] readonly
as
	begin
	if(@op = 'L')
		begin
			select f.Id, CONVERT(char(10), f.Fecha, 103)[Fecha],u.Nombre[Usuario], p.Nombre[Paciente], ps.Nombre[Personal], f.Total
			from Facturas as f
			inner join Pacientes as p on p.Id = f.Paciente
			inner join Usuarios as u on u.Id = f.Usuario
			inner join Personal as ps on ps.Id = f.Personal
		end
	if(@op = 'I')
		begin
			begin try
				
				declare @factura int = 0;
				begin tran registro
				
				insert into Facturas values (convert(date, getdate(),103), @paciente, @usuario, @personal, @descuento, @subTotal, @total)				
				
				set @factura = SCOPE_IDENTITY();				
				
				insert into Detalle_Factura(Factura, Servicio, Cantidad, Precio, Descuento, SubTotal, Total)
				select @factura , Servicio, Cantidad,Precio, Descuento, SubTotal, Total from @detalleFactura
				
				commit tran registro
			end try
			begin catch
				rollback tran registo
			end catch
		end
	end
go

-------------------------------------PROCEDIMIENTO PARA DETALLE DE FACTURA
create proc sp_detalleFactura
	@op char(1) = null,
	@id int = null,
	@factura int = null,
	@servicio int = null,
	@cantidad int = null,
	@descuento decimal(10,2) = null,
	@subTotal decimal(10,2) = null,
	@total decimal(10,2) = null
as
	if(@op = 'L')
	begin
		select dt.Id, dt.Factura[IdFactura], s.Nombre[Servicio], dt.Cantidad,dt.Precio, dt.Descuento, dt.SubTotal, dt.Total 
		from Detalle_Factura as dt
		inner join Servicios as s on s.Id = dt.Servicio
		where Factura = @factura
	end
go


-- PROCEDIMIENTOS ALAMACENADOS DE LA FARMACIA

create type dbo.[DetalleCompras] as table 
(
	[CodProducto] varchar(8) null,
	[PrecioCompra] decimal(10,2) null,
	[PrecioVenta] decimal(10,2) null,
	[Unidades] int null,
	[Descuento] decimal(10,2) null,
	[SubTotal] decimal(10,2) null,
	[Total] decimal(10,2) null
)
go

-------------------------------------PROCEDIMIENTO PARA COMPRAS
create proc sp_compras
	@op char(1) = null,
	@id int = null,
	@fecha date = null,
	@documento int = null,
	@usuario int = null,
	@proveedor int = null,
	@subTotal decimal(10,2) = null,
	@total decimal(10,2) = null,
	@detalleCompra [DetalleCompras] readonly
as
	begin
	if(@op = 'L')
		begin
			select c.Id, c.Fecha, td.Nombre as Documento, u.Nombre as Usuario, p.Nombre as Proveedor, c.SubTotal, c.Total
			from compras as c
			inner join TipoDocumentos as td on td.Id = c.Documento 
			inner join Usuarios as u on u.Id = c.Usuario
			inner join Proveedores as p on p.Id = c.Proveedor
		end
------------------------------------ PROCESO PARA REGISTRAR UNA VENTA
	if(@op = 'I')
		begin try
			declare @idCompra int = 0;
			begin tran compra
				insert into Compras (Fecha, Documento, Usuario, Proveedor, SubTotal, Total)
				values (convert(date, getdate(),103), @documento, @usuario, @proveedor, @subTotal, @total)
				 
				set @idCompra = SCOPE_IDENTITY();

				insert into DetalleCompra(IdCompra, CodProducto, PrecioCompra, PrecioVenta, Unidades, Descuento, SubTotal, Total) 
				select @idCompra, CodProducto, PrecioCompra, PrecioVenta, Unidades, Descuento, SubTotal,Total from @detalleCompra
				update p set 
				p.Existencias = p.Existencias + dc.Unidades,
				p.PrecioCompra = dc.PrecioCompra,
				p.PrecioVenta = dc.PrecioVenta
				from Productos as p
				inner join @detalleCompra as dc on dc.CodProducto = p.Codigo

			commit tran compra
			end try
		begin catch
			rollback tran registro
			print 'Ha ocurrido un error en la transacción'
		end catch
	end
go

-------------------------------------PROCEDIMIENTO PARA DETALLE DE COMPRA
create proc sp_detalleCompra
	@id int = null,
	@idCompra int = null,
	@codProducto varchar(8) = null,
	@precioCompra decimal(10,2) = null,
	@precioVenta decimal(10,2) = null,
	@unidades int = null,
	@descuento decimal(10,2) = null,
	@subTotal decimal(10,2) = null,
	@total decimal(10,2) = null
as
	begin
		select  dc.Id, c.Fecha, dc.IdCompra,p.Nombre as Productos, dc.PrecioCompra, dc.Unidades, dc.Descuento, dc.Total
		from DetalleCompra as dc
		inner join Productos as p on p.Codigo = dc.CodProducto   
		inner join Compras as c on c.Id = dc.IdCompra
		where IdCompra = @idCompra
	end
go

-------------------------------------PROCEDIMIENTO PARA PROVEEDORES
create proc sp_proveedores
	@op char(1) = null,
	@id int = null,
	@nombre varchar(50) = null,
	@telefono varchar(15) = null,
	@direccion varchar(50) = null
as
	if(@op = 'L')
	begin
		select * from Proveedores;
	end
	if(@op = 'I')
	begin
		insert into Proveedores values(@nombre, @telefono, @direccion);
	end
	if(@op = 'U')
	begin
		update Proveedores set Nombre = @nombre, Telefono = @telefono, Direccion = @direccion
		where Id = @id
	end
go


-------------------------------------PROCEDIMIENTO PARA PRODUCTOS
create proc sp_productos
	@op char(1) = null,
	@codigo varchar(8) = null,
	@nombre varchar(50) = null,
	@categoria int = null,
	@existencias int = null,
	@descripcion text = null,
	@precioCompra decimal(10,2) = null,
	@precioVenta decimal(10,2) = null
as
	begin
	if(@op = 'C')
		begin
			select * from Categorias;
		end
	if(@op = 'L')
		begin
			select p.Codigo, p.Nombre, c.Nombre as Categoria,p.Descripcion, p.Existencias, p.PrecioCompra, p.PrecioVenta,c.Id as IdCategoria
			from Productos as p
			inner join Categorias as c on c.Id = p.Categoria
			order by Codigo asc
		end
	if(@op = 'I')
		begin
			insert into Productos(Codigo,Nombre,Categoria,Descripcion)values (@codigo, @nombre, @categoria,@descripcion);
		end
	if(@op = 'U')
		begin
			update Productos set Codigo = @codigo, Nombre = @nombre,Categoria =@categoria, Descripcion = @descripcion
			where Codigo = @codigo
		end
	end
	if(@op = 'R') 
		begin 
			update Productos set Existencias = Existencias - @existencias where Codigo = @codigo
		end
	
	---------------------- Sumar existencias a ala hora de vender
	if(@op = 'S') 
		begin 
			update Productos set Existencias = Existencias + @existencias where Codigo = @codigo
		end
	---------------------- Inventario de los Productos
	if(@op = 'N')
	begin
		select 
			p.Codigo,
			p.Nombre as Producto,
			p.Descripcion,
			(select top 1
				sum(dc.Unidades) as Compras
				from DetalleCompra as dc
				where dc.CodProducto = p.Codigo
			)  as Compras,
		
			(select 
				sum(dv.Unidades) as Ventas
				from DetalleVentas as dv
				where dv.IdProducto = p.Codigo
			)  as Ventas,
			(
			select 
				sum(dc.Unidades)
				from DetalleCompra as dc
				where dc.CodProducto = p.Codigo
			) - (
				select 
				sum(dv.Unidades)
				from DetalleVentas as dv
				where dv.IdProducto = p.Codigo
			) as Stock_Actual
		
			 from 
			 Productos as p 	 
	end
go


create type dbo.[DetalleVentas] as table 
(
	[IdProducto] varchar(8) null,
	[Precio] decimal(10,2) null,
	[Descuento] decimal(10,2) null,
	[Unidades] decimal(10,2) null,
	[SubTotal] decimal(10,2) null,
	[Total] decimal(10,2) null
)
go

-------------------------------------PROCEDIMIENTO PARA VENTAS
create proc sp_Ventas
	@op char(1) = null,
	@id int = null,
	@fecha date = null,
	@tipoDocumento int = null,
	@idUsuario int = null,
	@idPaciente int = null,
	@subTotal decimal(10,2) = null,
	@total decimal(10,2) = null,
	@detalleVentas [DetalleVentas] readonly
as
	begin
	if(@op = 'L') 
		begin
			select  v.Id, v.Fecha, td.Nombre as Documento, u.Nombre as Usuario, p.Nombre as Paciente, v.SubTotal, v.Total
			from Ventas as v
			inner join TipoDocumentos as td on td.Id = v.TipoDocumento
			inner join Usuarios as u on u.Id = v.IdUsuario
			inner join Pacientes as p on p.Id = v.IdPaciente
		end

	if(@op = 'T')
		begin
			select * from TipoDocumentos;
		end

	if(@op = 'I')
		begin
			begin try
				
				declare @idVenta int = 0;
				begin tran registro
				
				insert into Ventas values (convert(date, getdate(),103),@tipoDocumento, @idUsuario, @idPaciente, @subTotal, @total)
				
				set @idVenta = SCOPE_IDENTITY();
				
				insert into DetalleVentas (IdVenta, IdProducto, Precio, Descuento, Unidades, SubTotal, Total)
				select @idVenta, IdProducto, Precio, Descuento, Unidades, SubTotal, Total from @detalleVentas
				commit tran registro
			end try
			begin catch
				rollback tran registo
			end catch
		end
	end
go

-------------------------------------PROCEDIMIENTO PARA DETALLE DE VENTAS
create proc sp_detalleVentas
	@id int = null,
	@idVenta int = null,
	@idProducto varchar(8) = null,
	@precio decimal(10,2) = null,
	@descuento decimal(10,2) = null,
	@unidades int = null,
	@subTotal decimal(10,2) = null,
	@total decimal(10,2) = null
as
	begin
		select dv.Id, v.Id as IdVenta, p.Nombre as Producto, dv.Precio, dv.Descuento, dv.Unidades, dv.SubTotal, dv.Total 
		from DetalleVentas as dv
		inner join Productos as p on p.Codigo = dv.IdProducto   
		inner join Ventas as v on v.Id = dv.IdVenta 
		where IdVenta = @idVenta
	end
go


/*###################### REPORTES ######################*/

-------------------------------------PROCEDIMIENTO PARA REPORTES DE PACIENTES
create proc sp_ReportesPacientes
	@fechaInicio varchar(10) = null, 
	@fechaFin varchar(10) = null 
as
	begin
		set dateformat dmy
		select 
		p.Id, convert(char(10), p.FechaIngreso, 103) as [Fecha_Ingreso],
		p.Nombre as [Nombre],
		p.Telefono,
		p.Direccion
		
		from Pacientes as p
		where p.FechaIngreso between @fechaInicio and @fechaFin
	end
go

-------------------------------------PROCEDIMIENTO PARA REPORTES DE COMPRAS
create proc sp_reportesCompras
	@fechaInicio varchar(10) = null, 
	@fechaFin varchar(10) = null 
as
	begin
		set dateformat dmy
		select 
		c.Id,
		convert(varchar(10), c.Fecha, 103) as Fecha,
		u.Nombre as Usuario,
		td.Nombre as Documento,
		pv.Nombre as Proveedor,
		p.Nombre Producto,
		dc.Unidades,
		dc.PrecioCompra,
		c.Total

		from Compras c
		inner join Usuarios as u on u.Id = c.Usuario
		inner join TipoDocumentos as td on td.Id = c.Documento
		inner join Proveedores as pv on pv.Id = c.Proveedor
		inner join DetalleCompra as dc on dc.IdCompra = c.Id
		inner join Productos as p on p.Codigo = dc.CodProducto
		where convert(date, c.Fecha) between @fechaInicio and @fechaFin
	end
go


create proc sp_reporteVentas
@fechaInicio varchar(10), 
@fechaFin varchar(10) 
as
	begin
		SET DATEFORMAT dmy;
		select 
		v.Id, 
		convert(char(10), v.Fecha, 103) as Fecha,
		u.Nombre as Usuario,
		pc.Nombre as Paciente,
		P.Nombre as Productos,
		dv.Unidades,
		dv.Precio,
		dv.Descuento,
		dv.Total
		
		from Ventas v 
		inner join DetalleVentas as dv on dv.IdVenta = v.Id
		inner join Productos as P on P.Codigo = dv.IdProducto
		inner join Pacientes as pc on pc.Id = v.IdPaciente
		inner join Usuarios as u on u.Id = v.IdUsuario
		where convert(date, v.Fecha) between @fechaInicio and @fechaFin
	end
go









 






















