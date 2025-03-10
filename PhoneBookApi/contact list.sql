create table contact
(
   id serial primary key,
    firstname varchar(25) not null,
    lastname varchar(25) not null,
    gender varchar(10) not null,
    dob date not null,
    email varchar(25) not null,
    phone numeric(10) not null,
    city varchar(25) not null,
    state varchar(25) not null,
    country varchar(25) not null,
    picture varchar(30) not null
)