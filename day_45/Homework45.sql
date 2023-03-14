--10,11

--Task1
use DB_BANK
--#TempTable არის ცვლადი, რომელიც ინახავს loan.Loans ცხრილს
select * into #TempTable from loan.Loans
update #TempTable set Purpose = isnull(Purpose,'There is not purpose')
select * from #TempTable
select * from loan.Loans
drop table #TempTable--ვშლით #TempTable ცვლად ცხრილს


--Task2
alter table Customers add WithoutDomain varchar(50)
select * from Customers
update Customers set WithoutDomain = SubString(EmailAddress , 0 , charindex('@',EmailAddress)) where 1 = 1

--Task3
select * from Customers where len(CustomerFirstName) > 7

--Task4


--Task5

select LoanID , DateDiff(DAY,StartDate,EndDate) as DayAmount from loan.Loans

--Task6
select CustomerID ,DateDiff(MONTH,BirthDate,GetDate()) as MonthAmount from Customers

--Task7
declare @mail varchar(50) = 'test@gmail.com'
select right(@mail,4)
select SUBSTRING(@mail,len(@mail) - 3,4)
--Task8
select left(@mail,4)
select SUBSTRING(@mail,1,4)

--Task9
declare @name varchar(100)  = 'Diego Armando Picaso'
select reverse(substring(reverse(@name),1,charindex(' ',reverse(@name))))

--Task12
--State amount
select * from Customers
select State, count(State) from Customers Group by State
--City amount
select City , count(City) from Customers group by City

--Task13
select * from Transactions
select DebitAccountID , sum(Amount) from Transactions group by DebitAccountID

--Task14
select C.CustomerID , sum(T.Amount) as Debit from
(
	(
		(select * from Customers) as C
		join 
		(select * from Accounts) as A
		on C.CustomerID = A.CustomerID
	)
	join
	(
		select * from Transactions
	) as T
	on A.AccountID = T.DebitAccountID
) group by C.CustomerID

select C.CustomerID , sum(T.Amount) as Credit from
(
	(
		(select * from Customers) as C
		join 
		(select * from Accounts) as A
		on C.CustomerID = A.CustomerID
	)
	join
	(
		select * from Transactions
	) as T
	on A.AccountID = T.CreditAccountID
) group by C.CustomerID

--Task15

--ვალუტის ჭრილში
select Currency, cast(sum(Amount) as varchar(100)) + ' ' + Currency Amount from loan.Loans group by Currency
--ფილიალების ჭრილში (Sum with constraint)
select FilialID, 
sum(case when Currency = 'USD' THEN Amount else 0 end) as USD,
sum(case when Currency = 'EUR' then Amount else 0 end) as EUR,
sum(case when Currency = 'GEL' then Amount else 0 end) as GEL,
sum(case when Currency = 'GBP' then Amount else 0 end) as GBP
from loan.Loans group by FilialID

--Task16
select C.CustomerID,Min(L.Amount) as min ,Max(L.Amount) as  max ,count(L.Amount) as loanAmount from 
Customers as C 
join 
loan.Loans as L 
on C.CustomerID = L.CustomerID  
group by C.CustomerID


--Task17
select * into #temp from 
(
	select C.CustomerID , sum(T.Amount) as Debit from
	(
		(
			(select * from Customers) as C
			join 
			(select * from Accounts) as A
			on C.CustomerID = A.CustomerID
		)
		join
		(
			select * from Transactions
		) as T
		on A.AccountID = T.DebitAccountID
	) group by C.CustomerID
	union
	select C.CustomerID , -1*sum(T.Amount) as Credit from
	(
		(
			(select * from Customers) as C
			join 
			(select * from Accounts) as A
			on C.CustomerID = A.CustomerID
		)
		join
		(
			select * from Transactions
		) as T
		on A.AccountID = T.CreditAccountID
	) group by C.CustomerID
) as d

select sum(Debit) as DebitMinusCredit from #temp group by CustomerID
drop table #temp


--Task18
select CustomerID from loan.Loans group by CustomerID having sum(case when Currency = 'USD' then Amount else 0 end) > 50000

--Task19
select * into #Temp from Customers
alter table #Temp add Street varchar(100)
update #Temp set Street = Left(CustomerAddress,charindex('#',CustomerAddress) - 1) where 1=1
select count(CustomerID) from #Temp group by Street
drop table #Temp

--Task20
select d.CustomerID , sum(d.OverDraftAmount) from
	(
		select CustomerID,O.OverDraftAmount from OverDrafts as O join (select C.CustomerID,A.AccountID from 
		(Customers as C join Accounts as A on A.CustomerID = C.CustomerID)
		) as C on O.AccountID = C.AccountID
		union all
		select CustomerID , Amount from loan.Loans
	) as d
group by d.CustomerID


