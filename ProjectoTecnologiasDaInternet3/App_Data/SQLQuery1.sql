-- -- create database
-- create database clientes

 -- --create TABLE clients 
 --create table clients(

	--idcli int identity(1,1)primary key,
	--name nvarchar(100)  not null,
	--password nvarchar(100)  not null,
	--role nvarchar(50) check(role = 'Admin' or role = 'Dad' or role = 'Mom' or role = 'Other') default 'Other',
	--datanasc date,
	--age as datediff(day,datanasc,getdate())/365.25,
	--boss int constraint fkclientsclients foreign key references clients(idcli)

 --);

 -- -- see database
 sp_help 'clients';
 
 -- -- on or off manual mode
 set identity_insert clients ON;
 set identity_insert clients OFF;

 -- Insert clients into table
 --insert into clients(name, password, role, datanasc)
 --values
 --('Ruben Amaro', 'xpto123', 'Admin', '1995-08-22'),
 --('Anabela', 'xpto123', 'Mom', '1980-10-22'),
 --('Carlos', 'xpto123', 'Dad', '1979-04-24')

 -- -- se all keys of table
--select * from clients;


--ALTER TABLE clients
--ADD salary decimal(10,2), savings decimal(10,2);


  -- Insert expenses into table house_expenses
 insert into house_expenses(name, value, anualy, monthly, weekly, daily, first_day_of_Payment, time_of_payment)
 values
 ('Light bill', '100', 0, 1, 0, 0, '2024-06-06', Null),
 ('Water bill', '90', 0, 1, 0, 0, '2024-06-06', Null),
 ('Telecomunication bill', '50', 0, 1, 0, 0, '2024-06-06',Null)


select * from house_expenses;

--update clients set boss = (
--case 
--when role = 'Admin' then 1
--else 2
--end
--);

 
 drop table expenses

create table expenses(
	idexpenses int identity(1,1)primary key,
	idcli int foreign key references clients(idcli),

	id_house_expenses int foreign key references house_expenses(id_house_expenses),
	value_house_expenses decimal (10,2),

	id_outside_expenses int foreign key references outside_expenses(idexpenses),
	value_outside_expenses decimal (10,2),

	id_insurance_expenses int foreign key references insurance_expenses(idexpenses),
	value_insurance_expenses decimal (10,2),

	id_education_expenses int foreign key references education_expenses(idexpenses),
	value_education_expenses decimal (10,2),

	id_car_expenses int foreign key references car_expenses(idexpenses),
	value_car_expenses decimal (10,2)
)

--alter table house_expenses add idclient int foreign key references clients(idcli)

--create table house_expenses(
--	id_house_expenses int identity(1,1)primary key,
--	name varchar(50) not null,
--	value decimal(10,2),
--	anualy bit,
--	monthly bit,
--	weekly bit,
--	daily bit,
--	first_day_of_Payment date,
--	time_of_payment date,
--	idclient int 
--)

--alter table house_expenses add idclient int foreign key references clients(idcli)

alter table expenses add value_house_expense int foreign key references house_expenses(value)


insert into expenses(idcli, id_house_expenses)
select c.idcli, house.id_house_expenses from clients c, house_expenses house

select * from clients
select * from expenses
select * from house_expenses

--create table outside_expenses(
--	idexpenses int identity(1,1)primary key,
--	name varchar(50) not null,
--	value decimal(10,2),
--	anualy bit,
--	monthly bit,
--	weekly bit,
--	daily bit,
--	first_day_of_Payment date,
--	time_of_payment date,
--	idclient int 
--)



--create table insurance_expenses(
--	idexpenses int identity(1,1)primary key,
--	name varchar(50) not null,
--	value decimal(10,2),
--	anualy bit,
--	monthly bit,
--	weekly bit,
--	daily bit,
--	first_day_of_Payment date,
--	time_of_payment date,
--	idclient int 
--)

--create table education_expenses(
--	idexpenses int identity(1,1)primary key,
--	name varchar(50) not null,
--	value decimal(10,2),
--	anualy bit,
--	monthly bit,
--	weekly bit,
--	daily bit,
--	first_day_of_Payment date,
--	time_of_payment date,
--	idclient int 
--)



--create table car_expenses(
--	idexpenses int identity(1,1)primary key,
--	name varchar(50) not null,
--	value decimal(10,2),
--	anualy bit,
--	monthly bit,
--	weekly bit,
--	daily bit,
--	first_day_of_Payment date,
--	time_of_payment date,
--	idclient int 
--)



insert into expenses(idcli, id_car_expenses)
select c.idcli, house.id_car_expenses from clients c, car_expenses house

