CREATE DATABASE NTTDATA
GO
USE NTTDATA
GO
CREATE TABLE Clientes(
Id int identity,
constraint PK_Clientes primary key (Id),
Nombre varchar(250),
Genero varchar(250),
Edad int not null,
Identificacion varchar(250),
Direccion varchar(250),
Telefono varchar(250),
Contrasenia varchar(250),
Estado bit default 1
)
GO
CREATE TABLE Cuentas(
Id int identity,
constraint PK_Cuentas primary key(Id),
NumeroCuenta varchar(250),
constraint UQ_NumeroCuenta unique(NumeroCuenta),
TipoCuenta int not null,
SaldoInicial decimal(18,4) not null,
Saldo decimal(18,4) not null,
ClienteId int not null,
constraint FK_Cuentas_Clientes foreign key(ClienteId)
references Clientes(Id),
Estado bit default 1
)
GO
CREATE TABLE Movimientos(
Id int identity,
constraint PK_Movimientos primary key(Id),
Fecha datetime not null,
Valor decimal(18,4) not null,
Saldo decimal(18,4) not null,
CuentaId int not null,
constraint FK_Movimientos_Cuentas foreign key (CuentaId)
references Cuentas(Id),
Estado bit default 1
)