--perdi o restante do codigo porque o pc desligou a meio e não tinha guardado

select * from details;
select * from clients;
select * from expense;
select * from type_Of_Expense;
select * from type_Of_Payment;
drop table details

create table details(
idfaturadet int identity(1,1)primary key,
idfatura int foreign key references expense(idfatura),
date_payment date,
value_Of_Paymente decimal(10,2))

set identity_insert details ON
insert into details(idfaturadet, idfatura, date_payment, value_Of_Paymente) values
(1,1,Null,235.0)


set identity_insert details OFF

select * from clients

