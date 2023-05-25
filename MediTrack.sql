create table ambulance 
(
	Id int not null primary key,
	FName varchar(150) not null,
	LName varchar(150) not null,
	MName varchar(150) not null
);

create table RolesUser
(
	RoleId int not null primary key,
	RoleName varchar(100) not null
);

create table UserData
(
	Id int not null primary key,
	LoginUser varchar(150) not null,
	PassUser varchar(150) not null,
	RoleId int not null,
	FOREIGN KEY (RoleId) REFERENCES RolesUser (RoleId)
);



create table Unit
(
	UnitId int not null primary key,
	UnitName varchar(150) not null
);

create table Uchet
(
	Id int not null primary key,
	ObjectName varchar(150) not null,
	Descriptions varchar(500) not null,
	Price float not null,
	UnitId int not null,
	FOREIGN KEY (UnitId) REFERENCES Unit(UnitId)
);