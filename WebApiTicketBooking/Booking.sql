create table Ticket(
id int primary key,
seatType varchar(20),
ticketCost decimal(10,2),
NoOfTicket int
);
select * from Ticket;
insert into Ticket values(101,'Platinum',250.0,100);
insert into Ticket values(102,'Gold',200.0,90),
(103,'Silver',150.0,100);