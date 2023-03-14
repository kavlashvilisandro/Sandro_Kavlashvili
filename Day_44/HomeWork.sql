Use DB_BANK

--Task1
select * from Customers 
where CustomerID in 
(
select CustomerID from loan.Loans 
where CustomerID in (select CustomerID from Deposits)
)

--Task2
--(1)Inner join CustomerID-ზე. ეს დააბრუნებს წყვილებს, სადაც დაწყვილებულნი იქნებიან
--შემდეგნაირად: Deposits-დან ყველა დაუწყვილდედბა Loans-ში ყველას, რომელზეც დაემთხვევა
--CustomerID. თუ არ წყვილდება, უბრალოდ არ შევა ამ სიაში
select * from Deposits as D join loan.Loans as L on D.CustomerID = L.CustomerID
--(2)Left Join CustomerID-ზე. ეს დააბრუნებს Inner join-მა რაც დააბრუნა ყველაფერს, მაგრამ
--ამას კიდევ მიემატება, ისეთი ელემენტებიც Deposits-დან, რომლებიც არაფერთან არ დაწყვილდნენ,
--ანუ ისეთი CustomerID-ების მქონე მონაცემებიც, რომლებსაც აქვთ დეპოზიტი, მაგრამ არ აქვთ
--სესხი. ხოლო ეს ველები, რომლებიც სესხში უნდა ეწეროს შეივსება Null-ებით.
--ანუ დაბრუნებდა ისეთი CustomerID-ების მქონე მონაცემები, რომლებსაც სესხიც აქვთ და 
--დეპოზიტიც + ისეთები, რომლებსაც სესხი არ აქვთ, მაგრამ დეპოზიტი აქვთ
select * from Deposits as D left join loan.Loans as L on D.CustomerID = L.CustomerID
--(3)Right join ეს დააბრუნებს ისეთი მონაცემებს, რომელ CusotmerID-ებსაც აქვთ სესხიც და 
--დეპოზიტიც + ისეთებს, რომლებსაც არ აქვთ დეპოზიტი, მაგრამ სესხი აქვთ. და ამ 
--მონაცეცმებს დააწყვილებს იმ პრინციპით, როგორც პირველში არის ახსნილი
select * from Deposits as D right join loan.Loans as L on D.CustomerID = L.CustomerID
--(4) Full join დააბრუნებს, Right join-ის და Left join-ის გაერთიანებას. ანუ ასეთ სიმრავლეს
--დააბრუნებს. Inner join-ით მიღებული აღვნიშნოთ A სიმრავლით, Left Join-ით მიღებული
--აღვნიშნოთ B სიმრავლით, და Right join-ით მიღებული აღვნიშნოთ C სიმრავლით
--ეს Full join დააბრუნებს A + (B - A) + (C - A) სიმრავლეს
select * from Deposits as D full join loan.Loans as L on D.CustomerID = L.CustomerID

--Task7
SELECT 
	TransactionDate,DebitAccountID , 
	CreditAccountID , 
	First.CustomerFirstName AS FromName , 
	First.CustomerLastName AS FromLastName , 
	Second.CustomerFirstName AS ToName , 
	Second.CustomerLastName AS ToLastName 
FROM 
(
	SELECT * FROM Transactions AS T JOIN 
	(
	select A.AccountID , C.CustomerFirstName , C.CustomerLastName 
	from Customers as C  join Accounts as A on C.CustomerID = A.CustomerID
	) 
	AS M
	on T.CreditAccountID = M.AccountID
) 
AS First 
JOIN 
(
	select A.AccountID , C.CustomerFirstName , C.CustomerLastName 
	from 
	Customers as C  join Accounts as A on C.CustomerID = A.CustomerID
) as Second
on First.DebitAccountID = Second.AccountID
--Task5 ფოტოშია
--Task6
/*
Customer -> Accounts (თითოეულ მომხმარებელს აქვს ბევრი ექაუნთი)one to many
Customer -> loans (თითოეულ მომხმარებელს აქვს ბევრი სესხი)one to many 
Loans -> LoanAccounts (ბევრ სესხს შეიძლება ჰქონდეს ერთი Loan Account)many to one
Customer -> Deposit (ერთ მომხმარებელს შეიძლება ჰქონდეს ბევრი დეპოზიტი) one to many
Accounts -> OverDraft (ერთ ექაუნთს შეიძლება უკავშირდებობდეს ერთი OverDraft)
Transactions -> Accounts (ერთი ექაუნთიდან ბევრი ტრანზაქცია შეიძლება)many to one
TransactionTypes -> Transactions () one to many
*/


--Task 8
SELECT * FROM loan.Loans as l
JOIN Deposits as d ON l.CustomerID = d.CustomerID WHERE l.CustomerID = 115
/*
ჯოინის დროს, რეალურად ერთი კონკრეტული მონაცემი Loan-ებიდან დაწყვილდა ბევრ
მონაცემთან Deposit-ებიდან, რადგან ბევრი ისეთი ელემენტი მოიძებნებოდა, რომელთაც
CustomerID-ები ემთხვეოდათ. ამ შემთხვევაში 18 ასეთი ჩანაწერი მოიძებნა.
ანუ მთავარი მომენტი არის ის, რომ აქ თითოეული დაწყვილდა ბევრ ელემენტთან, ხოლო
იმ წინა დავალებაში კი Distinct-ის მსგავსი რამ დავწერეთ.
*/



--Task 9
--ან სესხი და ან დეპოზიტი
/*
ჩვენ რეალურად გვჭირდება ისეთი ხალხი, ვისაც ან მარტო სესხი აქვს, ან
მარტო დეპოზიტი, ანუ დაბლა მოცემული სელექტი გვინდა, სადაც
XOR კავშირი წერია, რომელიც SQL-ს არ აქვს. ამიტომაც მოგვიწევს
ამის ლოგიკურად გაშლა
select * from Customers 
where 
CustomerID in (select CustomerID from Deposits) 
xor  
CustomerID in (select CustomerID from loan.Loans)
A = CustomerID in (select CustomerID form Deposits)
B = CustomerID in (select CustomerID from loan.Loans)
A xor B = (not A and B) or (A and not B)
*/
select * from Customers 
where 
(	CustomerID not in (select CustomerID from Deposits)
	and 
	CustomerID in (select CustomerID from loan.Loans)
)
or
(
	CustomerID in (select CustomerID from Deposits)
	and 
	CustomerID not in (select CustomerID from loan.Loans)
)


