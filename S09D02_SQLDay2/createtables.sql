


--initialize tables
create table Contacts (
 id int identity primary key,
 name varchar(30) not null,
 surname varchar(30)
);

create table PhoneNumbers (
 id int primary key identity,
 contact_id int not null,
 number varchar(20) not null,
 title varchar(20) not null,
 foreign key (contact_id) references contacts on update cascade on delete cascade
);