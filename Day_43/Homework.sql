USE DB_BANK

SELECT * FROM Accounts
SELECT * FROM AccountStatusTypes
SELECT * FROM AccountTypes
SELECT * FROM Deposits
SELECT * FROM Customers
SELECT * FROM OverDrafts
SELECT * FROM Transactions
SELECT * FROM TransactionTypes
SELECT * FROM loan.LoanAccounts
SELECT * FROM loan.Loans
SELECT * FROM OverDrafts

/*Where*/

select AccountID , OpenDate , Currency from Accounts where OpenDate < '2017-12-1'

select AccountID , OpenDate , Currency from Accounts where OpenDate < '2017-12-1' and Currency = 'USD'

select * from Deposits where InterestRate in (1.00,3.00,5.00)

select * from Customers where CustomerID in (select AccountID from Accounts where OpenDate > '2016-12-31')

select * from Customers where CustomerID not in (select AccountID from Accounts where OpenDate > '2016-12-31')


select * from Customers where CustomerLastName between 'a' and 'b'



/*აქ ვცდილობთ ამოვიღოთ, ისეთი იუზერები, რომელთაც აქვთ CustomerID და ProductID განსხვავებული
ამიტომ ჯერ ამოვიღებთ განსხვავებული CustomerID-ის მქონე მონაცემებს, და შემდეგ განსხვავებული 
ProductID-ის მქონე მონაცეცმებს 
*/
select Distinct ProductID , CustomerID from loan.Loans where CustomerID in (select Distinct CustomerID from loan.Loans)


/* Demorgan-ის იმპლემენტაცია */
/* not(A and B) = not A or not B */
/* ამოიღებს ექაუნტებს, რომელთა AccountID არ არის 4-ის ტოლი, ან არა აქტიულები არიან */
select * from Accounts where not (AccountTypeID = 4 and IsActive = 1)
select * from Accounts where not AccountTypeID = 4 or not IsActive = 1
select * from Accounts where AccountTypeID != 4 or IsActive != 1

/* not( A or B) = not A and not B */
/* ამოიღებს არა აქტიულ ექაუნთებს, რომელთა ტიპი არ არის 4-ის ტოლი */
select * from Accounts where not (AccountTypeID = 4 or IsActive = 1)
select * from Accounts where not AccountTypeID = 4 and not IsActive = 1
select * from Accounts where AccountTypeID != 4 and IsActive != 1

select * from Customers where CustomerAddress LIKE '%Lau%'/*შეიცავენ lau-ს*/
select * from Customers where CustomerAddress Like '%Lau'/*Lau-ზე დაბოლოვებულები*/
select * from Customers where CustomerAddress Like 'Lau%'/*Lau-თი იწყებიან*/


