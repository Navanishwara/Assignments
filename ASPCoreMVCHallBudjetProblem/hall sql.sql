CREATE TABLE hall( 
id int PRIMARY KEY ,
hall_name varchar(255) not null,

owner_name varchar(255) not null, 
cost_per_day int not null, mobile varchar(255) null,
address varchar(255) not null );
insert into hall values(101,'Hall Paradise','Steve Jobs',40000,987654320,'Washington'),
(102,'Rudolfinum','Othello',35000,7986574032,'DenMark'),
(103,'Casa da Musica','Jason Smith',25000,8967452310,'Portugal'),
(104,'Carnegie hall','Bratt',30000,7907056342,'New York'),
(105,'Palacio de Bellas Artes','James Harrry',32000,9056567832,'Mexico'),
(106,'Esplanade','bobby',30000,7589341240,'Singapore');
select * from hall;