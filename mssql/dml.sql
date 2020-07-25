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
from Person.Person;
--finds all names

select firstname, lastname
from Person.Person
where firstname = 'john' or lastname = 'john';
--vertical filter

select firstname, lastname
from Person.Person
where firstname <> 'john' and lastname <> 'john';
--finds all names that are NOT john

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

select firstname, lastname, count(*) as count
--aggregate functions such as: count, average, sum
from Person.Person
where firstname = 'john'
group by firstname, lastname;

select firstname, lastname, count(*) as squad
from Person.Person
where firstname = 'john'
--vertical filter of records
group by firstname, lastname
having count(*) > 1;
--vertical filter of groups


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

insert into Person.Address
  (AddressLine1, AddressLine2, City, StateProvinceID, PostalCode, SpatialLocation, rowguid, ModifiedDate)
values
  ('123 elm street', null, 'dallas', 14, 75200, 0xE6100000010C72C2B2242FE04A4016902E7EB1B7F8BF, 'fd069aaa-ad12-4a4c-a548-23b35dfeb242', '2020-07-23')

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

create view vw_getpersons
with
  schemabinding--firstname and lastname cannot change for the lifetime of this view
as
  select firstname, lastname
  from Person.Person
go

select *
from vw_getpersons; --read only, cannot update, insert, create, delete
go

alter view vw_getpersons
with
  schemabinding
as
  select firstname, middlename, lastname
  from Person.Person
go

drop view vw_getpersons;
go
--FUNCTION
--scalar returns a value; only 1 
create function fn_getname(@id int)
returns nvarchar(250)
as
begin
  declare @result nvarchar(250);
  select @result = firstname + ' ' + coalesce(middlename, '') + ' ' + lastname
  from Person.Person
  where businessentityid = @id
  return @result
end;
go

drop function fn_getname;
go

select dbo.fn_getname(100);
go

create function fn_fullname(@first nvarchar(200), @last nvarchar(200))
returns nvarchar(401)
as
begin
  return @first + ' ' + @last
end;
go

select dbo.fn_fullname(firstname, lastname) as FullName
from Person.Person;
go

--tabular returns 1 or more records
create function fn_getpeople(@first nvarchar(200))
returns table
as
return
  select firstname, lastname
from Person.Person
where firstname = @first
go

select *
from dbo.fn_getpeople('josh');
go
--STORED PROCEDURE

create proc sp_insertperson(@first nvarchar,
  @last nvarchar)
as
begin
  --validate first, last
  begin tran
  --Atomic = should affect 1 record set and it should be complete
  --Consistent = should be the same record set if repeated with same result
  --Isolated = isolation levels, should not have side effects
  --Durable = should be saved entirely
  if (@first is not null and @last is not null)
    begin
    declare @result int;

    select @result = BusinessEntityID
    from Person.Person
    where firstname = @first and lastname = @last;

    if (@result is null)
      begin
      insert into Person.Person
        (firstname, lastname)
      values(@first, @last);
      commit tran;
    --isolation levels (isolating read from, edit/delete)
    --READ UNCOMMITED = dirty read, any record in the table conplete or not
    --READ COMMITTED = clean read, only completed records can be read
    --REPEATABLE READ = clean read, only the latest snapshot can be read
    --SERIALIZABLE = clean read, dataset is locked from edit/delete
    end
    else
    begin
      rollback tran;
    end
  end
--validate duplicate
--insert
end;
go

--JOIN =  based on keys
--inner -> inner
--outer -> full, left, right
--cross
--self
select pp.FirstName, pp.LastName, pa.AddressLine1, pa.City
from Person.Person as pp
left join Person.BusinessEntityAddress as bea on bea.BusinessEntityID = pp.BusinessEntityID
left join Person.Address as pa on pa.AddressID = bea.AddressID
where pp.FirstName = 'john';
go

--UNION = based on datatypes
select firstname
from Person.Person
union all--filter duplicates, unique record set; union all = no filter
select name 
from Production.Product;

select firstname
from Person.Person
intersect --common record set
select name 
from Production.Product;

select firstname
from Person.Person
except --exclusive record set; still filters duplicates
select name 
from Production.Product;
go

--TRIGGER
--before = intercept event, and run pre-query ahead of event
--for = intercept event, and run post-query after event
--instead of = intercept event, and run new-query, event dismissed
create trigger tr_switchname
on Person.Person
for insert
as 
  declare @first NVARCHAR;
  declare @last NVARCHAR;

  select @first = firstname, @last = lastname
  from inserted; --inserted, deleted = special tables (temporary) to capture insert/update/delete events on a table

  update Person.Person 
  set firstname = @last, lastname = @first
  where firstname = @first and lastname = @last



--TRANSACTION
--ACID, COMMIT TRAN, ROLLBACK, *CHECKPOINT*

--ORM + Entity Framework Core + Data-First Approach
--ORM = object relational mapper
--ODBC connector = open db connector (serialization - XML)
--ADO.NET library to interface with ODBC
--in C# we write SQL as string > ADO.NET > executes query > Record Set