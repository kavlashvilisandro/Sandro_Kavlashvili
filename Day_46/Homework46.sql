--Task1
create function Zodiac(@birthDay Datetime) returns varchar(100)
begin
	declare @zodiacs table
	(
		Zodiac varchar(100),		
		StartTime datetime,
		EndTime datetime
	)
	insert into @zodiacs values ('Capicorn',cast('12-22-2022' as date),cast('1-19-2023' as date)),
								('Aquarius',cast('1-20-2023' as date),cast('2-18-2023' as date)),
								('Pisces',cast('2-19-2023' as date),cast('3-20-2023' as date)),
								('Aries',cast('3-21-2023' as date),cast('4-19-2023' as date)),
								('Taurus',cast('4-20-2023' as date),cast('5-20-2023' as date)),
								('Gemini',cast('5-21-2023' as date),cast('6-20-2023' as date)),
								('Cancer',cast('6-21-2023' as date),cast('7-22-2023' as date)),
								('Leo',cast('7-23-2023' as date),cast('8-22-2023' as date)),
								('Virgo',cast('8-23-2023' as date),cast('9-22-2023' as date)),
								('Libra',cast('9-23-2023' as date),cast('10-22-2023' as date)),
								('Scorpio',cast('10-23-2023' as date),cast('11-21-2023' as date)),
								('Sagittarius',cast('11-22-2023' as date),cast('12-21-2023' as date))
	
	if (month(@birthDay) = 12 and day(@birthDay) >= 22)
	begin
		set @birthDay = dateadd(year,2022 - year(@birthDay),@birthDay)
	end
	else
	begin
		set @birthDay = dateadd(year,2023 - year(@birthDay),@birthDay)
	end
	declare @result varchar(100) = ''
	select @result = Zodiac from @zodiacs where datediff(day,@birthDay,StartTime) <= 0
												and datediff(day,@birthDay,EndTime) >= 0
	return @result

end

declare @UserZodiacs table
(
	CustomerID int,
	ZodiacSign varchar(100)
)
insert into @UserZodiacs select CustomerID , dbo.Zodiac(BirthDate) from Customers
select * from @UserZodiacs

--ეს არის დაჯგუფებული ზოდიაქოს ნიშნით
select ZodiacSign,count(*) from @UserZodiacs group by ZodiacSign


/*
select dateadd(year,3,cast('2-9-2023' as date))
select dateadd(day,3,cast('2-9-2023' as date))
select dateadd(month,3,cast('2-9-2023' as date))
select day(cast('2-9-2023' as date))
select month(cast('2-9-2023' as date))
select year(cast('2-9-2023' as datetime))
select datediff(day,cast('2-9-2023' as date),cast('2-8-2023' as date))
*/


--Task7
use DB_BANK

alter function LatToGeo(@text varchar(4000)) returns nvarchar(4000) as
begin
	declare @Table table
	(
		lat varchar(2) primary key,
		geo nvarchar(2)
	)
	insert into @Table (geo,lat) values (N'ა','a'),(N'ბ','b'),(N'გ','g'),(N'დ','d'),(N'ე','e'),(N'ვ','v'),(N'ზ','z')
	,(N'ი','i'),(N'კ','k'),(N'ლ','l'),(N'მ','m'),(N'ო','o'),(N'პ','p'),(N'რ','r'),(N'ს','s'),(N'ტ','t'),(N'უ','u')
	,(N'ფ','f'),(N'ნ','n'),(N'ქ','q'),(N'ღ','gh'),(N'ყ','y'),(N'შ','sh'),(N'ჩ','ch'),(N'ც','ts'),(N'ძ','dz'),(N'წ','w'),(N'ხ','x')
	,(N'ჯ','j'),(N'ჰ','h')
	declare @result nvarchar(4000) = N''
	declare @counter int = 1
	declare @tableSize int
	while(@counter <= len(@text))
	begin
		select @tableSize = count(*) from @Table where lat = SUBSTRING(@text,@counter,2)
		if(@tableSize = 1)
		begin
			select @result = @result + geo from @Table where lat = SUBSTRING(@text,@counter,2)
			set @counter += 2
		end
		else
		begin
			select @tableSize = count(*) from @Table where lat = SUBSTRING(@text,@counter,1) 
			if(@tableSize = 1)
			begin
				select @result = @result + geo from @Table where lat = SUBSTRING(@text,@counter,1)
			end
			else
			begin
				set @result = @result + SUBSTRING(@text,@counter,1)
			end
			set @counter += 1
		end
	end
	return @result
