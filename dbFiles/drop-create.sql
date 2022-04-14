drop table appointments;
drop table availability;
drop table doctorservices;
drop table doctors;
drop table patients;
drop table times;
drop table services;
drop table users;

CREATE TABLE users ( 
 userId INT IDENTITY NOT NULL, 
 firstName VARCHAR (100) NOT NULL,
 lastName VARCHAR (100) NOT NULL,
 email VARCHAR (100) NOT NULL,
 password VARCHAR (100) NOT NULL,
 role int not null,
 CONSTRAINT pk_userId
 PRIMARY KEY ( userId ) ) ; 
 
 CREATE TABLE services ( 
 sId INT IDENTITY NOT NULL,
 sName VARCHAR (50),
 timeNeeded int not null,  
 CONSTRAINT pk_sId
 PRIMARY KEY ( sId ) ) ; 
 
 CREATE TABLE patients ( 
 pId int identity not null, 
 userId int not null,
 CONSTRAINT pk_pId
 PRIMARY KEY ( pId ) ) ; 
 
 ALTER TABLE patients ADD CONSTRAINT fk_pUserId
 FOREIGN KEY (userId) 
 REFERENCES users (userId) ;
 
 CREATE TABLE doctors ( 
 docId INT IDENTITY NOT NULL, 
 userId INT NOT NULL, 
 CONSTRAINT pk_docId
 PRIMARY KEY ( docId ) ) ; 
 
 ALTER TABLE doctors ADD CONSTRAINT fk_docUserId
 FOREIGN KEY (userId) 
 REFERENCES users (userId) ;
 
 create table doctorservices (
 dsId int identity not null,
 docId int not null,
 sId int not null,
 constraint pk_dsId
 primary key ( dsId ) );
 
 alter table doctorservices add constraint fk_dsDocId
 foreign key (docId)
 references doctors (docId) ;

 alter table doctorservices add constraint fk_dsSId
 foreign key (sId)
 references services (sId) ;

 create table times (
 timeId int identity not null,
 timeStart datetime not null,
 timeEnd datetime not null,
 constraint pk_timeId
 primary key ( timeId ) );

create table availability (
availId int identity not null,
docId int not null,
timeId int not null,
constraint pk_availId
primary key ( availId ) );

alter table availability add constraint fk_availDocId
foreign key (docId)
references doctors (docId);

alter table availability add constraint fk_availTimeId
foreign key (timeId)
references times (timeId);

create table appointments (
apptId int identity not null,
pId int not null,
docId int not null,
timeId int not null,
constraint pk_apptId
primary key ( apptId ) );

alter table appointments add constraint fk_apptDocId
foreign key (docId)
references doctors (docId);

alter table appointments add constraint fk_apptTimeId
foreign key (timeId)
references times (timeId);

alter table appointments add constraint fk_apptPId
foreign key (pId)
references patients (pId);