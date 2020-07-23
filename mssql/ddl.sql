-- data definition language

use master;
go

-- CREATE

create database PizzaStoreDb; --project
go

create schema Pizza; --namespace 
go

--constraints = datatype, key, default, check, null, ?
--number datatypes = tinyint, smallint, int, bigint, numeric, decimal, money
--text datatypes = text, ntext, varchar(ascii), nvarchar(should only use nvarchar primarily, uses utf-8, GLOBAL)
--datetime datatypes = date, time, datetime, datetime2 ---- date and time are almost never used
--boolean datatypes = bit
create table Pizza.Pizza 
(
  PizzaId int not null primary key,
  CrustId int null foreign key references Pizza.Crust(CrustId), 
  SizeId int null,
  [Name] nvarchar(250) not null,
  DateModified datetime2(0) not null,
  Active bit not null default 1,
  constraint SizeId foreign key references Pizza.Size(SizeId)
);

create table Pizza.Crust
(
  CrustId int not null,
  [Name] nvarchar(100) not null,
  Active bit not null,
  constraint CrustId primary key,
  constraint Active default 1
);

create table Pizza.Size
(
  SizeId int not null,
  [Name] nvarchar(100) not null,
  Active bit not null
);

create table Pizza.Topping
(
  ToppingId int not null,
  [Name] nvarchar(100) not null,
  Active bit not null
);

create table Pizza.PizzaTopping
(
  PizzaToppingId int not null,
  ToppingId int not null,
  Active bit not null
)
go

-- ALTER
alter table Pizza.Size
  add constraint PK_Size_SizeId SizeId primary key

alter table Pizza.Topping
  add constraint PK_Topping_ToppingId ToppingId primary key

alter table Pizza.PizzaTopping
  add constraint PK_PizzaTopping_PizzaToppingId PizzaToppingId primary key

alter table Pizza.PizzaTopping
  add constraint K_PizzaTopping_PizzaId PizzaId foreign key references Pizza.Pizza(PizzaId)

alter table Pizza.PizzaTopping
  add constraint K_PizzaTopping_ToppingId ToppingId foreign key references Pizza.Topping(ToppingId)

go

-- DROP
--replication, backup(full, incremental, differential), failover


-- TRUNCATE
--permanant deletion of tables, databases, etc.