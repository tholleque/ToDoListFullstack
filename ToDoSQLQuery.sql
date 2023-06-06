--create database ToDoDB;
--create table Employee (
--	Id int primary key identity(1,1),
--	[Name] nvarchar(25),
--	Hours int not null check (hours >= 0 and hours <=40),
--	Title nvarchar(40)
--);

--create Table ToDos(
--	Id int Primary Key Identity(1,1),
--	[Name] nvarchar(25),
--	[Description] nvarchar(100),
--	AssignedTo int Foreign Key References Employee(Id),
--	HoursNeeded int,
--	isCompleted bit
--);

--insert into Employee ([Name], Hours, Title)
--values ('Timmy', 25, 'Pencil Pusher'),
--('Theodore', 12, 'Complainer'),
--('Layla', 40, 'Is a Cat');

--insert into ToDos ([Name], [Description], AssignedTo, HoursNeeded, isCompleted)
--values ('Clean the Kitchen', 'Just do it', 5, 4, 0);