end

create function geoToLat(@text nvarchar(4000)) returns varchar(4000)
begin
	declare @Table table
	(
		lat varchar(2) primary key,
		geo nvarchar(2)
	)
	insert into @Table (geo,lat) values (N'ა','a'),(N'ბ','b'),(N'გ','g'),(N'დ','d'),(N'ე','e'),(N'ვ','v'),(N'ზ','z')
	,(N'ი','i'),(N'კ','k'),(N'ლ','l'),(N'მ','m'),(N'ო','o'),(N'პ','p'),(N'რ','r'),(N'ს','s'),(N'ტ','t'),(N'უ','u')
	,(N'ფ','f'),(N'ნ','n'),(N'ქ','q'),(N'ღ','gh'),(N'ყ','y'),(N'შ','sh'),(N'ჩ','ch'),(N'ც','ts'),(N'ძ','dz'),(N'წ','w'),(N'ხ','x')
	,(N'ჯ','j'),(N'ჰ','h')
	declare @result varchar(4000) = ''
	declare @counter int = 1
	declare @TempSize int 
	while(@counter <= len(@text))
	begin
		select @TempSize = count(*) from @Table where geo = SUBSTRING(@text,@counter,1)
		if(@TempSize = 1)
		begin
			select @result = @result + lat from @Table where geo = SUBSTRING(@text,@counter,1)
		end
		else
		begin
			set @result = @result + SUBSTRING(@text,@counter,1)
		end
		set @counter += 1
	end
	return @result

end

select dbo.latToGeo('gamarjoba')
select dbo.geoToLat(N'გამარჯობა')



-------------------------------------


--Task2
alter table loan.Loans add AmountInGel int 
alter table loan.Loans drop column AmountInGel
alter table loan.Loans add AmountInGel decimal
declare @EURO decimal = 2.85
declare @Dolar decimal = 2.65
update loan.Loans set AmountInGel = Case
										when Currency = 'USD' then Amount * @Dolar
										when Currency = 'EUR' then Amount * @EURO
										else Amount
									End   where 1=1

select * from loan.Loans

--Task3
create function Fibonacci(@nth int) returns int
Begin
	if(@nth = 1 or @nth = 2)
	begin
		return 1
	end
	declare @result int = 0
	declare @Nminus1 int = 1
	declare @Nminus2 int = 1
	--n = F(n-1) + F(n-2)
	declare @counter int = 0
	while(@counter != @nth - 2)
	begin
		declare @temp int = @Nminus2
		set @Nminus2 = @Nminus1
		set @Nminus1 = @Nminus1 + @temp
		set @counter += 1
	end
	return @Nminus1
end

select dbo.Fibonacci(10)--55

--Task4
alter function Factorial(@number int) returns int
begin
	declare @result int = 1
	declare @temp int = 1
	while(@temp <= @number)
	begin
		set @result = @temp * @result
		set @temp += 1
	end
	return @result
end

select dbo.Factorial(3)
select dbo.Factorial(4)
select dbo.Factorial(5)

--DROP FUNCTION IF EXISTS dbo.Factorial;(წაშლა)



--Task5
create function Devisors(@number int) returns int
begin
	declare @temp int = 1
	declare @counter int = 0
	while(@temp <= @number)
	begin
		if(@number % @temp = 0)
		begin
			set @counter += 1
		end
		set @temp += 1
	end
	return @counter
end	

select dbo.Devisors(127)--2

--Task6
alter function Segmenter(@X int, @Y int) 
returns @result table
(
	CustomerID int,
	Segment varchar(100)
)
begin
	declare @Temp table
	(
		CustomerID int,
		Amount decimal
	)
	insert into @Temp select C.CustomerID, Sum(T.Amount) from 
						(
							(Customers as C join Accounts as A on C.CustomerID = A.CustomerID)
							join
							Transactions as T
							on A.AccountID = T.CreditAccountID
						) group by C.CustomerID

	insert into @result select CustomerID, case
												when Amount < @X then 'Low'
												when Amount > @Y then 'High'
												else 'Medium'
											end
											as Segment
												from @Temp
	
	
	return;
end

select * from dbo.Segmenter(100000,200000000)