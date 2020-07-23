--data manipulation language 

use AdventureWorks2017;
go

--SELECT (select, from, where, group, having, order by)
select 'hello';
select 1 + 1;

select *--horizontal filter
from Person.Person;

--collation = character set is case insensitive, accent sensitive
-- A = a, a != â
select firstname, lastname
from Person.Person; --finds all names

select firstname, lastname
from Person.Person
where firstname = 'john' or lastname = 'john'; --vertical filter

select firstname, lastname
from Person.Person
where firstname <> 'john' and lastname <> 'john'; --finds all names that are NOT john

select firstname, lastname 
from Person.Person
where (firstname >= 'k' and firstname < 'l') or (lastname >= 'k' and lastname < 'l');--searches for names that start with the letter k, using 'l' as a boundary

select firstname, lastname 
from Person.Person
where (firstname like 'k%') or (lastname like 'k%');--% is a wildcard, meaning 0 or more characters

select firstname, lastname 
from Person.Person
where (firstname like '%k') or (lastname like '%k%');--looks for a k at the end of the name

select firstname, lastname 
from Person.Person
where (firstname like 'k__') or (lastname like '__k');-- the _ is another wildcard, exactly 1 character

select firstname, lastname 
from Person.Person
where (firstname like '[k,z]%') or (lastname like '[a-d]_k');

select firstname, lastname
from Person.Person
where firstname = 'john'
group by firstname, lastname;

select firstname, lastname, count(*) as count --aggregate functions such as: count, average, sum
from Person.Person
where firstname = 'john'
group by firstname, lastname;

select firstname, lastname, count(*) as squad
from Person.Person
where firstname = 'john' --vertical filter of records
group by firstname, lastname
having count(*) > 1; --vertical filter of groups


select firstname, lastname, count(*) as squad
from Person.Person
where firstname = 'john' 
group by firstname, lastname
having count(*) > 1
order by lastname desc, squad desc;

select firstname, lastname, count(*) as squad
from Person.Person
where firstname = 'john' 
group by firstname, lastname
having count(*) > 1
order by squad desc, lastname desc;

--ORDER OF EXECUTION
--from
--where
--group by
--having
--select
--order by

--INSERT
select *
from Person.Address
where AddressLine2 like '123 elm%';

insert into Person.Address(AddressLine1, AddressLine2, City, StateProvinceID, PostalCode, SpatialLocation, rowguid, ModifiedDate)
values ('123 elm street', null,	'dallas',	14,	75200, 0xE6100000010C72C2B2242FE04A4016902E7EB1B7F8BF, 'fd069aaa-ad12-4a4c-a548-23b35dfeb242', '2020-07-23')

--UPDATE
update pa
set addressline1 = 'suite 200', addressline2 = '123 elm street'
from Person.Address as pa
where AddressLine1 = '123 elm street';

--DELETE

delete pa
from Person.Address as pa
where AddressLine1 = 'suite 200';
go
--VIEW

create view vw_getpersons with schemabinding--firstname and lastname cannot change for the lifetime of this view
as
select firstname, lastname
from Person.Person
go

select * from vw_getpersons; --read only, cannot update, insert, create, delete
go

alter view vw_getpersons with schemabinding
as
select firstname, middlename, lastname
from Person.Person
go
--FUNCTION

--STORED PROCEDURE

--JOIN

--UNION

--TRIGGER

--TRANSACTION