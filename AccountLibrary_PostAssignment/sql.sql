create database BankDB;
CREATE TABLE Accounts (
    AccountId INT PRIMARY KEY,
    AccountNumber int  NOT NULL,
    Balance DECIMAL(18, 2) NOT NULL,
    AccountType VARCHAR(50) NOT NULL
);

insert into Accounts Values(101,456780,50000,'Savings');
insert into Accounts Values(102,896780,70000,'Current'),(103,567863,60000,'Savings'),
(104,789806,55000,'Current'),(105,897679,54000,'Savings'),(106,678749,65000,'Current');
select * from Accounts;



CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    MobileNumber VARCHAR(10) NOT NULL,
    Email VARCHAR(100)
);

insert into Customers  values (202,'Nandu',899004788,'Nandu@gmail.com'),
(203,'Naveen',897904799,'Naveen@gmail.com'),(204,'Srikanth',787904788,'Srikanth@gmail.com'),
(205,'mohan',777904788,'Mohan@gmail.com'),(206,'sai',980904788,'sai@gmail.com'),
(207,'kishore',887904677,'Kishore@gmail.com');
select * from Customers;




CREATE TABLE Transactions (
    TransactionId INT PRIMARY KEY,
    AccountId INT  REFERENCES Accounts(AccountId),
	CustomerId int  REFERENCES Customers(CustomerId),
    TransactionType VARCHAR(50) NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL
);
insert into Transactions values (302,102,202,'Deposit',7000),(303,103,201,'WithDraw',9000),
(304,104,207,'TransferFunds',4500),(305,105,206,'Deposit',5800),(306,106,204,'withDraw',8000),
(307,105,205,'Deposit',6500);
select * from Transactions;